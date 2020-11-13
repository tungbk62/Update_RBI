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
    public partial class UCComponentProperties : UserControl
    {
        #region Parameter
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        string[] itemsCyclicLoading = { "None", "PRV chatter", "Reciprocating machinery", "Valve with high pressure drop" };
        string[] itemsBranchDiameter = { "Any branch less than or equal to 2\" Nominal OD", "All branches greater than 2\" Nominal OD" };
        string[] itemsBranchJointType = { "None", "Piping tee weldolets", "Saddle in fittings", "Sweepolets", "Threaded, socket welded, or saddle on" };
        string[] itemsNumberPipeFittings = { "More than 10", "6 to 10", "Up to 5" };
        string[] itemsPipeCondition = { "Broken gussets or gussets welded directly to pipe", "Good condition", "Missing or damage supports, improper support" };
        string[] itemsPreviousFailure = { "Greater than one", "None", "One" };
        string[] itemsAmountShaking = { "Minor", "Moderate", "Severe" };
        string[] itemsAccumulatedTimeShaking = { "13 to 52 weeks", "2 to 13 weeks", "Less than 2 weeks" };
        string[] itemsCorrectiveAction = { "Engineering Analysis", "Experience", "None" };
        string[] itemsConfidenceCorrosionRate = { "Low", "Medium", "High" };
        string[] itemsComplexityProtrusion = { "Above average", "Average", "Below average" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        #endregion

        public UCComponentProperties(int ID, string diameterUnit, string thicknessUnit, string corrosionRateUnit, string volumeUnit, string stressUnit)
        {
            InitializeComponent();
            panel1.Height = 21;
            panel2.Height = 21;
            panel3.Height = 21;
            panel4.Height = 21;
            panel5.Height = 21;
            panel6.Height = 21;
            panel7.Height = 21;
            panel1.Top = panel2.Top + panel2.Height + 13;
            panel3.Top = panel1.Top + panel1.Height + 13;
            panel4.Top = panel3.Top + panel3.Height + 13;
            panel5.Top = panel4.Top + panel4.Height + 13;
            panel6.Top = panel5.Top + panel5.Height + 13;
            panel7.Top = panel6.Top + panel6.Height + 13;
            additemsBrinnellHardness();
            additemsComplexityProtrusion();
            additemsCyclicLoading();
            additemsBranchDiameter();
            additemsBranchJointType();
            additemsNumberPipeFittings();
            additemsPipeCondition();
            additemsPreviousFailure();
            additemsAmountShaking();
            additemsAccumulatedTimeShaking();
            additemsCorrectiveAction();
            ShowDatatoControl(ID, diameterUnit, thicknessUnit, corrosionRateUnit, volumeUnit, stressUnit);
            lblNominalThickness.Text = lblMinReqThickness.Text = thicknessUnit;
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
            lblNominalThickness.Text = lblMinReqThickness.Text = lblMiniumMeasuredThickness.Text = lblBrittleFractureThickness.Text =lblStructuralThickness.Text = changeUnit;
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

        public void ShowDatatoControl(int ID, string diameter, string thickness, string corrosionRate, string volumeUnit, string stressUnit)
        {
            RW_COMPONENT_BUS comBus = new RW_COMPONENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            List<RW_COMPONENT> listComponent = comBus.getDataSource();
            foreach (RW_COMPONENT comp in listComponent)
            {
                if (comp.ID == ID)
                {
                    // mai
                    if (diameter == "INCH") txtNominalDiameter.Text = (comp.NominalDiameter / convUnit.inch).ToString(); // converst mm sang in
                    else if (diameter == "MM")txtNominalDiameter.Text = comp.NominalDiameter.ToString(); // giữ nguyên
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

                    txtWeldJointEfficiency.Text = comp.WeldJointEfficiency.ToString();

                    //// end mai
                    chkMinimumStructuralThicknessGoverns.Checked = comp.MinimumStructuralThicknessGoverns == 1 ? true : false;
                    chkPresenceCracks.Checked = comp.CracksPresent == 1 ? true : false;
                    txtDeltaFATT.Text = comp.DeltaFATT.ToString();
                    chkVisibleAudible.Checked = comp.ShakingDetected == 1 ? true : false;
                    chkFabricatedSteel.Checked = comp.FabricatedSteel == 1 ? true : false;
                    chkEquipmentSatisfied.Checked = comp.EquipmentSatisfied == 1 ? true : false;
                    chkNominalOperating.Checked = comp.NominalOperatingConditions == 1 ? true : false;
                    chkCETGreaterOrEqual.Checked = comp.CETGreaterOrEqual == 1 ? true : false;
                    chkCyclicServiceFatigueVibration.Checked = comp.CyclicServiceFatigueVibration == 1 ? true : false;
                    chkEquipmentCircuitShock.Checked = comp.EquipmentCircuitShock == 1 ? true : false;
                    chkHTHADamageObserved.Checked = comp.HTHADamageObserved == 1 ? true : false;

                    for (int i = 0; i < itemsConfidenceCorrosionRate.Length; i++)
                    {
                        if (comp.ConfidenceCorrosionRate == itemsConfidenceCorrosionRate[i])
                            cbConfidenceCorrosionRate.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsAccumulatedTimeShaking.Length; i++)
                    {
                        if (comp.ShakingTime == itemsAccumulatedTimeShaking[i])
                            cbAccumalatedTimeShakingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsCorrectiveAction.Length; i++)
                    {
                        if (comp.CorrectiveAction == itemsCorrectiveAction[i])
                            cbCorrectiveAction.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsCyclicLoading.Length; i++)
                    {
                        if (comp.CyclicLoadingWitin15_25m == itemsCyclicLoading[i])
                            cbCyclicLoading.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBranchDiameter.Length; i++)
                    {
                        if (comp.BranchDiameter == itemsBranchDiameter[i])
                            cbBranchDiameter.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBranchJointType.Length; i++)
                    {
                        if (comp.BranchJointType == itemsBranchJointType[i])
                            cbJointTypeBranch.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBrinnellHardness.Length; i++)
                    {
                        if (comp.BrinnelHardness == itemsBrinnellHardness[i])
                            cbMaxBrillnessHardness.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsNumberPipeFittings.Length; i++)
                    {
                        if (comp.NumberPipeFittings == itemsNumberPipeFittings[i])
                            cbNumberFittingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsPipeCondition.Length; i++)
                    {
                        if (comp.PipeCondition == itemsPipeCondition[i])
                            cbPipeCondition.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsPreviousFailure.Length; i++)
                    {
                        if (comp.PreviousFailures == itemsPreviousFailure[i])
                            cbPreviousFailures.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsAmountShaking.Length; i++)
                    {
                        if (comp.ShakingAmount == itemsAmountShaking[i])
                            cbAmountShakingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsComplexityProtrusion.Length; i++)
                    {
                        if (comp.ComplexityProtrusion == itemsComplexityProtrusion[i])
                            cbComplexityProtrusion.SelectedIndex = i + 1;
                    }
                }
            }
        }

        public RW_COMPONENT getData(int ID, string diameter, string thickness, string corrosionRate, string volumeUnit, string stressUnit) // save vao base
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            comp.ID = ID;
            // Generic Properties
            if (diameter == "MM")
            {
                comp.NominalDiameter = txtNominalDiameter.Text != "" ? float.Parse(txtNominalDiameter.Text) : 0;
            }
            else if (diameter == "INCH")
            {
                comp.NominalDiameter = txtNominalDiameter.Text != "" ? (float)(double.Parse(txtNominalDiameter.Text) * convUnit.inch) : 0; // in sang mm
            }
            if (thickness == "MM")
            {
                comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
                comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
                comp.BrittleFractureThickness = txtBrittleFractureThickness.Text != "" ? float.Parse(txtBrittleFractureThickness.Text) : 0;
                comp.StructuralThickness = txtStructuralThickness.Text != "" ? float.Parse(txtStructuralThickness.Text) : 0;
            }
            else if (thickness == "INCH")
            {
                comp.CurrentThickness = txtCurrentThickness.Text != "" ? (float)(double.Parse(txtCurrentThickness.Text) * convUnit.inch) : 0;
                comp.NominalThickness = txtNominalThickness.Text != "" ? (float)(double.Parse(txtNominalThickness.Text) * convUnit.inch) : 0; // in sang mm
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? (float)(double.Parse(txtMinRequiredThickness.Text) * convUnit.inch) : 0;// in sang mm
                comp.BrittleFractureThickness = txtBrittleFractureThickness.Text != "" ? (float)(double.Parse(txtBrittleFractureThickness.Text) * convUnit.inch) : 0;
                comp.StructuralThickness = txtStructuralThickness.Text != "" ? (float)(double.Parse(txtStructuralThickness.Text) * convUnit.inch) : 0;            
            }

            if (corrosionRate == "MMYR")
                comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)double.Parse(txtCurrentCorrosionRate.Text) : 0;
            else comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)(double.Parse(txtCurrentCorrosionRate.Text) * convUnit.mil) : 0; // mil/yr sang mm/yr
            if (volumeUnit == "M3")
                comp.ComponentVolume = txtComponentVolume.Text != "" ? float.Parse(txtComponentVolume.Text) : 0;
            else comp.ComponentVolume = txtComponentVolume.Text != "" ? (float)(double.Parse(txtComponentVolume.Text) * convUnit.ft3) : 0;
            if (stressUnit == "KSI")
                comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.ksi) : 0;
            else if (stressUnit == "PSI") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.psi) : 0;
            else if (stressUnit == "MPA") comp.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) : 0;
            else if (stressUnit == "BAR") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.bar) :0;
            else if (stressUnit == "NM2") comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.NpM2) :0;
            else comp.AllowableStress = txtAllowableStress.Text != "" ? (float)(double.Parse(txtAllowableStress.Text) * convUnit.NpCM2) : 0;
            comp.WeldJointEfficiency = txtWeldJointEfficiency.Text != "" ? float.Parse(txtWeldJointEfficiency.Text) : 0;
            comp.ConfidenceCorrosionRate = cbConfidenceCorrosionRate.Text;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;
            comp.MinimumStructuralThicknessGoverns = chkMinimumStructuralThicknessGoverns.Checked ? 1 : 0;
            //Governing Brittle Fracture Damage Factor
            comp.DeltaFATT = txtDeltaFATT.Text != "" ? float.Parse(txtDeltaFATT.Text) : 0;
            comp.FabricatedSteel = chkFabricatedSteel.Checked ? 1 : 0;
            comp.EquipmentSatisfied = chkEquipmentSatisfied.Checked ? 1 : 0;
            comp.NominalOperatingConditions = chkNominalOperating.Checked ? 1 : 0;
            comp.CETGreaterOrEqual = chkCETGreaterOrEqual.Checked ? 1 : 0;
            comp.CyclicServiceFatigueVibration = chkCyclicServiceFatigueVibration.Checked ? 1 : 0;
            comp.EquipmentCircuitShock = chkEquipmentCircuitShock.Checked ? 1 : 0;
            //High Temperatur Hydrogen Attack Damage Factor
            comp.HTHADamageObserved = chkHTHADamageObserved.Checked ? 1 : 0;
            //Governing Stress Corrosion Cracking Damage Factor
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            //Governing External Damage Factor
            comp.ComplexityProtrusion = cbComplexityProtrusion.Text;
            //Fatigue Damage Factor
            comp.BranchDiameter = cbBranchDiameter.Text;
            comp.BranchJointType = cbJointTypeBranch.Text;
            comp.CorrectiveAction = cbCorrectiveAction.Text;
            comp.CyclicLoadingWitin15_25m = cbCyclicLoading.Text;
            comp.NumberPipeFittings = cbNumberFittingPipe.Text;
            comp.PipeCondition = cbPipeCondition.Text;
            comp.PreviousFailures = cbPreviousFailures.Text;
            comp.ShakingAmount = cbAmountShakingPipe.Text;
            comp.ShakingDetected = chkVisibleAudible.Checked ? 1 : 0;
            comp.ShakingTime = cbAccumalatedTimeShakingPipe.Text;
            return comp;
        }

        #region Add Data to Combobox
        private void additemsBrinnellHardness()
        {
            cbMaxBrillnessHardness.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBrinnellHardness.Length; i++)
            {
                cbMaxBrillnessHardness.Properties.Items.Add(itemsBrinnellHardness[i], i, i);
            }
        }
        private void additemsComplexityProtrusion()
        {
            cbComplexityProtrusion.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsComplexityProtrusion.Length; i++)
            {
                cbComplexityProtrusion.Properties.Items.Add(itemsComplexityProtrusion[i], i, i);
            }
        }
        private void additemsCyclicLoading()
        {
            cbCyclicLoading.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsCyclicLoading.Length; i++)
            {
                cbCyclicLoading.Properties.Items.Add(itemsCyclicLoading[i], i, i);
            }
        }
        private void additemsBranchDiameter()
        {
            cbBranchDiameter.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBranchDiameter.Length; i++)
            {
                cbBranchDiameter.Properties.Items.Add(itemsBranchDiameter[i], i, i);
            }
        }

        private void additemsBranchJointType()
        {
            cbJointTypeBranch.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBranchJointType.Length; i++)
            {
                cbJointTypeBranch.Properties.Items.Add(itemsBranchJointType[i], i, i);
            }
        }
        private void additemsNumberPipeFittings()
        {
            cbNumberFittingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsNumberPipeFittings.Length; i++)
            {
                cbNumberFittingPipe.Properties.Items.Add(itemsNumberPipeFittings[i], i, i);
            }
        }
        private void additemsPipeCondition()
        {
            cbPipeCondition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPipeCondition.Length; i++)
            {
                cbPipeCondition.Properties.Items.Add(itemsPipeCondition[i], i, i);
            }
        }
        private void additemsPreviousFailure()
        {
            cbPreviousFailures.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPreviousFailure.Length; i++)
            {
                cbPreviousFailures.Properties.Items.Add(itemsPreviousFailure[i], i, i);
            }
        }
        private void additemsAmountShaking()
        {
            cbAmountShakingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmountShaking.Length; i++)
            {
                cbAmountShakingPipe.Properties.Items.Add(itemsAmountShaking[i], i, i);
            }
        }

        private void additemsAccumulatedTimeShaking()
        {
            cbAccumalatedTimeShakingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAccumulatedTimeShaking.Length; i++)
            {
                cbAccumalatedTimeShakingPipe.Properties.Items.Add(itemsAccumulatedTimeShaking[i], i, i);
            }
        }
        private void additemsCorrectiveAction()
        {
            cbCorrectiveAction.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsCorrectiveAction.Length; i++)
            {
                cbCorrectiveAction.Properties.Items.Add(itemsCorrectiveAction[i], i, i);
            }
        }
        #endregion

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
        private void txtNominalDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalDiameter, e);
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

        private void txtDeltaFATT_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDeltaFATT, e);
        }
        #endregion


        #region Xu ly su kien khi data thay doi
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
        private void txtNominalDiameter_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtNominalDiameter_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPress1(e);
        }
        #endregion

        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text == "▼ Generic Properties")
            {
                panel2.Height = 198;
                label8.Text = "▶ Generic Properties";
                panel1.Top = panel2.Top + panel2.Height + 13;
                panel3.Top = panel1.Top + panel1.Height + 13;
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;
            }
            else if (label8.Text == "▶ Generic Properties")
            {
                panel2.Height = 21;
                label8.Text = "▼ Generic Properties";
                panel1.Top = panel2.Top + panel2.Height + 13;
                panel3.Top = panel1.Top + panel1.Height + 13;
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (label9.Text == "▼ Governing Thinning Damage Factor Properties")
            {
                panel1.Height = 83;
                label9.Text = "▶ Governing Thinning Damage Factor Properties";
                panel3.Top = panel1.Top + panel1.Height + 13;
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;
            }
            else if (label9.Text == "▶ Governing Thinning Damage Factor Properties")
            {
                panel1.Height = 21;
                label9.Text = "▼ Governing Thinning Damage Factor Properties";
                panel3.Top = panel1.Top + panel1.Height + 13;
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;
            }


        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (label11.Text == "▼ Governing External Damage Factor Properties")
            {
                panel3.Height = 64;
                label11.Text = "▶ Governing External Damage Factor Properties";
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
            else if (label11.Text == "▶ Governing External Damage Factor Properties")
            {
                panel3.Height = 21;
                label11.Text = "▼ Governing External Damage Factor Properties";
                panel4.Top = panel3.Top + panel3.Height + 13;
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (label13.Text == "▼ Governing Stress Corrosion Cracking Damage Factor Properties")
            {
                panel4.Height = 64;
                label13.Text = "▶ Governing Stress Corrosion Cracking Damage Factor Properties";
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
            else 
            {
                panel4.Height = 21;
                label13.Text = "▼ Governing Stress Corrosion Cracking Damage Factor Properties";
                panel5.Top = panel4.Top + panel4.Height + 13;
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (label14.Text == "▼ High Temperature Hydrogen Attack Damage Factor Properties")
            {
                panel5.Height = 64;
                label14.Text = "▶ High Temperature Hydrogen Attack Damage Factor Properties";
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
            else 
            {
                panel5.Height = 21;
                label14.Text = "▼ High Temperature Hydrogen Attack Damage Factor Properties";
                panel6.Top = panel5.Top + panel5.Height + 13;
                panel7.Top = panel6.Top + panel6.Height + 13;

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (label7.Text == "▼ Governing Brittle Fracture Damage Factor Properties")
            {
                panel6.Height = 345;
                label7.Text = "▶ Governing Brittle Fracture Damage Factor Properties";
                panel7.Top = panel6.Top + panel6.Height + 13;
            }
            else if (label7.Text == "▶ Governing Brittle Fracture Damage Factor Properties")
            {
                panel6.Height = 21;
                label7.Text = "▼ Governing Brittle Fracture Damage Factor Properties";
                panel7.Top = panel6.Top + panel6.Height + 13;
            }
        }

        private void label40_Click(object sender, EventArgs e)
        {
            if (label40.Text == "▼ Fatique Damage Factor Properties")
            {
                panel7.Height = 289;
                label40.Text = "▶ Fatique Damage Factor Properties";
            }
            else if (label40.Text == "▶ Fatique Damage Factor Properties")
            {
                panel7.Height = 21;
                label40.Text = "▼ Fatique Damage Factor Properties";
            }
        }
    }
}
