using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RBI.BUS.BUSMSSQL;
using RBI.Object;
using RBI.Object.ObjectMSSQL;
using DevExpress.XtraGrid.Columns;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using RBI.PRE.subForm.OutputDataForm;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmInspectionPlanDetail : Form
    {
        String InspectionFinding = "";
        int _coverageID = 1;
        public int planid;
        List<INSPECTION_DETAIL_TECHNIQUE> listNDT = new List<INSPECTION_DETAIL_TECHNIQUE>();
      
        List<ProcessPlant> listPro = new List<ProcessPlant>();
        List<ProcessPlant> listProTank = new List<ProcessPlant>();
        public frmInspectionPlanDetail(int PlanID)
        {
            InitializeComponent();
            gridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            //gridView3.OptionsView.he
            planid = PlanID;
           // Display();
            
            //Displaytab2();
            radioGroup1.EditValue = 1;
            Showtab(PlanID);
            
            initCombox();
            gridview1(0,0,0);
            ShowGridview2(PlanID);
            showGridControlMethod();

        }

        public void Showtab(int PlanID)
        {
            try
            {
                INSPECTION_PLAN_BUS businsplan = new INSPECTION_PLAN_BUS();
                InspectionPlanName.Text = businsplan.getPlanName(PlanID);
                InspectionDate.Text = businsplan.getPlanDate(PlanID).ToString();
                
            }
            catch
            {
                // do nothing
            }
        }  
        public void ShowGridview2(int PlanID)
        {
            INSPECTION_COVERAGE_BUS ICB = new INSPECTION_COVERAGE_BUS();
            List<INSPECTION_COVERAGE> IC = ICB.getDataID(PlanID);
            List<DevExpress.XtraGrid.Views.Grid.GridView> GrV = new List<DevExpress.XtraGrid.Views.Grid.GridView>();
            GrV.Add(gridView2);
            GrV.Add(gridView3);
            foreach (DevExpress.XtraGrid.Views.Grid.GridView gridview in GrV)
            {
                int n = gridview.RowCount;
                foreach (INSPECTION_COVERAGE ic in IC)
                {
                    EQUIPMENT_MASTER_BUS EMB = new EQUIPMENT_MASTER_BUS();
                    //EMB.getEquipmentName(ic.EquipmentID);//lay ten equipment
                    COMPONENT_MASTER_BUS CMB = new COMPONENT_MASTER_BUS();

                    for (int i = 0; i < n; i++)
                    {
                        if (gridview.GetRowCellValue(i, "ComponentNumber").ToString() == CMB.getComponentNumber(ic.ComponentID) && gridview.GetRowCellValue(i, "EquipmentNumber").ToString() == EMB.getEquipmentNumber(ic.EquipmentID))
                        {
                            gridview.SelectRow(i);
                        }
                    }
                }
            }
            if (IC.Count > 0)
            {
                txtRemarks.Text = IC[0].Remarks;
                InspectionFinding = IC[0].Findings;
            }

        }

        private void BTnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            //do something
          // string obj = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "EquipmentNumber").ToString();
            //Lưu tab Process Plant trong tab inspection scope
            int[] numberselectGView2 = gridView2.GetSelectedRows();// tra ve chi so hang dc tick
            int[] numberselectGView3 = gridView3.GetSelectedRows();// tra ve chi so hang dc tick
            if (numberselectGView2.Length==0&& numberselectGView2.Length == 0)
            {
                MessageBox.Show("There is no damage mechanism selected","Inspection / Mitigation Planner", MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }
            else
            {
                if(gridViewtab2.RowCount==0)
                {
                    MessageBox.Show("There is no damage mechanism selected", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            string obj = null;
            INSPECTION_COVERAGE IC = new INSPECTION_COVERAGE();
            INSPECTION_COVERAGE_BUS ICB=new INSPECTION_COVERAGE_BUS();
            // xoa database de luu database moi
            List<int> IDInsCov = ICB.getIDbyPlanID(planid);//khoa ngoai cua INSPECTION_DETAIL_TECHNIQUE
            INSPECTION_DETAIL_TECHNIQUE_BUS Bus_insTech = new INSPECTION_DETAIL_TECHNIQUE_BUS();
            INSPECTION_COVERAGE_DETAIL_BUS insCoDeBus = new INSPECTION_COVERAGE_DETAIL_BUS();
            foreach (int i in IDInsCov)
            {

                Bus_insTech.deletebyCoverageID(i);
                insCoDeBus.deletebyCoverageID(i);
            }
            ICB.deletebyPlanID(planid);
            List<DevExpress.XtraGrid.Views.Grid.GridView> GrV = new List<DevExpress.XtraGrid.Views.Grid.GridView>();
            GrV.Add(gridView2);
            GrV.Add(gridView3);
            foreach (DevExpress.XtraGrid.Views.Grid.GridView gridview in GrV)
            {
                int[] a = gridview.GetSelectedRows();
                for (int i = 0; i < gridview.SelectedRowsCount; i++)//SelectedRowsCount: so luong hang dc tick
                {

                    IC.PlanID = planid;
                    EQUIPMENT_MASTER_BUS EMB = new EQUIPMENT_MASTER_BUS();
                    obj = gridview.GetRowCellValue(a[i], "EquipmentNumber").ToString();
                    IC.EquipmentID = EMB.getIDbyName(obj);
                    COMPONENT_MASTER_BUS CMB = new COMPONENT_MASTER_BUS();
                    obj = gridview.GetRowCellValue(a[i], "ComponentNumber").ToString();
                    IC.ComponentID = CMB.getIDbyName(obj);
                    IC.Remarks = txtRemarks.Text;
                    IC.Findings = InspectionFinding;
                    ICB.add(IC);

                }
            }
            //Lưu inspectionMethod
            List<String> imIteam = new List<String>();
            List<String> imType = new List<String>();
            List<String> inspectionType = new List<string>();
            List<int> converage = new List<int>();
            String NTDMethod = null, IMIteam = null, IMType = null, InspectionType = null;
            int tam = 0;
            for (int i = 0; i < gridViewtab2.RowCount; i++)
            {
                NTDMethod = gridViewtab2.GetRowCellValue(i, "NDTMethod").ToString();
                converage.Add((int)gridViewtab2.GetRowCellValue(i, "Coverage"));
                tam = 0;
                for (int j  = 0; j < NTDMethod.Length; j++)
                {
                    if (NTDMethod[j] == '+')
                    {

                        if (tam == 0)
                        {
                            
                           InspectionType = "";
                            for (int t = 0; t < j-1; t++)
                            {
                                InspectionType += NTDMethod[t];
                            }
                            tam = j + 2;
                            j++;
                            continue;
                        }
                        else
                        {
                            IMIteam = "";
                            for (int t = tam; t < j; t++)
                            {
                                IMIteam += NTDMethod[t];
                            }
                                
                            tam =j+ 2;
                            break;
                          
                        }
                    }
                }
                IMType = "";
                for (int t = tam; t < NTDMethod.Length; t++)
                {
                    IMType+= NTDMethod[t];
                }
            
                imIteam.Add(IMIteam);
                imType.Add(IMType);
                inspectionType.Add(InspectionType);

            }
            IM_ITEMS_BUS imIteamsBus = new IM_ITEMS_BUS();
            IM_TYPE_BUS imTypeBus = new IM_TYPE_BUS();
            
            INSPECTION_DETAIL_TECHNIQUE insTech = new INSPECTION_DETAIL_TECHNIQUE();
            IDInsCov = ICB.getIDbyPlanID(planid);//khoa ngoai cua INSPECTION_DETAIL_TECHNIQUE
            Bus_insTech = new INSPECTION_DETAIL_TECHNIQUE_BUS();
            foreach (int i in IDInsCov)
            {
               // insTech = null;
                insTech.CoverageID = i;
                for (int j = 0; j < imIteam.Count; j++)
                {
                    insTech.IMItemID = imIteamsBus.getData(imIteam[j]).IMItemID;
                    insTech.IMTypeID = imTypeBus.getData(imType[j]).IMTypeID;
                    insTech.InspectionType = (inspectionType[j] == "Instrusive") ? 0 : 1;
                    insTech.Coverage = converage[j];
                    Bus_insTech.add(insTech);
                }
                
            }
            //Luu tab Damage Mechanism va luu vao [RW_INSPECTION_DETAIL]
            INSPECTION_COVERAGE_DETAIL_BUS inCoDeBus = new INSPECTION_COVERAGE_DETAIL_BUS();
            INSPECTION_COVERAGE_DETAIL inCoDe = null;
            RW_INSPECTION_HISTORY_BUS rwInsHisBus = new RW_INSPECTION_HISTORY_BUS();
            RW_INSPECTION_DETAIL rwInsDe = null;
            INSPECTION_COVERAGE_BUS insCovBus = new INSPECTION_COVERAGE_BUS();
            INSPECTION_PLAN_BUS insPlanBus = new INSPECTION_PLAN_BUS();
            RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                inCoDe = new INSPECTION_COVERAGE_DETAIL();
                rwInsDe = new RW_INSPECTION_DETAIL();
                INSPECTION_COVERAGE_BUS inCoBus = new INSPECTION_COVERAGE_BUS();
                COMPONENT_MASTER_BUS comMasBus = new COMPONENT_MASTER_BUS();
                EQUIPMENT_MASTER_BUS EquipMasBus = new EQUIPMENT_MASTER_BUS();
                String EquipmentNumber = gridView1.GetRowCellValue(i, "EquipmentNumber").ToString();
                String ComponentNumber = gridView1.GetRowCellValue(i, "ComponentNumber").ToString();
                inCoDe.CoverageID = inCoBus.getIDbyEquipmentIDandComponentIDandPlanID(EquipMasBus.getIDbyNumber(EquipmentNumber), comMasBus.getIDbyName(ComponentNumber), planid);
                
                DM_ITEMS_BUS dmItemsBus = new DM_ITEMS_BUS();
                inCoDe.DMItemID = dmItemsBus.getDMIteamIDbyDMDescription(gridView1.GetRowCellValue(i, "DamageMechanism").ToString());
                
                inCoDe.EffectivenessCode= gridView1.GetRowCellValue(i, "InspectionEffectiveness").ToString();
                
                inCoDe.InspectionSummary= gridView1.GetRowCellValue(i, "InspectionSummary").ToString();
                
                INSPECTION_PLAN_BUS inPlanBus = new INSPECTION_PLAN_BUS();
                inCoDe.InspectionDate = inPlanBus.getPlanDate(planid);
                inCoDe.IsCarriedOut = 0;
                inCoDe.CarriedOutDate = inCoDe.InspectionDate;
                rwInsDe.Coverage_DetailID = inCoDe.CoverageID;
                rwInsDe.InspectionSummary = inCoDe.InspectionSummary;
                rwInsDe.EffectivenessCode = inCoDe.EffectivenessCode;
                rwInsDe.DMItemID = inCoDe.DMItemID;
                rwInsDe.InspectionDate = inCoDe.InspectionDate;
                rwInsDe.IsCarriedOut = inCoDe.IsCarriedOut;
                rwInsDe.CarriedOutDate = inCoDe.CarriedOutDate;
                rwInsDe.IsActive = 1;
                rwInsDe.EquipmentID=insCovBus.getEquipmentID(inCoDe.CoverageID);
                rwInsDe.ComponentID= insCovBus.getComponentID(inCoDe.CoverageID);
                rwInsDe.InspPlanName = insPlanBus.getPlanName(insCovBus.getPlanIDbyID(inCoDe.CoverageID));
                rwInsDe.ID = rwAssBus.getTopIDbyComponentID(rwInsDe.ComponentID);
                rwInsHisBus.add(rwInsDe);
                inCoDeBus.add(inCoDe);
            }
           
            MessageBox.Show("Inspection / Mitigation planning's have been updated!", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        #region tab Inspection Method
        public bool ButtonAddClicked { set; get; }

        private void btnAddIspMethod_Click(object sender, EventArgs e)
        {
            INSPECTION_DETAIL_TECHNIQUE ipTech = new INSPECTION_DETAIL_TECHNIQUE();
            IM_ITEMS_BUS imIteamsBus = new IM_ITEMS_BUS();
            IM_TYPE_BUS imTypeBus = new IM_TYPE_BUS();
            ipTech.IMItemID = imIteamsBus.getData(this.lstMethod.GetItemText(this.lstMethod.SelectedItem)).IMItemID;
            ipTech.IMTypeID = imTypeBus.getData(this.lstTechnique.GetItemText(this.lstTechnique.SelectedItem)).IMTypeID;
            if ((int)radioGroup1.EditValue == 1)
                ipTech.InspectionType = 1;
            else ipTech.InspectionType = 0;
            ipTech.Coverage = 0;
            ipTech.CoverageID = _coverageID;//ko ro
            INSPECTION_DETAIL_TECHNIQUE_BUS ipTechBus = new INSPECTION_DETAIL_TECHNIQUE_BUS();
            //List<INSPECTION_DETAIL_TECHNIQUE> listTech = ipTechBus.getDataSource();
            foreach (INSPECTION_DETAIL_TECHNIQUE ds in listNDT)
            {
                if (ds.IMTypeID == ipTech.IMTypeID && ds.IMItemID == ipTech.IMItemID && ds.InspectionType == ipTech.InspectionType)
                {
                    return;
                }
            }
            string InspectionType = "Instrusive";
            if ((int)radioGroup1.EditValue == 0)
                InspectionType  = "Non-Instrusive";
            string item = InspectionType + " + "
                + this.lstMethod.GetItemText(this.lstMethod.SelectedItem) + " + " 
                + this.lstTechnique.GetItemText(this.lstTechnique.SelectedItem);
            
            //MessageBox.Show(item);
            ipTech.NDTMethod = item;
            ButtonAddClicked = true;
            listNDT.Add(ipTech);
            gridControlMethod.DataSource = null;
            gridControlMethod.DataSource = listNDT;
           //gridViewtab2.AddNewRow();
            //gridViewtab2.SetRowCellValue(gridViewtab2.RowCount-1, "Coverate", 12);


        }
        private void showGridControlMethod()
        {
            try
            {
                gridControlMethod.DataSource = null;
                INSPECTION_DETAIL_TECHNIQUE insMe = null;
                List<INSPECTION_DETAIL_TECHNIQUE> listInsMe = new List<INSPECTION_DETAIL_TECHNIQUE>();
                INSPECTION_COVERAGE_BUS insCoBus = new INSPECTION_COVERAGE_BUS();
                if (insCoBus.getDataID(planid).Count == 0) return;
                int CoverageID = insCoBus.getDataID(planid)[0].ID;
                INSPECTION_DETAIL_TECHNIQUE_BUS busisp = new INSPECTION_DETAIL_TECHNIQUE_BUS();
                List<INSPECTION_DETAIL_TECHNIQUE> listInsDeTe = new List<INSPECTION_DETAIL_TECHNIQUE>();
                listInsDeTe = busisp.getDataSource(CoverageID);
                foreach (INSPECTION_DETAIL_TECHNIQUE i in listInsDeTe)
                {
                    insMe = new INSPECTION_DETAIL_TECHNIQUE();
                    insMe.IMItemID = i.IMItemID;
                    insMe.IMTypeID = i.IMTypeID;
                    if (i.InspectionType == 1)
                    {
                        insMe.NDTMethod = "Non-Intrusive + ";
                        insMe.CoverageID = 1;
                    }

                    else insMe.NDTMethod = "Intrusive + ";
                    IM_ITEMS_BUS imItemsBus = new IM_ITEMS_BUS();
                    insMe.NDTMethod += imItemsBus.getDataSourcebyIMItemID(i.IMItemID).IMDescription;
                    insMe.NDTMethod += " + ";
                    IM_TYPE_BUS imTypeBus = new IM_TYPE_BUS();
                    insMe.NDTMethod += imTypeBus.getDataSourcebyIMTypeID(i.IMTypeID).IMTypeName;
                    insMe.Coverage = i.Coverage;
                    listInsMe.Add(insMe);
                }
                gridControlMethod.DataSource = listInsMe;

                listNDT = new List<INSPECTION_DETAIL_TECHNIQUE>(listInsMe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void gridControlMethod_Load(object sender, EventArgs e)
        {
            
          
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
        private void getListProcessPlant()
        {
           
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            List<COMPONENT_MASTER> comMas = new List<COMPONENT_MASTER>();
            COMPONENT_MASTER_BUS comMasBus = new COMPONENT_MASTER_BUS();
            EQUIPMENT_MASTER_BUS buseq = new EQUIPMENT_MASTER_BUS();
            EQUIPMENT_TYPE_BUS eqType = new EQUIPMENT_TYPE_BUS();
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_TYPE__BUS comType = new COMPONENT_TYPE__BUS();
            DESIGN_CODE_BUS desCode = new DESIGN_CODE_BUS();
            SITES_BUS site =new SITES_BUS();
            FACILITY_BUS facility = new FACILITY_BUS();
            //EquipmentProperty
            RW_EQUIPMENT_BUS rwEqB=new RW_EQUIPMENT_BUS();
            RW_EQUIPMENT rwEq=new RW_EQUIPMENT();
            RW_COMPONENT_BUS rwComB = new RW_COMPONENT_BUS();
            RW_COMPONENT rwCom = new RW_COMPONENT();
            RW_STREAM_BUS rwStrB = new RW_STREAM_BUS();
            RW_STREAM rwStr = new RW_STREAM();
            RW_MATERIAL_BUS rwMaterB = new RW_MATERIAL_BUS();
            RW_MATERIAL rwMater = new RW_MATERIAL();
            RW_COATING_BUS rwCoatB = new RW_COATING_BUS();
            RW_COATING rwCoat = new RW_COATING();
            RW_FULL_POF_BUS rwFullPOFBus = new RW_FULL_POF_BUS();
            comMas = comMasBus.getDataSource();
            int EquipmentID = 0;
            int ComponentID = 0;
            foreach (COMPONENT_MASTER com in comMas)
            {
                RW_ASSESSMENT inspCove = busAssessment.getTopDatabyComponentID(com.ComponentID);
                if (inspCove != null)
                {
                    EquipmentID = inspCove.EquipmentID;
                    ComponentID = inspCove.ComponentID;
                    ProcessPlant Pro = new ProcessPlant();
                    if (buseq.getEquipmentTypeID(EquipmentID) != 11)//thiet bi thuong
                    {
                        Pro.EquipmentNumber = buseq.getEquipmentNumber(EquipmentID);
                        Pro.ComponentNumber = buscom.getComponentNumber(ComponentID);
                        Pro.Component = Pro.ComponentType = comType.getComponentTypeName(buscom.getComponentTypeID(ComponentID));
                        Pro.Site = site.getSiteName(buseq.getSiteID(EquipmentID));
                        Pro.Facility = facility.getFacilityName(buseq.getFacilityID(EquipmentID));
                        Pro.AP1 = rwFullPOFBus.getData(inspCove.ID).PoFAP1Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.AP2 = rwFullPOFBus.getData(inspCove.ID).PoFAP2Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.AP3 = rwFullPOFBus.getData(inspCove.ID).PoFAP3Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.RLI = rwFullPOFBus.getData(inspCove.ID).RLI.ToString();
                        Pro.AssessmentName = inspCove.ProposalName;
                        Pro.AssessmentDate = inspCove.AdoptedDate.ToShortDateString();
                        Pro.CommissionDate = buseq.getComissionDate(EquipmentID).ToShortDateString();
                        Pro.RiskAnalysisPeriod = inspCove.RiskAnalysisPeriod.ToString();
                        Pro.EquipmentType = eqType.getEquipmentTypeName(buseq.getEqTypeID(EquipmentID));
                        Pro.DesignCode = desCode.getDesignCodeName(buseq.getDesignCodeID(EquipmentID));
                        //EquipmentProperty
                        rwEq = rwEqB.getData(inspCove.ID);
                        Pro.AdministrativeControl = rwEq.AdminUpsetManagement == 1 ? "✔" : "✘";
                        Pro.ContainsDeadlegs = rwEq.ContainsDeadlegs == 1 ? "✔" : "✘";
                        Pro.PresenceofSulphidesOperation = rwEq.PresenceSulphidesO2 == 1 ? "✔" : "✘";
                        Pro.SteamedOut = rwEq.SteamOutWaterFlush == 1 ? "✔" : "✘";
                        Pro.ThermalHistory = rwEq.ThermalHistory;
                        Pro.SystemManagementFactor = rwEq.ManagementFactor.ToString();
                        Pro.PWHT = rwEq.PWHT == 1 ? "✔" : "✘";
                        Pro.PressurisarionControlledbyAdmin = rwEq.PressurisationControlled == 1 ? "✔" : "✘";
                        Pro.PresenceofSulphidesShutdown = rwEq.PresenceSulphidesO2Shutdown == 1 ? "✔" : "✘";
                        Pro.OnlineMonitoring = rwEq.OnlineMonitoring;
                        Pro.MinRequiredTemperature = rwEq.MinReqTemperaturePressurisation.ToString();
                        Pro.MaterialisExposedtoFluids = rwEq.MaterialExposedToClExt == 1 ? "✔" : "✘";
                        Pro.CyclicOperation = rwEq.CyclicOperation == 1 ? "✔" : "✘";
                        Pro.LinerOnlineMonitoring = rwEq.LinerOnlineMonitoring == 1 ? "✔" : "✘";
                        Pro.DowntimeProtectionUsed = rwEq.DowntimeProtectionUsed == 1 ? "✔" : "✘";
                        Pro.EquipmentisOperating = rwEq.YearLowestExpTemp == 1 ? "✔" : "✘";
                        Pro.EquipmentVolume = rwEq.Volume.ToString();
                        Pro.InterfaceatSoilorWater = rwEq.InterfaceSoilWater == 1 ? "✔" : "✘";
                        Pro.ExternalEnvironment = rwEq.ExternalEnvironment;
                        Pro.HeatTraced = rwEq.HeatTraced == 1 ? "✔" : "✘";
                        Pro.HighlyEffectiveInspection = rwEq.HighlyDeadlegInsp == 1 ? "✔" : "✘";
                        //componentProperty
                        rwCom = rwComB.getData(ComponentID);
                        Pro.MinimumMeasuredThickness = (100 * rwCom.CurrentThickness).ToString();
                        Pro.NominalThickness = (100 * rwCom.NominalThickness).ToString();
                        Pro.NominalDiameter = (100 * rwCom.NominalDiameter).ToString();
                        Pro.MinRequiredThickness = (100 * rwCom.MinReqThickness).ToString();
                        Pro.CurrentCorrosionRate = (100 * rwCom.CurrentCorrosionRate).ToString();
                        Pro.PresenceofCracks = rwCom.CracksPresent == 1 ? "✔" : "✘";
                        Pro.PreviousFailures = rwCom.PreviousFailures;
                        Pro.DamageFoundDuringInspection = rwCom.DamageFoundInspection == 1 ? "✔" : "✘";
                        Pro.PresenceofInjectionMixPoint = rwCom.ChemicalInjection == 1 ? "✔" : "✘";
                        Pro.HighlyEffectiveInspectionCom = rwCom.HighlyInjectionInsp == 1 ? "✔" : "✘";
                        // Pro.TrampElements=rwCom.tra//chua ro la dau vao nao
                        Pro.DeltaFATT = rwCom.DeltaFATT.ToString();
                        Pro.CyclicLoadingConnected = rwCom.CyclicLoadingWitin15_25m;
                        Pro.MaximumBrinnellHardness = rwCom.BrinnelHardness;
                        Pro.NumberofFitting = rwCom.NumberPipeFittings;
                        Pro.JointTypeofBranch = rwCom.BranchJointType;
                        Pro.PipeCondition = rwCom.PipeCondition;
                        Pro.VisibleorAudible = rwCom.ShakingDetected == 1 ? "✔" : "✘";
                        Pro.AccummlatedTimeShaking = rwCom.ShakingTime;
                        Pro.AmountofShaking = rwCom.ShakingAmount;
                        Pro.CorrectAction = rwCom.CorrectiveAction;
                        Pro.BranchDiameter = rwCom.BranchDiameter;
                        Pro.ComplexityofProtrusions = rwCom.ComplexityProtrusion;
                        //STREAM
                        rwStr = rwStrB.getData(inspCove.ID);
                        Pro.MaximumOperatingTemperature = rwStr.MaxOperatingTemperature.ToString();
                        Pro.MinimumOperatingTemperature = rwStr.MinOperatingTemperature.ToString();
                        Pro.MaximumOperatingPressure = rwStr.MaxOperatingPressure.ToString();
                        Pro.MinimumOperatingPressure = rwStr.MinOperatingPressure.ToString();
                        Pro.CriticalExposureTemperature = rwStr.CriticalExposureTemperature.ToString();
                        Pro.AmineSolutionComposition = rwStr.AmineSolution;
                        Pro.NAOHConcentration = rwStr.NaOHConcentration.ToString();
                        Pro.H2Scontent = rwStr.H2S.ToString();
                        Pro.MaterialFluidsMistsSolids = rwStr.MaterialExposedToClInt == 1 ? "✔" : "✘";
                        Pro.FlowRate = rwStr.FlowRate.ToString();
                        Pro.pHofWater = rwStr.WaterpH.ToString();
                        Pro.ToxicConsitituents = rwStr.ToxicConstituent == 1 ? "✔" : "✘";
                        Pro.ReleaseFluidPercentToxic = rwStr.ReleaseFluidPercentToxic.ToString();
                        Pro.ProcessContainsHydrogen = rwStr.Hydrogen == 1 ? "✔" : "✘";
                        Pro.PresenceofHydrofluoric = rwStr.Hydrofluoric == 1 ? "✔" : "✘";
                        Pro.ExposuretoAmine = rwStr.ExposureToAmine;
                        Pro.PresenceofCyanides = rwStr.Cyanide == 1 ? "✔" : "✘";
                        Pro.ExposuretoAmine = rwStr.ExposureToAmine;
                        Pro.PresenceofCyanides = rwStr.Cyanide == 1 ? "✔" : "✘";
                        Pro.OperatingHydrogenPartialPressure = rwStr.Hydrogen.ToString();//can check lai
                        Pro.ExposedSulphurBearing = rwStr.ExposedToSulphur == 1 ? "✔" : "✘";
                        Pro.ExposedAcidGas = rwStr.ExposedToGasAmine == 1 ? "✔" : "✘";
                        Pro.EnvironmentContainsH2S = rwStr.H2S == 1 ? "✔" : "✘";
                        Pro.EnvironmentContainsCaustic = rwStr.Caustic == 1 ? "✔" : "✘";
                        Pro.CO3Concentration = rwStr.CO3Concentration.ToString();
                        Pro.ChlorideIon = rwStr.Chloride.ToString();
                        Pro.AqueousPhaseDuringOper = rwStr.AqueousOperation == 1 ? "✔" : "✘";
                        Pro.AqueousPhaseDuringShut = rwStr.AqueousShutdown == 1 ? "✔" : "✘";
                        //Material
                        rwMater = rwMaterB.getData(inspCove.ID);
                        Pro.DesignPressure = rwMater.DesignTemperature.ToString();
                        Pro.AllowableStress = rwMater.AllowableStress.ToString();
                        Pro.DesignPressure = rwMater.DesignPressure.ToString();
                        Pro.SusceptibletoTemper = rwMater.Temper == 1 ? "✔" : "✘";
                        Pro.SulfurContent = rwMater.SulfurContent;
                        Pro.SigmaPhase = rwMater.SigmaPhase.ToString();
                        Pro.ReferenceTemperature = rwMater.ReferenceTemperature.ToString();
                        Pro.NickelAlloy = rwMater.NickelBased == 1 ? "✔" : "✘";
                        Pro.MaterialCostFactor = rwMater.CostFactor.ToString();
                        Pro.HeatTreatment = rwMater.HeatTreatment;
                        Pro.CorrosionAllowance = (rwMater.CorrosionAllowance * 100).ToString();
                        Pro.Chromium = rwMater.ChromeMoreEqual12 == 1 ? "✔" : "✘";
                        Pro.CacbonorLow = rwMater.CarbonLowAlloy == 1 ? "✔" : "✘";
                        Pro.AusteniticSteel = rwMater.Austenitic == 1 ? "✔" : "✘";
                        // Coating 
                        rwCoat = rwCoatB.getData(inspCove.ID);
                        Pro.InternalCoating = rwCoat.InternalCladding == 1 ? "✔" : "✘";
                        Pro.ExternalCoating = rwCoat.ExternalCoating == 1 ? "✔" : "✘";
                        Pro.ExternalCoatingInstallationDate = rwCoat.ExternalCoatingDate.ToShortDateString();
                        Pro.ExternalCoatingQuality = rwCoat.ExternalCoatingQuality;
                        Pro.SupportConfiguration = rwCoat.SupportConfigNotAllowCoatingMaint == 1 ? "✔" : "✘";
                        Pro.InternalLining = rwCoat.InternalLining == 1 ? "✔" : "✘";
                        Pro.InternalLinerType = rwCoat.InternalLinerType;
                        Pro.InternalLinerCondition = rwCoat.InternalLinerCondition;
                        Pro.InternalCladding = rwCoat.InternalCladding == 1 ? "✔" : "✘";
                        Pro.CladdingCorrosionRate = rwCoat.CladdingCorrosionRate.ToString();
                        Pro.ExternalInsulation = rwCoat.ExternalInsulation == 1 ? "✔" : "✘";
                        Pro.ExternalInsulationType = rwCoat.ExternalInsulationType;
                        Pro.InsulationCondition = rwCoat.InsulationCondition;
                        Pro.InsulationContainsChlorides = rwCoat.InsulationContainsChloride == 1 ? "✔" : "✘";
                        //  Pro.
                        listPro.Add(Pro);
                    }
                    else//thiet bi tank
                    {
                        Pro.EquipmentNumber = buseq.getEquipmentNumber(EquipmentID);
                        Pro.ComponentNumber = buscom.getComponentNumber(ComponentID);
                        Pro.Component = Pro.ComponentType = comType.getComponentTypeName(buscom.getComponentTypeID(ComponentID));
                        Pro.Site = site.getSiteName(buseq.getSiteID(EquipmentID));
                        Pro.Facility = facility.getFacilityName(buseq.getFacilityID(EquipmentID));
                        Pro.AP1 = rwFullPOFBus.getData(inspCove.ID).PoFAP1Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.AP2 = rwFullPOFBus.getData(inspCove.ID).PoFAP2Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.AP3 = rwFullPOFBus.getData(inspCove.ID).PoFAP3Category + rwFullPOFBus.getData(inspCove.ID).CoFCategory;
                        Pro.RLI = rwFullPOFBus.getData(inspCove.ID).RLI.ToString();
                        Pro.AssessmentName = inspCove.ProposalName;
                        Pro.AssessmentDate = inspCove.AdoptedDate.ToShortDateString();
                        Pro.CommissionDate = buseq.getComissionDate(EquipmentID).ToShortDateString();
                        Pro.RiskAnalysisPeriod = inspCove.RiskAnalysisPeriod.ToString();
                        Pro.EquipmentType = eqType.getEquipmentTypeName(buseq.getEqTypeID(EquipmentID));
                        Pro.DesignCode = desCode.getDesignCodeName(buseq.getDesignCodeID(EquipmentID));
                        //EquipmentProperty
                        rwEq = rwEqB.getData(inspCove.ID);
                        Pro.AdministrativeControl = rwEq.AdminUpsetManagement == 1 ? "✔" : "✘";
                        Pro.ContainsDeadlegs = rwEq.ContainsDeadlegs == 1 ? "✔" : "✘";
                        Pro.PresenceofSulphidesOperation = rwEq.PresenceSulphidesO2 == 1 ? "✔" : "✘";
                        Pro.SteamedOut = rwEq.SteamOutWaterFlush == 1 ? "✔" : "✘";
                        Pro.ThermalHistory = rwEq.ThermalHistory;
                        Pro.SystemManagementFactor = rwEq.ManagementFactor.ToString();
                        Pro.PWHT = rwEq.PWHT == 1 ? "✔" : "✘";
                        Pro.PressurisarionControlledbyAdmin = rwEq.PressurisationControlled == 1 ? "✔" : "✘";
                        Pro.PresenceofSulphidesShutdown = rwEq.PresenceSulphidesO2Shutdown == 1 ? "✔" : "✘";
                        Pro.OnlineMonitoring = rwEq.OnlineMonitoring;
                        Pro.MinRequiredTemperature = rwEq.MinReqTemperaturePressurisation.ToString();
                        Pro.MaterialisExposedtoFluids = rwEq.MaterialExposedToClExt == 1 ? "✔" : "✘";
                        Pro.CyclicOperation = rwEq.CyclicOperation == 1 ? "✔" : "✘";
                        Pro.LinerOnlineMonitoring = rwEq.LinerOnlineMonitoring == 1 ? "✔" : "✘";
                        Pro.DowntimeProtectionUsed = rwEq.DowntimeProtectionUsed == 1 ? "✔" : "✘";
                        Pro.EquipmentisOperating = rwEq.YearLowestExpTemp == 1 ? "✔" : "✘";
                        Pro.EquipmentVolume = rwEq.Volume.ToString();
                        Pro.InterfaceatSoilorWater = rwEq.InterfaceSoilWater == 1 ? "✔" : "✘";
                        Pro.ExternalEnvironment = rwEq.ExternalEnvironment;
                        Pro.HighlyEffectiveInspection = rwEq.HighlyDeadlegInsp == 1 ? "✔" : "✘";
                        Pro.TypeofSoil = rwEq.TypeOfSoil;
                        Pro.EnvironmentalSensitivity = rwEq.EnvironmentSensitivity;
                        Pro.DistanceToGroundWater = rwEq.DistanceToGroundWater.ToString();
                        //componentProperty
                        rwCom = rwComB.getData(ComponentID);
                        Pro.MinimumMeasuredThickness = (100 * rwCom.CurrentThickness).ToString();
                        Pro.NominalThickness = (100 * rwCom.NominalThickness).ToString();
                        Pro.NominalDiameter = (100 * rwCom.NominalDiameter).ToString();
                        Pro.MinRequiredThickness = (100 * rwCom.MinReqThickness).ToString();
                        Pro.CurrentCorrosionRate = (100 * rwCom.CurrentCorrosionRate).ToString();
                        Pro.PresenceofCracks = rwCom.CracksPresent == 1 ? "✔" : "✘";
                        Pro.DamageFoundDuringInspection = rwCom.DamageFoundInspection == 1 ? "✔" : "✘";
                        // Pro.TrampElements=rwCom.tra//chua ro la dau vao nao
                        Pro.DeltaFATT = rwCom.DeltaFATT.ToString();
                        Pro.MaximumBrinnellHardness = rwCom.BrinnelHardness;
                        Pro.ComplexityofProtrusions = rwCom.ComplexityProtrusion;
                        Pro.ReleasePreventionBarrier = rwCom.ReleasePreventionBarrier == 1 ? "✔" : "✘";
                        Pro.ShellHeight = rwCom.ShellHeight.ToString();
                        Pro.ConcreteorAsphaltFoundation = rwCom.ConcreteFoundation == 1 ? "✔" : "✘";
                        Pro.SeverityofVibration = rwCom.SeverityOfVibration;
                        //STREAM
                        rwStr = rwStrB.getData(inspCove.ID);
                        Pro.MaximumOperatingTemperature = rwStr.MaxOperatingTemperature.ToString();
                        Pro.MinimumOperatingTemperature = rwStr.MinOperatingTemperature.ToString();
                        Pro.MaximumOperatingPressure = rwStr.MaxOperatingPressure.ToString();
                        Pro.MinimumOperatingPressure = rwStr.MinOperatingPressure.ToString();
                        Pro.CriticalExposureTemperature = rwStr.CriticalExposureTemperature.ToString();
                        Pro.AmineSolutionComposition = rwStr.AmineSolution;
                        Pro.NAOHConcentration = rwStr.NaOHConcentration.ToString();
                        Pro.H2Scontent = rwStr.H2S.ToString();
                        Pro.MaterialFluidsMistsSolids = rwStr.MaterialExposedToClInt == 1 ? "✔" : "✘";
                        Pro.FlowRate = rwStr.FlowRate.ToString();
                        Pro.pHofWater = rwStr.WaterpH.ToString();
                        Pro.ToxicConsitituents = rwStr.ToxicConstituent == 1 ? "✔" : "✘";
                        Pro.ReleaseFluidPercentToxic = rwStr.ReleaseFluidPercentToxic.ToString();
                        Pro.ProcessContainsHydrogen = rwStr.Hydrogen == 1 ? "✔" : "✘";
                        Pro.PresenceofHydrofluoric = rwStr.Hydrofluoric == 1 ? "✔" : "✘";
                        Pro.ExposuretoAmine = rwStr.ExposureToAmine;
                        Pro.PresenceofCyanides = rwStr.Cyanide == 1 ? "✔" : "✘";
                        Pro.ExposuretoAmine = rwStr.ExposureToAmine;
                        Pro.PresenceofCyanides = rwStr.Cyanide == 1 ? "✔" : "✘";
                        Pro.OperatingHydrogenPartialPressure = rwStr.Hydrogen.ToString();//can check lai
                        Pro.ExposedSulphurBearing = rwStr.ExposedToSulphur == 1 ? "✔" : "✘";
                        Pro.ExposedAcidGas = rwStr.ExposedToGasAmine == 1 ? "✔" : "✘";
                        Pro.EnvironmentContainsH2S = rwStr.H2S == 1 ? "✔" : "✘";
                        Pro.EnvironmentContainsCaustic = rwStr.Caustic == 1 ? "✔" : "✘";
                        Pro.CO3Concentration = rwStr.CO3Concentration.ToString();
                        Pro.ChlorideIon = rwStr.Chloride.ToString();
                        Pro.AqueousPhaseDuringOper = rwStr.AqueousOperation == 1 ? "✔" : "✘";
                        Pro.AqueousPhaseDuringShut = rwStr.AqueousShutdown == 1 ? "✔" : "✘";
                        Pro.FluidHeight = rwStr.FluidHeight.ToString();
                        Pro.PercentageofFluidLeavingtheDike = rwStr.FluidLeaveDikePercent.ToString();
                        Pro.PercentageofFluidLeavingtheDikebutRemainsonSite = rwStr.FluidLeaveDikeRemainOnSitePercent.ToString();
                        Pro.PercentageofFluidGoingOffsite = rwStr.FluidGoOffSitePercent.ToString();
                        //Material
                        rwMater = rwMaterB.getData(inspCove.ID);
                        Pro.DesignPressure = rwMater.DesignTemperature.ToString();
                        Pro.AllowableStress = rwMater.AllowableStress.ToString();
                        Pro.DesignPressure = rwMater.DesignPressure.ToString();
                        Pro.SulfurContent = rwMater.SulfurContent;
                        Pro.ReferenceTemperature = rwMater.ReferenceTemperature.ToString();
                        Pro.NickelAlloy = rwMater.NickelBased == 1 ? "✔" : "✘";
                        Pro.MaterialCostFactor = rwMater.CostFactor.ToString();
                        Pro.HeatTreatment = rwMater.HeatTreatment;
                        Pro.CorrosionAllowance = (rwMater.CorrosionAllowance * 100).ToString();
                        Pro.Chromium = rwMater.ChromeMoreEqual12 == 1 ? "✔" : "✘";
                        Pro.CacbonorLow = rwMater.CarbonLowAlloy == 1 ? "✔" : "✘";
                        Pro.AusteniticSteel = rwMater.Austenitic == 1 ? "✔" : "✘";
                        // Coating 
                        rwCoat = rwCoatB.getData(inspCove.ID);
                        Pro.InternalCoating = rwCoat.InternalCladding == 1 ? "✔" : "✘";
                        Pro.ExternalCoating = rwCoat.ExternalCoating == 1 ? "✔" : "✘";
                        Pro.ExternalCoatingInstallationDate = rwCoat.ExternalCoatingDate.ToShortDateString();
                        Pro.ExternalCoatingQuality = rwCoat.ExternalCoatingQuality;
                        Pro.SupportConfiguration = rwCoat.SupportConfigNotAllowCoatingMaint == 1 ? "✔" : "✘";
                        Pro.InternalLining = rwCoat.InternalLining == 1 ? "✔" : "✘";
                        Pro.InternalLinerType = rwCoat.InternalLinerType;
                        Pro.InternalLinerCondition = rwCoat.InternalLinerCondition;
                        Pro.InternalCladding = rwCoat.InternalCladding == 1 ? "✔" : "✘";
                        Pro.CladdingCorrosionRate = rwCoat.CladdingCorrosionRate.ToString();
                        Pro.ExternalInsulation = rwCoat.ExternalInsulation == 1 ? "✔" : "✘";
                        Pro.ExternalInsulationType = rwCoat.ExternalInsulationType;
                        Pro.InsulationCondition = rwCoat.InsulationCondition;
                        Pro.InsulationContainsChlorides = rwCoat.InsulationContainsChloride == 1 ? "✔" : "✘";
                        listProTank.Add(Pro);
                    }
                }

            }
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl1.DataSource = listPro;
            gridControl2.DataSource = listProTank;
            //List<ProcessPlant> lISTPRO = listPro;
           // lISTPRO.AddRange(listPro);
            //List<ProcessPlant> LISTPROTANK = new List<ProcessPlant>(listProTank);
        }
      
        private List<RW_ASSESSMENT> getListAssessment(int EquipmentID)
        {
            List<RW_ASSESSMENT> listData = new List<RW_ASSESSMENT>();
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            List<RW_ASSESSMENT> assessment;
            if(EquipmentID == 0 ){
                assessment= busAssessment.getDataSource();
            }
            else
            {
                assessment = busAssessment.getDataSourceEquipmentID(EquipmentID);
            }
            EQUIPMENT_MASTER_BUS buseq = new EQUIPMENT_MASTER_BUS();
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_TYPE__BUS comType = new COMPONENT_TYPE__BUS();
            foreach (RW_ASSESSMENT inspCove in assessment)
            {
                RW_ASSESSMENT rwAssessment = inspCove;
                rwAssessment.EquipmentNumber = buseq.getEquipmentNumber(inspCove.EquipmentID);
                rwAssessment.ComponentName = buscom.getComponentName(inspCove.ComponentID);//khong can
                rwAssessment.ComponentNumber = buscom.getComponentNumber(inspCove.ComponentID);

                rwAssessment.ComponentType = comType.getComponentTypeName(buscom.getComponentTypeID(inspCove.ComponentID));
                listData.Add(rwAssessment);
            }

            return listData;
        }

        public void gridview1(int SiteID,int FavilityID, int EquipmentID)
        {
            gridControl1.DataSource = null;
            RW_ASSESSMENT_BUS busAss = new RW_ASSESSMENT_BUS();
            getListProcessPlant();
        }
        private void btnDelete_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //int a = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colInvisiableID);
           // INSPECTION_DETAIL_TECHNIQUE ip = new INSPECTION_DETAIL_TECHNIQUE();
            //ip.ID = a;
            //INSPECTION_DETAIL_TECHNIQUE_BUS busisp = new INSPECTION_DETAIL_TECHNIQUE_BUS();
            //busisp.delete(ip);
            //Displaytab2();
            listNDT.RemoveAt(gridViewtab2.FocusedRowHandle);
            gridControlMethod.DataSource = null;
            gridControlMethod.DataSource = listNDT;
        }
        private void GridViewtab2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region spinEdit in gridView
            INSPECTION_DETAIL_TECHNIQUE tech = new INSPECTION_DETAIL_TECHNIQUE();
            //tech.ID = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colInvisiableID);
            tech.CoverageID = _coverageID;
            //tech.IMItemID = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colInvisiableTechnique);
            //tech.IMTypeID = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colInvisiableTypeMethod);
            //tech.InspectionType = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colInvisiableIspType);
            tech.Coverage = (int)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colCoverage);
            tech.NDTMethod = (String)gridViewtab2.GetRowCellValue(gridViewtab2.FocusedRowHandle, colNDT);
            INSPECTION_DETAIL_TECHNIQUE_BUS busisp = new INSPECTION_DETAIL_TECHNIQUE_BUS();
            busisp.edit(tech);
            #endregion
            //#region cột NDT
            /*if ((int)gridViewtab2.GetFocusedRowCellValue(colInvisiableIspType) == 1)
                {
                chuoi1 = "Intrusive + ";
                }
            else chuoi1 = "Non-Intrusive + ";
            gridViewtab2.SetFocusedRowCellValue(colNDT, chuoi1);
            int a = (int)gridViewtab2.GetFocusedRowCellValue(colInvisiableTypeMethod);
            gridViewtab2.SetFocusedRowCellValue(colNDT, a);
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != "IMItemID" && e.Column.FieldName != "InspectionType") return;
            int test = int.Parse(view.GetRowCellValue(e.RowHandle, "IMItemID").ToString()) 
            + int.Parse(view.GetRowCellValue(e.RowHandle, "InspectionType").ToString())*1000;
            view.SetRowCellValue(e.RowHandle, "ndt", test);*/
            /*GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.Caption != "Technique") return;
            string cellValue = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns["IspType"]).ToString();
            view.SetRowCellValue(e.RowHandle, view.Columns["NDT Method"], cellValue);
            #endregion*/
        }
        private void Displaytab2() // dự tính bỏ function này thay bằng gridControlMethod_Load
        {
            try
            {
                //gridControlMethod.DataSource = null;
                //INSPECTION_DETAIL_TECHNIQUE_BUS busisp = new INSPECTION_DETAIL_TECHNIQUE_BUS();
                //RW_ASSESSMENT_BUS busisp = new RW_ASSESSMENT_BUS();
                //gridControlMethod.DataSource = busisp.getDataSource();
                //gridViewtab2.SetRowCellValue(2, 1, "aaa");
                //gridControlMethod.DataSource = listDetail;
                //gridViewtab2.AddNewRow();
                //DataRow dt = new DataRow();
                List<INSPECTION_DETAIL_TECHNIQUE> list= new List<INSPECTION_DETAIL_TECHNIQUE>();
                INSPECTION_DETAIL_TECHNIQUE ins = new INSPECTION_DETAIL_TECHNIQUE();
                ins.NDTMethod = "aaa";
                ins.Coverage = 12;
                list.Add(ins);
                gridControlMethod.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddListData(String NDT)
        {
            //List<INSPECTION_DETAIL_TECHNIQUE> list = new List<INSPECTION_DETAIL_TECHNIQUE>();
            //list = obj;
            INSPECTION_DETAIL_TECHNIQUE ins = new INSPECTION_DETAIL_TECHNIQUE();
            ins.NDTMethod = NDT;
            //ins.Coverage = 12;
            listNDT.Add(ins);
            //return list;
        }

        #endregion
        #region test
        private void frmInspectionPlanDetail_Load(object sender, EventArgs e)
        {
            lstMethod.SelectedIndex = 0;
        }
        public bool ButtonSelectClicked { set; get; }
        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonSelectClicked = true;
            this.Close();
        }
        private void DisplayDamagemachanism()
        {
            int[] listDMItemIDhasRule = { 8, 9, 32,34,57,60,61,62,63,66,67,69,70,72,73 };
            try
            {

                Damage_Mechanism DaMe = null;
                List<Damage_Mechanism> listDaMe = new List<Damage_Mechanism>();
                
                RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
                RW_DAMAGE_MECHANISM_BUS rwDaMeBus = new RW_DAMAGE_MECHANISM_BUS();
                INSPECTION_DM_RULE_BUS insDMRuleBus = new INSPECTION_DM_RULE_BUS();
                DM_ITEMS_BUS dmItemsBus = new DM_ITEMS_BUS();
                List<int> listIMItemID = new List<int>();
                List<int> listIMTypeID = new List<int>();
                List<String> listNDTMethod = new List<String>();
                List<int> listCoverage = new List<int>();
                List<DevExpress.XtraGrid.Views.Grid.GridView> GrV = new List<DevExpress.XtraGrid.Views.Grid.GridView>();
               GrV.Add(gridView2);
                GrV.Add(gridView3);
                foreach (DevExpress.XtraGrid.Views.Grid.GridView gridview in GrV)
                {
                    int[] a = gridview.GetSelectedRows();
                    for (int i = 0; i < gridview.SelectedRowsCount; i++)
                    {
                        DaMe = new Damage_Mechanism();
                        DaMe.EquipmentNumber = gridview.GetRowCellValue(a[i], "EquipmentNumber").ToString();
                        DaMe.ComponentNumber = gridview.GetRowCellValue(a[i], "ComponentNumber").ToString();
                        COMPONENT_MASTER_BUS CMB = new COMPONENT_MASTER_BUS();

                        for (int j = 0; j < listDMItemIDhasRule.Length; j++)
                        {
                            if (rwDaMeBus.checkIsDF(rwAssBus.getTopIDbyComponentID(CMB.getIDbyName(DaMe.ComponentNumber)), listDMItemIDhasRule[j]) == true)//co ton tai yeu to DM nay
                            {
                                //ktra inspection_DM_Rule
                                foreach (INSPECTION_DETAIL_TECHNIQUE insDeTe in listNDT)
                                {

                                    foreach (int DMItemID in insDMRuleBus.getDMItemID(insDeTe.IMItemID, insDeTe.IMTypeID))
                                    {
                                        if (DMItemID == listDMItemIDhasRule[j])
                                        {
                                            listIMItemID.Add(insDeTe.IMItemID);
                                            listIMTypeID.Add(insDeTe.IMTypeID);
                                            listNDTMethod.Add(insDeTe.NDTMethod);
                                            listCoverage.Add(insDeTe.Coverage);
                                        }
                                    }
                                }
                                if (listIMItemID.Count != 0)
                                {
                                    Damage_Mechanism dame_copy = null;

                                    DaMe.DamageMechanism = dmItemsBus.getDMDescriptionbyDMItemID(listDMItemIDhasRule[j]);
                                    DaMe.InspectionSummary = "";
                                    DaMe.InspectionEffectiveness = "E";
                                    for (int t = 0; t < listIMItemID.Count - 1; t++)
                                    {
                                        DaMe.InspectionSummary += listNDTMethod[t] + " - ";
                                        DaMe.InspectionSummary += listCoverage[t] + " %\n";
                                        DaMe.InspectionSummary += "AND\n";
                                    }
                                    DaMe.InspectionSummary += listNDTMethod[listIMItemID.Count - 1] + " - ";
                                    DaMe.InspectionSummary += listCoverage[listIMItemID.Count - 1] + " % ";

                                    // DaMe.InspectionSummary += listCoverage[listIMItemID.Count-1];
                                    //kiem tra xem InspectionEffectiveness co trong database chua?
                                    dame_copy = new Damage_Mechanism();
                                    dame_copy.EquipmentNumber = DaMe.EquipmentNumber;
                                    dame_copy.ComponentNumber = DaMe.ComponentNumber;
                                    dame_copy.DamageMechanism = DaMe.DamageMechanism;
                                    dame_copy.InspectionSummary = DaMe.InspectionSummary;
                                    //dame_copy.InspectionEffectiveness = DaMe.InspectionEffectiveness;
                                    INSPECTION_COVERAGE_BUS inCoBus = new INSPECTION_COVERAGE_BUS();
                                    COMPONENT_MASTER_BUS comMasBus = new COMPONENT_MASTER_BUS();
                                    EQUIPMENT_MASTER_BUS EquipMasBus = new EQUIPMENT_MASTER_BUS();
                                    int coverageID = inCoBus.getIDbyEquipmentIDandComponentIDandPlanID(EquipMasBus.getIDbyNumber(DaMe.EquipmentNumber), comMasBus.getIDbyName(DaMe.ComponentNumber), planid);
                                    INSPECTION_COVERAGE_DETAIL_BUS inCoDeBus = new INSPECTION_COVERAGE_DETAIL_BUS();
                                    dame_copy.InspectionEffectiveness = inCoDeBus.getEffectivenessCodebyCoverageIDandDMItemID(coverageID, listDMItemIDhasRule[j]);
                                    listDaMe.Add(dame_copy);
                                }

                                listIMItemID.Clear();
                                listIMTypeID.Clear();
                                listNDTMethod.Clear();
                                listCoverage.Clear();

                            }
                        }


                    }
                }
                //
                gridControl3.DataSource = null;
                gridControl3.DataSource = listDaMe;
                //hient thi clolumn INSPECTION_EFFECTIVENESS
                List<INSPECTION_EFFECTIVENESS> list_ins_eff = new List<INSPECTION_EFFECTIVENESS>();
                list_ins_eff.Add(new INSPECTION_EFFECTIVENESS("A","Highly Effective"));
                list_ins_eff.Add(new INSPECTION_EFFECTIVENESS("B","Usually Effective"));
                list_ins_eff.Add(new INSPECTION_EFFECTIVENESS("C", "Fairly Effective"));
                list_ins_eff.Add(new INSPECTION_EFFECTIVENESS("D", "Poorly Effective"));
                list_ins_eff.Add(new INSPECTION_EFFECTIVENESS("E", "Ineffective Effective"));
                repositoryItemGridLookUpEditInspectionEffectivess.DataSource = list_ins_eff;
                repositoryItemGridLookUpEditInspectionEffectivess.ValueMember = "EffectivenessCode";
                repositoryItemGridLookUpEditInspectionEffectivess.DisplayMember = "EffectivenessCode";
                //colInspectionEffectiveness.
                
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion
        #region Combobox
        private void initCombox()
        {
            additemsSite();
        }
        private void additemsSite()
        {   
            
            SITES_BUS busSite = new SITES_BUS();
            List<SITES> listitemsSite = busSite.getData();
            int index = 0;
            cbSite.Properties.Items.Add("<ALL>", -1, -1);
            
            for (int i = 0; i < listitemsSite.Count; i++)
            {
                cbSite.Properties.Items.Add(listitemsSite[i].SiteName, i, i);
                index = i;
            }
            cbSite.SelectedIndex = 0;            
        }

        private void additemsFacility()
        {
            cbFacility.Properties.Items.Add("<ALL>", -1, -1);
            cbFacility.SelectedIndex = 0;
            int SIteID = 0;
            if (cbSite.Text == "<ALL>")
            {
                SIteID = 0;
            }
            else
            {
                SITES_BUS busSite = new SITES_BUS();
                SIteID = busSite.getIDbyName(cbSite.Text);
            }
            FACILITY_BUS busFaci = new FACILITY_BUS();
            List<string> listitemsFaci = busFaci.getListFacilityName(SIteID);
            for (int i = 0; i < listitemsFaci.Count; i++)
            {
                cbFacility.Properties.Items.Add(listitemsFaci[i], i, i);
            }
        }
        private List<ProcessPlant> refressBySite (string site)//nomal
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            foreach (ProcessPlant i in listPro)
            {
                if (i.Site == site)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private List<ProcessPlant> refressTankBySite(string site)
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            foreach (ProcessPlant i in listProTank)
            {
                if (i.Site == site)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private List<ProcessPlant> refressBySiteAndFacility(string site,string facility)
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            List<ProcessPlant> PRO2=refressBySite(site);
            foreach (ProcessPlant i in PRO2)
            {
                if (i.Facility == facility)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private List<ProcessPlant> refressTankBySiteAndFacility(string site, string facility)
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            List<ProcessPlant> PRO2 = refressTankBySite(site);
            foreach (ProcessPlant i in PRO2)
            {
                if (i.Facility == facility)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private List<ProcessPlant> refressBySiteAndFacilityAndEquipment(string site, string facility, string equipment)
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            List<ProcessPlant> PRO2 = refressBySiteAndFacility(site, facility);
            foreach (ProcessPlant i in PRO2)
            {
                if (i.EquipmentNumber == equipment)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private List<ProcessPlant> refressTankBySiteAndFacilityAndEquipment(string site, string facility,string equipment)
        {
            List<ProcessPlant> pro = new List<ProcessPlant>();
            List<ProcessPlant> PRO2 = refressTankBySiteAndFacility(site, facility);
            foreach (ProcessPlant i in PRO2)
            {
                if (i.EquipmentNumber == equipment)
                {
                    pro.Add(i);
                }
            }
            return pro;
        }
        private void cbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ImageComboBoxEdit cb = sender as DevExpress.XtraEditors.ImageComboBoxEdit;
            cbFacility.Properties.Items.Clear();
            cbEquipment.Properties.Items.Clear();
            additemsFacility();
            additemsEquipment();
            if (cb.Text != "<ALL>")
            {
               
                SITES_BUS busSite = new SITES_BUS();
                FACILITY_BUS busFacility = new FACILITY_BUS();
                EQUIPMENT_MASTER_BUS busEquipment = new EQUIPMENT_MASTER_BUS();
                gridControl1.DataSource = refressBySite(cb.SelectedItem.ToString());
                gridControl2.DataSource = refressTankBySite(cb.SelectedItem.ToString());
            }
            else
            {
                gridControl1.DataSource = listPro;
                gridControl2.DataSource = listProTank;
            }
           
            //gridview1(busSite.getIDbyName(cbSite.Text), busFacility.getIDbyName(cbFacility.Text), busEquipment.getIDbyName(cbEquipment.Text));
        }

        private void additemsEquipment()
        {
            cbEquipment.Properties.Items.Clear();
            cbEquipment.Properties.Items.Add("<ALL>", -1, -1);
            cbEquipment.SelectedIndex = 0;
            int FacilityID1 = 0;
            if (cbFacility.Text == "<ALL>")
            {
                FacilityID1 = 0;
            }
            else
            {
                FACILITY_BUS busFaci = new FACILITY_BUS();
                FacilityID1 = busFaci.getIDbyName(cbFacility.Text);
            }
            EQUIPMENT_MASTER_BUS busequip = new EQUIPMENT_MASTER_BUS();
            List<String> listitemsEquip = busequip.getListEquipmentNumberbyFacilityID(FacilityID1);    
            for (int i = 0; i < listitemsEquip.Count; i++)
            {
                cbEquipment.Properties.Items.Add(listitemsEquip[i], i, i);
            }
        }
        private void cbFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ImageComboBoxEdit cb = sender as DevExpress.XtraEditors.ImageComboBoxEdit;
            additemsEquipment();
            if (cb.Text != "<ALL>")
            {
               
                gridControl1.DataSource = refressBySiteAndFacility(cbSite.Text,cb.Text);
                gridControl2.DataSource = refressTankBySiteAndFacility(cbSite.Text,cb.Text);
                // cbEquipment.Properties.Items.Clear();

            }
            else
            {
                gridControl1.DataSource = refressBySite(cbSite.Text);
                gridControl2.DataSource = refressTankBySite(cbSite.Text);
                //additemsEquipment();
            }
            
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            cbSite.Properties.Items.Clear();
            cbFacility.Properties.Items.Clear();
            cbEquipment.Properties.Items.Clear();
            additemsSite();
            additemsFacility();
            additemsEquipment();
            SplashScreenManager.CloseForm();
        }

        private void cbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ImageComboBoxEdit cb = sender as DevExpress.XtraEditors.ImageComboBoxEdit;

            if (cb.Text != "<ALL>")
            {
                gridControl1.DataSource = refressBySiteAndFacilityAndEquipment(cbSite.Text, cbFacility.Text,cb.Text);
                gridControl2.DataSource = refressTankBySiteAndFacilityAndEquipment(cbSite.Text, cbFacility.Text,cb.Text);
            }
            else
            {
                gridControl1.DataSource = refressBySiteAndFacility(cbSite.Text, cbFacility.Text);
                gridControl1.DataSource = refressTankBySiteAndFacility(cbSite.Text, cbFacility.Text);

            }
        }
        #endregion 

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void gridControl3_Load(object sender, EventArgs e)
        {
            
        }

        private void gridControl3_DataSourceChanged(object sender, EventArgs e)
        {
            //Display();
        }

        private void tabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if (tabPane1.SelectedPage.Name == "tabDamageMechanism")
                DisplayDamagemachanism();
            else
            {
               // if (tabPane1.SelectedPage.Name == "tabInspectionMethod")
                  //  showGridControlMethod();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }





        // Mở Word ở Inspection Finding trong tab thứ 4
        private void btnViewEditFindings_Click(object sender, EventArgs e)
        {
            frmInspectionFinding office = new frmInspectionFinding(InspectionFinding);
            office.ShowDialog();
            InspectionFinding = office.InsFinding;
        }

        private void btnClearFindings_Click(object sender, EventArgs e)
        {
            InspectionFinding = "";
        }

        private void btnSelectAllOnScreen_Click(object sender, EventArgs e)
        {
            if (tabPane2.SelectedPage == tabProcessPlan)
            {
                gridView2.SelectAll();
            }
            else gridView3.SelectAll();
        }

        private void btnClearAllOnScreen_Click(object sender, EventArgs e)
        {
            if (tabPane2.SelectedPage == tabProcessPlan)
            {
                gridView2.ClearSelection();
            }
            else gridView3.ClearSelection();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            gridView2.ClearSelection();
            gridView3.ClearSelection();
        }
    }
}