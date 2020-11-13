using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using DevExpress.XtraSplashScreen;
using RBI.BUS.BUSMSSQL;
using RBI.PRE.subForm.InputDataForm;
using RBI.Object;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using RBI.BUS.BUSMSSQL_CAL;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCCorrosionRateTank : DevExpress.XtraEditors.XtraUserControl
    {
        public int Proposal_ID { get; set; }
        public UCCorrosionRateTank(int ID)
        {
            InitializeComponent();
            unitdata(showData(ID));
            //MessageBox.Show(ID.ToString());
            Proposal_ID = ID;
        }

        private RW_CORROSION_RATE_TANK getData(int row)
        {
            RW_CORROSION_RATE_TANK CorRate = new RW_CORROSION_RATE_TANK();
            RW_CORROSION_RATE_TANK_BUS busCorRate = new RW_CORROSION_RATE_TANK_BUS();
            GridColumn CorrosionID = gridView1.Columns[0]; //CorrosionID
            GridColumn SoilSideCorrosionRate = gridView1.Columns[1]; //"Soil Side Base Corrosion Rate"
            GridColumn ProductSideCorrosionRate = gridView1.Columns[2];//"Product Side Base Corrosion Rate"
            GridColumn PotentialCorrosion = gridView1.Columns[3];//"Potential Corrosion Activity(Resistivity)"
            GridColumn TankPadMaterial = gridView1.Columns[4];//"Tank Pad Meterial"
            GridColumn TankDrainageType = gridView1.Columns[5];//"Tank Drainage Type"
            GridColumn CathodicProtectionType = gridView1.Columns[6];//"Cathodic Protection Type"
            GridColumn TankBottomType = gridView1.Columns[7];//"Tank bottom Type"
            GridColumn SoilSideTemperature = gridView1.Columns[8];//"Tank bottom Type"
            GridColumn ProductCondition = gridView1.Columns[9];//"Product Side Condition"
            GridColumn ProductSideTemp = gridView1.Columns[10];//"Product Side Temperature"
            GridColumn SteamCoil = gridView1.Columns[11];//"Stram Coil";
            GridColumn WaterDrawOff = gridView1.Columns[12];//"Water Draw-off"
            GridColumn ProductSideBottom = gridView1.Columns[13];//"Product Side Bottom Corrosion"
            GridColumn ModifiedSoilSideCorrosionRate = gridView1.Columns[14];
            GridColumn ModifiedProductSideCorrosionRate = gridView1.Columns[15];
            GridColumn FinalEstimatedCorrosionRate = gridView1.Columns[16];
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            try
            {
                CorRate.CorrosionID = (int)gridView1.GetRowCellValue(row, CorrosionID);
            }
            catch
            {
                CorRate.CorrosionID = 0;
            }
            try
            {
                CorRate.SoilSideCorrosionRate = (float)gridView1.GetRowCellValue(row, SoilSideCorrosionRate);
            }
            catch
            {
                CorRate.SoilSideCorrosionRate = 0;
            }
            try
            {
                CorRate.ProductSideCorrosionRate = (float)gridView1.GetRowCellValue(row, ProductSideCorrosionRate);
            }
            catch
            {
                CorRate.ProductSideCorrosionRate = 0;
            }
            CorRate.PotentialCorrosion = gridView1.GetRowCellDisplayText(row, PotentialCorrosion).ToString();
            CorRate.TankPadMaterial = gridView1.GetRowCellDisplayText(row, TankPadMaterial).ToString();
            CorRate.TankDrainageType = gridView1.GetRowCellDisplayText(row, TankDrainageType).ToString();
            CorRate.CathodicProtectionType = gridView1.GetRowCellDisplayText(row, CathodicProtectionType).ToString();
            CorRate.TankBottomType = gridView1.GetRowCellDisplayText(row, TankBottomType).ToString();
            CorRate.SoilSideTemperature = gridView1.GetRowCellDisplayText(row, SoilSideTemperature).ToString();
            CorRate.ProductCondition = gridView1.GetRowCellDisplayText(row, ProductCondition).ToString();
            CorRate.ProductSideTemp = gridView1.GetRowCellDisplayText(row, ProductSideTemp).ToString();
            CorRate.SteamCoil = gridView1.GetRowCellDisplayText(row, SteamCoil).ToString();
            CorRate.WaterDrawOff = gridView1.GetRowCellDisplayText(row, WaterDrawOff).ToString();
            CorRate.ProductSideBottom = gridView1.GetRowCellDisplayText(row, ProductSideBottom).ToString();
            try
            {
                CorRate.ModifiedSoilSideCorrosionRate = (float)gridView1.GetRowCellValue(row, ModifiedSoilSideCorrosionRate);
            }
            catch
            {
                CorRate.ModifiedProductSideCorrosionRate = 0;
            }
            try
            {
                CorRate.ModifiedProductSideCorrosionRate = (float)gridView1.GetRowCellValue(row, ModifiedProductSideCorrosionRate);
            }
            catch
            {
                CorRate.ModifiedProductSideCorrosionRate = 0;
            }
            try
            {
                CorRate.FinalEstimatedCorrosionRate = (float)gridView1.GetRowCellValue(row, FinalEstimatedCorrosionRate);
            }
            catch
            {
                CorRate.FinalEstimatedCorrosionRate = 0;
            }
            
            return CorRate;
        }

        private List<RW_CORROSION_RATE_TANK> showData(int ID)
        {
            RW_CORROSION_RATE_TANK_BUS busConRate = new RW_CORROSION_RATE_TANK_BUS();
            List<RW_CORROSION_RATE_TANK> listConRate = busConRate.getDataSource(ID);
            List<RW_CORROSION_RATE_TANK> listdata = new List<RW_CORROSION_RATE_TANK>();
            foreach (RW_CORROSION_RATE_TANK ConRate in listConRate)
            {
                RW_CORROSION_RATE_TANK RwConRate = ConRate;
                listdata.Add(RwConRate);
            }
            return listdata;
        }

        public int LengthRow()
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            return selectedRowHandles.Length;
        }

        private void unitdata(List<RW_CORROSION_RATE_TANK> listdata)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            string[] header = {"CorrosionID","Soil Side Base Corrosion Rate", "Product Side Base Corrosion Rate", "Potential Corrosion Activity(Resistivity)", "Tank Pad Meterial", "Tank Drainage Type", "Cathodic Protection Type", "Tank bottom Type", "Soid Side Temperature", "Product Side Condition", "Product Side Temperature", "Stram Coil", "Water Draw-off", "Product Side Bottom Corrosion", "Modified Soil Side Corrosion Rate", "Modified Product Side Corrosion Rate", "Final Estimated Corrosion Rate" };
            try
            {
                gridControl1.DataSource = listdata;
                gridView1.Columns.Remove(gridView1.Columns["ID"]);
                //gridView1.Columns.Remove(gridView1.Columns["CorrosionID"]);
                for (int i = 0; i < header.Length; i++)
                {
                    gridView1.Columns[i].Caption = header[i];
                }
                //gridView1.BestFitColumns();

            }
            catch
            {
                // do nothing  
            }
            string[] PotentialCorrosion = new string[] { "Very Corrosive (<500 Ω-cm)" , "Corrosive (500-1000 Ω-cm)" , "Moderately Corrosive (1000-2000 Ω-cm)", "Mildly Corrosive (2000-10000 Ω-cm)", "Progressively Less Corrosive (>10000 Ω-cm)" };
            string[] TankPadMaterial = new string[] { "Soid With High Salt", "Crushed Limestone", "Native Soil", "Construction Grade Sand", "Continuous Asphalt", "Continuous Concrete", "Oil Sand", "High Resistivity Low Chloride Sand" };
            string[] TankDrainageType = new string[] { "One Third Frequently Underwater", "Storm Water Collects At AST Base", "Storm Water Does Not Collect At AST Base" };
            string[] CathodicProtectionType = new string[] { "None", "Yes Not Per API 651", "Yes Per API 651" };
            string[] TankBottomType = new string[] { "RPB Not Per API 650", "RPB Per API 650", "Single Bottom" };
            string[] SoilSideTemperature = new string[] { "Temp ≤ 24", "24< Temp ≤ 66","66 < Temp ≤ 93", "93 < Temp ≤ 121", "> 121" };
            string[] ProductCondition = new string[] { "Wet", "Dry" };
            string[] ProductSideTemp = new string[] { "Temp ≤ 24", "24< Temp ≤ 66", "66 < Temp ≤ 93", "93 < Temp ≤ 121", "> 121" };
            string[] SteamCoil = new string[] { "No", "Yes" };
            string[] WaterDrawOff = new string[] { "No", "Yes" };
            string[] ProductSideBottom = new string[] { "Localised","Widespread" };

            RepositoryItemComboBox riComboBox3 = new RepositoryItemComboBox();
            riComboBox3.Items.AddRange(PotentialCorrosion);
            gridControl1.RepositoryItems.Add(riComboBox3);
            gridView1.Columns[3].ColumnEdit = riComboBox3;

            RepositoryItemComboBox riComboBox4 = new RepositoryItemComboBox();
            riComboBox4.Items.AddRange(TankPadMaterial);
            gridControl1.RepositoryItems.Add(riComboBox4);
            gridView1.Columns[4].ColumnEdit = riComboBox4;

            RepositoryItemComboBox riComboBox5 = new RepositoryItemComboBox();
            riComboBox5.Items.AddRange(TankDrainageType);
            gridControl1.RepositoryItems.Add(riComboBox5);
            gridView1.Columns[5].ColumnEdit = riComboBox5;

            RepositoryItemComboBox riComboBox6= new RepositoryItemComboBox();
            riComboBox6.Items.AddRange(CathodicProtectionType);
            gridControl1.RepositoryItems.Add(riComboBox6);
            gridView1.Columns[6].ColumnEdit = riComboBox6;

            RepositoryItemComboBox riComboBox7 = new RepositoryItemComboBox();
            riComboBox7.Items.AddRange(TankBottomType);
            gridControl1.RepositoryItems.Add(riComboBox7);
            gridView1.Columns[7].ColumnEdit = riComboBox7;

            RepositoryItemComboBox riComboBox8 = new RepositoryItemComboBox();
            riComboBox8.Items.AddRange(SoilSideTemperature);
            gridControl1.RepositoryItems.Add(riComboBox8);
            gridView1.Columns[8].ColumnEdit = riComboBox8;

            RepositoryItemComboBox riComboBox9 = new RepositoryItemComboBox();
            riComboBox9.Items.AddRange(ProductCondition);
            gridControl1.RepositoryItems.Add(riComboBox9);
            gridView1.Columns[9].ColumnEdit = riComboBox9;

            RepositoryItemComboBox riComboBox10 = new RepositoryItemComboBox();
            riComboBox10.Items.AddRange(ProductSideTemp);
            gridControl1.RepositoryItems.Add(riComboBox10);
            gridView1.Columns[10].ColumnEdit = riComboBox10;

            RepositoryItemComboBox riComboBox11 = new RepositoryItemComboBox();
            riComboBox11.Items.AddRange(SteamCoil);
            gridControl1.RepositoryItems.Add(riComboBox11);
            gridView1.Columns[11].ColumnEdit = riComboBox11;

            RepositoryItemComboBox riComboBox12 = new RepositoryItemComboBox();
            riComboBox12.Items.AddRange(WaterDrawOff);
            gridControl1.RepositoryItems.Add(riComboBox12);
            gridView1.Columns[12].ColumnEdit = riComboBox12;

            RepositoryItemComboBox riComboBox13 = new RepositoryItemComboBox();
            riComboBox13.Items.AddRange(ProductSideBottom);
            gridControl1.RepositoryItems.Add(riComboBox13);
            gridView1.Columns[13].ColumnEdit = riComboBox13;
            SplashScreenManager.CloseForm();
        }

        #region Xu ly su kien Data thay doi
        private int datachange = 0;
        private int ctrlSpress = 0;
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }

        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }

        public int DataChange
        {
            get { return datachange; }
            set
            {
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        #endregion

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            RW_CORROSION_RATE_TANK_BUS busConRate = new RW_CORROSION_RATE_TANK_BUS();
            RW_CORROSION_RATE_TANK obj = new RW_CORROSION_RATE_TANK();
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            List<RW_ASSESSMENT> listAss = busAssessment.getDataSource();
            //int ID = listAss.Max(RW_ASSESSMENT => RW_ASSESSMENT.ID);
            obj.ID = Proposal_ID;
            busConRate.add(obj);
            unitdata(showData(Proposal_ID));
        }

        private void binDeleteRow_Click(object sender, EventArgs e)
        {
            GridColumn CorrosionID = gridView1.Columns[0];
            int[] selectedRowHandles = gridView1.GetSelectedRows();
         
            for(int i=0; i <= selectedRowHandles.Length + 1; i++)
            {
                var a = gridView1.GetRowCellValue(i, CorrosionID);
                MessageBox.Show(gridView1.GetRowCellDisplayText(i, CorrosionID).ToString());
            }    
            
        }

        private void btnCalculateCorrosionRate_Click(object sender, EventArgs e)
        {
            RW_CORROSION_RATE_TANK CorTank = new RW_CORROSION_RATE_TANK();
            Corrosion_Rate CorRate = new Corrosion_Rate();
            List<RW_CORROSION_RATE_TANK> list = new List<RW_CORROSION_RATE_TANK>();
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                CorTank = getData(i);
                CorRate.SoilSideCorrosionRate = CorTank.SoilSideCorrosionRate;
                CorRate.ProductSideCorrosionRate = CorTank.ProductSideCorrosionRate;
                CorRate.PotentialCorrosion = CorTank.PotentialCorrosion;
                CorRate.TankPadMaterial = CorTank.TankPadMaterial;
                CorRate.TankDrainageType = CorTank.TankDrainageType;
                CorRate.CathodicProtectionType = CorTank.CathodicProtectionType;
                CorRate.TankBottomType = CorTank.TankBottomType;
                CorRate.SoilSideTemperature = CorTank.SoilSideTemperature;
                CorRate.ProductCondition = CorTank.ProductCondition;
                CorRate.ProductSideTemp = CorTank.ProductSideTemp;
                CorRate.SteamCoil = CorTank.SteamCoil;
                CorRate.WaterDrawOff = CorTank.WaterDrawOff;
                CorRate.ProductSideBottom = CorTank.ProductSideBottom;
                CorRate.ModifiedSoilSideCorrosionRate = CorRate.CRS_Bottom();
                CorRate.ModifiedProductSideCorrosionRate = CorRate.CRP_Bottom();
                CorRate.FinalEstimatedCorrosionRate = CorRate.Final_CR();
                CorTank.ModifiedSoilSideCorrosionRate = CorRate.CRS_Bottom();
                CorTank.ModifiedProductSideCorrosionRate = CorRate.CRP_Bottom();
                CorTank.FinalEstimatedCorrosionRate = CorRate.Final_CR();
                //MessageBox.Show(CorTank.PotentialCorrosion.ToString());
                //MessageBox.Show("SR="+CorRate.F_SR().ToString()+" PA= "+CorRate.F_PA().ToString()+" ID="+CorRate.F_ID().ToString()+" CP="+CorRate.F_CP().ToString()+" TB="+CorRate.F_TB().ToString()+" ST="+CorRate.F_ST().ToString());
                Console.WriteLine(CorTank.SoilSideCorrosionRate);
                MessageBox.Show(CorTank.ModifiedSoilSideCorrosionRate.ToString() +"::"+ CorTank.ModifiedProductSideCorrosionRate.ToString() +"::"+ CorTank.FinalEstimatedCorrosionRate.ToString());
                list.Add(CorTank);
                Console.WriteLine("update ok");  
            }
            unitdata(list);
        }
        public void SaveDateCorrosinRate(){
            RW_CORROSION_RATE_TANK CorTank = new RW_CORROSION_RATE_TANK();
            RW_CORROSION_RATE_TANK_BUS busConRate = new RW_CORROSION_RATE_TANK_BUS();
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                CorTank = getData(i);
                MessageBox.Show(CorTank.SoilSideCorrosionRate.ToString());
                CorTank.ID = (float)Proposal_ID;
                MessageBox.Show(CorTank.ID.ToString());
                busConRate.edit(CorTank);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveDateCorrosinRate();
        }
    }
}
