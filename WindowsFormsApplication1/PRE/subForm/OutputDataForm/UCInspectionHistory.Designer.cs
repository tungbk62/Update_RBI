namespace RBI.PRE.subForm.OutputDataForm
{
    partial class UCInspectionHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControlInseptionMitigationPlanner = new DevExpress.XtraEditors.GroupControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInspectionCoverage = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.InspectionDate = new System.Windows.Forms.TextBox();
            this.InspectionPlanName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScheduledCarried = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInseptionMitigationPlanner)).BeginInit();
            this.groupControlInseptionMitigationPlanner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInspectionCoverage.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlInseptionMitigationPlanner
            // 
            this.groupControlInseptionMitigationPlanner.Controls.Add(this.panel1);
            this.groupControlInseptionMitigationPlanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInseptionMitigationPlanner.Location = new System.Drawing.Point(0, 0);
            this.groupControlInseptionMitigationPlanner.Name = "groupControlInseptionMitigationPlanner";
            this.groupControlInseptionMitigationPlanner.Size = new System.Drawing.Size(800, 600);
            this.groupControlInseptionMitigationPlanner.TabIndex = 1;
            this.groupControlInseptionMitigationPlanner.Text = "Inseption/ Mitigation Planner";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 577);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInspectionCoverage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 577);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInspectionCoverage
            // 
            this.tabPageInspectionCoverage.Controls.Add(this.panel4);
            this.tabPageInspectionCoverage.Controls.Add(this.panel3);
            this.tabPageInspectionCoverage.Controls.Add(this.panel2);
            this.tabPageInspectionCoverage.Location = new System.Drawing.Point(4, 22);
            this.tabPageInspectionCoverage.Name = "tabPageInspectionCoverage";
            this.tabPageInspectionCoverage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInspectionCoverage.Size = new System.Drawing.Size(788, 551);
            this.tabPageInspectionCoverage.TabIndex = 1;
            this.tabPageInspectionCoverage.Text = "Inspection Coverage";
            this.tabPageInspectionCoverage.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 95);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(782, 453);
            this.panel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inspection Coverages of the selected Inseption / Mitigation Plan";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gridControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(776, 439);
            this.panel5.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(776, 439);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAddEdit);
            this.panel3.Controls.Add(this.InspectionDate);
            this.panel3.Controls.Add(this.InspectionPlanName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnScheduledCarried);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 67);
            this.panel3.TabIndex = 1;
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddEdit.Location = new System.Drawing.Point(567, 0);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(110, 65);
            this.btnAddEdit.TabIndex = 6;
            this.btnAddEdit.Text = "Add/ Edit Inspection Plan Detail";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // InspectionDate
            // 
            this.InspectionDate.Location = new System.Drawing.Point(170, 34);
            this.InspectionDate.Name = "InspectionDate";
            this.InspectionDate.ReadOnly = true;
            this.InspectionDate.Size = new System.Drawing.Size(179, 21);
            this.InspectionDate.TabIndex = 5;
            // 
            // InspectionPlanName
            // 
            this.InspectionPlanName.Location = new System.Drawing.Point(170, 7);
            this.InspectionPlanName.Name = "InspectionPlanName";
            this.InspectionPlanName.ReadOnly = true;
            this.InspectionPlanName.Size = new System.Drawing.Size(179, 21);
            this.InspectionPlanName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inseption / Mitigation Plan Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inseption / Mitigation Plan";
            // 
            // btnScheduledCarried
            // 
            this.btnScheduledCarried.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnScheduledCarried.Location = new System.Drawing.Point(677, 0);
            this.btnScheduledCarried.Name = "btnScheduledCarried";
            this.btnScheduledCarried.Size = new System.Drawing.Size(103, 65);
            this.btnScheduledCarried.TabIndex = 1;
            this.btnScheduledCarried.Text = "Scheduled or Carried";
            this.btnScheduledCarried.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRestore);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 25);
            this.panel2.TabIndex = 0;
            // 
            // btnRestore
            // 
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRestore.Location = new System.Drawing.Point(313, 0);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(121, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore Component";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCreate.Location = new System.Drawing.Point(158, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(155, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create New Inspection Plan";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search Within Inspection Plan";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // UCInspectionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlInseptionMitigationPlanner);
            this.Name = "UCInspectionHistory";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInseptionMitigationPlanner)).EndInit();
            this.groupControlInseptionMitigationPlanner.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInspectionCoverage.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControlInseptionMitigationPlanner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInspectionCoverage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.TextBox InspectionDate;
        private System.Windows.Forms.TextBox InspectionPlanName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScheduledCarried;
        private System.Windows.Forms.Button btnRestore;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
