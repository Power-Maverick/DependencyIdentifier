using Maverick.XTB.DI.Helper;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
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
using Enum = Maverick.XTB.DI.Helper.Enum;

namespace Maverick.XTB.DependencyIdentifier
{
    public partial class DependencyIdentifierControl : PluginControlBase
    {
        #region Private Variables

        private Settings mySettings;

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

        public DependencyIdentifierControl()
        {
            InitializeComponent();
        }

        private void DependencyIdentifierControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            entityListView2.InitializeControl();
        }

        private void DependencyIdentifierControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            LoadEntityMetadata();
        }

        private void dlvEntities_CheckedItemsChanged(object sender, EventArgs e)
        {
            lblSelectedEntities.Text = string.Empty;

            foreach (EntityMetadata data in dlvEntities.SelectedData)
            {
                lblSelectedEntities.Text += $"{data.DisplayName?.UserLocalizedLabel?.Label}\n";
            }
        }
    }
}