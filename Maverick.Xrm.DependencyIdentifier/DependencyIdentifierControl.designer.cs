
namespace Maverick.Xrm.DependencyIdentifier
{
    partial class DependencyIdentifierControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DependencyIdentifierControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbCloseTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGenerateDependencies = new System.Windows.Forms.ToolStripButton();
            this.tsbExportDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiExportToCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.gboxDependencyType = new System.Windows.Forms.GroupBox();
            this.pnlDependencyType = new System.Windows.Forms.Panel();
            this.radDependenciesForDelete = new System.Windows.Forms.RadioButton();
            this.radAllDependencies = new System.Windows.Forms.RadioButton();
            this.pnlEntityListViewControl = new System.Windows.Forms.Panel();
            this.dlvEntities = new Maverick.Xrm.DependencyIdentifier.UserControls.DataListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedEntities = new System.Windows.Forms.Label();
            this.gboxEntityListView = new System.Windows.Forms.GroupBox();
            this.dgvDependencyReport = new System.Windows.Forms.DataGridView();
            this.toolStripMenu.SuspendLayout();
            this.gboxDependencyType.SuspendLayout();
            this.pnlDependencyType.SuspendLayout();
            this.pnlEntityListViewControl.SuspendLayout();
            this.gboxEntityListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDependencyReport)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseTool,
            this.toolStripSeparator1,
            this.tsbLoadEntities,
            this.tssSeparator1,
            this.tsbGenerateDependencies,
            this.tsbExportDropDown});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1363, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbCloseTool
            // 
            this.tsbCloseTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseTool.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseTool.Image")));
            this.tsbCloseTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseTool.Name = "tsbCloseTool";
            this.tsbCloseTool.Size = new System.Drawing.Size(28, 28);
            this.tsbCloseTool.Text = "toolStripButton1";
            this.tsbCloseTool.Click += new System.EventHandler(this.tsbCloseTool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadEntities.Image")));
            this.tsbLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(102, 28);
            this.tsbLoadEntities.Text = "Load Entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.tsbLoadEntities_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbGenerateDependencies
            // 
            this.tsbGenerateDependencies.Enabled = false;
            this.tsbGenerateDependencies.Image = ((System.Drawing.Image)(resources.GetObject("tsbGenerateDependencies.Image")));
            this.tsbGenerateDependencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenerateDependencies.Name = "tsbGenerateDependencies";
            this.tsbGenerateDependencies.Size = new System.Drawing.Size(159, 28);
            this.tsbGenerateDependencies.Text = "Generate Dependencies";
            this.tsbGenerateDependencies.Click += new System.EventHandler(this.tsbGenerateDependencies_Click);
            // 
            // tsbExportDropDown
            // 
            this.tsbExportDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportToCSV,
            this.tsmiExportToExcel});
            this.tsbExportDropDown.Enabled = false;
            this.tsbExportDropDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportDropDown.Image")));
            this.tsbExportDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportDropDown.Name = "tsbExportDropDown";
            this.tsbExportDropDown.Size = new System.Drawing.Size(78, 28);
            this.tsbExportDropDown.Text = "Export";
            // 
            // tsmiExportToCSV
            // 
            this.tsmiExportToCSV.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExportToCSV.Image")));
            this.tsmiExportToCSV.Name = "tsmiExportToCSV";
            this.tsmiExportToCSV.Size = new System.Drawing.Size(101, 22);
            this.tsmiExportToCSV.Text = "CSV";
            this.tsmiExportToCSV.Click += new System.EventHandler(this.tsmiExportToCSV_Click);
            // 
            // tsmiExportToExcel
            // 
            this.tsmiExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExportToExcel.Image")));
            this.tsmiExportToExcel.Name = "tsmiExportToExcel";
            this.tsmiExportToExcel.Size = new System.Drawing.Size(101, 22);
            this.tsmiExportToExcel.Text = "Excel";
            this.tsmiExportToExcel.Click += new System.EventHandler(this.tsmiExportToExcel_Click);
            // 
            // gboxDependencyType
            // 
            this.gboxDependencyType.Controls.Add(this.pnlDependencyType);
            this.gboxDependencyType.Location = new System.Drawing.Point(18, 45);
            this.gboxDependencyType.Name = "gboxDependencyType";
            this.gboxDependencyType.Size = new System.Drawing.Size(331, 69);
            this.gboxDependencyType.TabIndex = 7;
            this.gboxDependencyType.TabStop = false;
            this.gboxDependencyType.Text = "Dependency Type";
            // 
            // pnlDependencyType
            // 
            this.pnlDependencyType.Controls.Add(this.radDependenciesForDelete);
            this.pnlDependencyType.Controls.Add(this.radAllDependencies);
            this.pnlDependencyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDependencyType.Location = new System.Drawing.Point(3, 16);
            this.pnlDependencyType.Name = "pnlDependencyType";
            this.pnlDependencyType.Size = new System.Drawing.Size(325, 50);
            this.pnlDependencyType.TabIndex = 0;
            // 
            // radDependenciesForDelete
            // 
            this.radDependenciesForDelete.AutoSize = true;
            this.radDependenciesForDelete.Location = new System.Drawing.Point(127, 15);
            this.radDependenciesForDelete.Name = "radDependenciesForDelete";
            this.radDependenciesForDelete.Size = new System.Drawing.Size(143, 17);
            this.radDependenciesForDelete.TabIndex = 1;
            this.radDependenciesForDelete.TabStop = true;
            this.radDependenciesForDelete.Text = "Dependencies for Delete";
            this.radDependenciesForDelete.UseVisualStyleBackColor = true;
            // 
            // radAllDependencies
            // 
            this.radAllDependencies.AutoSize = true;
            this.radAllDependencies.Checked = true;
            this.radAllDependencies.Location = new System.Drawing.Point(13, 15);
            this.radAllDependencies.Name = "radAllDependencies";
            this.radAllDependencies.Size = new System.Drawing.Size(108, 17);
            this.radAllDependencies.TabIndex = 0;
            this.radAllDependencies.TabStop = true;
            this.radAllDependencies.Text = "All Dependencies";
            this.radAllDependencies.UseVisualStyleBackColor = true;
            // 
            // pnlEntityListViewControl
            // 
            this.pnlEntityListViewControl.Controls.Add(this.dlvEntities);
            this.pnlEntityListViewControl.Controls.Add(this.label1);
            this.pnlEntityListViewControl.Controls.Add(this.lblSelectedEntities);
            this.pnlEntityListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntityListViewControl.Location = new System.Drawing.Point(3, 16);
            this.pnlEntityListViewControl.Name = "pnlEntityListViewControl";
            this.pnlEntityListViewControl.Size = new System.Drawing.Size(647, 547);
            this.pnlEntityListViewControl.TabIndex = 8;
            // 
            // dlvEntities
            // 
            this.dlvEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dlvEntities.DisplayType = Maverick.Xrm.DI.Helper.Enum.ListViewDisplayType.Entities;
            this.dlvEntities.Entities = null;
            this.dlvEntities.Location = new System.Drawing.Point(0, 0);
            this.dlvEntities.Name = "dlvEntities";
            this.dlvEntities.ShowSearchBox = true;
            this.dlvEntities.Size = new System.Drawing.Size(436, 544);
            this.dlvEntities.TabIndex = 0;
            this.dlvEntities.CheckedItemsChanged += new System.EventHandler(this.dlvEntities_CheckedItemsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selected Entities";
            // 
            // lblSelectedEntities
            // 
            this.lblSelectedEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedEntities.Location = new System.Drawing.Point(442, 29);
            this.lblSelectedEntities.Name = "lblSelectedEntities";
            this.lblSelectedEntities.Size = new System.Drawing.Size(202, 515);
            this.lblSelectedEntities.TabIndex = 11;
            // 
            // gboxEntityListView
            // 
            this.gboxEntityListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxEntityListView.Controls.Add(this.pnlEntityListViewControl);
            this.gboxEntityListView.Location = new System.Drawing.Point(21, 120);
            this.gboxEntityListView.Name = "gboxEntityListView";
            this.gboxEntityListView.Size = new System.Drawing.Size(653, 566);
            this.gboxEntityListView.TabIndex = 9;
            this.gboxEntityListView.TabStop = false;
            this.gboxEntityListView.Text = "Entities";
            // 
            // dgvDependencyReport
            // 
            this.dgvDependencyReport.AllowUserToAddRows = false;
            this.dgvDependencyReport.AllowUserToDeleteRows = false;
            this.dgvDependencyReport.AllowUserToOrderColumns = true;
            this.dgvDependencyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDependencyReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDependencyReport.Location = new System.Drawing.Point(680, 120);
            this.dgvDependencyReport.Name = "dgvDependencyReport";
            this.dgvDependencyReport.ReadOnly = true;
            this.dgvDependencyReport.ShowEditingIcon = false;
            this.dgvDependencyReport.Size = new System.Drawing.Size(680, 563);
            this.dgvDependencyReport.TabIndex = 14;
            // 
            // DependencyIdentifierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDependencyReport);
            this.Controls.Add(this.gboxEntityListView);
            this.Controls.Add(this.gboxDependencyType);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "DependencyIdentifierControl";
            this.Size = new System.Drawing.Size(1363, 689);
            this.OnCloseTool += new System.EventHandler(this.DependencyIdentifierControl_OnCloseTool);
            this.Load += new System.EventHandler(this.DependencyIdentifierControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gboxDependencyType.ResumeLayout(false);
            this.pnlDependencyType.ResumeLayout(false);
            this.pnlDependencyType.PerformLayout();
            this.pnlEntityListViewControl.ResumeLayout(false);
            this.pnlEntityListViewControl.PerformLayout();
            this.gboxEntityListView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDependencyReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.GroupBox gboxDependencyType;
        private System.Windows.Forms.Panel pnlDependencyType;
        private System.Windows.Forms.RadioButton radDependenciesForDelete;
        private System.Windows.Forms.RadioButton radAllDependencies;
        private System.Windows.Forms.Panel pnlEntityListViewControl;
        private System.Windows.Forms.GroupBox gboxEntityListView;
        private System.Windows.Forms.Label lblSelectedEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbCloseTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvDependencyReport;
        private System.Windows.Forms.ToolStripButton tsbGenerateDependencies;
        private System.Windows.Forms.ToolStripDropDownButton tsbExportDropDown;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportToCSV;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportToExcel;
        private UserControls.DataListView dlvEntities;
    }
}
