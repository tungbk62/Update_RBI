namespace RBI.PRE.subForm.InputDataForm
{
    partial class frmInspectionSummary
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.labelMain = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstMethod = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTechnique = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddIspMethod = new System.Windows.Forms.Button();
            this.gridControlMethod = new DevExpress.XtraGrid.GridControl();
            this.gridViewtab2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCoverage = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colButtonDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewtab2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.labelMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 59);
            this.panel2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(249, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Inspection Summary for Inspection / Mitigation Plan";
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.Location = new System.Drawing.Point(87, 10);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(147, 16);
            this.labelMain.TabIndex = 0;
            this.labelMain.Text = "Inspection Summary";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstMethod);
            this.groupBox2.Location = new System.Drawing.Point(3, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 128);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inspection Methods";
            // 
            // lstMethod
            // 
            this.lstMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethod.FormattingEnabled = true;
            this.lstMethod.Items.AddRange(new object[] {
            "Acoustic Emission",
            "Eddy Current",
            "Magnetic",
            "Metallurgical ",
            "Monitoring ",
            "Penetrant ",
            "Radiography",
            "Thermography",
            "Ultrasonic",
            "Visual"});
            this.lstMethod.Location = new System.Drawing.Point(3, 16);
            this.lstMethod.Name = "lstMethod";
            this.lstMethod.Size = new System.Drawing.Size(389, 109);
            this.lstMethod.TabIndex = 5;
            this.lstMethod.SelectedIndexChanged += new System.EventHandler(this.lstMethod_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioGroup1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 163);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTechnique);
            this.groupBox1.Location = new System.Drawing.Point(398, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inspection Technique";
            // 
            // lstTechnique
            // 
            this.lstTechnique.FormattingEnabled = true;
            this.lstTechnique.Location = new System.Drawing.Point(3, 16);
            this.lstTechnique.Name = "lstTechnique";
            this.lstTechnique.Size = new System.Drawing.Size(577, 108);
            this.lstTechnique.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Inspection Type:";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(116, 3);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Intrusive"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Non-Intrusive")});
            this.radioGroup1.Size = new System.Drawing.Size(215, 24);
            this.radioGroup1.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddIspMethod);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 222);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(978, 36);
            this.panel3.TabIndex = 6;
            // 
            // btnAddIspMethod
            // 
            this.btnAddIspMethod.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddIspMethod.Location = new System.Drawing.Point(893, 0);
            this.btnAddIspMethod.Name = "btnAddIspMethod";
            this.btnAddIspMethod.Size = new System.Drawing.Size(85, 36);
            this.btnAddIspMethod.TabIndex = 1;
            this.btnAddIspMethod.Text = "Add";
            this.btnAddIspMethod.UseVisualStyleBackColor = true;
            this.btnAddIspMethod.Click += new System.EventHandler(this.btnAddIspMethod_Click);
            // 
            // gridControlMethod
            // 
            this.gridControlMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlMethod.Location = new System.Drawing.Point(0, 0);
            this.gridControlMethod.MainView = this.gridViewtab2;
            this.gridControlMethod.Name = "gridControlMethod";
            this.gridControlMethod.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete,
            this.txtCoverage});
            this.gridControlMethod.Size = new System.Drawing.Size(978, 206);
            this.gridControlMethod.TabIndex = 48;
            this.gridControlMethod.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewtab2});
            // 
            // gridViewtab2
            // 
            this.gridViewtab2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNDT,
            this.colCoverage,
            this.colButtonDelete});
            this.gridViewtab2.GridControl = this.gridControlMethod;
            this.gridViewtab2.Name = "gridViewtab2";
            this.gridViewtab2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewtab2.OptionsView.ColumnAutoWidth = false;
            this.gridViewtab2.OptionsView.ShowGroupPanel = false;
            // 
            // colNDT
            // 
            this.colNDT.Caption = "NDT Method";
            this.colNDT.FieldName = "NDTMethod";
            this.colNDT.Name = "colNDT";
            this.colNDT.OptionsColumn.AllowEdit = false;
            this.colNDT.Visible = true;
            this.colNDT.VisibleIndex = 0;
            this.colNDT.Width = 283;
            // 
            // colCoverage
            // 
            this.colCoverage.Caption = "Coverage (%)";
            this.colCoverage.ColumnEdit = this.txtCoverage;
            this.colCoverage.FieldName = "Coverage";
            this.colCoverage.Name = "colCoverage";
            this.colCoverage.Visible = true;
            this.colCoverage.VisibleIndex = 1;
            this.colCoverage.Width = 78;
            // 
            // txtCoverage
            // 
            this.txtCoverage.AutoHeight = false;
            this.txtCoverage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.txtCoverage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtCoverage.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtCoverage.Name = "txtCoverage";
            this.txtCoverage.ShowNullValuePromptWhenFocused = true;
            // 
            // colButtonDelete
            // 
            this.colButtonDelete.ColumnEdit = this.btnDelete;
            this.colButtonDelete.Name = "colButtonDelete";
            this.colButtonDelete.OptionsColumn.AllowMove = false;
            this.colButtonDelete.OptionsColumn.AllowSize = false;
            this.colButtonDelete.OptionsColumn.FixedWidth = true;
            this.colButtonDelete.OptionsFilter.AllowFilter = false;
            this.colButtonDelete.Visible = true;
            this.colButtonDelete.VisibleIndex = 2;
            this.colButtonDelete.Width = 43;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = "";
            this.btnDelete.AutoHeight = false;
            editorButtonImageOptions1.ImageUri.Uri = "Cancel;Size16x16";
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Delete", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gridControlMethod);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(978, 209);
            this.panel4.TabIndex = 7;
            // 
            // BTnCancel
            // 
            this.BTnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTnCancel.Location = new System.Drawing.Point(887, 31);
            this.BTnCancel.Name = "BTnCancel";
            this.BTnCancel.Size = new System.Drawing.Size(80, 26);
            this.BTnCancel.TabIndex = 3;
            this.BTnCancel.Text = "Cancel";
            this.BTnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(791, 31);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 26);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnOK);
            this.panel5.Controls.Add(this.BTnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 470);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(978, 70);
            this.panel5.TabIndex = 8;
            // 
            // frmInspectionSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(978, 540);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInspectionSummary";
            this.ShowIcon = false;
            this.Text = "Inspection Summary";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewtab2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTechnique;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControlMethod;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewtab2;
        private DevExpress.XtraGrid.Columns.GridColumn colNDT;
        private DevExpress.XtraGrid.Columns.GridColumn colCoverage;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtCoverage;
        private DevExpress.XtraGrid.Columns.GridColumn colButtonDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BTnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAddIspMethod;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.Label label4;
    }
}