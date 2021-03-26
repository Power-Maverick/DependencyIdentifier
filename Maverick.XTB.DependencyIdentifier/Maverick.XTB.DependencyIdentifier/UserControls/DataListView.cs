using Maverick.XTB.DI.Helper;
using Maverick.XTB.DI.DataObjects;
using Maverick.XTB.DI.Extensions;
using Maverick.XTB.DI.CustomAttributes;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enum = Maverick.XTB.DI.Helper.Enum;

namespace Maverick.XTB.DependencyIdentifier.UserControls
{
    public partial class DataListView : UserControl
    {
        #region Control Properties

        public Enum.ListViewDisplayType DisplayType { get; set; }

        public bool ShowSearchBox { get; set; }

        public List<EntityMetadata> Entities { get; set; }

        public List<object> SelectedData
        {
            get
            {
                switch (DisplayType)
                {
                    case Enum.ListViewDisplayType.Entities:
                        return lstSelectedEntitites.ToList<object>();
                    case Enum.ListViewDisplayType.ComponentTypes:
                        return lstSelectedComponentType.ToList<object>();
                    default:
                        return null;
                }

            }
        }

        #endregion

        #region Control Functions & Events

        [Description("Load")]
        public void InitializeControl(List<EntityMetadata> entities = null)
        {
            Entities = entities;
            PopulateControls();
        }

        [Description("Clear Search Text")]
        public void ClearSearchText()
        {
            txtSearch.Clear();
        }

        [Description("Event that fires when the list of Checked Items changes")]
        public event EventHandler CheckedItemsChanged;

        #endregion

        #region Private Properties & Variables

        private List<ListViewItem> lstEntitites = null;
        private List<EntityMetadata> lstSelectedEntitites = null;

        private List<ListViewItem> lstComponentType = null;
        private List<object> lstSelectedComponentType = null;

        #endregion

        #region Private Methods

        private void PopulateControls()
        {
            ClearData();
            SetAllItems(Entities);

            lblSearch.Visible = ShowSearchBox;
            txtSearch.Visible = ShowSearchBox;
        }

        private void ClearData()
        {
            lvData.Items.Clear();
        }

        private void SetAllItems(List<EntityMetadata> items)
        {
            SetUpListViewColumns(GetDefaultColumns());
            PopulateListView();
        }

        private ListViewColumnDefinition[] GetDefaultColumns()
        {
            switch (DisplayType)
            {
                case Enum.ListViewDisplayType.Entities:
                    // default the col defs
                    return new ListViewColumnDefinition[] {
                        new ListViewColumnDefinition("DisplayName", 1, "Display Name") { Width = 250 },
                        new ListViewColumnDefinition( "SchemaName", 0, "Schema Name") { Width = 250 }
                    };
                case Enum.ListViewDisplayType.ComponentTypes:
                    // default the col defs
                    return new ListViewColumnDefinition[] {
                        new ListViewColumnDefinition("Type", 1, "Type") { Width = 150 }
                    };
                default:
                    return null;
            }
        }

        private void SetUpListViewColumns(ListViewColumnDefinition[] lvColumns)
        {
            var cols = new List<ColumnHeader>();

            foreach (var colDef in lvColumns.OrderBy(o => o.Order))
            {
                cols.Add(new ColumnHeader()
                {
                    Name = colDef.Name,
                    Text = colDef.DisplayName,
                    DisplayIndex = colDef.Order,
                    Width = colDef.Width,
                    Tag = colDef
                });
            }

            // if the two are the same, then no need to reset
            if (lvData.Columns.Count == cols.Count)
            {
                var listCols = lvData.Columns.Cast<ColumnHeader>().Select(c => c.Name);
                if (cols.Select(c => c.Name).SequenceEqual(listCols))
                {
                    return;
                }
            }

            lvData.SuspendLayout();
            lvData.Columns.Clear();

            lvData.Columns.AddRange(cols.ToArray());
            lvData.ResumeLayout();

        }

