namespace RBI.PRE.subForm.InputDataForm
{
    partial class UCMaterial
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlGovBrittleFractureDf = new System.Windows.Forms.Panel();
            this.txtMinDesignTemperature = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGovBrittleFractureDf = new System.Windows.Forms.Label();
            this.lblMinDesignTem = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.chkChromium = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReferenceTemperature = new System.Windows.Forms.TextBox();
            this.lblRefTem = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSigmaPhase = new System.Windows.Forms.TextBox();
            this.pnlHTHADf = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.chkIsHTHASeverity = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.lblHTHADf = new System.Windows.Forms.Label();
            this.cbHTHAMaterial = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.pnlGovSccDf = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.chkSusceptibleTemper = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblGovSccDf = new System.Windows.Forms.Label();
            this.chkNickelAlloy = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbSulfurContent = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbPTAMaterialGrade = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.chkIsPTASeverity = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pnlGovThinningDf = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCorrosionAllowance = new System.Windows.Forms.TextBox();
            this.lblCorrosion = new System.Windows.Forms.Label();
            this.lblGovThinningDf = new System.Windows.Forms.Label();
            this.pnlGenericProperties = new System.Windows.Forms.Panel();
            this.txtTensileStrength = new System.Windows.Forms.TextBox();
            this.lblTensileStrength = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtYieldStrength = new System.Windows.Forms.TextBox();
            this.lblYieldStrength = new System.Windows.Forms.Label();
            this.lblGenericProperties = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkCarbonLowAlloySteel = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkAusteniticSteel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesignPressure = new System.Windows.Forms.TextBox();
            this.lblDesignPressure = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxDesignTemperature = new System.Windows.Forms.TextBox();
            this.lblMaxDesignTem = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtMaterialCostFactor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.pnlGovBrittleFractureDf.SuspendLayout();
            this.pnlHTHADf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbHTHAMaterial.Properties)).BeginInit();
            this.pnlGovSccDf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSulfurContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPTAMaterialGrade.Properties)).BeginInit();
            this.pnlGovThinningDf.SuspendLayout();
            this.pnlGenericProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlGovBrittleFractureDf);
            this.groupBox1.Controls.Add(this.pnlHTHADf);
            this.groupBox1.Controls.Add(this.pnlGovSccDf);
            this.groupBox1.Controls.Add(this.pnlGovThinningDf);
            this.groupBox1.Controls.Add(this.pnlGenericProperties);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 742);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material";
            this.groupBox1.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            // 
            // pnlGovBrittleFractureDf
            // 
            this.pnlGovBrittleFractureDf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGovBrittleFractureDf.Controls.Add(this.txtMinDesignTemperature);
            this.pnlGovBrittleFractureDf.Controls.Add(this.label7);
            this.pnlGovBrittleFractureDf.Controls.Add(this.lblGovBrittleFractureDf);
            this.pnlGovBrittleFractureDf.Controls.Add(this.lblMinDesignTem);
            this.pnlGovBrittleFractureDf.Controls.Add(this.label21);
            this.pnlGovBrittleFractureDf.Controls.Add(this.chkChromium);
            this.pnlGovBrittleFractureDf.Controls.Add(this.label8);
            this.pnlGovBrittleFractureDf.Controls.Add(this.txtReferenceTemperature);
            this.pnlGovBrittleFractureDf.Controls.Add(this.lblRefTem);
            this.pnlGovBrittleFractureDf.Controls.Add(this.label16);
            this.pnlGovBrittleFractureDf.Controls.Add(this.txtSigmaPhase);
            this.pnlGovBrittleFractureDf.Location = new System.Drawing.Point(26, 580);
            this.pnlGovBrittleFractureDf.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGovBrittleFractureDf.Name = "pnlGovBrittleFractureDf";
            this.pnlGovBrittleFractureDf.Size = new System.Drawing.Size(877, 141);
            this.pnlGovBrittleFractureDf.TabIndex = 31;
            // 
            // txtMinDesignTemperature
            // 
            this.txtMinDesignTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinDesignTemperature.Location = new System.Drawing.Point(282, 25);
            this.txtMinDesignTemperature.Name = "txtMinDesignTemperature";
            this.txtMinDesignTemperature.Size = new System.Drawing.Size(138, 21);
            this.txtMinDesignTemperature.TabIndex = 6;
            this.txtMinDesignTemperature.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtMinDesignTemperature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtMinDesignTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinDesignTemperature_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(22, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Min. Design Temperature";
            // 
            // lblGovBrittleFractureDf
            // 
            this.lblGovBrittleFractureDf.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblGovBrittleFractureDf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovBrittleFractureDf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGovBrittleFractureDf.Location = new System.Drawing.Point(-1, -1);
            this.lblGovBrittleFractureDf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGovBrittleFractureDf.Name = "lblGovBrittleFractureDf";
            this.lblGovBrittleFractureDf.Size = new System.Drawing.Size(876, 16);
            this.lblGovBrittleFractureDf.TabIndex = 30;
            this.lblGovBrittleFractureDf.Text = "▼ Governing Brittle Fracture Damage Factor Properties";
            this.lblGovBrittleFractureDf.Click += new System.EventHandler(this.lblGovBrittleFractureDf_Click);
            // 
            // lblMinDesignTem
            // 
            this.lblMinDesignTem.AutoSize = true;
            this.lblMinDesignTem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinDesignTem.ForeColor = System.Drawing.Color.Black;
            this.lblMinDesignTem.Location = new System.Drawing.Point(426, 29);
            this.lblMinDesignTem.Name = "lblMinDesignTem";
            this.lblMinDesignTem.Size = new System.Drawing.Size(18, 13);
            this.lblMinDesignTem.TabIndex = 3;
            this.lblMinDesignTem.Text = "⁰C";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(22, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Chromium ≥ 12%";
            // 
            // chkChromium
            // 
            this.chkChromium.AutoSize = true;
            this.chkChromium.Location = new System.Drawing.Point(282, 51);
            this.chkChromium.Name = "chkChromium";
            this.chkChromium.Size = new System.Drawing.Size(15, 14);
            this.chkChromium.TabIndex = 12;
            this.chkChromium.UseVisualStyleBackColor = true;
            this.chkChromium.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkChromium.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Reference Temperature";
            // 
            // txtReferenceTemperature
            // 
            this.txtReferenceTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceTemperature.Location = new System.Drawing.Point(282, 73);
            this.txtReferenceTemperature.Name = "txtReferenceTemperature";
            this.txtReferenceTemperature.Size = new System.Drawing.Size(138, 21);
            this.txtReferenceTemperature.TabIndex = 7;
            this.txtReferenceTemperature.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtReferenceTemperature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtReferenceTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferenceTemperature_KeyPress);
            // 
            // lblRefTem
            // 
            this.lblRefTem.AutoSize = true;
            this.lblRefTem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefTem.ForeColor = System.Drawing.Color.Black;
            this.lblRefTem.Location = new System.Drawing.Point(426, 78);
            this.lblRefTem.Name = "lblRefTem";
            this.lblRefTem.Size = new System.Drawing.Size(18, 13);
            this.lblRefTem.TabIndex = 3;
            this.lblRefTem.Text = "⁰C";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Sigma Phase (%)";
            // 
            // txtSigmaPhase
            // 
            this.txtSigmaPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSigmaPhase.Location = new System.Drawing.Point(281, 102);
            this.txtSigmaPhase.Name = "txtSigmaPhase";
            this.txtSigmaPhase.Size = new System.Drawing.Size(138, 21);
            this.txtSigmaPhase.TabIndex = 9;
            this.txtSigmaPhase.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtSigmaPhase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtSigmaPhase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSigmaPhase_KeyPress);
            // 
            // pnlHTHADf
            // 
            this.pnlHTHADf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHTHADf.Controls.Add(this.label24);
            this.pnlHTHADf.Controls.Add(this.chkIsHTHASeverity);
            this.pnlHTHADf.Controls.Add(this.label25);
            this.pnlHTHADf.Controls.Add(this.lblHTHADf);
            this.pnlHTHADf.Controls.Add(this.cbHTHAMaterial);
            this.pnlHTHADf.Location = new System.Drawing.Point(26, 471);
            this.pnlHTHADf.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHTHADf.Name = "pnlHTHADf";
            this.pnlHTHADf.Size = new System.Drawing.Size(877, 90);
            this.pnlHTHADf.TabIndex = 29;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(22, 26);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(179, 15);
            this.label24.TabIndex = 0;
            this.label24.Text = "Material is Susceptible to HTHA";
            // 
            // chkIsHTHASeverity
            // 
            this.chkIsHTHASeverity.AutoSize = true;
            this.chkIsHTHASeverity.Location = new System.Drawing.Point(282, 28);
            this.chkIsHTHASeverity.Name = "chkIsHTHASeverity";
            this.chkIsHTHASeverity.Size = new System.Drawing.Size(15, 14);
            this.chkIsHTHASeverity.TabIndex = 17;
            this.chkIsHTHASeverity.UseVisualStyleBackColor = true;
            this.chkIsHTHASeverity.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkIsHTHASeverity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(22, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(124, 15);
            this.label25.TabIndex = 0;
            this.label25.Text = "HTHA Material Grade";
            // 
            // lblHTHADf
            // 
            this.lblHTHADf.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHTHADf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHTHADf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHTHADf.Location = new System.Drawing.Point(-1, 0);
            this.lblHTHADf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHTHADf.Name = "lblHTHADf";
            this.lblHTHADf.Size = new System.Drawing.Size(876, 16);
            this.lblHTHADf.TabIndex = 28;
            this.lblHTHADf.Text = "▼ High Temperature Hydrogen Attack Damage Factor Properties";
            this.lblHTHADf.Click += new System.EventHandler(this.lblHTHADf_Click);
            // 
            // cbHTHAMaterial
            // 
            this.cbHTHAMaterial.Location = new System.Drawing.Point(282, 52);
            this.cbHTHAMaterial.Name = "cbHTHAMaterial";
            this.cbHTHAMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbHTHAMaterial.Size = new System.Drawing.Size(368, 20);
            this.cbHTHAMaterial.TabIndex = 18;
            this.cbHTHAMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.cbHTHAMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // pnlGovSccDf
            // 
            this.pnlGovSccDf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGovSccDf.Controls.Add(this.label19);
            this.pnlGovSccDf.Controls.Add(this.chkSusceptibleTemper);
            this.pnlGovSccDf.Controls.Add(this.label20);
            this.pnlGovSccDf.Controls.Add(this.lblGovSccDf);
            this.pnlGovSccDf.Controls.Add(this.chkNickelAlloy);
            this.pnlGovSccDf.Controls.Add(this.label22);
            this.pnlGovSccDf.Controls.Add(this.cbSulfurContent);
            this.pnlGovSccDf.Controls.Add(this.cbPTAMaterialGrade);
            this.pnlGovSccDf.Controls.Add(this.label26);
            this.pnlGovSccDf.Controls.Add(this.chkIsPTASeverity);
            this.pnlGovSccDf.Controls.Add(this.label27);
            this.pnlGovSccDf.Location = new System.Drawing.Point(26, 286);
            this.pnlGovSccDf.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGovSccDf.Name = "pnlGovSccDf";
            this.pnlGovSccDf.Size = new System.Drawing.Size(877, 166);
            this.pnlGovSccDf.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(21, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "Susceptible to Temper";
            // 
            // chkSusceptibleTemper
            // 
            this.chkSusceptibleTemper.AutoSize = true;
            this.chkSusceptibleTemper.Location = new System.Drawing.Point(282, 27);
            this.chkSusceptibleTemper.Name = "chkSusceptibleTemper";
            this.chkSusceptibleTemper.Size = new System.Drawing.Size(15, 14);
            this.chkSusceptibleTemper.TabIndex = 11;
            this.chkSusceptibleTemper.UseVisualStyleBackColor = true;
            this.chkSusceptibleTemper.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkSusceptibleTemper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(21, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "Nickel-based Alloy";
            // 
            // lblGovSccDf
            // 
            this.lblGovSccDf.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblGovSccDf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovSccDf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGovSccDf.Location = new System.Drawing.Point(-1, 0);
            this.lblGovSccDf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGovSccDf.Name = "lblGovSccDf";
            this.lblGovSccDf.Size = new System.Drawing.Size(876, 16);
            this.lblGovSccDf.TabIndex = 26;
            this.lblGovSccDf.Text = "▼ Governing Stress Corrosion Cracking Damage Factor Properties";
            this.lblGovSccDf.Click += new System.EventHandler(this.lblGovSccDf_Click);
            // 
            // chkNickelAlloy
            // 
            this.chkNickelAlloy.AutoSize = true;
            this.chkNickelAlloy.Location = new System.Drawing.Point(282, 50);
            this.chkNickelAlloy.Name = "chkNickelAlloy";
            this.chkNickelAlloy.Size = new System.Drawing.Size(15, 14);
            this.chkNickelAlloy.TabIndex = 14;
            this.chkNickelAlloy.UseVisualStyleBackColor = true;
            this.chkNickelAlloy.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkNickelAlloy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(21, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "Sulfur Content";
            // 
            // cbSulfurContent
            // 
            this.cbSulfurContent.Location = new System.Drawing.Point(282, 70);
            this.cbSulfurContent.Name = "cbSulfurContent";
            this.cbSulfurContent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSulfurContent.Size = new System.Drawing.Size(368, 20);
            this.cbSulfurContent.TabIndex = 15;
            this.cbSulfurContent.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.cbSulfurContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // cbPTAMaterialGrade
            // 
            this.cbPTAMaterialGrade.Enabled = false;
            this.cbPTAMaterialGrade.Location = new System.Drawing.Point(282, 127);
            this.cbPTAMaterialGrade.Name = "cbPTAMaterialGrade";
            this.cbPTAMaterialGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPTAMaterialGrade.Size = new System.Drawing.Size(368, 20);
            this.cbPTAMaterialGrade.TabIndex = 20;
            this.cbPTAMaterialGrade.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.cbPTAMaterialGrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(21, 94);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(155, 30);
            this.label26.TabIndex = 0;
            this.label26.Text = "Material Grade to Evaluate \r\nSeverity of PTA Cracking";
            // 
            // chkIsPTASeverity
            // 
            this.chkIsPTASeverity.AutoSize = true;
            this.chkIsPTASeverity.Location = new System.Drawing.Point(282, 102);
            this.chkIsPTASeverity.Name = "chkIsPTASeverity";
            this.chkIsPTASeverity.Size = new System.Drawing.Size(15, 14);
            this.chkIsPTASeverity.TabIndex = 19;
            this.chkIsPTASeverity.UseVisualStyleBackColor = true;
            this.chkIsPTASeverity.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkIsPTASeverity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(21, 132);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(114, 15);
            this.label27.TabIndex = 0;
            this.label27.Text = "PTA Material Grade";
            // 
            // pnlGovThinningDf
            // 
            this.pnlGovThinningDf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGovThinningDf.Controls.Add(this.label14);
            this.pnlGovThinningDf.Controls.Add(this.txtCorrosionAllowance);
            this.pnlGovThinningDf.Controls.Add(this.lblCorrosion);
            this.pnlGovThinningDf.Controls.Add(this.lblGovThinningDf);
            this.pnlGovThinningDf.Location = new System.Drawing.Point(26, 203);
            this.pnlGovThinningDf.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGovThinningDf.Name = "pnlGovThinningDf";
            this.pnlGovThinningDf.Size = new System.Drawing.Size(877, 64);
            this.pnlGovThinningDf.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Corrosion Allowance";
            // 
            // txtCorrosionAllowance
            // 
            this.txtCorrosionAllowance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrosionAllowance.Location = new System.Drawing.Point(404, 28);
            this.txtCorrosionAllowance.Name = "txtCorrosionAllowance";
            this.txtCorrosionAllowance.Size = new System.Drawing.Size(138, 21);
            this.txtCorrosionAllowance.TabIndex = 5;
            this.txtCorrosionAllowance.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtCorrosionAllowance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtCorrosionAllowance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorrosionAllowance_KeyPress);
            // 
            // lblCorrosion
            // 
            this.lblCorrosion.AutoSize = true;
            this.lblCorrosion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrosion.ForeColor = System.Drawing.Color.Black;
            this.lblCorrosion.Location = new System.Drawing.Point(548, 31);
            this.lblCorrosion.Name = "lblCorrosion";
            this.lblCorrosion.Size = new System.Drawing.Size(23, 13);
            this.lblCorrosion.TabIndex = 3;
            this.lblCorrosion.Text = "mm";
            // 
            // lblGovThinningDf
            // 
            this.lblGovThinningDf.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblGovThinningDf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovThinningDf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGovThinningDf.Location = new System.Drawing.Point(-1, 0);
            this.lblGovThinningDf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGovThinningDf.Name = "lblGovThinningDf";
            this.lblGovThinningDf.Size = new System.Drawing.Size(876, 16);
            this.lblGovThinningDf.TabIndex = 25;
            this.lblGovThinningDf.Text = "▼ Governing Thinning Damage Factor Properties";
            this.lblGovThinningDf.Click += new System.EventHandler(this.lblGovThinningDf_Click);
            // 
            // pnlGenericProperties
            // 
            this.pnlGenericProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGenericProperties.Controls.Add(this.txtTensileStrength);
            this.pnlGenericProperties.Controls.Add(this.lblTensileStrength);
            this.pnlGenericProperties.Controls.Add(this.label11);
            this.pnlGenericProperties.Controls.Add(this.txtYieldStrength);
            this.pnlGenericProperties.Controls.Add(this.lblYieldStrength);
            this.pnlGenericProperties.Controls.Add(this.lblGenericProperties);
            this.pnlGenericProperties.Controls.Add(this.label6);
            this.pnlGenericProperties.Controls.Add(this.label1);
            this.pnlGenericProperties.Controls.Add(this.txtMaterial);
            this.pnlGenericProperties.Controls.Add(this.label17);
            this.pnlGenericProperties.Controls.Add(this.chkCarbonLowAlloySteel);
            this.pnlGenericProperties.Controls.Add(this.label18);
            this.pnlGenericProperties.Controls.Add(this.chkAusteniticSteel);
            this.pnlGenericProperties.Controls.Add(this.label3);
            this.pnlGenericProperties.Controls.Add(this.txtDesignPressure);
            this.pnlGenericProperties.Controls.Add(this.lblDesignPressure);
            this.pnlGenericProperties.Controls.Add(this.label2);
            this.pnlGenericProperties.Controls.Add(this.txtMaxDesignTemperature);
            this.pnlGenericProperties.Controls.Add(this.lblMaxDesignTem);
            this.pnlGenericProperties.Controls.Add(this.label28);
            this.pnlGenericProperties.Controls.Add(this.txtMaterialCostFactor);
            this.pnlGenericProperties.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlGenericProperties.Location = new System.Drawing.Point(25, 30);
            this.pnlGenericProperties.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGenericProperties.Name = "pnlGenericProperties";
            this.pnlGenericProperties.Size = new System.Drawing.Size(878, 156);
            this.pnlGenericProperties.TabIndex = 23;
            // 
            // txtTensileStrength
            // 
            this.txtTensileStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTensileStrength.Location = new System.Drawing.Point(657, 78);
            this.txtTensileStrength.Name = "txtTensileStrength";
            this.txtTensileStrength.Size = new System.Drawing.Size(138, 21);
            this.txtTensileStrength.TabIndex = 27;
            // 
            // lblTensileStrength
            // 
            this.lblTensileStrength.AutoSize = true;
            this.lblTensileStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTensileStrength.ForeColor = System.Drawing.Color.Black;
            this.lblTensileStrength.Location = new System.Drawing.Point(801, 83);
            this.lblTensileStrength.Name = "lblTensileStrength";
            this.lblTensileStrength.Size = new System.Drawing.Size(20, 13);
            this.lblTensileStrength.TabIndex = 28;
            this.lblTensileStrength.Text = "psi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(460, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Tensile Strength";
            // 
            // txtYieldStrength
            // 
            this.txtYieldStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYieldStrength.Location = new System.Drawing.Point(657, 53);
            this.txtYieldStrength.Name = "txtYieldStrength";
            this.txtYieldStrength.Size = new System.Drawing.Size(138, 21);
            this.txtYieldStrength.TabIndex = 24;
            // 
            // lblYieldStrength
            // 
            this.lblYieldStrength.AutoSize = true;
            this.lblYieldStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYieldStrength.ForeColor = System.Drawing.Color.Black;
            this.lblYieldStrength.Location = new System.Drawing.Point(801, 58);
            this.lblYieldStrength.Name = "lblYieldStrength";
            this.lblYieldStrength.Size = new System.Drawing.Size(20, 13);
            this.lblYieldStrength.TabIndex = 25;
            this.lblYieldStrength.Text = "psi";
            // 
            // lblGenericProperties
            // 
            this.lblGenericProperties.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblGenericProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenericProperties.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGenericProperties.Location = new System.Drawing.Point(-1, 0);
            this.lblGenericProperties.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenericProperties.Name = "lblGenericProperties";
            this.lblGenericProperties.Size = new System.Drawing.Size(877, 16);
            this.lblGenericProperties.TabIndex = 3;
            this.lblGenericProperties.Text = "▼ Generic Properties";
            this.lblGenericProperties.Click += new System.EventHandler(this.lblGenericProperties_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Yield Strength";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(201, 25);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(594, 22);
            this.txtMaterial.TabIndex = 22;
            this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(22, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(146, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Carbon or Low Alloy Steel";
            // 
            // chkCarbonLowAlloySteel
            // 
            this.chkCarbonLowAlloySteel.AutoSize = true;
            this.chkCarbonLowAlloySteel.Location = new System.Drawing.Point(201, 52);
            this.chkCarbonLowAlloySteel.Name = "chkCarbonLowAlloySteel";
            this.chkCarbonLowAlloySteel.Size = new System.Drawing.Size(15, 14);
            this.chkCarbonLowAlloySteel.TabIndex = 10;
            this.chkCarbonLowAlloySteel.UseVisualStyleBackColor = true;
            this.chkCarbonLowAlloySteel.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkCarbonLowAlloySteel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(22, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Austenitic Steel";
            // 
            // chkAusteniticSteel
            // 
            this.chkAusteniticSteel.AutoSize = true;
            this.chkAusteniticSteel.Location = new System.Drawing.Point(201, 74);
            this.chkAusteniticSteel.Name = "chkAusteniticSteel";
            this.chkAusteniticSteel.Size = new System.Drawing.Size(15, 14);
            this.chkAusteniticSteel.TabIndex = 13;
            this.chkAusteniticSteel.UseVisualStyleBackColor = true;
            this.chkAusteniticSteel.CheckedChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.chkAusteniticSteel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Design Pressure";
            // 
            // txtDesignPressure
            // 
            this.txtDesignPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignPressure.Location = new System.Drawing.Point(201, 93);
            this.txtDesignPressure.Name = "txtDesignPressure";
            this.txtDesignPressure.Size = new System.Drawing.Size(138, 21);
            this.txtDesignPressure.TabIndex = 3;
            this.txtDesignPressure.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtDesignPressure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtDesignPressure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesignPressure_KeyPress);
            // 
            // lblDesignPressure
            // 
            this.lblDesignPressure.AutoSize = true;
            this.lblDesignPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignPressure.ForeColor = System.Drawing.Color.Black;
            this.lblDesignPressure.Location = new System.Drawing.Point(357, 97);
            this.lblDesignPressure.Name = "lblDesignPressure";
            this.lblDesignPressure.Size = new System.Drawing.Size(20, 13);
            this.lblDesignPressure.TabIndex = 3;
            this.lblDesignPressure.Text = "psi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max. Design Temperature";
            // 
            // txtMaxDesignTemperature
            // 
            this.txtMaxDesignTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDesignTemperature.Location = new System.Drawing.Point(201, 118);
            this.txtMaxDesignTemperature.Name = "txtMaxDesignTemperature";
            this.txtMaxDesignTemperature.Size = new System.Drawing.Size(138, 21);
            this.txtMaxDesignTemperature.TabIndex = 2;
            this.txtMaxDesignTemperature.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtMaxDesignTemperature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtMaxDesignTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxDesignTemperature_KeyPress);
            // 
            // lblMaxDesignTem
            // 
            this.lblMaxDesignTem.AutoSize = true;
            this.lblMaxDesignTem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDesignTem.ForeColor = System.Drawing.Color.Black;
            this.lblMaxDesignTem.Location = new System.Drawing.Point(358, 121);
            this.lblMaxDesignTem.Name = "lblMaxDesignTem";
            this.lblMaxDesignTem.Size = new System.Drawing.Size(18, 13);
            this.lblMaxDesignTem.TabIndex = 3;
            this.lblMaxDesignTem.Text = "⁰C";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(460, 107);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(116, 15);
            this.label28.TabIndex = 0;
            this.label28.Text = "Material Cost Factor";
            // 
            // txtMaterialCostFactor
            // 
            this.txtMaterialCostFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialCostFactor.Location = new System.Drawing.Point(657, 104);
            this.txtMaterialCostFactor.Name = "txtMaterialCostFactor";
            this.txtMaterialCostFactor.Size = new System.Drawing.Size(138, 21);
            this.txtMaterialCostFactor.TabIndex = 21;
            this.txtMaterialCostFactor.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtMaterialCostFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
            this.txtMaterialCostFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialCostFactor_KeyPress);
            // 
            // UCMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCMaterial";
            this.Size = new System.Drawing.Size(927, 742);
            this.Load += new System.EventHandler(this.UCMaterial_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlGovBrittleFractureDf.ResumeLayout(false);
            this.pnlGovBrittleFractureDf.PerformLayout();
            this.pnlHTHADf.ResumeLayout(false);
            this.pnlHTHADf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbHTHAMaterial.Properties)).EndInit();
            this.pnlGovSccDf.ResumeLayout(false);
            this.pnlGovSccDf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSulfurContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPTAMaterialGrade.Properties)).EndInit();
            this.pnlGovThinningDf.ResumeLayout(false);
            this.pnlGovThinningDf.PerformLayout();
            this.pnlGenericProperties.ResumeLayout(false);
            this.pnlGenericProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDesignPressure;
        private System.Windows.Forms.TextBox txtMaxDesignTemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNickelAlloy;
        private System.Windows.Forms.CheckBox chkAusteniticSteel;
        private System.Windows.Forms.CheckBox chkIsPTASeverity;
        private System.Windows.Forms.CheckBox chkIsHTHASeverity;
        private System.Windows.Forms.CheckBox chkChromium;
        private System.Windows.Forms.CheckBox chkSusceptibleTemper;
        private System.Windows.Forms.CheckBox chkCarbonLowAlloySteel;
        private System.Windows.Forms.Label lblCorrosion;
        private System.Windows.Forms.Label lblDesignPressure;
        private System.Windows.Forms.Label lblRefTem;
        private System.Windows.Forms.Label lblMinDesignTem;
        private System.Windows.Forms.Label lblMaxDesignTem;
        private System.Windows.Forms.TextBox txtReferenceTemperature;
        private System.Windows.Forms.TextBox txtMaterialCostFactor;
        private System.Windows.Forms.TextBox txtCorrosionAllowance;
        private System.Windows.Forms.TextBox txtMinDesignTemperature;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSigmaPhase;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbSulfurContent;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbPTAMaterialGrade;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbHTHAMaterial;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Panel pnlGenericProperties;
        private System.Windows.Forms.Label lblGenericProperties;
        private System.Windows.Forms.TextBox txtTensileStrength;
        private System.Windows.Forms.Label lblTensileStrength;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtYieldStrength;
        private System.Windows.Forms.Label lblYieldStrength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHTHADf;
        private System.Windows.Forms.Panel pnlGovSccDf;
        private System.Windows.Forms.Label lblGovSccDf;
        private System.Windows.Forms.Label lblGovThinningDf;
        private System.Windows.Forms.Panel pnlGovThinningDf;
        private System.Windows.Forms.Panel pnlHTHADf;
        private System.Windows.Forms.Label lblGovBrittleFractureDf;
        private System.Windows.Forms.Panel pnlGovBrittleFractureDf;
    }
}
