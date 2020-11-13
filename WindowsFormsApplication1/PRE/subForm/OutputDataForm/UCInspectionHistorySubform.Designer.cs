namespace RBI.PRE.subForm.OutputDataForm
{
    partial class UCInspectionHistorySubform
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvInsHis = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestoreInspectionPlan = new System.Windows.Forms.Button();
            this.btnAddInspectionPlan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInsHis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 629);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inspection / Mitigation Planning";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvInsHis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1047, 573);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inspection Coverages of the selected Inspection / Mitigation Plan";
            // 
            // dtgvInsHis
            // 
            this.dtgvInsHis.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvInsHis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInsHis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvInsHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvInsHis.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvInsHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvInsHis.Location = new System.Drawing.Point(3, 16);
            this.dtgvInsHis.Name = "dtgvInsHis";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInsHis.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvInsHis.RowHeadersVisible = false;
            this.dtgvInsHis.Size = new System.Drawing.Size(1041, 554);
            this.dtgvInsHis.TabIndex = 0;
            this.dtgvInsHis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvInsHis_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRestoreInspectionPlan);
            this.panel1.Controls.Add(this.btnAddInspectionPlan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnRestoreInspectionPlan
            // 
            this.btnRestoreInspectionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreInspectionPlan.Location = new System.Drawing.Point(160, 3);
            this.btnRestoreInspectionPlan.Name = "btnRestoreInspectionPlan";
            this.btnRestoreInspectionPlan.Size = new System.Drawing.Size(134, 23);
            this.btnRestoreInspectionPlan.TabIndex = 1;
            this.btnRestoreInspectionPlan.Text = "Restore Inspection Plan";
            this.btnRestoreInspectionPlan.UseVisualStyleBackColor = true;
            this.btnRestoreInspectionPlan.Click += new System.EventHandler(this.btnRestoreInspectionPlan_Click);
            // 
            // btnAddInspectionPlan
            // 
            this.btnAddInspectionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInspectionPlan.Location = new System.Drawing.Point(3, 3);
            this.btnAddInspectionPlan.Name = "btnAddInspectionPlan";
            this.btnAddInspectionPlan.Size = new System.Drawing.Size(134, 23);
            this.btnAddInspectionPlan.TabIndex = 0;
            this.btnAddInspectionPlan.Text = "Add Inspection Plan";
            this.btnAddInspectionPlan.UseVisualStyleBackColor = true;
            this.btnAddInspectionPlan.Click += new System.EventHandler(this.btnAddInspectionPlan_Click);
            // 
            // UCInspectionHistorySubform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCInspectionHistorySubform";
            this.Size = new System.Drawing.Size(1053, 629);
            this.Load += new System.EventHandler(this.UCInspectionHistorySubform_Load);
            this.ContextMenuStripChanged += new System.EventHandler(this.UCInspectionHistorySubform_ContextMenuStripChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInsHis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvInsHis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestoreInspectionPlan;
        private System.Windows.Forms.Button btnAddInspectionPlan;
    }
}
