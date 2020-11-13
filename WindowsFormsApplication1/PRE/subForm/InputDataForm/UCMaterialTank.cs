using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.Object;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCMaterialTank : UserControl
    {
        string[] itemsSulfurContent = { "High > 0.01%", "Low 0.002 - 0.01%", "Ultra Low < 0.002%" };
        string[] itemsHeatTreatment = {"Annealed", "None", "Normalised Temper", "Quench Temper", "Stress Relieved", "Sub Critical PWHT" };
        string[] itemsPTAMterial = {"321 Stainless Steel",
                                "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay",
                                "Regular 300 series Stainless Steels and Alloys 600 and 800",
                                "H Grade 300 series Stainless Steels",
                                "L Grade 300 series Stainless Steels",
                                "Not Applicable"};
 
        public UCMaterialTank(int ID, string temUnit, string pressureUnit, string corrosionUnit)
        {
            InitializeComponent();
            txtMaterial.Enabled = false;
            addSulfurContent();
            addPTAMterial();
            ShowDataToControl(ID, temUnit, pressureUnit, corrosionUnit);
            string changeUnit = "";
            switch (temUnit)
            {
                case "DEG_C":
                    changeUnit = "⁰C";
                    break;
                case "DEG_F":
                    changeUnit = "⁰F";
                    break;
                case "K":
                    changeUnit = "K";
                    break;
            }
            lblMaxDesignTem.Text = lblMinDesignTem.Text = lblRefTem.Text = changeUnit;
            switch (pressureUnit)
            {
                case "PSI":
                    changeUnit = "psi";
                    break;
                case "KSI":
                    changeUnit = "KSI";
                    break;
                case "BAR":
                    changeUnit = "bar";
                    break;
                case "MPA":
                    changeUnit = "MPa";
                    break;
                case "NM2":
                    changeUnit = "N/m²";
                    break;
                case "NCM2":
                    changeUnit = "N/cm²";
                    break;
            }
            lblDesignPressure.Text = lblYieldStrength.Text = lblTensileStrength.Text = changeUnit;
            switch (corrosionUnit)
            {
                case "MM":
                    changeUnit = "mm";
                    break;
                case "MIL":
                    changeUnit = "mil";
                    break;
            }
            lblCorrosion.Text = changeUnit;
        }
        
        public void ShowDataToControl(int ID, string temUnit, string pressureUnit, string corrosionUnit)
        {
            RW_MATERIAL_BUS BUS = new RW_MATERIAL_BUS();
            RW_MATERIAL obj = BUS.getData(ID);
            RW_INPUT_CA_TANK_BUS busTank = new RW_INPUT_CA_TANK_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            float tank = busTank.getProductionCost(ID);
            switch(temUnit)
            {
                case "DEG_C":
                    txtMaxDesignTemperature.Text = obj.DesignTemperature.ToString();
                    txtMinDesignTemperature.Text = obj.MinDesignTemperature.ToString();
                    txtReferenceTemperature.Text = obj.ReferenceTemperature.ToString();
                    break;
                case "DEG_F":
                    txtMaxDesignTemperature.Text = (convUnit.CelToFah(obj.DesignTemperature)).ToString();
                    txtMinDesignTemperature.Text = (convUnit.CelToFah(obj.MinDesignTemperature)).ToString();
                    txtReferenceTemperature.Text = (convUnit.CelToFah(obj.ReferenceTemperature)).ToString();
                    break;
                case "K":
                    txtMaxDesignTemperature.Text = (convUnit.CelToKenvin(obj.DesignTemperature)).ToString();
                    txtMinDesignTemperature.Text = (convUnit.CelToKenvin(obj.MinDesignTemperature)).ToString();
                    txtReferenceTemperature.Text = (convUnit.CelToKenvin(obj.ReferenceTemperature)).ToString();
                    break;
            }
            switch (pressureUnit)
            {
                case "PSI":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.psi).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength / convUnit.psi).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength / convUnit.psi).ToString();
                    break;
                case "KSI":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.ksi).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength / convUnit.ksi).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength / convUnit.ksi).ToString();
                    break;
                case "BAR":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.bar).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength / convUnit.bar).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength / convUnit.bar).ToString();
                    break;
                case "MPA":
                    txtDesignPressure.Text = (obj.DesignPressure).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength).ToString();
                    break;
                case "NM2":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.NpM2).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength / convUnit.NpM2).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength / convUnit.NpM2).ToString();
                    break;
                case "NCM2":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.NpCM2).ToString();
                    txtYieldStrength.Text = (obj.YieldStrength / convUnit.NpCM2).ToString();
                    txtTensileStrength.Text = (obj.TensileStrength / convUnit.NpCM2).ToString();
                    break;
            }
            switch (corrosionUnit)
            {
                case "mm":
                    txtCorrosionAllowance.Text = obj.CorrosionAllowance.ToString();
                    break;
                case "mil":
                    txtCorrosionAllowance.Text = (obj.CorrosionAllowance / convUnit.mil).ToString();
                    break;
            }
            txtMaterial.Text = obj.MaterialName;                    
            for (int i = 0; i < itemsSulfurContent.Length; i++)
            {
                if (obj.SulfurContent == itemsSulfurContent[i])
                {
                    cbSulfurContent.SelectedIndex = i + 1;
                    break;
                }
            }
            
            for (int i = 0; i < itemsPTAMterial.Length; i++)
            {
                if (obj.PTAMaterialCode == itemsPTAMterial[i])
                {
                    cbPTAMaterialGrade.SelectedIndex = i + 1;
                    break;
                }
            }
            chkIsPTASeverity.Checked = Convert.ToBoolean(obj.IsPTA);
            chkAusteniticSteel.Checked = Convert.ToBoolean(obj.Austenitic);
            chkCarbonLowAlloySteel.Checked = Convert.ToBoolean(obj.CarbonLowAlloy);
            chkNickelAlloy.Checked = Convert.ToBoolean(obj.NickelBased);
            chkChromium.Checked = Convert.ToBoolean(obj.ChromeMoreEqual12);
            txtMaterialCostFactor.Text = obj.CostFactor.ToString();
        }

        public RW_MATERIAL getData(int ID, string temUnit, string pressureUnit, string corrosionUnit)
        {
            RW_MATERIAL ma = new RW_MATERIAL();
            BUS_UNITS convUnit = new BUS_UNITS();
            ma.ID = ID;
            ma.MaterialName = txtMaterial.Text;
            switch (temUnit)
            {
                case "DEG_C":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? float.Parse(txtMaxDesignTemperature.Text) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? float.Parse(txtMinDesignTemperature.Text) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? float.Parse(txtReferenceTemperature.Text) : 0;
                    break;
                case "DEG_F":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMaxDesignTemperature.Text)) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMinDesignTemperature.Text)) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtReferenceTemperature.Text)) : 0;
                    break;
                case "K":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMaxDesignTemperature.Text)) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMinDesignTemperature.Text)) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtReferenceTemperature.Text)) : 0;
                    break;
            }

            switch (pressureUnit)
            {
                case "PSI":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) * (float)convUnit.psi : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) * (float)convUnit.psi : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.psi : 0;
                    break;
                case "KSI":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) * (float)convUnit.ksi : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) * (float)convUnit.ksi : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.ksi : 0;
                    break;
                case "BAR":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) * (float)convUnit.bar : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) * (float)convUnit.bar : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.bar : 0;
                    break;
                case "MPA":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) : 0;
                    break;
                case "NM2":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) * (float)convUnit.NpM2 : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) * (float)convUnit.NpM2 : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.NpM2 : 0;
                    break;
                case "NCM2":
                    ma.YieldStrength = txtYieldStrength.Text != "" ? float.Parse(txtYieldStrength.Text) * (float)convUnit.NpCM2 : 0;
                    ma.TensileStrength = txtTensileStrength.Text != "" ? float.Parse(txtTensileStrength.Text) * (float)convUnit.NpCM2 : 0;
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.NpCM2 : 0;
                    break;
            }

            switch (corrosionUnit)
            {
                case "mm":
                    ma.CorrosionAllowance = txtCorrosionAllowance.Text != "" ? float.Parse(txtCorrosionAllowance.Text) : 0;
                    break;
                case "mil":
                    ma.CorrosionAllowance = txtCorrosionAllowance.Text != "" ? float.Parse(txtCorrosionAllowance.Text) * (float)convUnit.mil : 0;
                    break;
            }

            ma.SulfurContent = cbSulfurContent.Text;
            ma.PTAMaterialCode = cbPTAMaterialGrade.Text;
            ma.IsPTA = chkIsPTASeverity.Checked ? 1 : 0;
            ma.Austenitic = chkAusteniticSteel.Checked ? 1 : 0;
            ma.CarbonLowAlloy = chkCarbonLowAlloySteel.Checked ? 1 : 0;
            ma.NickelBased = chkNickelAlloy.Checked ? 1 : 0;
            ma.ChromeMoreEqual12 = chkChromium.Checked ? 1 : 0;
            ma.CostFactor = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ma;
        }
        public RW_INPUT_CA_LEVEL_1 getDataForCA(int ID)
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.ID = ID;
            ca.Material_Cost = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ca;
        }
        public RW_INPUT_CA_TANK getDataforTank(int ID)
        {
            RW_INPUT_CA_TANK ca = new RW_INPUT_CA_TANK();
            ca.ID = ID;
            return ca;
        }
        private void chkIsPTASeverity_CheckedChanged(object sender, EventArgs e)// kiem tra lai
        {

        }
        #region Add Data to ComboBox
        private void addSulfurContent()
        {
            cbSulfurContent.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsSulfurContent.Length; i++)
            {
                cbSulfurContent.Properties.Items.Add(itemsSulfurContent[i], i, i);
            }
        }
        private void addPTAMterial()
        {
            cbPTAMaterialGrade.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPTAMterial.Length; i++)
            {
                cbPTAMaterialGrade.Properties.Items.Add(itemsPTAMterial[i], i, i);
            }
        }
        #endregion

        #region Key Press Event
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev, bool textTemper)
        {
            string a = textbox.Text;
            if (!textTemper)
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
                {
                    ev.Handled = true;
                }
                if (a.Contains(".") && ev.KeyChar == '.')
                {
                    ev.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.') && (ev.KeyChar != '-'))
                {
                    ev.Handled = true;
                }
                if ((a.StartsWith("-") && ev.KeyChar == '-') || (a.Contains(".") && ev.KeyChar == '.'))
                {
                    ev.Handled = true;
                }
            }
        }
        private void txtMaxDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaxDesignTemperature, e, true);
        }

        private void txtDesignPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDesignPressure, e, false);
        }

        private void txtCorrosionAllowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCorrosionAllowance, e, false);
        }

        private void txtMinDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinDesignTemperature, e, true);
        }

        private void txtReferenceTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtReferenceTemperature, e, true);
        }

        private void txtMaterialCostFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaterialCostFactor, e, false);
        }
        private void txtProductionCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaterialCostFactor, e, false);
        }
        #endregion

        #region Xu ly su kien khi Data thay doi
        private int datachange = 0;
        private int ctrlSpress = 0;
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int DataChange
        {
            get { return datachange; }
            set
            {
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }
        
        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            if(sender is CheckBox)
            {
                CheckBox chk = sender as CheckBox;
                switch(chk.Name)
                {
                    case "chkIsPTASeverity":
                        cbPTAMaterialGrade.Enabled = chk.Checked ? true : false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }


        #endregion
    }
}
