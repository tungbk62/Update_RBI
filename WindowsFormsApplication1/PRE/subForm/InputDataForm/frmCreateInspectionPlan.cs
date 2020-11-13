using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmCreateInspectionPlan : Form
    {
        public frmCreateInspectionPlan()
        {
            InitializeComponent();
        }
        public bool ButtonSaveClicked { set; get; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPlanName.Text == "")
            {
                MessageBox.Show("Please enter Inspection Plan Name!", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (datePlanDate.Text == "")
                {
                    MessageBox.Show("Please enter Inspection Plan Date!", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    INSPECTION_PLAN ip = new INSPECTION_PLAN();
                    ip.InspPlanName = txtPlanName.Text;
                    ip.InspPlanDate = datePlanDate.DateTime;
                    INSPECTION_PLAN_BUS ipBus = new INSPECTION_PLAN_BUS();
                    List<INSPECTION_PLAN> listPlan = ipBus.getDataSource();
                    foreach (INSPECTION_PLAN ds in listPlan)
                    {
                        if (ds.InspPlanName == txtPlanName.Text)
                        {
                            MessageBox.Show("Plan Name already exist!", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                    ButtonSaveClicked = true;
                    ipBus.add(ip);
                    this.Close();
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateInspectionPlan_Load(object sender, EventArgs e)
        {
            txtPlanName.Text = "Plan "+ DateTime.Now;
        }

        
    }
    
}

