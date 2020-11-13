using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RBI.PRE.subForm.OutputDataForm.OutputPOF;
using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.OutputDataForm.OutputPOF
{
    
    public partial class frmDamageFactor : DevExpress.XtraEditors.XtraForm
    {
        private Control uc { get; set; }
        private string _nameUC {get; set;}
        public UCCarbonateCracking _ucCarbonate { get; private set; }
        public UCSulphideStressCracking ucSulphide { get; private set; }

        private int _idProposal;

        public frmDamageFactor()
        {
            InitializeComponent();
        }

        public frmDamageFactor(int ID, String Type)
        {
            InitializeComponent();
            _nameUC = Type;
            _idProposal = ID;
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            RW_ASSESSMENT ass = busAssessment.getData(ID);
            EQUIPMENT_MASTER_BUS equipmentMasterBus = new EQUIPMENT_MASTER_BUS();
            COMPONENT_MASTER_BUS comMaBus = new COMPONENT_MASTER_BUS();
            int[] equipmentID_componentID = busAssessment.getEquipmentID_ComponentID(ID);
            EQUIPMENT_MASTER eqMa = equipmentMasterBus.getData(equipmentID_componentID[0]);
            COMPONENT_MASTER comMa = comMaBus.getData(equipmentID_componentID[1]);
            txtAssName.Text = ass.ProposalName;
            txtCompoNumber.Text = comMa.ComponentNumber;
            txtEquipNumber.Text = eqMa.EquipmentNumber;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        UserControl abc; 
        private void frmDamageFactor_Load(object sender, EventArgs e)
        {
              
            flowLayoutPanel1.Controls.Clear();
            if (_nameUC == "UC_HF_Produced_HIC_SOHIC")
            {
                UC_HF_Produced_HIC_SOHIC uc = new UC_HF_Produced_HIC_SOHIC(_idProposal);
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UC_HIC_SOHIC_H2S")
            {
                UC_HIC_SOHIC_H2S uc = new UC_HIC_SOHIC_H2S();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCAmineStressCorrosionCracking")
            {
                UCAmineStressCorrosionCracking uc = new UCAmineStressCorrosionCracking();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCBrittleFracture")
            {
                UCBrittleFracture uc = new UCBrittleFracture();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCCarbonateCracking")
            {
                UCCarbonateCracking uc = new UCCarbonateCracking();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCCausticCracking")
            {
                UCCausticCracking uc = new UCCausticCracking();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCChlorideCracking")
            {
                UCChlorideCracking uc = new UCChlorideCracking();
                this.Width = uc.Width + 40;
                this.Width = uc.Width;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCExternalCLSCC")
            {
                UCExternalCLSCC uc = new UCExternalCLSCC();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCExternalCorrosion")
            {
                UCExternalCorrosion uc = new UCExternalCorrosion();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCExternalCUI_CLSCC")
            {
                UCExternalCUI_CLSCC uc = new UCExternalCUI_CLSCC();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCHydrogenStressCracking_HSC_HF_")
            {
                UCHydrogenStressCracking_HSC_HF_ uc = new UCHydrogenStressCracking_HSC_HF_();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCInternalLiningDegradation")
            {
                UCInternalLiningDegradation uc = new UCInternalLiningDegradation(_idProposal);
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCInternalThinning")
            {
                UCInternalThinning uc = new UCInternalThinning();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCPolythionicAcidCracking")
            {
                UCPolythionicAcidCracking uc = new UCPolythionicAcidCracking();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCSulphideStressCracking")
            {
                UCSulphideStressCracking uc = new UCSulphideStressCracking();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else if (_nameUC == "UCVibration_Induced_Mechanical_Fatigue")
            {
                UCVibration_Induced_Mechanical_Fatigue uc = new UCVibration_Induced_Mechanical_Fatigue();
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
            }
            else
            {
                lbHeader.Text = "Carbonate Cracking Damage Factor";
                lbSubHeader.Text = "Carbonate Cracking Damage Factor";
                UCCarbonateCracking uc = new UCCarbonateCracking(_idProposal);
                this.Width = uc.Width + 40;
                uc.Parent = flowLayoutPanel1;
                uc.Show();
                uc.Dock = DockStyle.Top;
                _ucCarbonate = uc;
            }
            
            //sidePanel1.Controls.Add( new UCInternalLiningDegradation());
          
        }
        
        private void btnTemporaryCalculate_Click(object sender, EventArgs e)
        {
            if (_nameUC == "UC_HF_Produced_HIC_SOHIC")
            {
                UC_HF_Produced_HIC_SOHIC uc = new UC_HF_Produced_HIC_SOHIC(_idProposal);
            }
            else if (_nameUC == "UC_HIC_SOHIC_H2S")
            {
                UC_HIC_SOHIC_H2S uc = new UC_HIC_SOHIC_H2S();
            }
            else if (_nameUC == "UCAmineStressCorrosionCracking")
            {
                UCAmineStressCorrosionCracking uc = new UCAmineStressCorrosionCracking();
            }
            else if (_nameUC == "UCBrittleFracture")
            {
                UCBrittleFracture uc = new UCBrittleFracture();
            }
            else if (_nameUC == "UCCarbonateCracking")
            {
                UCCarbonateCracking uc = new UCCarbonateCracking();
            }
            else if (_nameUC == "UCCausticCracking")
            {
                UCCausticCracking uc = new UCCausticCracking();
            }
            else if (_nameUC == "UCChlorideCracking")
            {
                UCChlorideCracking uc = new UCChlorideCracking();
            }
            else if (_nameUC == "UCExternalCLSCC")
            {
                UCExternalCLSCC uc = new UCExternalCLSCC();
            }
            else if (_nameUC == "UCExternalCorrosion")
            {
                UCExternalCorrosion uc = new UCExternalCorrosion();
            }
            else if (_nameUC == "UCExternalCUI_CLSCC")
            {
                UCExternalCUI_CLSCC uc = new UCExternalCUI_CLSCC();
            }
            else if (_nameUC == "UCHydrogenStressCracking_HSC_HF_")
            {
                UCHydrogenStressCracking_HSC_HF_ uc = new UCHydrogenStressCracking_HSC_HF_();
            }
            else if (_nameUC == "UCInternalLiningDegradation")
            {
                UCInternalLiningDegradation uc = new UCInternalLiningDegradation(_idProposal);
                uc.Calculate();
            }
            else if (_nameUC == "UCInternalThinning")
            {
                UCInternalThinning uc = new UCInternalThinning();
            }
            else if (_nameUC == "UCPolythionicAcidCracking")
            {
                UCPolythionicAcidCracking uc = new UCPolythionicAcidCracking();
            }
            else if (_nameUC == "UCSulphideStressCracking")
            {
                UCSulphideStressCracking uc = new UCSulphideStressCracking();
            }
            else if (_nameUC == "UCVibration_Induced_Mechanical_Fatigue")
            {
                UCVibration_Induced_Mechanical_Fatigue uc = new UCVibration_Induced_Mechanical_Fatigue();
            }
            else
            {
                _ucCarbonate.Calculate();
                MessageBox.Show("FAIL");
            }

        }
        
    }
}