        private void PopulateListView()
        {
            lvData.SuspendLayout();
            lvData.Enabled = false;
            lvData.Items.Clear();
            lvData.Refresh();

            switch (DisplayType)
            {
                case Enum.ListViewDisplayType.Entities:
                    PopulateEntityMetadata();
                    break;
                case Enum.ListViewDisplayType.ComponentTypes:
                    PopulateComponentType();
                    break;
                default:
                    break;
            }

            lvData.ResumeLayout();
            lvData.Enabled = true;
        }

        private void PopulateEntityMetadata()
        {
            // persist the list of list view items for the filtering
            lstEntitites = new List<ListViewItem>();

            if (Entities != null && Entities?.Count > 0)
            {
                var cols = lvData.Columns;

                var props = typeof(EntityMetadata).GetProperties().ToDictionary(p => p.Name, p => p);

                foreach (var item in Entities)
                {
                    var col = cols[0];
                    var colDef = col.Tag as ListViewColumnDefinition;

                    // get the ListView group for the current row/ListViewItem
                    var group = GetListItemGroup(item, props);

                    var text = Utility.GetPropertyValue<string>(item, props[col.Name]);

                    // new list view item 
                    var lvItem = new ListViewItem()
                    {
                        Name = cols[0].Name,
                        ImageIndex = 0,
                        StateImageIndex = 0,
                        Text = text,
                        Tag = item,  // stash the template here so we can view details later
                        Group = group
                    };

                    for (var i = 1; i < cols.Count; i++)
                    {
                        var prop = props[cols[i].Name];
                        var colVal = Utility.GetPropertyValue<string>(item, prop);
                        var subitem = new ListViewItem.ListViewSubItem(lvItem, colVal)
                        {
                            Name = cols[i].Name
                        };
                        lvItem.SubItems.Add(subitem);
                    }

                    // add to the internal collection of ListView Items and the external list
                    lstEntitites.Add(lvItem);
                }

                lvData.Items.AddRange(lstEntitites.ToArray<ListViewItem>());
            }
        }

        private void PopulateComponentType()
        {
            var lstComponentTypes = System.Enum.GetValues(typeof(Enum.ComponentType)).Cast<Enum.ComponentType>().ToList();
            lstComponentType = new List<ListViewItem>();

            foreach (var ct in lstComponentTypes)
            {
                var text = ct.GetAttribute<DI.CustomAttributes.DisplayAttribute>();

                var lvItem = new ListViewItem()
                {
                    Name = ct.ToString(),
                    ImageIndex = 0,
                    StateImageIndex = 0,
                    Text = text.Name,
                    Tag = ct  // stash the template here so we can view details later
                };

                lstComponentType.Add(lvItem);
            }

            lvData.Items.AddRange(lstComponentType.ToArray<ListViewItem>());
        }

        private ListViewGroup GetListItemGroup(object item, Dictionary<string, PropertyInfo> props = null)
        {
            if (props == null)
            {
                props = typeof(EntityMetadata).GetProperties().ToDictionary(p => p.Name, p => p);
            }

            ListViewGroup group = null;

            var label = Utility.GetPropertyValue<string>(item, props["IsManaged"]) ?? "(no value)";
            var groupVal = $"Managed: {label}";

            group = lvData.Groups[groupVal];

            if (group == null)
            {
                group = new ListViewGroup(groupVal, HorizontalAlignment.Left)
                {
                    Header = groupVal,
                    Name = groupVal,
                    Tag = groupVal
                };
                lvData.Groups.Add(group);
            }

            return group;
        }

        private void FilterList()
        {
            string filterText = txtSearch.Text.ToLower();
            lvData.SuspendLayout();

            switch (DisplayType)
            {
                case Enum.ListViewDisplayType.Entities:
                    FilterEntities(filterText);
                    break;
                case Enum.ListViewDisplayType.ComponentTypes:
                    FilterComponentTypes(filterText);
                    break;
                default:
                    break;
            }

            lvData.ResumeLayout();
        }

