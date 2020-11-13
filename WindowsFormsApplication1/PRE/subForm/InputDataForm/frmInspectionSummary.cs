using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmInspectionSummary : Form
    {
        public String result { set; get; }
        public frmInspectionSummary()
        {
            InitializeComponent();
            radioGroup1.EditValue = 1;
            result = "";
        }

        private void lstMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstMethod.SelectedIndex)
            {
                case 0:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Crack Detection");
                    lstTechnique.Items.Add("Leak Detection");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 1:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("ACFM");
                    lstTechnique.Items.Add("Low frequency");
                    lstTechnique.Items.Add("Pulsed");
                    lstTechnique.Items.Add("Remote field");
                    lstTechnique.Items.Add("Standard (flat coil)");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 2:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Magnetic Fluorescent Inspection");
                    lstTechnique.Items.Add("Magnetic Flux Leakage");
                    lstTechnique.Items.Add("Magnetic Particle Inspection");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 3:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Hardness Surveys");
                    lstTechnique.Items.Add("Microstructure Replication");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 4:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("On-line Monitoring");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 5:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Liquid Penetrant Inspection");
                    lstTechnique.Items.Add("Penetrant Leak Detection");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 6:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Compton Scatter");
                    lstTechnique.Items.Add("Gamma Radiography");
                    lstTechnique.Items.Add("Real-time Radiography");
                    lstTechnique.Items.Add("X-Radiography");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 7:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Passive Thermography");
                    lstTechnique.Items.Add("Transient Thermography");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 8:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Advanced Ultrasonic Backscatter Technique");
                    lstTechnique.Items.Add("Angled Compression Wave");
                    lstTechnique.Items.Add("Angled Shear Wave");
                    lstTechnique.Items.Add("A-scan Thickness Survey");
                    lstTechnique.Items.Add("Chime");
                    lstTechnique.Items.Add("C-scan");
                    lstTechnique.Items.Add("Digital Ultrasonic Thickness Gauge");
                    lstTechnique.Items.Add("International Rotational Inspection System");
                    lstTechnique.Items.Add("Lorus");
                    lstTechnique.Items.Add("Surface Waves");
                    lstTechnique.Items.Add("Teletest");
                    lstTechnique.Items.Add("TOFD");
                    lstTechnique.SelectedIndex = 0;
                    break;
                case 9:
                    lstTechnique.Items.Clear();
                    lstTechnique.Items.Add("Endoscopy");
                    lstTechnique.Items.Add("Holiday Test");
                    lstTechnique.Items.Add("Hydrotesting");
                    lstTechnique.Items.Add("Naked Eye");
                    lstTechnique.Items.Add("Video");
                    lstTechnique.SelectedIndex = 0;
                    break;
            }
        }

        private void btnAddIspMethod_Click(object sender, EventArgs e)
        {
            INSPECTION_DETAIL_TECHNIQUE ipTech = new INSPECTION_DETAIL_TECHNIQUE();
            List<INSPECTION_DETAIL_TECHNIQUE> listNDT = new List<INSPECTION_DETAIL_TECHNIQUE>();
            string InspectionType = "Instrusive";
            if ((int)radioGroup1.EditValue == 0)
                InspectionType = "Non-Instrusive";
            string item = InspectionType + " + "
                + this.lstMethod.GetItemText(this.lstMethod.SelectedItem) + " + "
                + this.lstTechnique.GetItemText(this.lstTechnique.SelectedItem);

            //MessageBox.Show(item);
            ipTech.NDTMethod = item;
           // ButtonAddClicked = true;
            listNDT.Add(ipTech);
            gridControlMethod.DataSource = null;
            gridControlMethod.DataSource = listNDT;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(gridViewtab2.RowCount>0)
            {
                for (int i = 0; i < gridViewtab2.RowCount-1; i++)
                {
                    result+=gridViewtab2.GetRowCellValue(i, "NDTMethod").ToString()+ " - "+ gridViewtab2.GetRowCellValue(i, "Coverage").ToString() + " % AND ";
                   
                }
                result += gridViewtab2.GetRowCellValue(gridViewtab2.RowCount - 1, "NDTMethod").ToString() + gridViewtab2.GetRowCellValue(gridViewtab2.RowCount - 1, "Coverage").ToString() +" % ";

            }
            this.Close();
        }
    }
}
