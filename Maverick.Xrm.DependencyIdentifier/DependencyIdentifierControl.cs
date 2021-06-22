using Maverick.Xrm.DI.DataObjects;
using Maverick.Xrm.DI.Helper;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Maverick.Xrm.DependencyIdentifier.Forms;
using Enum = Maverick.Xrm.DI.Helper.Enum;
using Maverick.XTB.DI.Helper;
using XrmToolBox.Extensibility.Interfaces;

namespace Maverick.Xrm.DependencyIdentifier
{
    public partial class DependencyIdentifierControl : PluginControlBase, IGitHubPlugin, IHelpPlugin, IPayPalPlugin
    {
        const int maxRequestsPerBatch = 100;

        #region XrmToolBox settings
        private Settings pluginSettings;
        public string RepositoryName => "DependencyIdentifier";
        public string UserName => "Power-Maverick";
        public string HelpUrl => "https://github.com/Power-Maverick/DependencyIdentifier/blob/main/README.md";
        public string DonationDescription => "Thank you for your support.";
        public string EmailAccount => "danz@techgeek.co.in";
        #endregion

        #region Private Variables

        private List<DependencyReport> dependentComponents;
        private Enum.UserOperations operations;

        #endregion

        #region Private Helper Methods

        private void LoadEntityMetadata()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entities... Please wait.",
                Work = (worker, args) =>
                {
                    var start = DateTime.Now;

                    args.Result = DataverseHelper.RetrieveAllEntities(Service);

                    var end = DateTime.Now;
                    var duration = end - start;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log(args.Error.ToString(), Enum.LogLevel.Error);
                    }
                    else
                    {
                        var result = args.Result as List<EntityMetadata>;
                        dlvEntities.InitializeControl(result);
                        Log("LoadEntityMetadata success", Enum.LogLevel.Success);
                    }
                }
            });
        }

        private void ExecuteDependencyIdentifier()
        {
            dataGridView1.DataSource = null;
            ExecuteMultipleResponse response = new ExecuteMultipleResponse();

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Generating dependency...",
                Work = (worker, args) =>
                {
                    dependentComponents = new List<DependencyReport>();

                    if (Service is CrmServiceClient svc)
                    {
                        Parallel.ForEach(dlvEntities.SelectedData,
                            new ParallelOptions { MaxDegreeOfParallelism = 10 },
                            () => new
                            {
                                Service = svc.Clone(),
                                EMRequest = new ExecuteMultipleRequest
                                {
                                    Requests = new OrganizationRequestCollection(),
                                    Settings = new ExecuteMultipleSettings
                                    {
                                        ContinueOnError = false,
                                        ReturnResponses = true
                                    }
                                }
                            },
                            (obj, loopState, index, threadLocalState) =>
                            {
                                EntityMetadata entityMetadata = (EntityMetadata)obj;
                                if (radAllDependencies.Checked)
                                {
                                    threadLocalState.EMRequest.Requests.Add(new RetrieveDependentComponentsRequest
                                    {
                                        ObjectId = entityMetadata.MetadataId.Value,
                                        ComponentType = (int)Enum.ComponentType.Entity
                                    });
                                }
                                else if (radDependenciesForDelete.Checked)
                                {
                                    threadLocalState.EMRequest.Requests.Add(new RetrieveDependenciesForDeleteRequest
                                    {
                                        ObjectId = entityMetadata.MetadataId.Value,
                                        ComponentType = (int)Enum.ComponentType.Entity
                                    });
                                }

                                return threadLocalState;
                            },
                            (threadLocalState) =>
                            {
                                if (threadLocalState.EMRequest.Requests.Count > 0)
                                {
                                    response = (ExecuteMultipleResponse)threadLocalState.Service.Execute(threadLocalState.EMRequest);
                                    dependentComponents.AddRange(ProcessDependencies(threadLocalState.Service, dlvEntities.SelectedData, threadLocalState.EMRequest.Requests, response.Responses));
                                }
                            });
                    }
                    else
                    {
                        Parallel.ForEach(dlvEntities.SelectedData,
                        new ParallelOptions { MaxDegreeOfParallelism = 10 },
                        (obj) =>
                        {
                            EntityMetadata entityMetadata = (EntityMetadata)obj;
                            var dc = DataverseHelper.GetDependencyList(Service, entityMetadata.MetadataId.Value, (int)Enum.ComponentType.Entity);
                            dependentComponents.AddRange(SanitizeDependencyReportList(entityMetadata.SchemaName, dc));
                        });
                    }

                    args.Result = dependentComponents;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log(args.Error.ToString(), Enum.LogLevel.Error);
                    }
                    else
                    {
                        dataGridView1.DataSource = args.Result;
                        ColumnResize();
                    }
                }
            });
        }

        private List<DependencyReport> ProcessDependencies(CrmServiceClient svc, List<object> selectedEntities, OrganizationRequestCollection requests, ExecuteMultipleResponseItemCollection emrItems)
        {
            List<DependencyReport> dependentComponents = new List<DependencyReport>();

            // Display the results returned in the responses.
            foreach (var responseItem in emrItems)
            {
                if (radAllDependencies.Checked)
                {
                    var request = (RetrieveDependentComponentsRequest)requests[responseItem.RequestIndex];
                    var entityMetadata = selectedEntities
                                            .Cast<EntityMetadata>()
                                            .FirstOrDefault(e => e.MetadataId.Value == request.ObjectId);

                    // A valid response.
                    if (responseItem.Response != null)
                    {
                        EntityCollection dependencies = (EntityCollection)responseItem.Response.Results["EntityCollection"];
                        var dc = DataverseHelper.ProcessDependencyList(svc, dependencies);
                        dependentComponents.AddRange(SanitizeDependencyReportList(entityMetadata.SchemaName, dc));
                    }
                }
                else if (radDependenciesForDelete.Checked)
                {
                    var request = (RetrieveDependenciesForDeleteRequest)requests[responseItem.RequestIndex];
                    var entityMetadata = selectedEntities
                                            .Cast<EntityMetadata>()
                                            .FirstOrDefault(e => e.MetadataId.Value == request.ObjectId);

                    // A valid response.
                    if (responseItem.Response != null)
                    {
                        EntityCollection dependencies = (EntityCollection)responseItem.Response.Results["EntityCollection"];
                        var dc = DataverseHelper.ProcessDependencyList(svc, dependencies);
                        dependentComponents.AddRange(SanitizeDependencyReportList(entityMetadata.SchemaName, dc));
                    }
                }
            }

            return dependentComponents;
        }

        private List<DependencyReport> SanitizeDependencyReportList(string entityName, List<DependencyReport> dependentComponents)
        {
            foreach (DependencyReport dr in dependentComponents)
            {
                dr.EntitySchemaName = entityName;
                if (dr.DependentComponentType == Enum.ComponentType.Entity.ToString())
                {
                    dr.DependentComponentName = dlvEntities.Entities
                                                    .FirstOrDefault(e => e.MetadataId == new Guid(dr.DependentComponentName))
                                                    .SchemaName;
                }
                if (dr.RequiredComponentType == Enum.ComponentType.Entity.ToString())
                {
                    dr.RequiredComponentName = dlvEntities.Entities
                                                    .FirstOrDefault(e => e.MetadataId == new Guid(dr.RequiredComponentName))
                                                    .SchemaName;
                }
            }

            return dependentComponents;
        }

        private void ColumnResize()
        {
            dataGridView1.Columns[0].Width = 150; // Entity Schema
            dataGridView1.Columns[1].Width = 300; // Dependent Component
            dataGridView1.Columns[2].Width = 200; // Dependent Component Type
            dataGridView1.Columns[3].Width = 200; // Required Component
            dataGridView1.Columns[4].Width = 200; // Required Component Type
        }

        private void EnsureServiceIsAvailable()
        {
            ExecuteMethod(WhoAmI);
        }

        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void ValidateButtonEnablement()
        {
            switch (operations)
            {
                case Enum.UserOperations.EntitiesLoaded:
                    tsbGenerateDependencies.Enabled = true;
                    break;
                case Enum.UserOperations.DependenciesGenerated:
                    tsbGenerateDependencies.Enabled = true;
                    tsbExportDropDown.Enabled = true;
                    break;
                default:
                    tsbGenerateDependencies.Enabled = false;
                    tsbExportDropDown.Enabled = false;
                    break;
            }
        }

        #endregion

        #region Logger

        private void Log(string message, Enum.LogLevel level)
        {
            switch (level)
            {
                case Enum.LogLevel.Success:
                    LogInfo(message);
                    break;
                case Enum.LogLevel.Info:
                    LogInfo(message);
                    break;
                case Enum.LogLevel.Warning:
                    LogWarning(message);
                    break;
                case Enum.LogLevel.Error:
                    LogError(message);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Constructor

        public DependencyIdentifierControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Plugin Control Private Events

        private void DependencyIdentifierControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out pluginSettings))
            {
                pluginSettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            PrivatePreview frmPrivatePreview = new PrivatePreview();
            frmPrivatePreview.StartPosition = FormStartPosition.CenterScreen;
            frmPrivatePreview.ShowDialog();

            EnsureServiceIsAvailable();
        }

        private void DependencyIdentifierControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), pluginSettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (pluginSettings != null && detail != null)
            {
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            LoadEntityMetadata();
            operations = Enum.UserOperations.EntitiesLoaded;
            ValidateButtonEnablement();
        }

        private void dlvEntities_CheckedItemsChanged(object sender, EventArgs e)
        {
            lblSelectedEntities.Text = string.Empty;

            foreach (EntityMetadata data in dlvEntities.SelectedData)
            {
                lblSelectedEntities.Text += $"{data.DisplayName?.UserLocalizedLabel?.Label}\n";
            }
        }

        private void tsbCloseTool_Click(object sender, EventArgs e)
        {
            Log("Close", Enum.LogLevel.Info);
            CloseTool();
        }

        private void btnGenerateDependencies_Click(object sender, EventArgs e)
        {
            dlvEntities.ClearSearchText();
            ExecuteDependencyIdentifier();
        }

        private void tsmiExportToCSV_Click(object sender, EventArgs e)
        {
            if (dependentComponents != null)
            {
                Export.ExportAsCsv(dependentComponents);
            }
        }

        private void tsmiExportToExcel_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            var filter = "Excel file (*.xlsx)|*.xlsx| All Files (*.*)|*.*";
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = @"Export as Excel";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Generating Microsoft Excel file...",
                Work = (worker, args) =>
                {
                    Export.ExportAsExcel(dependentComponents, saveFileDialog.FileName);

                    args.Result = dependentComponents;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log(args.Error.ToString(), Enum.LogLevel.Error);
                    }
                }
            });
        }

        private void tsbGenerateDependencies_Click(object sender, EventArgs e)
        {
            dlvEntities.ClearSearchText();

            if (dlvEntities.Entities.Count > 0)
            {
                ExecuteDependencyIdentifier();
                operations = Enum.UserOperations.DependenciesGenerated;
                ValidateButtonEnablement();
            }
            else
            {
                MessageBox.Show("Please select entities before generating the dependency report.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion


    }
}