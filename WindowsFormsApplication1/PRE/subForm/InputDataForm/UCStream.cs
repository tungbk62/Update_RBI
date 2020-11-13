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
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCStream : UserControl
    {

        string[] itemsExposureAmine = { "High Rich Amine", "Low Lean Amine", "None" };
        string[] itemsAmineSolutionComposition = { "Diethanolamine DEA", "Diglycolamine DGA", "Disopropanolamine DIPA", "Methyldiethanolamine MDEA", "Monoethanolamine MEA", "Sulfinol" };
        string[] itemsPhaseFluidStorage = { "Gas", "Liquid" };
        public UCStream()
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
            addIteamsPhaseFluidStorage();
        }
        public UCStream(int ID)
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
            addIteamsPhaseFluidStorage();
            ShowDatatoControl(ID);
        }
        public void ShowDatatoControl(int ID)
        {
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_STREAM obj = SteamBus.getData(ID);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++)
            {
                if (obj.AmineSolution == itemsAmineSolutionComposition[i])
                {
                    cbAmineSolutionComposition.SelectedIndex = i + 1;
                    break;
                }
            }
            chkAqueousPhaseDuringOperation.Checked = Convert.ToBoolean(obj.AqueousOperation);
            chkAqueousPhaseShutdown.Checked = Convert.ToBoolean(obj.AqueousShutdown);
            chkEnvironmentContainsCaustic.Checked = Convert.ToBoolean(obj.Caustic);
            txtChlorideIon.Text = obj.Chloride.ToString();
            txtCO3ConcentrationWater.Text = obj.CO3Concentration.ToString();
            chkPresenceCyanides.Checked = Convert.ToBoolean(obj.Cyanide);
            chkExposedAcidGas.Checked = Convert.ToBoolean(obj.ExposedToGasAmine);
            chkExposedSulphurBearing.Checked = Convert.ToBoolean(obj.ExposedToSulphur);
            for (int i = 0; i < itemsExposureAmine.Length; i++)
            {
                if (obj.ExposureToAmine == itemsExposureAmine[i])
                {
                    cbExposureAmine.SelectedIndex = i + 1;
                    break;
                }
            }
            chkEnviromentContainsH2S.Checked = Convert.ToBoolean(obj.H2S);
            txtH2SContentInWater.Text = obj.H2SInWater.ToString();
            chkProcessContainsHydrogen.Checked = Convert.ToBoolean(obj.Hydrogen);
            chkPresenceHydrofluoricAcid.Checked = Convert.ToBoolean(obj.Hydrofluoric);
            chkChlorine.Checked = Convert.ToBoolean(obj.MaterialExposedToClInt);
            txtNaOHConcentration.Text = obj.NaOHConcentration.ToString();
            txtpHWater.Text = obj.WaterpH.ToString();
            txbModelFluid.Text = obj.TankFluidName;
            txbToxicFluid.Text = obj.ToxicFluidName;
            cbPhaseFluidStorage.SelectItemByDescription(obj.StoragePhase);
            //cbPhaseFluidStorage.SelectedItem = 
        }
        public RW_STREAM getData(int ID)
        {
            RW_STREAM stream = new RW_STREAM();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            stream.ID = ID;
            stream.AmineSolution = cbAmineSolutionComposition.Text;
            stream.AqueousOperation = chkAqueousPhaseDuringOperation.Checked ? 1 : 0;
            stream.AqueousShutdown = chkAqueousPhaseShutdown.Checked ? 1 : 0;
            stream.Caustic = chkEnvironmentContainsCaustic.Checked ? 1 : 0;
            stream.Chloride = txtChlorideIon.Text != "" ? float.Parse(txtChlorideIon.Text) : 0;
            stream.CO3Concentration = txtCO3ConcentrationWater.Text != "" ? float.Parse(txtCO3ConcentrationWater.Text) : 0;
            stream.Cyanide = chkPresenceCyanides.Checked ? 1 : 0;
            stream.ExposedToGasAmine = chkExposedAcidGas.Checked ? 1 : 0;
            stream.ExposedToSulphur = chkExposedSulphurBearing.Checked ? 1 : 0;
            stream.ExposureToAmine = cbExposureAmine.Text;
            //stream.FlammableFluidID
            //stream.FlowRate 
            stream.H2S = chkEnviromentContainsH2S.Checked ? 1 : 0;
            stream.H2SInWater = txtH2SContentInWater.Text != "" ? float.Parse(txtH2SContentInWater.Text) : 0;
            stream.Hydrogen = chkProcessContainsHydrogen.Checked ? 1 : 0;
            //stream.H2SPartialPressure
            stream.Hydrofluoric = chkPresenceHydrofluoricAcid.Checked ? 1 : 0;
            stream.MaterialExposedToClInt = chkChlorine.Checked ? 1 : 0;
            //stream.MaxOperatingPressure
            //stream.MaxOperatingTemperature
            //stream.MinOperatingPressure
            //stream.MinOperatingTemperature
            //stream.CriticalExposureTemperature
            //stream.ModelFluidID
            stream.NaOHConcentration = txtNaOHConcentration.Text != "" ? float.Parse(txtNaOHConcentration.Text) : 0;
            //stream.NonFlameToxicFluidID = cbToxicFluid.Text;
            stream.StoragePhase = cbPhaseFluidStorage.Text;
            //stream.ToxicFluidID = 
            stream.WaterpH = txtpHWater.Text != "" ? float.Parse(txtpHWater.Text) : 0;
            stream.TankFluidName = txbModelFluid.Text;
            stream.ToxicFluidName = txbToxicFluid.Text;
            //stream.FluidHeight
            //stream.FluidLeaveDikePercent
            //stream.FluidLeaveDikeRemainOnSitePercent
            //stream.FluidGoOffSitePercent
            stream.ReleaseFluidPercentToxic = (float)numToxicFluidPercent.Value;
            return stream;
        }
        private void addItemsExposureAmine()
        {
            cbExposureAmine.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsExposureAmine.Length; i++)
            {
                cbExposureAmine.Properties.Items.Add(itemsExposureAmine[i], i, i);
            }
        }
        private void addItemsAmineSolutionComposition()
        {
            cbAmineSolutionComposition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++)
            {
                cbAmineSolutionComposition.Properties.Items.Add(itemsAmineSolutionComposition[i], i, i);
            }
        }
       private void addIteamsPhaseFluidStorage()
        {
            cbPhaseFluidStorage.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPhaseFluidStorage.Length; i++)
            {
                cbPhaseFluidStorage.Properties.Items.Add(itemsPhaseFluidStorage[i], i, i);
            }
        }

        #region KeyPress Event Handle
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

        private void txtNaOHConcentration_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNaOHConcentration, e);
        }

        private void txtChlorideIon_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtChlorideIon, e);
        }

        private void txtH2SContentInWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            keyPressEvent(txtH2SContentInWater, e);
        }


        private void txtCO3ConcentrationWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            keyPressEvent(txtCO3ConcentrationWater, e);
        }

        private void txtpHWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtpHWater, e);
        }
        #endregion

        private void txtNaOHConcentration_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            try
            {
                if(float.Parse(txtNaOHConcentration.Text) > 100)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNaOHConcentration.Text = "100";
                }
            }
            catch
            {
                txtNaOHConcentration.Text = "0";
            }
        }


        private void txtpHWater_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            try
            {
                if (float.Parse(txtpHWater.Text) > 14)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpHWater.Text = "14";
                }
            }
            catch
            {
                txtpHWater.Text = "0";
            }
        }

        #region Xu ly su kien khi data thay doi
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
        private void txtPrimaryFluid_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtPrimaryFluid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        #endregion

        #region Hidden Button
        private void lblGenericProperties_Click(object sender, EventArgs e)
        {
            if (lblGenericProperties.Text == "▼ Generic Properties")
            {
                pnlGenericProperties.Height = 156;
                lblGenericProperties.Text = "▶ Generic Properties";

                pnlStress.Top = pnlGenericProperties.Top + pnlGenericProperties.Height + 13;
                pnlHydrogen.Top = pnlStress.Top + pnlStress.Height + 13;
            }
            else if (lblGenericProperties.Text == "▶ Generic Properties")
            {
                pnlGenericProperties.Height = 21;
                lblGenericProperties.Text = "▼ Generic Properties";

                pnlStress.Top = pnlGenericProperties.Top + pnlGenericProperties.Height + 13;
                pnlHydrogen.Top = pnlStress.Top + pnlStress.Height + 13;
            }
        }

        private void lblStress_Click(object sender, EventArgs e)
        {
            if (lblStress.Text == "▼ Governing Stress Corosion Cracking Damahe Factor Properties")
            {
                pnlStress.Height = 264;
                lblStress.Text = "▶ Governing Stress Corosion Cracking Damahe Factor Properties";

                pnlHydrogen.Top = pnlStress.Top + pnlStress.Height + 13;
            }
            else if (lblStress.Text == "▶ Governing Stress Corosion Cracking Damahe Factor Properties")
            {
                pnlStress.Height = 21;
                lblStress.Text = "▼ Governing Stress Corosion Cracking Damahe Factor Properties";

                pnlHydrogen.Top = pnlStress.Top + pnlStress.Height + 13;
            }
        }

        private void lblHydrogen_Click(object sender, EventArgs e)
        {
            if (lblHydrogen.Text == "▼ Hight Temperature Hydrogen Attack Damage Factor Properties")
            {
                pnlHydrogen.Height = 62;
                lblHydrogen.Text = "▶ Hight Temperature Hydrogen Attack Damage Factor Properties";
            }
            else if (lblHydrogen.Text == "▶ Hight Temperature Hydrogen Attack Damage Factor Properties")
            {
                pnlHydrogen.Height = 21;
                lblHydrogen.Text = "▼ Hight Temperature Hydrogen Attack Damage Factor Properties";
            }
        }

        private void UCStream_Load(object sender, EventArgs e)
        {
            pnlGenericProperties.Height = 21;
            pnlStress.Top = pnlGenericProperties.Top + pnlGenericProperties.Height + 13;

            pnlStress.Height = 21;
            pnlHydrogen.Top = pnlStress.Top + pnlStress.Height + 13;

            pnlHydrogen.Height = 21;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Hide();
            frmModelFluid mf = new frmModelFluid();
            mf.ShowDialog();
            //this.Show();
            this.txbModelFluid.Text = mf.Representative_Fluid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txbModelFluid.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmToxicFluid mf = new frmToxicFluid();
            mf.ShowDialog();
            this.txbToxicFluid.Text = mf.Representative_Fluid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txbToxicFluid.Text = "";
        }
    }
}