        private void FilterEntities(string filterText)
        {
            List<ListViewItem> newList = null;

            // filter the cols 
            if (filterText.Length > 3)
            {
                var filterCols = GetDefaultColumns();
                newList = new List<ListViewItem>();
                foreach (var col in filterCols)
                {
                    var curr = lstEntitites
                                .Where(i => (col.Order == 0) ?
                                i.Text.ToLower().Contains(filterText) :
                                i.SubItems[col.Name].Text.ToLower().Contains(filterText)
                                );

                    // add to the current list
                    newList.AddRange(curr.Except(newList));
                }
            }
            else
            {
                if (lvData.Items.Count != lstEntitites.Count)
                {
                    newList = lstEntitites;
                }
            }

            // if we have a new list to be set, clear and reset groups
            if (newList != null)
            {
                lvData.Items.Clear();
                lvData.Items.AddRange(newList.ToArray<ListViewItem>());

                var props = typeof(EntityMetadata).GetProperties().ToDictionary(p => p.Name, p => p);

                // now reset the group for each list item
                foreach (var item in newList)
                {
                    item.Group = GetListItemGroup(item.Tag, props);
                }

                // now that we have an updated list view, udpate the list of selected items
                UpdateSelectedItemsList();
            }
        }

        private void FilterComponentTypes(string filterText)
        {
            List<ListViewItem> newList = null;

            // filter the cols 
            if (filterText.Length > 3)
            {
                var filterCols = GetDefaultColumns();
                newList = new List<ListViewItem>();
                foreach (var col in filterCols)
                {
                    var curr = lstComponentType
                                .Where(i => i.Text.ToLower().Contains(filterText)
                                );

                    // add to the current list
                    newList.AddRange(curr.Except(newList));
                }
            }
            else
            {
                if (lvData.Items.Count != lstComponentType.Count)
                {
                    newList = lstComponentType;
                }
            }

            //UpdateSelectedItemsList();
        }

        private void UpdateSelectedItemsList()
        {
            switch (DisplayType)
            {
                case Enum.ListViewDisplayType.Entities:
                    UpdateSelectedEntities();
                    break;
                case Enum.ListViewDisplayType.ComponentTypes:
                    UpdateSelectedComponentTypes();
                    break;
                default:
                    break;
            }

            CheckedItemsChanged?.Invoke(this, new EventArgs());
        }

        private void UpdateSelectedEntities()
        {
            if (lstSelectedEntitites == null)
            {
                lstSelectedEntitites = new List<EntityMetadata>();
            }

            if (lvData.CheckedItems.Count == 0)
            {
                lstSelectedEntitites.Clear();
            }
            else
            {
                foreach (ListViewItem listItem in lvData.Items)
                {
                    if (listItem != null)
                    {
                        var item = listItem.Tag as EntityMetadata;
                        if (listItem.Checked)
                        {
                            // if not already added, add the checked item
                            if (!lstSelectedEntitites.Contains(item))
                            {
                                lstSelectedEntitites.Add(item);
                            }
                        }
                        else
                        {
                            // if already added, then remove it
                            if (lstSelectedEntitites.Contains(item))
                            {
                                lstSelectedEntitites.Remove(item);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateSelectedComponentTypes()
        {
            if (lstSelectedComponentType == null)
            {
                lstSelectedComponentType = new List<object>();
            }

            if (lvData.CheckedItems.Count == 0)
            {
                lstSelectedComponentType.Clear();
            }
            else
            {
                foreach (ListViewItem listItem in lvData.Items)
                {
                    if (listItem != null)
                    {
                        var item = listItem.Text;
                        if (listItem.Checked)
                        {
                            // if not already added, add the checked item
                            if (!lstSelectedComponentType.Contains(item))
                            {
                                lstSelectedComponentType.Add(item);
                            }
                        }
                        else
                        {
                            // if already added, then remove it
                            if (lstSelectedComponentType.Contains(item))
                            {
                                lstSelectedComponentType.Remove(item);
                            }
                        }
                    }
                }
            }
        }

        private void ToggleSelectAll()
        {
            lvData.SuspendLayout();

            foreach (ListViewItem item in lvData.Items)
            {
                item.Checked = chkSelectAll.Checked;
            }

            lvData.ResumeLayout();

            // now that we have an updated list view, udpate the list of selected items
            UpdateSelectedItemsList();
        }

        #endregion

        #region Constructor

        public DataListView()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList();
        }
        private void lvEntities_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateSelectedItemsList();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ToggleSelectAll();
        }

        #endregion


    }
}
