using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sza.FormPassContextUpdaterPlugin
{
    partial class PluginControl
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
        private void EntitiesListViewColum_Click(object sender, ColumnClickEventArgs e)
        {
            ListView listView = (ListView)sender;
            listView.Sorting = ((listView.Sorting != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
        }
        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.loadEntitiesButton = new System.Windows.Forms.ToolStripButton();
            this.checkOptionButton = new System.Windows.Forms.ToolStripButton();
            this.entitieslistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formlistView = new System.Windows.Forms.ListView();
            this.columnHeaderSelect2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1,
            this.tsbClose,
            this.loadEntitiesButton,
            this.checkOptionButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1015, 42);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::Sza.FormPassContextUpdaterPlugin.Properties.Resources.icons8_close_window_16;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(101, 36);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // loadEntitiesButton
            // 
            this.loadEntitiesButton.Image = global::Sza.FormPassContextUpdaterPlugin.Properties.Resources.icons8_refresh_16;
            this.loadEntitiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadEntitiesButton.Name = "loadEntitiesButton";
            this.loadEntitiesButton.Size = new System.Drawing.Size(179, 36);
            this.loadEntitiesButton.Text = "Load entities";
            this.loadEntitiesButton.Click += new System.EventHandler(this.loadEntites_Click);
            // 
            // checkOptionButton
            // 
            this.checkOptionButton.Enabled = false;
            this.checkOptionButton.Image = global::Sza.FormPassContextUpdaterPlugin.Properties.Resources.icons8_submit_progress_16;
            this.checkOptionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkOptionButton.Name = "checkOptionButton";
            this.checkOptionButton.Size = new System.Drawing.Size(481, 36);
            this.checkOptionButton.Text = "Update and Publish \'Pass Context\' option";
            this.checkOptionButton.Click += new System.EventHandler(this.UpdateForm_Click);
            // 
            // entitieslistView
            // 
            this.entitieslistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entitieslistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.entitieslistView.FullRowSelect = true;
            this.entitieslistView.HideSelection = false;
            this.entitieslistView.Location = new System.Drawing.Point(2, 0);
            this.entitieslistView.Name = "entitieslistView";
            this.entitieslistView.Size = new System.Drawing.Size(369, 736);
            this.entitieslistView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.entitieslistView.TabIndex = 5;
            this.entitieslistView.UseCompatibleStateImageBehavior = false;
            this.entitieslistView.View = System.Windows.Forms.View.Details;
            this.entitieslistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.EntitiesListViewColum_Click);
            this.entitieslistView.Click += new System.EventHandler(this.EntitySelect_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display name";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Logical name";
            this.columnHeader2.Width = 100;
            // 
            // formlistView
            // 
            this.formlistView.CheckBoxes = true;
            this.formlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSelect2,
            this.columnHeaderEntityName,
            this.columnHeaderName,
            this.columnHeaderDesc});
            this.formlistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formlistView.FullRowSelect = true;
            this.formlistView.HoverSelection = true;
            this.formlistView.Location = new System.Drawing.Point(0, 0);
            this.formlistView.Name = "formlistView";
            this.formlistView.Size = new System.Drawing.Size(636, 736);
            this.formlistView.TabIndex = 0;
            this.formlistView.UseCompatibleStateImageBehavior = false;
            this.formlistView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSelect2
            // 
            this.columnHeaderSelect2.Width = 40;
            // 
            // columnHeaderEntityName
            // 
            this.columnHeaderEntityName.DisplayIndex = 2;
            this.columnHeaderEntityName.Text = "Entity";
            this.columnHeaderEntityName.Width = 150;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.DisplayIndex = 1;
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderDesc
            // 
            this.columnHeaderDesc.Text = "Description";
            this.columnHeaderDesc.Width = 306;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.entitieslistView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formlistView);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 736);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 90;
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1015, 778);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton loadEntitiesButton;
        private System.Windows.Forms.ListView entitieslistView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private ListView formlistView;
        private ColumnHeader columnHeaderSelect2;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderDesc;
        private SplitContainer splitContainer1;
        private ToolStripButton checkOptionButton;
        private ColumnHeader columnHeaderEntityName;
    }
}
