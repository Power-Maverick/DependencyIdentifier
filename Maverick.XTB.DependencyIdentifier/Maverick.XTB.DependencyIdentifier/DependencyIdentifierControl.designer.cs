
namespace Maverick.XTB.DependencyIdentifier
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
            this.gboxDependencyType = new System.Windows.Forms.GroupBox();
            this.pnlDependencyType = new System.Windows.Forms.Panel();
            this.radDependenciesForDelete = new System.Windows.Forms.RadioButton();
            this.radAllDependencies = new System.Windows.Forms.RadioButton();
            this.pnlEntityListViewControl = new System.Windows.Forms.Panel();
            this.dlvEntities = new Maverick.XTB.DependencyIdentifier.UserControls.DataListView();
            this.gboxEntityListView = new System.Windows.Forms.GroupBox();
            this.gboxComponentTypes = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entityListView2 = new Maverick.XTB.DependencyIdentifier.UserControls.DataListView();
            this.lblSelectedEntities = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateDependencies = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripMenu.SuspendLayout();
            this.gboxDependencyType.SuspendLayout();
            this.pnlDependencyType.SuspendLayout();
            this.pnlEntityListViewControl.SuspendLayout();
            this.gboxEntityListView.SuspendLayout();
            this.gboxComponentTypes.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseTool,
            this.toolStripSeparator1,
            this.tsbLoadEntities,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1087, 31);
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
            this.pnlEntityListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntityListViewControl.Location = new System.Drawing.Point(3, 16);
            this.pnlEntityListViewControl.Name = "pnlEntityListViewControl";
            this.pnlEntityListViewControl.Size = new System.Drawing.Size(516, 478);
            this.pnlEntityListViewControl.TabIndex = 8;
            // 
            // dlvEntities
            // 
            this.dlvEntities.DisplayType = Maverick.XTB.DI.Helper.Enum.ListViewDisplayType.Entities;
            this.dlvEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvEntities.Entities = null;
            this.dlvEntities.Location = new System.Drawing.Point(0, 0);
            this.dlvEntities.Name = "dlvEntities";
            this.dlvEntities.ShowSearchBox = true;
            this.dlvEntities.Size = new System.Drawing.Size(516, 478);
            this.dlvEntities.TabIndex = 0;
            this.dlvEntities.CheckedItemsChanged += new System.EventHandler(this.dlvEntities_CheckedItemsChanged);
            // 
            // gboxEntityListView
            // 
            this.gboxEntityListView.Controls.Add(this.pnlEntityListViewControl);
            this.gboxEntityListView.Location = new System.Drawing.Point(21, 120);
            this.gboxEntityListView.Name = "gboxEntityListView";
            this.gboxEntityListView.Size = new System.Drawing.Size(522, 497);
            this.gboxEntityListView.TabIndex = 9;
            this.gboxEntityListView.TabStop = false;
            this.gboxEntityListView.Text = "Entities";
            // 
            // gboxComponentTypes
            // 
            this.gboxComponentTypes.Controls.Add(this.panel1);
            this.gboxComponentTypes.Location = new System.Drawing.Point(759, 499);
            this.gboxComponentTypes.Name = "gboxComponentTypes";
            this.gboxComponentTypes.Size = new System.Drawing.Size(325, 306);
            this.gboxComponentTypes.TabIndex = 10;
            this.gboxComponentTypes.TabStop = false;
            this.gboxComponentTypes.Text = "Components";
            this.gboxComponentTypes.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.entityListView2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 287);
            this.panel1.TabIndex = 8;
            // 
            // entityListView2
            // 
            this.entityListView2.DisplayType = Maverick.XTB.DI.Helper.Enum.ListViewDisplayType.ComponentTypes;
            this.entityListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityListView2.Entities = null;
            this.entityListView2.Location = new System.Drawing.Point(0, 0);
            this.entityListView2.Name = "entityListView2";
            this.entityListView2.ShowSearchBox = false;
            this.entityListView2.Size = new System.Drawing.Size(319, 287);
            this.entityListView2.TabIndex = 0;
            // 
            // lblSelectedEntities
            // 
            this.lblSelectedEntities.Location = new System.Drawing.Point(272, 633);
            this.lblSelectedEntities.Name = "lblSelectedEntities";
            this.lblSelectedEntities.Size = new System.Drawing.Size(268, 50);
            this.lblSelectedEntities.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 620);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selected Entities";
            // 
            // btnGenerateDependencies
            // 
            this.btnGenerateDependencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateDependencies.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateDependencies.Image")));
            this.btnGenerateDependencies.Location = new System.Drawing.Point(18, 633);
            this.btnGenerateDependencies.Name = "btnGenerateDependencies";
            this.btnGenerateDependencies.Size = new System.Drawing.Size(248, 50);
            this.btnGenerateDependencies.TabIndex = 13;
            this.btnGenerateDependencies.Text = "Generate Dependencies";
            this.btnGenerateDependencies.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateDependencies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateDependencies.UseVisualStyleBackColor = true;
            this.btnGenerateDependencies.Click += new System.EventHandler(this.btnGenerateDependencies_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(549, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 494);
            this.dataGridView1.TabIndex = 14;
            // 
            // DependencyIdentifierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerateDependencies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectedEntities);
            this.Controls.Add(this.gboxComponentTypes);
            this.Controls.Add(this.gboxEntityListView);
            this.Controls.Add(this.gboxDependencyType);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "DependencyIdentifierControl";
            this.Size = new System.Drawing.Size(1087, 695);
            this.OnCloseTool += new System.EventHandler(this.DependencyIdentifierControl_OnCloseTool);
            this.Load += new System.EventHandler(this.DependencyIdentifierControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gboxDependencyType.ResumeLayout(false);
            this.pnlDependencyType.ResumeLayout(false);
            this.pnlDependencyType.PerformLayout();
            this.pnlEntityListViewControl.ResumeLayout(false);
            this.gboxEntityListView.ResumeLayout(false);
            this.gboxComponentTypes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private UserControls.DataListView dlvEntities;
        private System.Windows.Forms.GroupBox gboxComponentTypes;
        private System.Windows.Forms.Panel panel1;
        private UserControls.DataListView entityListView2;
        private System.Windows.Forms.Label lblSelectedEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbCloseTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnGenerateDependencies;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
