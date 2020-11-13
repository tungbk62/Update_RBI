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
using RBI.Object;
using RBI.BUS.BUSMSSQL_CAL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCComponentPropertiesTank : UserControl
    {
        string[] itemsSeverity = { "None", "Low", "Medium", "High" };
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        string[] itemsComplexityProtrusion = { "Above average", "Average", "Below average" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        public UCComponentPropertiesTank(int ID, string type, string diameterUnit, string thicknessUnit, string corrosionRateUnit, string volumeUnit, string stressUnit)
        {
            InitializeComponent();
            panel1.Height = 20;
            panel2.Height = 20;
            panel3.Height = 20;
            panel4.Height = 20;
            panel5.Height = 20;
            panel6.Height = 20;
            panel2.Top = panel1.Top + panel1.Height + 20;
            panel3.Top = panel2.Top + panel2.Height + 20;
            panel4.Top = panel3.Top + panel3.Height + 20;
            panel5.Top = panel4.Top + panel4.Height + 20;
            panel6.Top = panel5.Top + panel5.Height + 20;
            ShowDataToControl(ID, diameterUnit, thicknessUnit, corrosionRateUnit, volumeUnit, stressUnit);
            if (type == "Shell")
            {
                chkConcreteAsphalt.Enabled = false;
                chkPreventionBarrier.Enabled = false;
            }
            lblDiameter.Text = diameterUnit;
            lblCorrosionRate.Text = corrosionRateUnit;
            string changeUnit = "";
            switch (diameterUnit)
            {
                case "INCH":
                    changeUnit = "in";
                    break;
                case "MM":
                    changeUnit = "mm";
                    break;
            }
            lblDiameter.Text = changeUnit;
            switch (thicknessUnit)
            {
                case "INCH":
                    changeUnit = "in";
                    break;
                case "MM":
                    changeUnit = "mm";
                    break;
            }
            lblNominalThickness.Text = lblMinReqThickness.Text = lblMiniumMeasuredThickness.Text = lblBrittleFractureThickness.Text = lblStructuralThickness.Text = changeUnit;
            switch (corrosionRateUnit)
            {
                case "MILYR":
                    changeUnit = "mil/yr";
                    break;
                case "MMYR":
                    changeUnit = "mm/yr";
                    break;
            }
            lblCorrosionRate.Text = changeUnit;
            switch (volumeUnit)
            {
                case "FT3":
                    changeUnit = "ft³";
                    break;
                case "M3":
                    changeUnit = "m³";
                    break;
            }
            lblComponentVolume.Text = changeUnit;
            switch (stressUnit)
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
            lblAllowableStress.Text = changeUnit;
        }
        private void ShowDataToControl(int ID, string diameter, string thickness, string corrosionRate, string volumeUnit, string stressUnit)
        {
            RW_COMPONENT_BUS busCom = new RW_COMPONENT_BUS();
            RW_COMPONENT comp = busCom.getData(ID);
            BUS_UNITS convUnit = new BUS_UNITS();
            if (diameter == "INCH") txtTankDiameter.Text = (comp.NominalDiameter/ convUnit.inch).ToString(); // converst mm sang in
            else if (diameter == "MM") txtTankDiameter.Text = comp.NominalDiameter.ToString(); // giữ nguyên

            if (thickness == "MM")
            {
                txtNominalThickness.Text = comp.NominalThickness.ToString(); //giữ nguyên
                txtMinRequiredThickness.Text = comp.MinReqThickness.ToString();//  giữ nguyên
                txtCurrentThickness.Text = comp.CurrentThickness.ToString();
                txtBrittleFractureThickness.Text = comp.BrittleFractureThickness.ToString();
                txtStructuralThickness.Text = comp.StructuralThickness.ToString();
            }
            else if (thickness == "INCH")
            {
                txtNominalThickness.Text = (comp.NominalThickness / convUnit.inch).ToString(); //converst mm sang in
                txtMinRequiredThickness.Text = (comp.MinReqThickness / convUnit.inch).ToString(); //convert mm sang in
                txtCurrentThickness.Text = (comp.CurrentThickness / convUnit.inch).ToString();
                txtBrittleFractureThickness.Text = (comp.BrittleFractureThickness / convUnit.inch).ToString();
                txtStructuralThickness.Text = (comp.StructuralThickness / convUnit.inch).ToString();
            }
            if (corrosionRate == "MMYR")
                txtCurrentCorrosionRate.Text = comp.CurrentCorrosionRate.ToString(); // converst mm sang mm
            else txtCurrentCorrosionRate.Text = (comp.CurrentCorrosionRate / convUnit.mil).ToString(); // converst mm sang mil

            if (stressUnit == "KSI") txtAllowableStress.Text = (comp.AllowableStress / convUnit.ksi).ToString();
            else if (stressUnit == "PSI") txtAllowableStress.Text = (comp.AllowableStress / convUnit.psi).ToString();
            else if (stressUnit == "MPA") txtAllowableStress.Text = (comp.AllowableStress).ToString();
            else if (stressUnit == "BAR") txtAllowableStress.Text = (comp.AllowableStress / convUnit.bar).ToString();
            else if (stressUnit == "NM2") txtAllowableStress.Text = (comp.AllowableStress / convUnit.NpM2).ToString();
            else txtAllowableStress.Text = (comp.AllowableStress / convUnit.NpCM2).ToString();

            if (volumeUnit == "M3") txtComponentVolume.Text = comp.ComponentVolume.ToString();
            else txtComponentVolume.Text = (comp.ComponentVolume / convUnit.ft3).ToString();

            txtShellHeight.Text = (comp.ShellHeight).ToString();// lay don vi m

            chkConcreteAsphalt.Checked = comp.ConcreteFoundation == 1 ? true : false;
            chkPresenceCracks.Checked = comp.CracksPresent == 1 ? true : false;
            chkPreventionBarrier.Checked = comp.ReleasePreventionBarrier == 1 ? true : false;
            for(int i = 0; i<itemsBrinnellHardness.Length;i++)
            {
                if(itemsBrinnellHardness[i] == comp.BrinnelHardness)
                {
                    cbMaxBrillnessHardness.SelectedIndex = i + 1;
                    break;
                }
            }
            for(int i = 0; i < itemsComplexityProtrusion.Length; i++)
            {
                if(itemsComplexityProtrusion[i] == comp.ComplexityProtrusion)
                {
                    cbComplexityProtrusion.SelectedIndex = i + 1;
                    break;
                }
            }
            for(int i = 0; i < itemsSeverity.Length; i++)
            {
                if(itemsSeverity[i] == comp.SeverityOfVibration)
                {
                    cbSeverityVibration.SelectedIndex = i + 1;
                    break;
                }
            }
        }
        public RW_COMPONENT getData(int ID, string diameter, string thickness, string corrosionRate, string volumeUnit, string stressUnit)
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.ID = ID;
            BUS_UNITS convUnit = new BUS_UNITS();
            //Generic Properties
            if (diameter == "MM") comp.NominalDiameter = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            else if (diameter == "INCH") comp.NominalDiameter = txtTankDiameter.Text != "" ? (float)(double.Parse(txtTankDiameter.Text) * convUnit.inch) : 0; // in sang mm
            if (thickness == "MM")
            {
                comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
                comp.BrittleFractureThickness = txtBrittleFractureThickness.Text != "" ? float.Parse(txtBrittleFractureThickness.Text) : 0;
                comp.StructuralThickness = txtStructuralThickness.Text != "" ? float.Parse(txtStructuralThickness.Text) : 0;

            }
            else if (thickness == "INCH")
            {
                comp.NominalThickness = txtNominalThickness.Text != "" ? (float)(double.Parse(txtNominalThickness.Text) * convUnit.inch) : 0; // in sang mm
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? (float)(double.Parse(txtMinRequiredThickness.Text) * convUnit.inch) : 0;// in sang mm
                comp.BrittleFractureThickness = txtBrittleFractureThickness.Text != "" ? (float)(double.Parse(txtBrittleFractureThickness.Text) * convUnit.inch) : 0;
                comp.StructuralThickness = txtStructuralThickness.Text != "" ? (float)(double.Parse(txtStructuralThickness.Text) * convUnit.inch) : 0;
            }
            if (corrosionRate == "MMYR") comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)double.Parse(txtCurrentCorrosionRate.Text) : 0;
            else comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)(double.Parse(txtCurrentCorrosionRate.Text) * convUnit.mil) : 0; // mil/yr sang mm/yr
            if (volumeUnit == "M3")
                comp.ComponentVolume = txtComponentVolume.Text != "" ? float.Parse(txtComponentVolume.Text) : 0;
            else comp.ComponentVolume = txtComponentVolume.Text != "" ? (float)(double.Parse(txtComponentVolume.Text) * convUnit.ft3) : 0;
            if (stressUnit == "KSI")
                comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.ksi) : 0;
            else if (stressUnit == "PSI") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.psi) : 0;
            else if (stressUnit == "MPA") comp.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) : 0;
            else if (stressUnit == "BAR") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.bar) : 0;
            else if (stressUnit == "NM2") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.NpM2) : 0;
            else comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.NpCM2) : 0;
            comp.WeldJointEfficiency = txtWeldJointEfficiency.Text != "" ? float.Parse(txtWeldJointEfficiency.Text) : 0;
            comp.ConfidenceCorrosionRate = cbConfidenceCorrosionRate.Text;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;
            comp.MinimumStructuralThicknessGoverns = chkMinimumStructuralThicknessGoverns.Checked ? 1 : 0;
            //Governing Stress Corrosion Cracking Damage Factor
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            //Governing Brittle Fracture Damage Factor
            comp.FabricatedSteel = chkFabricatedSteel.Checked ? 1 : 0;
            comp.EquipmentSatisfied = chkEquipmentSatisfied.Checked ? 1 : 0;
            comp.NominalOperatingConditions = chkNominalOperatingConditions.Checked ? 1 : 0;
            comp.CETGreaterOrEqual = chkCETGreaterOrEqual.Checked ? 1 : 0;
            comp.CyclicServiceFatigueVibration = chkCyclicServiceFatigueVibration.Checked ? 1 : 0;
            comp.EquipmentCircuitShock = chkEquipmentCircuitShock.Checked ? 1 : 0;
            //Governing Fatigue Damage Factor
            comp.SeverityOfVibration = cbSeverityVibration.Text;
            //Governing External Damage Factor
            comp.ComplexityProtrusion = cbComplexityProtrusion.Text;
            //Tank Consequence of Falure
            comp.ConcreteFoundation = chkConcreteAsphalt.Checked ? 1 : 0;
            comp.ShellHeight = txtShellHeight.Text != "" ? float.Parse(txtShellHeight.Text) : 0;
            comp.ReleasePreventionBarrier = chkPreventionBarrier.Checked ? 1 : 0;
            return comp;
        }

        public RW_INPUT_CA_TANK getDataforTank(int ID, string diameter)
        {
            RW_INPUT_CA_TANK tank = new RW_INPUT_CA_TANK();
            BUS_UNITS convUnit = new BUS_UNITS();
            tank.ID = ID;
            if (diameter == "MM") tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            else if (diameter == "INCH") tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? (float)(double.Parse(txtTankDiameter.Text) * convUnit.inch) : 0; // in sang mm
           //else tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text)  : 0; // m sang mm
            tank.ConcreteFoundation= chkConcreteAsphalt.Checked ? 1 : 0;
            tank.Prevention_Barrier = chkPreventionBarrier.Checked ? 1 : 0;
            tank.SHELL_COURSE_HEIGHT = txtShellHeight.Text != "" ? (float)(double.Parse(txtShellHeight.Text) ) : 0; // lay don vi m
            return tank;
        }
        private void addItemsBrinnellHardness()
        {
            cbMaxBrillnessHardness.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsBrinnellHardness.Length; i++)
            {
                cbMaxBrillnessHardness.Properties.Items.Add(itemsBrinnellHardness[i], i, i);
            }
        }
        #region Key Press Event

        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }

        private void txtTankDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtTankDiameter, e);
        }

        private void txtCurrentThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentThickness, e);
        }

        private void txtCurrentCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentCorrosionRate, e);
        }

        private void txtNominalThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalThickness, e);
        }

        private void txtMinRequiredThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinRequiredThickness, e);
        }
        #endregion

        #region Xu ly su kien data thay doi

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

        private void KeyPress1(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        private void txtTankDiameter_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtTankDiameter_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPress1(e);
        }
        #endregion

        private void label7_Click(object sender, EventArgs e)
        {
            if (label7.Text == "▼ Generic Properties")
            {
                panel1.Height = 198;
                label7.Text = "▶ Generic Properties";
                panel2.Top = panel1.Top + panel1.Height + 20;
                panel3.Top = panel2.Top + panel2.Height + 20;
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
            else if (label7.Text == "▶ Generic Properties")
            {
                panel1.Height = 21;
                label7.Text = "▼ Generic Properties";
                panel2.Top = panel1.Top + panel1.Height + 20;
                panel3.Top = panel2.Top + panel2.Height + 20;
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text == "▼ Governing External Damage Factor Properties")
            {
                panel2.Height = 64;
                label8.Text = "▶ Governing External Damage Factor Properties";
                panel3.Top = panel2.Top + panel2.Height + 20;
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
            else if (label8.Text == "▶ Governing External Damage Factor Properties")
            {
                panel2.Height = 21;
                label8.Text = "▼ Governing External Damage Factor Properties";
                panel3.Top = panel2.Top + panel2.Height + 20;
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (label9.Text == "▼ Governing Stress Corrosion Cracking Damage Factor Properties")
            {
                panel3.Height = 64;
                label9.Text = "▶ Governing Stress Corrosion Cracking Damage Factor Properties";
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
            else if (label9.Text == "▶ Governing Stress Corrosion Cracking Damage Factor Properties")
            {
                panel3.Height = 21;
                label9.Text = "▼ Governing Stress Corrosion Cracking Damage Factor Properties";
                panel4.Top = panel3.Top + panel3.Height + 20;
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (label13.Text == "▼ Governing Brittle Fracture Damage Factor Properties")
            {
                panel4.Height = 315;
                label13.Text = "▶ Governing Brittle Fracture Damage Factor Properties";
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
            else if (label13.Text == "▶ Governing Brittle Fracture Damage Factor Properties")
            {
                panel4.Height = 21;
                label13.Text = "▼ Governing Brittle Fracture Damage Factor Properties";
                panel5.Top = panel4.Top + panel4.Height + 20;
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
        }

        private void label40_Click(object sender, EventArgs e)
        {
            if (label40.Text == "▼ Governing Fatique Damage Factor Properties")
            {
                panel5.Height = 64;
                label40.Text = "▶ Governing Fatique Damage Factor Properties";
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
            else if (label40.Text == "▶ Governing Fatique Damage Factor Properties")
            {
                panel5.Height = 21;
                label40.Text = "▼ Governing Fatique Damage Factor Properties";
                panel6.Top = panel5.Top + panel5.Height + 20;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (label20.Text == "▼ Tank Consequence of Failure Properties")
            {
                panel6.Height = 109;
                label20.Text = "▶ Tank Consequence of Failure Properties";
            }
            else if (label20.Text == "▶ Tank Consequence of Failure Properties")
            {
                panel6.Height = 21;
                label20.Text = "▼ Tank Consequence of Failure Properties";
            }
        }
    }
}
