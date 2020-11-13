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
using RBI.DAL.MSSQL_CAL;
using DevExpress.XtraSplashScreen;
using RBI.PRE.subForm.OutputDataForm.OutputPOF;

namespace RBI.PRE.subForm.OutputDataForm
{
    public delegate void DataUCChangedHanlder(object sender, DataUCChangedEventArgs e);
    public delegate void CtrlSHandler(object sender, CtrlSPressEventArgs e);
    
    public partial class UCRiskFactor : UserControl
    {
        string[] itemDetectionSystem= { "Instrumentation designed specifically to detect material losses by changes in operating conditions (i.e., loss of pressure or flow) in the system",
                                        "Suitably located detectors to determine when the material is present outside the pressure-containing envelope",
                                        "Visual detection, cameras, or detectors with marginal coverage" };
        string[] itemIsolationSystem= { "Isolation or shutdown systems activated directly from process instrumentation or detectors, with no operator intervention",
                                        "Isolation or shutdown systems activated by operators in the control room or other suitable locations remote from the leak",
                                        "Isolation dependent on manually-operated valves" };
        string[] itemMitigationSystem= {"Inventory Blowdown, coupled with isolation system actived remotely or automatically",
                                        "Fire water deluge system and monitors",
                                        "Foam spray system",
                                        "Fire water monitor only",
                                        "None"};
        private RW_FULL_COF_BUS rw_full_COF_bus = null;
        private RW_FULL_COF rw_full_COF = null;
        private int IDProposal;
        public UCRiskFactor()
        {
            InitializeComponent();
        }
        private int id = -1;
        public UCRiskFactor(int ID)
        {
            id = ID;
            InitializeComponent();
            IDProposal = ID;
            riskPoF(ID);
            riskCA(ID);
            addItemDetectionSystem();
            addItemIsolationSystem();
            addItemMitigation();
            //initinput();
            initOutputCA();
            //ShowDataOutputCA(ID);
            //initData_Shell(ID);
            //initData_Tank(ID);
            initData_CA(ID);
        }
        public String type { set; get; }
        public void riskPoF(int ID)
        {
            RW_FULL_POF_BUS bus = new RW_FULL_POF_BUS();
            RW_FULL_POF obj = bus.getData(ID);
            cbThinningType.Text = obj.ThinningType;
            textEdit1.Text = obj.GFFTotal.ToString();
            textEdit2.Text = obj.FMS.ToString();
            txt0Thinning.Text = obj.ThinningAP1.ToString();
            txt36Thinning.Text = obj.ThinningAP2.ToString();
            txt72Thinning.Text = obj.ThinningAP3.ToString();

            txt0StressCorrosion.Text = obj.SCCAP1.ToString();
            txt36StressCorrosion.Text = obj.SCCAP2.ToString();
            txt72StressCorrosion.Text = obj.SCCAP3.ToString();

            txt0External.Text = obj.ExternalAP1.ToString();
            txt36External.Text = obj.ExternalAP2.ToString();
            txt72External.Text = obj.ExternalAP3.ToString();

            txt0HighTemperature.Text = obj.HTHA_AP1.ToString();
            txt36HighTemperature.Text = obj.HTHA_AP2.ToString();
            txt72HighTemperature.Text = obj.HTHA_AP3.ToString();

            txt0BrittleFracture.Text = obj.BrittleAP1.ToString();
            txt36BrittleFracture.Text = obj.BrittleAP2.ToString();
            txt72BrittleFracture.Text = obj.BrittleAP3.ToString();

            txt0Piping.Text = obj.FatigueAP1.ToString();
            txt36Piping.Text = obj.FatigueAP2.ToString();
            txt72Piping.Text = obj.FatigueAP3.ToString();

            txt0Other.Text = obj.SemiAP1.ToString();
            txt32Other.Text = obj.SemiAP2.ToString();
            txt72Other.Text = obj.SemiAP3.ToString();

            txt0TotalGeneralThinning.Text = obj.ThinningGeneralAP1.ToString();
            txt36TotalGeneralThinning.Text = obj.ThinningGeneralAP2.ToString();
            txt72TotalGeneralThinning.Text = obj.ThinningGeneralAP3.ToString();

            txt0TotalLocalThinning.Text = obj.ThinningLocalAP1.ToString();
            txt36TotalLocalThinning.Text = obj.ThinningLocalAP2.ToString();
            txt72TotalLocalThinning.Text = obj.ThinningLocalAP3.ToString();

            txt0FinalTotalDamage.Text = obj.TotalDFAP1.ToString();
            txt36FinalTotalDamage.Text = obj.TotalDFAP2.ToString();
            txt72FinalTotalDamage.Text = obj.TotalDFAP3.ToString();

            txt0PoF.Text = obj.PoFAP1.ToString();
            txt36PoF.Text = obj.PoFAP2.ToString();
            txt72PoF.Text = obj.PoFAP3.ToString();

            txt0PoFCategory.Text = obj.PoFAP1Category;
            txt36PoFCategory.Text = obj.PoFAP2Category;
            txt72PoFCategory.Text = obj.PoFAP3Category;
        }
        public void initAreabaseCOF(int ID) 
        {
            RW_FULL_COF_HOLE_SIZE_BUS hsbus = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = hsbus.getData(ID);
            RW_FULL_COF_INPUT_BUS fcipbus= new RW_FULL_COF_INPUT_BUS();
            RW_FULL_COF_INPUT fcip = fcipbus.getData(ID);

            txtHoleSizeAreaSmall.Text = obj.A1.ToString();
            txtHoleSizeAreaMedium.Text = obj.A2.ToString();
            txtHoleSizeAreaLarge.Text = obj.A3.ToString();
            txtHoleSizeAreaRupture.Text = obj.A4.ToString();

            txtReleaseRateSmall.Text = obj.W1.ToString();
            txtReleaseRateMedium.Text = obj.W2.ToString();
            txtReleaseRateLarge.Text = obj.W3.ToString();
            txtReleaseRateRupture.Text = obj.W4.ToString();

            txtGffSmall.Text = obj.GFF_small.ToString();
            txtGffMedium.Text = obj.GFF_medium.ToString();
            txtGffLarge.Text = obj.GFF_large.ToString();
            txtGffRupture.Text = obj.GFF_rupture.ToString();

            txtMassAddSmall.Text = obj.mass_add_1.ToString();
            txtMassAddMedium.Text = obj.mass_add_2.ToString();
            txtMassAddLarge.Text = obj.mass_add_3.ToString();
            txtMassAddRupture.Text = obj.mass_add_4.ToString();

            txtMassAvailSmall.Text = obj.mass_avail_1.ToString();
            txtMassAvailMedium.Text = obj.mass_avail_2.ToString();
            txtMassAvailLarge.Text = obj.mass_avail_3.ToString();
            txtMassAvailRupture.Text = obj.mass_avail_4.ToString();

            txtTnSmall.Text = obj.t_n1.ToString();
            txtTnMedium.Text = obj.t_n2.ToString();
            txtTnLarge.Text = obj.t_n3.ToString();
            txtTnRupture.Text = obj.t_n4.ToString();

            txtReleaseTypeSmall.Text = obj.ReleaseType_1.ToString();
            txtReleaseTypeMedium.Text = obj.ReleaseType_2.ToString();
            txtReleaseTypeLarge.Text = obj.ReleaseType_3.ToString();
            txtReleaseTypeRupture.Text = obj.ReleaseType_4.ToString();

            txtLdMaxSmall.Text = obj.ld_max_1.ToString();
            txtLdMaxMedium.Text = obj.ld_max_2.ToString();
            txtLdMaxLarge.Text = obj.ld_max_3.ToString();
            txtLdMaxRupture.Text = obj.ld_max_4.ToString();

            txtRatenSmall.Text = obj.rate_1.ToString();
            txtRatenMedium.Text = obj.rate_2.ToString();
            txtRatenLarge.Text = obj.rate_3.ToString();
            txtRatenRupture.Text = obj.rate_4.ToString();

            txtLdSmall.Text = obj.ld_1.ToString();
            txtLdMedium.Text = obj.ld_2.ToString();
            txtLdLarge.Text = obj.ld_3.ToString();
            txtLdRupture.Text = obj.ld_4.ToString();

            txtReleaseMassSmall.Text = obj.mass_1.ToString();
            txtReleaseMassMedium.Text = obj.mass_2.ToString();
            txtReleaseMassLarge.Text = obj.mass_3.ToString();
            txtReleaseMassRupture.Text = obj.mass_4.ToString();

        }
        public void initinput()
        {
            MSSQL_RBI_CAL_ConnUtils DAL_CAL=new MSSQL_RBI_CAL_ConnUtils();
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE();
            RW_COMPONENT_BUS buscomponent = new RW_COMPONENT_BUS();
            RW_COMPONENT component = buscomponent.getData(IDProposal);
            RW_STREAM_BUS bustream = new RW_STREAM_BUS();
            RW_STREAM st = bustream.getData(IDProposal);
            RW_ASSESSMENT_BUS busass = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_MASTER com = buscom.getData(busass.getComponentID(IDProposal));
            int apicomponentID = com.APIComponentTypeID;
            int equipmentID = com.EquipmentID;
            API_COMPONENT_TYPE_BUS busapi = new API_COMPONENT_TYPE_BUS();
            API_COMPONENT_TYPE api = busapi.getDatabyID(apicomponentID);
            RW_FULL_COF_FLUID_BUS busrwcfc = new RW_FULL_COF_FLUID_BUS();
            RW_FULL_COF_FLUID rwcfc = busrwcfc.getData(IDProposal);
            CA_CAL.FLUID = st.TankFluidName;
            CA_CAL_FLA.FLUID_TOXIC = st.ToxicFluidName;
            String data = String.IsNullOrEmpty(DAL_CAL.GET_FLUID_TYPE(CA_CAL.FLUID)) ? " " : DAL_CAL.GET_FLUID_TYPE(CA_CAL.FLUID);
            String data1 = String.IsNullOrEmpty(DAL_CAL.GET_FLUID_TYPE(CA_CAL_FLA.FLUID_TOXIC)) ? " " : DAL_CAL.GET_FLUID_TYPE(CA_CAL_FLA.FLUID_TOXIC);
            float[] data3 = DAL_CAL.GET_TBL_52(CA_CAL.FLUID);
            txtACT.Text = api.APIComponentTypeName.ToString();
            txtLL.Text = st.LiquidLevel.ToString();
            txtMF.Text = st.TankFluidName;
            txtTFP.Text = st.ReleaseFluidPercentToxic.ToString();
            txtDia.Text = component.NominalDiameter.ToString();
            txtComponent.Text = component.ComponentVolume.ToString();
            txtTF.Text = st.ToxicFluidName.ToString();
            txtPhase.Text = st.StoragePhase.ToString();
            txtMOT.Text = st.MaxOperatingTemperature.ToString();
            txtMOP.Text = ((st.MaxOperatingPressure)*1000).ToString();
            txtModelFluidType.Text = data.ToString();
            txtToxicFluidType.Text = data1.ToString();
            txtCp.Text = rwcfc.Cp.ToString();
            txtLiquidDensity.Text = rwcfc.Density.ToString();
            //txtVapourDensity.Text
            txtMW.Text = rwcfc.MW.ToString();
            float a = ((data3[9]-32)/1.8f);
            if (a < 0)
            {
                txtAIT.Text = 0.ToString();
            }
            else
            {
                txtAIT.Text = a.ToString();
            }
            txtNBP.Text = rwcfc.NBP.ToString();
            txtK.Text = rwcfc.k.ToString();
            txtAmbientState.Text = rwcfc.ambient.ToString();
            txtReleasePhase.Text = rwcfc.ReleasePhase.ToString();
            txtRMRF.Text = rwcfc.fact_di.ToString();
            txtCARF.Text = rwcfc.fact_mit.ToString();
        }
        public void initOutputCA()
        {
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE();
            MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC();
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_ASSESSMENT_BUS busass = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_MASTER com = buscom.getData(busass.getComponentID(IDProposal));
            int apicomponentID = com.APIComponentTypeID;
            API_COMPONENT_TYPE_BUS busapi = new API_COMPONENT_TYPE_BUS();
            API_COMPONENT_TYPE api = busapi.getDatabyID(apicomponentID);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            CA_CAL_FLA.FLUID = st.TankFluidName;
            CA_CAL_TOX.FLUID = st.TankFluidName;
            CA_CAL_FLA.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_TOX.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_FLA.FLUID_PHASE = st.StoragePhase;
            CA_CAL_FLA.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_TOX.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_FLA.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_TOX.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_FLA.IDProposal = IDProposal;
            CA_CAL_TOX.IDProposal = IDProposal;
            CA_CAL_FLA.STORED_PRESSURE = st.MaxOperatingPressure * 1000;
            CA_CAL_FLA.STORE_TEMP = st.MaxOperatingTemperature;
            String ReleasePhase = CA_CAL.GET_RELEASE_PHASE();
            CA_CAL_FLA.FLUID = st.TankFluidName;
        
        }

        public void riskCA(int ID)
        {
            RW_FULL_FCOF_BUS fullPoFBus = new RW_FULL_FCOF_BUS();
            RW_FULL_FCOF fullPoF = fullPoFBus.getData(ID);
            txtProductionCost.Text = fullPoF.prodcost.ToString();
            txtEquipmentCost.Text = fullPoF.equipcost.ToString();
            txtPopdens.Text = fullPoF.popdens.ToString();
            txtInjureCost.Text = fullPoF.injcost.ToString();
            txtEnvironmentCost.Text = fullPoF.envcost.ToString();
            txtFC.Text = fullPoF.FCoFValue.ToString();
            txtCA.Text = fullPoF.FCoFCategory;
        }
        public void ShowDataOutputCA(int ID)
        {
            //RW_CA_TANK_BUS busTank = new RW_CA_TANK_BUS();
            //RW_CA_TANK ca = busTank.getData(ID);
            //txtCA.Text = ca.ConsequenceCategory;
            //txtFC.Text = ca.Consequence.ToString();
            //RW_CA_LEVEL_1_BUS busCA = new RW_CA_LEVEL_1_BUS();
            //RW_CA_LEVEL_1 ca = busCA.getData(ID);
            //txtCAcmd.Text = ca.CA_cmd.ToString();
            //txtCAinj.Text = ca.CA_inj_flame.ToString();
            //txtFCcmd.Text = ca.FC_cmd.ToString();
            //txtFCinj.Text = ca.FC_inj.ToString();
            //txtFCaffa.Text = ca.FC_affa.ToString();
            //txtFCprod.Text = ca.FC_prod.ToString();
            //txtFCenviron.Text = ca.FC_envi.ToString();
        }

        private void cbThinningType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbThinningType.Text == "")
            {
                type = "Local";
            }
            else
            {
                type = cbThinningType.Text;
            } 
        }
        private void initData_CA(int ID)
        {
            RW_ASSESSMENT_BUS busAssess = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS busCompMaster = new COMPONENT_MASTER_BUS();
            int[] temp = busAssess.getEquipmentID_ComponentID(ID);
            int compTypeID = busCompMaster.getComponentTypeID(temp[1]);
            Console.WriteLine("comTypeID=" + compTypeID + " " + temp[1]);
            

            if (compTypeID == 12) //tank bottom
            {
                initData_Tank(ID);
                tabCATankBottom.PageVisible = true;
                tabCAShell.PageVisible = false;
                tabCA.PageVisible = false;
                tabCATankShell.PageVisible = false;
                TabArea.PageVisible = false;
                tabCATankRoof.PageVisible = false;
                tabCAnormal.PageVisible = false;
            }
            else if (compTypeID == 8) 
            {
                initData_Shell(ID);
                tabCA.PageVisible = false;
                tabCATankBottom.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCATankShell.PageVisible = true;
                TabArea.PageVisible = false;
                tabCATankRoof.PageVisible = false;
                tabCAnormal.PageVisible = false;
            }
            else if (compTypeID == 13) //shell
            {
                initData_Shell(ID);
                TabArea.PageVisible = false;
                tabCA.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCATankBottom.PageVisible = false;
                TabArea.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCATankShell.PageVisible = true;
                tabCATankRoof.PageVisible = false;
                initData_InputTank(ID);
                LoadDataForControlInTabCATankShell(ID);
                tabCAnormal.PageVisible = false;
            }
            else if (compTypeID == 14) //fixed roof
            {

                tabCA.PageVisible = false;
                tabCATankBottom.PageVisible = false;
                TabArea.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCATankShell.PageVisible = false;
                tabCATankRoof.PageVisible = true;
                initData_InputTank(ID);
                initData_Roof(ID);
                tabCAnormal.PageVisible = false;
            }
            else if (compTypeID == 15) //floating roof
            {

                tabCA.PageVisible = false;
                tabCATankBottom.PageVisible = false;
                TabArea.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCATankShell.PageVisible = false;
                tabCATankRoof.PageVisible = true;
                initData_InputTank(ID);
                initData_Roof(ID);
                tabCAnormal.PageVisible = false;
                //tab.
            }
            else
            {
                riskCA(ID);
                ShowDataOutputCA(ID);
                tabCATankBottom.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCA.PageVisible = false;
                tabCATankShell.PageVisible = false;
                tabCAnormal.PageVisible = true;
                tabCATankRoof.PageVisible = false;
                initinput();
                initAreabaseCOF(ID);
            }
        }
        private void addItemDetectionSystem()
        {
            cbDetectionSystem.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemDetectionSystem.Length; i++)
            {
                cbDetectionSystem.Properties.Items.Add(itemDetectionSystem[i], i, i);
            }
        }
        private void addItemIsolationSystem()
        {
            cbIsolationSystem.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemIsolationSystem.Length; i++)
            {
                cbIsolationSystem.Properties.Items.Add(itemIsolationSystem[i], i, i);
            }
        }
        private void addItemMitigation()
        {
            cbMitigationSystem.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemMitigationSystem.Length; i++)
            {
                cbMitigationSystem.Properties.Items.Add(itemMitigationSystem[i], i, i);
            }
        }



        private void initData_Roof(int ID)
        {
            RW_FULL_COF_TANK_BUS COFBus = new RW_FULL_COF_TANK_BUS();
            RW_FULL_COF_TANK obj = COFBus.getData(ID);
            RW_CA_TANK_BUS busCA_Tank = new RW_CA_TANK_BUS();
            RW_CA_TANK caTank = busCA_Tank.getData(ID);
            txtOutageMulRoof.Text = obj.EquipOutageMultiplier.ToString();
            txtPrrodCostRoof.Text = obj.ProdCost.ToString();
            txtMaterialRoof.Text = caTank.Material_Factor.ToString();
            txtComDamRoof.Text = caTank.Component_Damage_Cost.ToString();
            txtDowntimeRoof.Text = caTank.Leak_Duration_D1.ToString();//lưu tạm giá trị
            txtBusInterRoof.Text = caTank.Business_Cost.ToString();
            txtTotalConsequenceRoof.Text = caTank.Consequence.ToString();
            txtConsequenceCategoryRoof.Text = caTank.ConsequenceCategory;
            //luu vao bang RW_FULL_COF_BUS de ve riskmatrix
            rw_full_COF_bus = new RW_FULL_COF_BUS();
            rw_full_COF = new RW_FULL_COF();
            rw_full_COF.ID = id;
            rw_full_COF.CoFValue = float.Parse(txtTotalConsequenceRoof.Text);
            rw_full_COF.CoFCategory = txtConsequenceCategoryRoof.Text;
            rw_full_COF.CoFMatrixValue = 0;
            if (rw_full_COF_bus.checkExistCoF(id))
            {
                rw_full_COF_bus.edit(rw_full_COF);
            }
            else rw_full_COF_bus.add(rw_full_COF);
        }
 
        private void initData_Tank(int ID)
        {
            RW_CA_TANK_BUS busCA_Tank = new RW_CA_TANK_BUS();
            RW_CA_TANK caTank = busCA_Tank.getData(ID);
            tbHdraulicFluid.Text = caTank.Hydraulic_Fluid.ToString();
            tbHdraulicWater.Text = caTank.Hydraulic_Water.ToString();
            tbSeepageVelocity.Text = caTank.Seepage_Velocity.ToString();
            tbFlowRateD1.Text = caTank.Flow_Rate_D1.ToString();
            tbFlowRateD4.Text = caTank.Flow_Rate_D4.ToString();
            tbLeakDurationD1.Text = caTank.Leak_Duration_D1.ToString();
            tbLeakDurationD4.Text = caTank.Leak_Duration_D4.ToString();
            tbRealeaseVolumeFromLeakageD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            //MessageBox.Show(caTank.Release_Volume_Leak_D1.ToString());
            // MessageBox.Show(caTank.FC_Environ_Rupture.ToString());
            tbRealeaseVolumeFromLeakageD4.Text = caTank.Release_Volume_Leak_D4.ToString();
            tbReleaseVolumeFromRuptureD1.Text = caTank.Release_Volume_Rupture_D1.ToString();
            tbReleaseVolumeFromRuptureD4.Text = caTank.Release_Volume_Rupture_D4.ToString();
            tbTimeToInitiate.Text = caTank.Time_Leak_Ground.ToString();
           // MessageBox.Show(caTank.Time_Leak_Ground.ToString());
            tbVolumeSubsoilFromLeakageD1.Text = caTank.Volume_SubSoil_Leak_D1.ToString();
            tbVolumeSubsoilFromLeakageD4.Text = caTank.Volume_SubSoil_Leak_D4.ToString();
            tbVolumeGroundWaterFromLeakageD1.Text = caTank.Volume_Ground_Water_Leak_D1.ToString();
            tbVolumeGroundWaterFromLeakageD4.Text = caTank.Volume_Ground_Water_Leak_D4.ToString();
            tbWithinTheDike.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbWithinTheDike.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbOnsiteRupture.Text = caTank.Barrel_Onsite_Rupture.ToString();
            tbOffsiteRupture.Text = caTank.Barrel_Offsite_Rupture.ToString();
            tbReachWater.Text = caTank.Barrel_Water_Rupture.ToString();
            tbFC_Env_Leakage.Text = caTank.FC_Environ_Leak.ToString();
            tbFC_Env_Rupture.Text = caTank.FC_Environ_Rupture.ToString();
            tbMaterialFactor.Text = caTank.Material_Factor.ToString();
            tbTotalCost.Text = caTank.FC_Environ.ToString();
            tbComponentDamageCost.Text = caTank.Component_Damage_Cost.ToString();
            tbCostOfBusinessInterruption.Text = caTank.Business_Cost.ToString();
            tbTotalConsequence.Text = caTank.Consequence.ToString();
            tbConsequenceCategory.Text = caTank.ConsequenceCategory;

            RW_FULL_COF_TANK_BUS COFBus = new RW_FULL_COF_TANK_BUS();
            RW_FULL_COF_TANK obj = COFBus.getData(ID);
            txtEquipMulBottom.Text = obj.EquipOutageMultiplier.ToString();
            txtCostProdBottom.Text = obj.ProdCost.ToString();
            //luu vao bang RW_FULL_COF_BUS de ve riskmatrix
            rw_full_COF_bus = new RW_FULL_COF_BUS();
            rw_full_COF = new RW_FULL_COF();
            rw_full_COF.ID = id;
            rw_full_COF.CoFValue = float.Parse(tbTotalConsequence.Text);
            rw_full_COF.CoFCategory = tbConsequenceCategory.Text;
            rw_full_COF.CoFMatrixValue = 0;
            if (rw_full_COF_bus.checkExistCoF(id))
            {
                rw_full_COF_bus.edit(rw_full_COF);
            }
            else rw_full_COF_bus.add(rw_full_COF);
        }
        
        private void initData_InputTank(int ID)
        {
            #region  table RW_FULL_COF_TANK
            RW_FULL_COF_TANK_BUS COFBus = new RW_FULL_COF_TANK_BUS();
            RW_FULL_COF_TANK obj = COFBus.getData(ID);
            txtIDFullCOFTankInTabShell.Text = obj.ID.ToString();
            txtProcessUnitReplace.Text = obj.equipcost.ToString();
            txtEquipOutageMultiplier.Text = obj.EquipOutageMultiplier.ToString();
            txtLossProduction.Text = obj.ProdCost.ToString();
            txtDensity.Text = obj.popdens.ToString();
            txtInjury.Text = obj.injcost.ToString();
            #endregion
        }
        private void initData_Shell(int ID)
        {
            RW_CA_TANK_BUS busCA_Tank = new RW_CA_TANK_BUS();
            RW_CA_TANK caTank = busCA_Tank.getData(ID);

            #region consequences area
            tbFlowRateShellD1.Text = caTank.Flow_Rate_D1.ToString();
            tbFlowRateShellD2.Text = caTank.Flow_Rate_D2.ToString();
            tbFlowRateShellD3.Text = caTank.Flow_Rate_D3.ToString();
            tbFlowRateShellD4.Text = caTank.Flow_Rate_D4.ToString();

            tbLeakDurationShellD1.Text = caTank.Leak_Duration_D1.ToString();
            tbLeakDurationShellD2.Text = caTank.Leak_Duration_D2.ToString();
            tbLeakDurationShellD3.Text = caTank.Leak_Duration_D3.ToString();
            tbLeakDurationShellD4.Text = caTank.Leak_Duration_D4.ToString();

            tbReleaseVolumeLeakageShellD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            tbReleaseVolumeLeakageShellD2.Text = caTank.Release_Volume_Leak_D2.ToString();
            tbReleaseVolumeLeakageShellD3.Text = caTank.Release_Volume_Leak_D3.ToString();
            tbReleaseVolumeLeakageShellD4.Text = caTank.Release_Volume_Leak_D4.ToString();

            tbReleaseVolumeLeakageShellD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            tbReleaseVolumeLeakageShellD2.Text = caTank.Release_Volume_Leak_D2.ToString();
            tbReleaseVolumeLeakageShellD3.Text = caTank.Release_Volume_Leak_D3.ToString();
            tbReleaseVolumeLeakageShellD4.Text = caTank.Release_Volume_Leak_D4.ToString();
            tbTimeLeakageGroundWaterShell.Text = caTank.Time_Leak_Ground.ToString();
            tbVolumeSubsoilShellD1.Text = caTank.Volume_SubSoil_Leak_D1.ToString();
            tbVolumeSubsoilShellD4.Text = caTank.Volume_SubSoil_Leak_D4.ToString();
            tbVolumeGroundWaterShellD1.Text = caTank.Volume_Ground_Water_Leak_D1.ToString();
            tbVolumeGroundWaterShellD4.Text = caTank.Volume_Ground_Water_Leak_D4.ToString();
            tbDikeRuptureShell.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbOn_siteShell.Text = caTank.Barrel_Onsite_Rupture.ToString();
            tbIn_siteShell.Text = caTank.Barrel_Offsite_Rupture.ToString();
            tbReachWaterRuptureShell.Text = caTank.Barrel_Water_Rupture.ToString();
            tbFCleakageShell.Text = caTank.FC_Environ_Leak.ToString();
            tbFCruptureShell.Text = caTank.FC_Environ_Rupture.ToString();

            tbTotalF_Shell.Text = caTank.FC_Environ.ToString();
            tbComponentDamageCost.Text = caTank.Component_Damage_Cost.ToString();
            
            #endregion

            #region Tab COF Financial for Shell

            txtHdraulicWater.Text = caTank.Hydraulic_Water.ToString();
            txtHdraulicFluid.Text = caTank.Hydraulic_Fluid.ToString();
            txtSeepageVelocity.Text = caTank.Seepage_Velocity.ToString();

            txtFlowRateShellD1.Text = caTank.Flow_Rate_D1.ToString();
            txtFlowRateShellD2.Text = caTank.Flow_Rate_D2.ToString();
            txtFlowRateShellD3.Text = caTank.Flow_Rate_D3.ToString();
            txtFlowRateShellD4.Text = caTank.Flow_Rate_D4.ToString();
            
            txtHeightAboveShell.Text = caTank.Liquid_Height.ToString();
            txtVolumnAboveShell.Text = caTank.Volume_Fluid.ToString();

            txtLeakDurationShellD1.Text = caTank.Leak_Duration_D1.ToString();
            txtLeakDurationShellD2.Text = caTank.Leak_Duration_D2.ToString();
            txtLeakDurationShellD3.Text = caTank.Leak_Duration_D3.ToString();
            txtLeakDurationShellD4.Text = caTank.Leak_Duration_D4.ToString();

            txtReleaseVolumeLeakageShellD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            txtReleaseVolumeLeakageShellD2.Text = caTank.Release_Volume_Leak_D2.ToString();
            txtReleaseVolumeLeakageShellD3.Text = caTank.Release_Volume_Leak_D3.ToString();
            txtReleaseVolumeLeakageShellD4.Text = caTank.Release_Volume_Leak_D4.ToString();

            txtReleaseVolumeFromRuptureShell.Text = caTank.Release_Volume_Rupture_D1.ToString(); // lưu giá trị này ở D1

            tbWithinDikeLeakageShell.Text = caTank.Barrel_Dike_Leak.ToString();
            tbWithinDikeRuptureShell.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbOn_siteLeakageShell.Text = caTank.Barrel_Onsite_Leak.ToString();
            tbOn_siteRuptureShell.Text = caTank.Barrel_Onsite_Rupture.ToString();
            tbOff_siteLeakageShell.Text = caTank.Barrel_Offsite_Leak.ToString();
            tbOff_siteRupureShell.Text = caTank.Barrel_Offsite_Rupture.ToString();
            txtReachWaterLeakageShell.Text = caTank.Barrel_Water_Leak.ToString();
            txtReachWaterRuptureShell.Text = caTank.Barrel_Water_Rupture.ToString();

            tbFCenvLeakageShell.Text = caTank.FC_Environ_Leak.ToString();
            tbFCenvRuptureShell.Text = caTank.FC_Environ_Rupture.ToString();

            tbTotalFCenvShell.Text = caTank.FC_Environ.ToString();
            tbComponentDamageCostShell.Text = caTank.Component_Damage_Cost.ToString();
            //tbDamageSurroundEquipmentShell.Text = cần bổ sung base 
            //tbCostOfBusinessInterruptionShell.Text = caTank.Business_Cost.ToString();
            //tbCostAssociatedPersonInjury.Text = cần bổ sung base 
            
            #endregion
        }

        RW_FULL_COF_TANK input = new RW_FULL_COF_TANK();
        public RW_FULL_COF_TANK getDataInputCOFTank(int ID)
        {
            input.ID = ID;
            //input.ProdCost = float.Parse(a) ;
            //MessageBox.Show(txtProdCost.ToString(), txtDensity.ToString());
            input.equipcost = txtProcessUnitReplace.Text != "" ? float.Parse(txtProcessUnitReplace.Text) : 0;
            input.EquipOutageMultiplier = txtEquipOutageMultiplier.Text != "" ? float.Parse(txtEquipOutageMultiplier.Text) : 0;
            input.ProdCost = txtLossProduction.Text != "" ? float.Parse(txtLossProduction.Text) : 0; 
            input.injcost =  txtInjury.Text != "" ? float.Parse(txtInjury.Text) : 0;
            input.popdens = txtDensity.Text != "" ? float.Parse(txtDensity.Text) : 0; 
            return input;
        }

        #region event
        private void lblLF1_Click(object sender, EventArgs e)
        {
            if (lblLF1.Text == "▼ LF1")
            {
                panelLF1.Height = 71;
                lblLF1.Text = "▶ LF1";

                panelLF2.Top = panelLF1.Top + panelLF1.Height + 13;
                panelLF3.Top = panelLF2.Top + panelLF2.Height + 13;
                panelLF4567.Top = panelLF3.Top + panelLF4567.Height + 13;
            }
            else if (lblLF1.Text == "▶ LF1")
            {
                panelLF1.Height = 21;
                lblLF1.Text = "▼ LF1";

                panelLF2.Top = panelLF1.Top + panelLF1.Height + 13;
                panelLF3.Top = panelLF2.Top + panelLF2.Height + 13;
                panelLF4567.Top = panelLF3.Top + panelLF4567.Height + 13;
            }
        }

        private void lblLF2_Click(object sender, EventArgs e)
        {

            if (lblLF2.Text == "▼ LF2")
            {
                panelLF2.Height = 131;
                lblLF2.Text = "▶ LF2";
                panelLF3.Top = panelLF2.Top + panelLF2.Height + 13;
                panelLF4567.Top = panelLF3.Top + panelLF3.Height + 13;

            }
            else if (lblLF2.Text == "▶ LF2")
            {
                panelLF2.Height = 21;
                lblLF2.Text = "▼ LF2";
                panelLF3.Top = panelLF2.Top + panelLF2.Height + 13;
                panelLF4567.Top = panelLF3.Top + panelLF3.Height + 13;
            }
        }

        private void lblLF3_Click(object sender, EventArgs e)
        {
            if (lblLF3.Text == "▼ LF3")
            {
                panelLF3.Height = 114;
                lblLF3.Text = "▶ LF3";
                panelLF4567.Top = panelLF3.Top + panelLF3.Height + 13;
            }
            else if (lblLF3.Text == "▶ LF3")
            {
                panelLF3.Height = 21;
                lblLF3.Text = "▼ LF3";
                panelLF4567.Top = panelLF3.Top + panelLF3.Height + 13;
            }
        }

        private void lblLF4567_Click(object sender, EventArgs e)
        {
            if (lblLF4567.Text == "▼ LF4, LF5, LF6 and LF7")
            {
                panelLF4567.Height = 205;
                lblLF4567.Text = "▶ LF4, LF5, LF6 and LF7";

            }
            else if (lblLF4567.Text == "▶ LF4, LF5, LF6 and LF7")
            {
                panelLF4567.Height = 21;
                lblLF4567.Text = "▼ LF4, LF5, LF6 and LF7";

            }
        }
        private void UCRiskFactor_Load_1(object sender, EventArgs e)
        {
            panelLF1.Height = 21;
            panelLF2.Top = panelLF1.Top + panelLF1.Height + 13;
            panelLF2.Height = 21;
            panelLF3.Top = panelLF2.Top + panelLF2.Height + 13;
            panelLF3.Height = 21;
            panelLF4567.Top = panelLF3.Top + panelLF3.Height + 13;
            panelLF4567.Height = 21;
            panelInput.Height = 21;
            panelFQF.Top = panelInput.Top + panelInput.Height + 13;
            panelFQF.Height = 21;
            groupBoxIV.Top = panelFQF.Top + panelFQF.Height + 13;
            panelInflu.Height = 21;
            panelCAP.Top = panelInflu.Top + panelInflu.Height + 13;
            panelCAP.Height = 21;
            panelRHP.Top = panelCAP.Top + panelCAP.Height + 13;
            panelRHP.Height = 21;
            panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
            panelFCA.Height = 21;
            panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
            panelTCA.Height = 21;
            panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            panelNonTF.Height = 21;
        }

        private void lblInput_Click(object sender, EventArgs e)
        {
            if (lblInput.Text == "▼ Input")
            {
                panelInput.Height = 142;
                lblInput.Text = "▶ Input";
                panelFQF.Top = panelInput.Top + panelInput.Height + 13;
                groupBoxIV.Top = panelFQF.Top + panelFQF.Height + 13;
                
            }
            else if (lblInput.Text == "▶ Input")
            {
                panelInput.Height = 21;
                lblInput.Text = "▼ Input";
                panelFQF.Top = panelInput.Top + panelInput.Height + 13;
                groupBoxIV.Top = panelFQF.Top + panelFQF.Height + 13;
            }
        }

        private void lblFQF_Click(object sender, EventArgs e)
        {
            if (lblFQF.Text == "▼ Fully-Quantitive Financial Consequence of Failture and Category")
            {
                panelFQF.Height = 87;
                lblFQF.Text = "▶ Fully-Quantitive Financial Consequence of Failture and Category";
                groupBoxIV.Top = panelFQF.Top + panelFQF.Height + 13;
            }
            else if (lblFQF.Text == "▶ Fully-Quantitive Financial Consequence of Failture and Category")
            {
                panelFQF.Height = 21;
                lblFQF.Text = "▼ Fully-Quantitive Financial Consequence of Failture and Category";
                groupBoxIV.Top = panelFQF.Top + panelFQF.Height + 13;
            }
        }

        private void lbllnfinput_Click(object sender, EventArgs e)
        {
            if (lbllnfinput.Text == "▼ Influencing Inputs")
            {
                panelInflu.Height = 207;
                lbllnfinput.Text = "▶ Influencing Inputs";
                panelCAP.Top = panelInflu.Top + panelInflu.Height + 13;
                panelRHP.Top = panelCAP.Top + panelCAP.Height + 13;
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
            else if (lbllnfinput.Text == "▶ Influencing Inputs")
            {
                panelInflu.Height = 21;
                lbllnfinput.Text = "▼ Influencing Inputs";
                panelCAP.Top = panelInflu.Top + panelInflu.Height + 13;
                panelRHP.Top = panelCAP.Top + panelCAP.Height + 13;
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
        }

        private void lblCAP_Click(object sender, EventArgs e)
        {
            if (lblCAP.Text == "▼ Consequence Analysis Properties")
            {
                panelCAP.Height = 368;
                lblCAP.Text = "▶ Consequence Analysis Properties";
                panelRHP.Top = panelCAP.Top + panelCAP.Height + 13;
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
            else if (lblCAP.Text == "▶ Consequence Analysis Properties")
            {
                panelCAP.Height = 21;
                lblCAP.Text = "▼ Consequence Analysis Properties";
                panelRHP.Top = panelCAP.Top + panelCAP.Height + 13;
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
        }

        private void lblRHP_Click(object sender, EventArgs e)
        {
            if (lblRHP.Text == "▼ Release Holes Properties")
            {
                panelRHP.Height = 342;
                lblRHP.Text = "▶ Release Holes Properties";
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
            else if (lblRHP.Text == "▶ Release Holes Properties")
            {
                panelRHP.Height = 21;
                lblRHP.Text = "▼ Release Holes Properties";
                panelFCA.Top = panelRHP.Top + panelRHP.Height + 13;
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
        }
        private void lblFCA_Click(object sender, EventArgs e)
        {
            if (lblFCA.Text == "▼ Flammable Consequence Area")
            {
                panelFCA.Height = 831;
                lblFCA.Text = "▶ Flammable Consequence Area";
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
            else if (lblFCA.Text == "▶ Flammable Consequence Area")
            {
                panelFCA.Height = 21;
                lblFCA.Text = "▼ Flammable Consequence Area";
                panelTCA.Top = panelFCA.Top + panelFCA.Height + 13;
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
        }
        private void lblTCA_Click(object sender, EventArgs e)
        {
            if (lblTCA.Text == "▼ Toxic Consequence Area")
            {
                panelTCA.Height = 342;
                lblTCA.Text = "▶ Toxic Consequence Area";
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
            else if (lblTCA.Text == "▶ Toxic Consequence Area")
            {
                panelTCA.Height = 21;
                lblTCA.Text = "▼ Toxic Consequence Area";
                panelNonTF.Top = panelTCA.Top + panelTCA.Height + 13;
            }
        }
        private void lblNonTF_Click(object sender, EventArgs e)
        {
            if (lblNonTF.Text == "▼ Non-Flammable Non-Toxic Consequence Area")
            {
                panelNonTF.Height = 192;
                lblNonTF.Text = "▶ Non-Flammable Non-Toxic Consequence Area";
            }
            else if (lblNonTF.Text == "▶ Non-Flammable Non-Toxic Consequence Area")
            {
                panelNonTF.Height = 21;
                lblNonTF.Text = "▼ Non-Flammable Non-Toxic Consequence Area";
            }
        }


        #endregion
        #region Xu ly su kien khi data thay doi
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
        public int DataChange
        {
            get { return datachange; }
            set
            {
                if (datachange == value) return;
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
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

        private void txtRiskFactor_TextChanged(object sender, EventArgs e)
        {
             DataChange++;
        }
       

        private void txtRiskFactor_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.Control && e.KeyCode == Keys.S)
             {
                 CtrlSPress++;
             }
         }
        
        #endregion
        #region KeyPress Event Handle
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.') && (ev.KeyChar != '-'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }
        private void txtProdCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtProcessUnitReplace, e);
        }

        private void txtEquipOutageMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtEquipOutageMultiplier, e);
        }
        
        private void txtEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtLossProduction, e);
        }

        private void txtDensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDensity, e);
        }

        private void txtInjury_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtInjury, e);
        }

        #endregion

        private void btnSaveInputShell_Click(object sender, EventArgs e) //dùng button này để sửa giá trị bảng RW full cof tank
        {
            int ID = int.Parse(txtIDFullCOFTankInTabShell.Text);
            RW_FULL_COF_TANK inputShell = new RW_FULL_COF_TANK();
            inputShell = getDataInputCOFTank(ID);
            RW_FULL_COF_TANK_BUS busCA_Tank = new RW_FULL_COF_TANK_BUS();
            busCA_Tank.edit(inputShell);
            MessageBox.Show("Update Input", "Coterk RBI");
        }

        private void btnSaveInputRoof_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtIDFullCOFTankInTabShell.Text);
            RW_FULL_COF_TANK inputShell = new RW_FULL_COF_TANK();
            txtEquipOutageMultiplier.Text = txtOutageMulRoof.Text;
            txtLossProduction.Text = txtPrrodCostRoof.Text;
            inputShell = getDataInputCOFTank(ID);
            RW_FULL_COF_TANK_BUS busCA_Tank = new RW_FULL_COF_TANK_BUS();
            busCA_Tank.edit(inputShell);
            MessageBox.Show("Update Input", "Coterk RBI");
        }
        public void getData(int ID)//luu database
        {
            RW_FULL_COF_INPUT fcip = new RW_FULL_COF_INPUT();
            RW_FULL_COF_INPUT_BUS fcipbus = new RW_FULL_COF_INPUT_BUS();
            if (cbDetectionSystem.Text != "" && txtFM.Text != "" && cbIsolationSystem.Text != "" && cbMitigationSystem.Text != "")
            {
                fcip.ID = ID;
                fcip.mass_inv = float.Parse(txtFM.Text);
                if (cbDetectionSystem.SelectedIndex == 1) fcip.DetectionType = "A";
                else if (cbDetectionSystem.SelectedIndex == 2) fcip.DetectionType = "B";
                else if (cbDetectionSystem.SelectedIndex == 3) fcip.DetectionType = "C";
                fcip.Mitigation = cbMitigationSystem.SelectedItem.ToString();
                if (cbIsolationSystem.SelectedIndex == 1) fcip.IsolationType = "A";
                if (cbIsolationSystem.SelectedIndex == 2) fcip.IsolationType = "B";
                if (cbIsolationSystem.SelectedIndex == 3) fcip.IsolationType = "C";
                fcip.mass_comp = 0;
                fcipbus.edit(fcip);

            }
        }
        public void showDataTabArea(int ID)//lay database
        {
            RW_FULL_COF_INPUT_BUS fcipbus = new RW_FULL_COF_INPUT_BUS();
            RW_FULL_COF_INPUT fcip = fcipbus.getData(ID);
            txtFM.Text = fcip.mass_inv.ToString();
            if (fcip.DetectionType == "A")
                cbDetectionSystem.SelectedIndex = 1;
            else if (fcip.DetectionType == "B")
                cbDetectionSystem.SelectedIndex = 2;
            else if (fcip.DetectionType == "C")
                cbDetectionSystem.SelectedIndex = 3;
            else cbDetectionSystem.SelectedIndex = 0;
            if (fcip.IsolationType == "A")
                cbIsolationSystem.SelectedIndex = 1;
            else if (fcip.IsolationType == "B")
                cbIsolationSystem.SelectedIndex = 2;
            else if (fcip.IsolationType == "C")
                cbIsolationSystem.SelectedIndex = 3;
            else
                cbIsolationSystem.SelectedIndex = 0;
            cbMitigationSystem.SelectItemByDescription(fcip.Mitigation);
        }
        public void getDataFINALCOF(int ID)//luu database
        {
            if (txtPURCFC.Text != "" && txtEOM.Text!="" && txtLoPC.Text!=""&& txtTuPDoDoE.Text!=""&& txtTCAWSIOFOP.Text!=""&& txtECUP.Text!="")
            {
                RW_FULL_FINALCOF ffcof = new RW_FULL_FINALCOF();
                RW_FULL_FINALCOF_BUS ffcofbus = new RW_FULL_FINALCOF_BUS();
                ffcof.ID = ID;
                ffcof.ComponentDamageCosts = float.Parse(txtPURCFC.Text);
                ffcof.EquipmentOutageMultiplier = float.Parse(txtEOM.Text);
                ffcof.LossProductCost = float.Parse(txtLoPC.Text);
                ffcof.PopDen = float.Parse(txtTuPDoDoE.Text);
                ffcof.InjCost = float.Parse(txtTCAWSIOFOP.Text);
                ffcof.EnviCost = float.Parse(txtECUP.Text);
                ffcofbus.edit(ffcof);
            }
        }
        public void showDataFinalCoF(int ID)//lay database
        {
            RW_FULL_FINALCOF_BUS ffcofbus = new RW_FULL_FINALCOF_BUS();
            RW_FULL_FINALCOF ffcof = ffcofbus.getData(ID);
            txtPURCFC.Text = ffcof.ComponentDamageCosts.ToString();
            //Console.WriteLine("cost= " + ffcof.ComponentDamageCosts);
            txtEOM.Text = ffcof.EquipmentOutageMultiplier.ToString();
            txtLoPC.Text = ffcof.LossProductCost.ToString();
            txtTuPDoDoE.Text = ffcof.PopDen.ToString();
            txtTCAWSIOFOP.Text = ffcof.InjCost.ToString();
            txtECUP.Text = ffcof.EnviCost.ToString();
        }
        private void LoadDataForControlInTabCANomal()
        {
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE();
            MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC();
            MSSQL_CA_CAL_FINAL CA_CAL_FIN = new MSSQL_CA_CAL_FINAL();
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_ASSESSMENT_BUS busass = new RW_ASSESSMENT_BUS();
            //int componentID = ass.ComponentID;
            //Console.WriteLine("id com= " + componentID);
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_MASTER com = buscom.getData(busass.getComponentID(IDProposal));
            //Console.WriteLine("id pro= " + IDProposal);
            int apicomponentID = com.APIComponentTypeID;
            //Console.WriteLine("apicom id= " + apicomponentID);
            API_COMPONENT_TYPE_BUS busapi = new API_COMPONENT_TYPE_BUS();
            API_COMPONENT_TYPE api = busapi.getDatabyID(apicomponentID);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            RW_MATERIAL_BUS busmater = new RW_MATERIAL_BUS();
            RW_MATERIAL mater = busmater.getData(IDProposal);
            RW_FULL_FINALCOF_BUS busfin = new RW_FULL_FINALCOF_BUS();
            RW_FULL_FINALCOF fin = busfin.getData(IDProposal);
            CA_CAL_FLA.FLUID = st.TankFluidName;
            CA_CAL_TOX.FLUID = st.TankFluidName;
            CA_CAL_FIN.FLUID = st.TankFluidName;
            CA_CAL_FLA.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_TOX.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_FIN.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_FLA.FLUID_PHASE = st.StoragePhase;
            CA_CAL_TOX.FLUID_PHASE = st.StoragePhase;
            CA_CAL_FIN.FLUID_PHASE = st.StoragePhase;
            CA_CAL_FLA.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_TOX.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_FIN.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_FLA.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_TOX.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_FIN.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_FLA.IDProposal = IDProposal;
            CA_CAL_TOX.IDProposal = IDProposal;
            CA_CAL_FIN.IDProposal = IDProposal;
            CA_CAL_FLA.STORED_PRESSURE = st.MaxOperatingPressure * 1000;
            CA_CAL_FLA.STORE_TEMP = st.MaxOperatingTemperature;
            CA_CAL_FIN.STORE_TEMP = st.MaxOperatingTemperature;
            CA_CAL_FIN.MATERIAL_COST = mater.CostFactor;
            CA_CAL_FIN.INJURE_COST = fin.InjCost;
            CA_CAL_FIN.PERSON_DENSITY = fin.PopDen;
            CA_CAL_FIN.PRODUCTION_COST = fin.LossProductCost;
            CA_CAL_FIN.Outage_mul = fin.EquipmentOutageMultiplier;
            CA_CAL_FIN.EQUIPMENT_COST = fin.ComponentDamageCosts;
            CA_CAL_FIN.ENVIRON_COST = fin.EnviCost;
            String ReleasePhase = CA_CAL.GET_RELEASE_PHASE();
            txtMaterialcostfactor.Text = mater.CostFactor.ToString();
            switch (CA_CAL_FIN.FLUID)
            {
                case "C6-C8":
                    txtFoFE.Text = "0.9";
                    break;
                case "Acid":
                    txtFoFE.Text = "0.9";
                    break;
                case "C9-C12":
                    txtFoFE.Text = "0.5";
                    break;
                case "C13-C16":
                    txtFoFE.Text = "0.1";
                    break;
                case "C17-C25":
                    txtFoFE.Text = "0.05";
                    break;
                case "C25+":
                    txtFoFE.Text = "0.02";
                    break;
                case "Nitric Acid":
                    txtFoFE.Text = "0.8";
                    break;
                case "NO2":
                case "EE":
                    txtFoFE.Text = "0.75";
                    break;
                case "TDI":
                    txtFoFE.Text = "0.15";
                    break;
                case "Styrene":
                    txtFoFE.Text = "0.6";
                    break;
                case "EEA":
                    txtFoFE.Text = "0.65";
                    break;
                case "EG":
                    txtFoFE.Text = "0.45";
                    break;
                default:
                    txtFoFE.Text = "0";
                    break;
            }
            txtGFF_small.Text = api.GFFSmall.ToString();
            txtGFF_medium.Text = api.GFFMedium.ToString();
            txtGFF_large.Text = api.GFFLarge.ToString();
            txtGFF_rupture.Text = api.GFFRupture.ToString();
            txtCost_small.Text = api.HoleCostSmall.ToString();
            txtCost_medium.Text = api.HoleCostMedium.ToString();
            txtCost_large.Text = api.HoleCostLarge.ToString();
            txtCost_rupture.Text = api.HoleCostRupture.ToString();
            txtOutage_small.Text = api.OutageSmall.ToString();
            txtOutage_medium.Text = api.OutageMedium.ToString();
            txtOutage_large.Text = api.OutageLarge.ToString();
            txtOutage_rupture.Text = api.OutageRupture.ToString();
            txtFinancialcomdamage.Text = CA_CAL_FIN.fc_cmd().ToString();
            txtFinancialdamageSurround.Text = CA_CAL_FIN.fc_affa().ToString();
            txtNoofSurroundingEquip.Text = CA_CAL_FIN.outage_affa().ToString();
            txtFinancialConsequenceLostProduct.Text = CA_CAL_FIN.fc_prod().ToString();
            txtFinancialConsequenceSerious.Text = CA_CAL_FIN.fc_inj(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_FIN.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE()).ToString();
            txtEnvironmentalCost.Text = CA_CAL_FIN.fc_environ().ToString();
            txtNoofDowntimeRepairSpecific.Text = CA_CAL_FIN.outage_cmd().ToString();
            float a = CA_CAL_FIN.fc(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_FIN.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE());
            txtFCoF.Text = a.ToString();
            if (a <= 10000)
            {
                txtCoFC.Text = "A";
            }
            if (a > 10000 && a <= 100000)
            {
                txtCoFC.Text = "B";
            }
            if (a > 100000 && a <= 1000000)
            {
                txtCoFC.Text = "C";
            }
            if (a > 1000000 && a <= 10000000)
            {
                txtCoFC.Text = "D";
            }
            if (a > 10000000)
            {
                txtCoFC.Text = "E";
            }
            //luu vao bang RW_FULL_COF


            rw_full_COF_bus = new RW_FULL_COF_BUS();
            rw_full_COF = new RW_FULL_COF();
            rw_full_COF.ID = id;
            rw_full_COF.CoFValue = float.Parse(txtFCoF.Text);
            if (float.IsNaN(rw_full_COF.CoFValue)) rw_full_COF.CoFValue = 0;
            rw_full_COF.CoFCategory = txtCoFC.Text;
            rw_full_COF.CoFMatrixValue = 0;
            if (rw_full_COF_bus.checkExistCoF(id))
            {
                rw_full_COF_bus.edit(rw_full_COF);
            }
            else rw_full_COF_bus.add(rw_full_COF);
        }
        private void LoadDataForControlInTabArea()
        {
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE();
            MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC();
            MSSQL_CA_CAL_FINAL CA_CAL_FIN = new MSSQL_CA_CAL_FINAL();
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_ASSESSMENT_BUS busass = new RW_ASSESSMENT_BUS();
            //int componentID = ass.ComponentID;
            //Console.WriteLine("id com= " + componentID);
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            COMPONENT_MASTER com = buscom.getData(busass.getComponentID(IDProposal));
            //Console.WriteLine("id pro= " + IDProposal);
            int apicomponentID = com.APIComponentTypeID;
            //Console.WriteLine("apicom id= " + apicomponentID);
            API_COMPONENT_TYPE_BUS busapi = new API_COMPONENT_TYPE_BUS();
            API_COMPONENT_TYPE api = busapi.getDatabyID(apicomponentID);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            RW_MATERIAL_BUS busmater = new RW_MATERIAL_BUS();
            RW_MATERIAL mater = busmater.getData(IDProposal);
            RW_FULL_FINALCOF_BUS busfin = new RW_FULL_FINALCOF_BUS();
            RW_FULL_FINALCOF fin = busfin.getData(IDProposal);
            CA_CAL_FLA.FLUID = st.TankFluidName;
            CA_CAL_TOX.FLUID = st.TankFluidName;
            CA_CAL_FIN.FLUID = st.TankFluidName;
            CA_CAL_FLA.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_TOX.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_FIN.FLUID_TOXIC = st.ToxicFluidName;
            CA_CAL_FLA.FLUID_PHASE = st.StoragePhase;
            CA_CAL_TOX.FLUID_PHASE = st.StoragePhase;
            CA_CAL_FIN.FLUID_PHASE = st.StoragePhase;
            CA_CAL_FLA.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_TOX.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_FIN.TOXIC_PERCENT = (st.ReleaseFluidPercentToxic) / 100;
            CA_CAL_FLA.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_TOX.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_FIN.API_COMPONENT_TYPE_NAME = api.APIComponentTypeName;
            CA_CAL_FLA.IDProposal = IDProposal;
            CA_CAL_TOX.IDProposal = IDProposal;
            CA_CAL_FIN.IDProposal = IDProposal;
            CA_CAL_FLA.STORED_PRESSURE = st.MaxOperatingPressure * 1000;
            CA_CAL_FLA.STORE_TEMP = st.MaxOperatingTemperature;
            CA_CAL_FIN.STORE_TEMP = st.MaxOperatingTemperature;
            CA_CAL_FIN.MATERIAL_COST = mater.CostFactor;
            CA_CAL_FIN.INJURE_COST = fin.InjCost;
            CA_CAL_FIN.PERSON_DENSITY = fin.PopDen;
            CA_CAL_FIN.PRODUCTION_COST = fin.LossProductCost;
            CA_CAL_FIN.Outage_mul = fin.EquipmentOutageMultiplier;
            CA_CAL_FIN.EQUIPMENT_COST = fin.ComponentDamageCosts;
            CA_CAL_FIN.ENVIRON_COST = fin.EnviCost;
            String ReleasePhase = CA_CAL.GET_RELEASE_PHASE();
            if (CA_CAL_FLA.FLUID == "C1-C2" || CA_CAL_FLA.FLUID == "C3-C4" || CA_CAL_FLA.FLUID == "C5" || CA_CAL_FLA.FLUID == "C6-C8" || CA_CAL_FLA.FLUID == "C9-C12" || CA_CAL_FLA.FLUID == "C13-C-16" ||
                    CA_CAL_FLA.FLUID == "C17-C25" || CA_CAL_FLA.FLUID == "C25+" || CA_CAL_FLA.FLUID == "H2" || CA_CAL_FLA.FLUID == "H2S" || CA_CAL_FLA.FLUID == "CO" || CA_CAL_FLA.FLUID == "DEE" ||
                    CA_CAL_FLA.FLUID == "Methanol" || CA_CAL_FLA.FLUID == "PO" || CA_CAL_FLA.FLUID == "Aromatics" || CA_CAL_FLA.FLUID == "Styrene" || CA_CAL_FLA.FLUID == "EEA" || CA_CAL_FLA.FLUID == "EE" ||
                    CA_CAL_FLA.FLUID == "EG" || CA_CAL_FLA.FLUID == "EO" || CA_CAL_FLA.FLUID == "Pyrophoric" || CA_CAL_FLA.FLUID == "Ammonia" || CA_CAL_FLA.FLUID == "Chlorine")
            {
                tabmodel.Text = CA_CAL_FLA.FLUID;
                txtAContAINLCMD_model.Text = CA_CAL_FLA.a_cmd(1).ToString();
                txtAContAILCMD_model.Text = CA_CAL_FLA.a_cmd(2).ToString();
                txtAInstAINLCMD_model.Text = CA_CAL_FLA.a_cmd(3).ToString();
                txtAInstAILCMD_model.Text = CA_CAL_FLA.a_cmd(4).ToString();
                txtBContAINLCMD_model.Text = CA_CAL_FLA.b_cmd(1).ToString();
                txtBContAILCMD_model.Text = CA_CAL_FLA.b_cmd(2).ToString();
                txtBInstAINLCMD_model.Text = CA_CAL_FLA.b_cmd(3).ToString();
                txtBInstAILCMD_model.Text = CA_CAL_FLA.b_cmd(4).ToString();
                txtAContAINLINJ_model.Text = CA_CAL_FLA.a_inj(1).ToString();
                txtAContAILINJ_model.Text = CA_CAL_FLA.a_inj(2).ToString();
                txtAInstAINLINJ_model.Text = CA_CAL_FLA.a_inj(3).ToString();
                txtAInstAILINJ_model.Text = CA_CAL_FLA.a_inj(4).ToString();
                txtBContAINLINJ_model.Text = CA_CAL_FLA.b_inj(1).ToString();
                txtBContAILINJ_model.Text = CA_CAL_FLA.b_inj(2).ToString();
                txtBInstAINLINJ_model.Text = CA_CAL_FLA.b_inj(3).ToString();
                txtBInstAILINJ_model.Text = CA_CAL_FLA.b_inj(4).ToString();

                txtEneffSmall_model.Text = CA_CAL_FLA.eneff_n(1).ToString();
                txtEneffMedium_model.Text = CA_CAL_FLA.eneff_n(2).ToString();
                txtEneffLarge_model.Text = CA_CAL_FLA.eneff_n(3).ToString();
                txtEneffRupture_model.Text = CA_CAL_FLA.eneff_n(4).ToString();

                txtContCMDAINLSmall_model.Text = CA_CAL_FLA.ca_cmdn_cont(1, 1).ToString();
                txtContCMDAINLMedium_model.Text = CA_CAL_FLA.ca_cmdn_cont(1, 2).ToString();
                txtContCMDAINLLarge_model.Text = CA_CAL_FLA.ca_cmdn_cont(1, 3).ToString();
                txtContCMDAINLRupture_model.Text = CA_CAL_FLA.ca_cmdn_cont(1, 4).ToString();
                txtContCMDAILSmall_model.Text = CA_CAL_FLA.ca_cmdn_cont(2, 1).ToString();
                txtContCMDAILMedium_model.Text = CA_CAL_FLA.ca_cmdn_cont(2, 2).ToString();
                txtContCMDAILLarge_model.Text = CA_CAL_FLA.ca_cmdn_cont(2, 3).ToString();
                txtContCMDAILRupture_model.Text = CA_CAL_FLA.ca_cmdn_cont(2, 4).ToString();
                txtInstCMDAINLSmall_model.Text = CA_CAL_FLA.ca_cmdn_inst(3, 1).ToString();
                txtInstCMDAINLMedium_model.Text = CA_CAL_FLA.ca_cmdn_inst(3, 2).ToString();
                txtInstCMDAINLLarge_model.Text = CA_CAL_FLA.ca_cmdn_inst(3, 3).ToString();
                txtInstCMDAINLRupture_model.Text = CA_CAL_FLA.ca_cmdn_inst(3, 4).ToString();
                txtInstCMDAILSmall_model.Text = CA_CAL_FLA.ca_cmdn_inst(4, 1).ToString();
                txtInstCMDAILMedium_model.Text = CA_CAL_FLA.ca_cmdn_inst(4, 2).ToString();
                txtInstCMDAILLarge_model.Text = CA_CAL_FLA.ca_cmdn_inst(4, 3).ToString();
                txtInstCMDAILRupture_model.Text = CA_CAL_FLA.ca_cmdn_inst(4, 4).ToString();
                txtContINJAINLSmall_model.Text = CA_CAL_FLA.ca_injn_cont(1, 1).ToString();
                txtContINJAINLMedium_model.Text = CA_CAL_FLA.ca_injn_cont(1, 2).ToString();
                txtContINJAINLLarge_model.Text = CA_CAL_FLA.ca_injn_cont(1, 3).ToString();
                txtContINJAINLRupture_model.Text = CA_CAL_FLA.ca_injn_cont(1, 4).ToString();
                txtContINJAILSmall_model.Text = CA_CAL_FLA.ca_injn_cont(2, 1).ToString();
                txtContINJAILMedium_model.Text = CA_CAL_FLA.ca_injn_cont(2, 2).ToString();
                txtContINJAILLarge_model.Text = CA_CAL_FLA.ca_injn_cont(2, 3).ToString();
                txtContINJAILRupture_model.Text = CA_CAL_FLA.ca_injn_cont(2, 4).ToString();
                txtInstINJAINLSmall_model.Text = CA_CAL_FLA.ca_injn_inst(3, 1).ToString();
                txtInstINJAINLMedium_model.Text = CA_CAL_FLA.ca_injn_inst(3, 2).ToString();
                txtInstINJAINLLarge_model.Text = CA_CAL_FLA.ca_injn_inst(3, 3).ToString();
                txtInstINJAINLRupture_model.Text = CA_CAL_FLA.ca_injn_inst(3, 4).ToString();
                txtInstINJAILSmall_model.Text = CA_CAL_FLA.ca_injn_inst(4, 1).ToString();
                txtInstINJAILMedium_model.Text = CA_CAL_FLA.ca_injn_inst(4, 2).ToString();
                txtInstINJAILLarge_model.Text = CA_CAL_FLA.ca_injn_inst(4, 3).ToString();
                txtInstINJAILRupture_model.Text = CA_CAL_FLA.ca_injn_inst(4, 4).ToString();

                txtBlendFactorSmall_model.Text = CA_CAL_FLA.fact_n_ic(1).ToString();
                txtBlendFactorMedium_model.Text = CA_CAL_FLA.fact_n_ic(2).ToString();
                txtBlendFactorLarge_model.Text = CA_CAL_FLA.fact_n_ic(3).ToString();
                txtBlendFactorRupture_model.Text = CA_CAL_FLA.fact_n_ic(4).ToString();
                txtBlendCMDAINLSmall_model.Text = CA_CAL_FLA.ca_cmdn_ainl(1).ToString();
                txtBlendCMDAINLMedium_model.Text = CA_CAL_FLA.ca_cmdn_ainl(2).ToString();
                txtBlendCMDAINLLarge_model.Text = CA_CAL_FLA.ca_cmdn_ainl(3).ToString();
                txtBlendCMDAINLRupture_model.Text = CA_CAL_FLA.ca_cmdn_ainl(4).ToString();
                txtBlendCMDAILSmall_model.Text = CA_CAL_FLA.ca_cmdn_ail(1).ToString();
                txtBlendCMDAILMedium_model.Text = CA_CAL_FLA.ca_cmdn_ail(2).ToString();
                txtBlendCMDAILLarge_model.Text = CA_CAL_FLA.ca_cmdn_ail(3).ToString();
                txtBlendCMDAILRupture_model.Text = CA_CAL_FLA.ca_cmdn_ail(4).ToString();
                txtBlendINJAINLSmall_model.Text = CA_CAL_FLA.ca_injn_ainl(1).ToString();
                txtBlendINJAINLMedium_model.Text = CA_CAL_FLA.ca_injn_ainl(2).ToString();
                txtBlendINJAINLLarge_model.Text = CA_CAL_FLA.ca_injn_ainl(3).ToString();
                txtBlendINJAINLRupture_model.Text = CA_CAL_FLA.ca_injn_ainl(4).ToString();
                txtBlendINJAILSmall_model.Text = CA_CAL_FLA.ca_inji_ail(1).ToString();
                txtBlendINJAILMedium_model.Text = CA_CAL_FLA.ca_inji_ail(2).ToString();
                txtBlendINJAILLarge_model.Text = CA_CAL_FLA.ca_inji_ail(3).ToString();
                txtBlendINJAILRupture_model.Text = CA_CAL_FLA.ca_inji_ail(4).ToString();
                txtAITBlendCMDSmall_model.Text = CA_CAL_FLA.ca_cmdn_ait(1).ToString();
                txtAITBlendCMDMedium_model.Text = CA_CAL_FLA.ca_cmdn_ait(2).ToString();
                txtAITBlendCMDLarge_model.Text = CA_CAL_FLA.ca_cmdn_ait(3).ToString();
                txtAITBlendCMDRupture_model.Text = CA_CAL_FLA.ca_cmdn_ait(4).ToString();
                txtAITBlendINJSmall_model.Text = CA_CAL_FLA.ca_injn_ait(1).ToString();
                txtAITBlendINJMedium_model.Text = CA_CAL_FLA.ca_injn_ait(2).ToString();
                txtAITBlendINJLarge_model.Text = CA_CAL_FLA.ca_injn_ait(3).ToString();
                txtAITBlendINJRupture_model.Text = CA_CAL_FLA.ca_injn_ait(4).ToString();
                txtFlammableCDCA_model.Text = CA_CAL_FLA.ca_cmd_flame().ToString();
                txtFlammablePICA_model.Text = CA_CAL_FLA.ca_inj_flame().ToString();

            }

            else
            {
                tabmodel.PageVisible = false;
            }


            // Toxic             

            if (CA_CAL_FLA.FLUID_TOXIC == "H2S" || CA_CAL_FLA.FLUID_TOXIC == "CO" || CA_CAL_FLA.FLUID_TOXIC == "PO" || CA_CAL_FLA.FLUID_TOXIC == "EE" || CA_CAL_FLA.FLUID_TOXIC == "EO" || CA_CAL_FLA.FLUID_TOXIC == "Pyrophoric")
            {
                tabtoxic.Text = CA_CAL_FLA.FLUID_TOXIC;
                txtAContAINLCMD_toxic.Text = CA_CAL_FLA.a_cmd_toxic(1).ToString();
                txtAContAILCMD_toxic.Text = CA_CAL_FLA.a_cmd_toxic(2).ToString();
                txtAInstAINLCMD_toxic.Text = CA_CAL_FLA.a_cmd_toxic(3).ToString();
                txtAInstAILCMD_toxic.Text = CA_CAL_FLA.a_cmd_toxic(4).ToString();
                txtBContAINLCMD_toxic.Text = CA_CAL_FLA.b_cmd_toxic(1).ToString();
                txtBContAILCMD_toxic.Text = CA_CAL_FLA.b_cmd_toxic(2).ToString();
                txtBInstAINLCMD_toxic.Text = CA_CAL_FLA.b_cmd_toxic(3).ToString();
                txtBInstAILCMD_toxic.Text = CA_CAL_FLA.b_cmd_toxic(4).ToString();
                txtAContAINLINJ_toxic.Text = CA_CAL_FLA.a_inj_toxic(1).ToString();
                txtAContAILINJ_toxic.Text = CA_CAL_FLA.a_inj_toxic(2).ToString();
                txtAInstAINLINJ_toxic.Text = CA_CAL_FLA.a_inj_toxic(3).ToString();
                txtAInstAILINJ_toxic.Text = CA_CAL_FLA.a_inj_toxic(4).ToString();
                txtBContAINLINJ_toxic.Text = CA_CAL_FLA.b_inj_toxic(1).ToString();
                txtBContAILINJ_toxic.Text = CA_CAL_FLA.b_inj_toxic(2).ToString();
                txtBInstAINLINJ_toxic.Text = CA_CAL_FLA.b_inj_toxic(3).ToString();
                txtBInstAILINJ_toxic.Text = CA_CAL_FLA.b_inj_toxic(4).ToString();

                txtEneffSmall_toxic.Text = CA_CAL_FLA.eneff_n(1).ToString();
                txtEneffMedium_toxic.Text = CA_CAL_FLA.eneff_n(2).ToString();
                txtEneffLarge_toxic.Text = CA_CAL_FLA.eneff_n(3).ToString();
                txtEneffRupture_toxic.Text = CA_CAL_FLA.eneff_n(4).ToString();

                txtContCMDAINLSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(1, 1).ToString();
                txtContCMDAINLMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(1, 2).ToString();
                txtContCMDAINLLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(1, 3).ToString();
                txtContCMDAINLRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(1, 4).ToString();
                txtContCMDAILSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(2, 1).ToString();
                txtContCMDAILMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(2, 2).ToString();
                txtContCMDAILLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(2, 3).ToString();
                txtContCMDAILRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_cont_toxic(2, 4).ToString();
                txtInstCMDAINLSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(3, 1).ToString();
                txtInstCMDAINLMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(3, 2).ToString();
                txtInstCMDAINLLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(3, 3).ToString();
                txtInstCMDAINLRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(3, 4).ToString();
                txtInstCMDAILSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(4, 1).ToString();
                txtInstCMDAILMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(4, 2).ToString();
                txtInstCMDAILLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(4, 3).ToString();
                txtInstCMDAILRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_inst_toxic(4, 4).ToString();
                txtContINJAINLSmall_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(1, 1).ToString();
                txtContINJAINLMedium_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(1, 2).ToString();
                txtContINJAINLLarge_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(1, 3).ToString();
                txtContINJAINLRupture_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(1, 4).ToString();
                txtContINJAILSmall_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(2, 1).ToString();
                txtContINJAILMedium_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(2, 2).ToString();
                txtContINJAILLarge_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(2, 3).ToString();
                txtContINJAILRupture_toxic.Text = CA_CAL_FLA.ca_injn_cont_toxic(2, 4).ToString();
                txtInstINJAINLSmall_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(3, 1).ToString();
                txtInstINJAINLMedium_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(3, 2).ToString();
                txtInstINJAINLLarge_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(3, 3).ToString();
                txtInstINJAINLRupture_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(3, 4).ToString();
                txtInstINJAILSmall_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(4, 1).ToString();
                txtInstINJAILMedium_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(4, 2).ToString();
                txtInstINJAILLarge_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(4, 3).ToString();
                txtInstINJAILRupture_toxic.Text = CA_CAL_FLA.ca_injn_inst_toxic(4, 4).ToString();

                txtBlendFactorSmall_toxic.Text = CA_CAL_FLA.fact_n_ic(1).ToString();
                txtBlendFactorMedium_toxic.Text = CA_CAL_FLA.fact_n_ic(2).ToString();
                txtBlendFactorLarge_toxic.Text = CA_CAL_FLA.fact_n_ic(3).ToString();
                txtBlendFactorRupture_toxic.Text = CA_CAL_FLA.fact_n_ic(4).ToString();
                txtBlendCMDAINLSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_ainl_toxic(1).ToString();
                txtBlendCMDAINLMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_ainl_toxic(2).ToString();
                txtBlendCMDAINLLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_ainl_toxic(3).ToString();
                txtBlendCMDAINLRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_ainl_toxic(4).ToString();
                txtBlendCMDAILSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_ail_toxic(1).ToString();
                txtBlendCMDAILMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_ail_toxic(2).ToString();
                txtBlendCMDAILLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_ail_toxic(3).ToString();
                txtBlendCMDAILRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_ail_toxic(4).ToString();
                txtBlendINJAINLSmall_toxic.Text = CA_CAL_FLA.ca_injn_ainl_toxic(1).ToString();
                txtBlendINJAINLMedium_toxic.Text = CA_CAL_FLA.ca_injn_ainl_toxic(2).ToString();
                txtBlendINJAINLLarge_toxic.Text = CA_CAL_FLA.ca_injn_ainl_toxic(3).ToString();
                txtBlendINJAINLRupture_toxic.Text = CA_CAL_FLA.ca_injn_ainl_toxic(4).ToString();
                txtBlendINJAILSmall_toxic.Text = CA_CAL_FLA.ca_inji_ail_toxic(1).ToString();
                txtBlendINJAILMedium_toxic.Text = CA_CAL_FLA.ca_inji_ail_toxic(2).ToString();
                txtBlendINJAILLarge_toxic.Text = CA_CAL_FLA.ca_inji_ail_toxic(3).ToString();
                txtBlendINJAILRupture_toxic.Text = CA_CAL_FLA.ca_inji_ail_toxic(4).ToString();
                txtAITBlendCMDSmall_toxic.Text = CA_CAL_FLA.ca_cmdn_ait_toxic(1).ToString();
                txtAITBlendCMDMedium_toxic.Text = CA_CAL_FLA.ca_cmdn_ait_toxic(2).ToString();
                txtAITBlendCMDLarge_toxic.Text = CA_CAL_FLA.ca_cmdn_ait_toxic(3).ToString();
                txtAITBlendCMDRupture_toxic.Text = CA_CAL_FLA.ca_cmdn_ait_toxic(4).ToString();
                txtAITBlendINJSmall_toxic.Text = CA_CAL_FLA.ca_injn_ait_toxic(1).ToString();
                txtAITBlendINJMedium_toxic.Text = CA_CAL_FLA.ca_injn_ait_toxic(2).ToString();
                txtAITBlendINJLarge_toxic.Text = CA_CAL_FLA.ca_injn_ait_toxic(3).ToString();
                txtAITBlendINJRupture_toxic.Text = CA_CAL_FLA.ca_injn_ait_toxic(4).ToString();
                txtFlammableCDCA_toxic.Text = CA_CAL_FLA.ca_cmd_flame_toxic().ToString();
                txtFlammablePICA_toxic.Text = CA_CAL_FLA.ca_inj_flame_toxic().ToString();
            }
            else
            {
                tabtoxic.PageVisible = false;
            }

            //Toxic Consequence
            txtLDToxicSmall_toxic1.Text = CA_CAL_TOX.toxic_leak_duration(1).ToString();
            txtLDToxicMedium_toxic1.Text = CA_CAL_TOX.toxic_leak_duration(2).ToString();
            txtLDToxicLarge_toxic1.Text = CA_CAL_TOX.toxic_leak_duration(3).ToString();
            txtLDToxicRupture_toxic1.Text = CA_CAL_TOX.toxic_leak_duration(4).ToString();
            txtLDToxicSmall_toxic2.Text = CA_CAL_TOX.toxic_leak_duration(1).ToString();
            txtLDToxicMedium_toxic2.Text = CA_CAL_TOX.toxic_leak_duration(2).ToString();
            txtLDToxicLarge_toxic2.Text = CA_CAL_TOX.toxic_leak_duration(3).ToString();
            txtLDToxicRupture_toxic2.Text = CA_CAL_TOX.toxic_leak_duration(4).ToString();
            txtMassRateSmall_toxic1.Text = CA_CAL_TOX.rate_tox_n(1).ToString();
            txtMassRateMedium_toxic1.Text = CA_CAL_TOX.rate_tox_n(2).ToString();
            txtMassRateLarge_toxic1.Text = CA_CAL_TOX.rate_tox_n(3).ToString();
            txtMassRateRupture_toxic1.Text = CA_CAL_TOX.rate_tox_n(4).ToString();
            txtMassSmall_toxic1.Text = CA_CAL_TOX.mass_tox_n(1).ToString();
            txtMassMedium_toxic1.Text = CA_CAL_TOX.mass_tox_n(2).ToString();
            txtMassLarge_toxic1.Text = CA_CAL_TOX.mass_tox_n(3).ToString();
            txtMassRupture_toxic1.Text = CA_CAL_TOX.mass_tox_n(4).ToString();
            txtMassRateSmall_toxic2.Text = CA_CAL_TOX.rate_tox_n(1).ToString();
            txtMassRateMedium_toxic2.Text = CA_CAL_TOX.rate_tox_n(2).ToString();
            txtMassRateLarge_toxic2.Text = CA_CAL_TOX.rate_tox_n(3).ToString();
            txtMassRateRupture_toxic2.Text = CA_CAL_TOX.rate_tox_n(4).ToString();
            txtMassSmall_toxic2.Text = CA_CAL_TOX.mass_tox_n(1).ToString();
            txtMassMedium_toxic2.Text = CA_CAL_TOX.mass_tox_n(2).ToString();
            txtMassLarge_toxic2.Text = CA_CAL_TOX.mass_tox_n(3).ToString();
            txtMassRupture_toxic2.Text = CA_CAL_TOX.mass_tox_n(4).ToString();


            if (CA_CAL_TOX.FLUID == "HFAcid" || CA_CAL_TOX.FLUID == "H2S" || CA_CAL_TOX.FLUID == "Ammonia" || CA_CAL_TOX.FLUID == "Chlorine")
            {
                tabToxic1.Text = CA_CAL_TOX.FLUID;
                txtContCSmall_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID, 1).c.ToString();
                txtContCMedium_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID, 2).c.ToString();
                txtContCLarge_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID, 3).c.ToString();
                txtContCRupture_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID, 4).c.ToString();
                txtContDSmall_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID, 1).d.ToString();
                txtContDMedium_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID, 2).d.ToString();
                txtContDLarge_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID, 3).d.ToString();
                txtContDRupture_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID, 4).d.ToString();
                txtContESmall_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID, 1).e.ToString();
                txtContEMedium_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID, 2).e.ToString();
                txtContELarge_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID, 3).e.ToString();
                txtContERupture_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID, 4).e.ToString();
                txtContFSmall_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID, 1).f.ToString();
                txtContFMedium_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID, 2).f.ToString();
                txtContFLarge_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID, 3).f.ToString();
                txtContFRupture_toxic1.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID, 4).f.ToString();
                txtToxicCASmall_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_1, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE(), 1).ToString();
                txtToxicCAMedium_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_2, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE(), 2).ToString();
                txtToxicCALarge_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_3, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE(), 3).ToString();
                txtToxicCARupture_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_4, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE(), 4).ToString();
                txtFlammalbePICA_toxic1.Text = CA_CAL_TOX.ca_inj_tox(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE()).ToString();
            }
            else if (CA_CAL_TOX.FLUID == "AlCl3" || CA_CAL_TOX.FLUID == "CO" || CA_CAL_TOX.FLUID == "HCl" || CA_CAL_TOX.FLUID == "Nitric Acid" ||
                    CA_CAL_TOX.FLUID == "NO2" || CA_CAL_TOX.FLUID == "Phosgene" || CA_CAL_TOX.FLUID == "TDI" || CA_CAL_TOX.FLUID == "EE" || CA_CAL_TOX.FLUID == "EO" || CA_CAL_TOX.FLUID == "PO")
            {
                tabToxic1.Text = CA_CAL_TOX.FLUID;
                txtContCSmall_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 1).c.ToString();
                txtContCMedium_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 2).c.ToString();
                txtContCLarge_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 3).c.ToString();
                txtContCRupture_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 4).c.ToString();
                txtContDSmall_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 1).d.ToString();
                txtContDMedium_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 2).d.ToString();
                txtContDLarge_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 3).d.ToString();
                txtContDRupture_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 4).d.ToString();
                txtContESmall_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 1).e.ToString();
                txtContEMedium_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 2).e.ToString();
                txtContELarge_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 3).e.ToString();
                txtContERupture_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 4).e.ToString();
                txtContFSmall_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 1).f.ToString();
                txtContFMedium_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 2).f.ToString();
                txtContFLarge_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 3).f.ToString();
                txtContFRupture_toxic1.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID, 4).f.ToString();
                txtToxicCASmall_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_1, CA_CAL_TOX.FLUID, CA_CAL_TOX.GET_RELEASE_PHASE(), 1).ToString();
                txtToxicCAMedium_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_2, CA_CAL_TOX.FLUID, CA_CAL_TOX.GET_RELEASE_PHASE(), 2).ToString();
                txtToxicCALarge_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_3, CA_CAL_TOX.FLUID, CA_CAL_TOX.GET_RELEASE_PHASE(), 3).ToString();
                txtToxicCARupture_toxic1.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_4, CA_CAL_TOX.FLUID, CA_CAL_TOX.GET_RELEASE_PHASE(), 4).ToString();
                txtFlammalbePICA_toxic1.Text = CA_CAL_TOX.ca_inj_tox(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_TOX.FLUID, CA_CAL.GET_RELEASE_PHASE()).ToString();
            }
            else
            {
                tabToxic1.PageVisible = false;
            }
            if (CA_CAL_TOX.FLUID_TOXIC == "HFAcid" || CA_CAL_TOX.FLUID_TOXIC == "H2S" || CA_CAL_TOX.FLUID_TOXIC == "Ammonia" || CA_CAL_TOX.FLUID_TOXIC == "Chlorine")
            {
                tabToxic2.Text = CA_CAL_TOX.FLUID_TOXIC;
                txtContCSmall_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, 1).c.ToString();
                txtContCMedium_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, 2).c.ToString();
                txtContCLarge_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, 3).c.ToString();
                txtContCRupture_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, 4).c.ToString();
                txtContDSmall_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, 1).d.ToString();
                txtContDMedium_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, 2).d.ToString();
                txtContDLarge_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, 3).d.ToString();
                txtContDRupture_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, 4).d.ToString();
                txtContESmall_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, 1).e.ToString();
                txtContEMedium_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, 2).e.ToString();
                txtContELarge_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, 3).e.ToString();
                txtContERupture_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, 4).e.ToString();
                txtContFSmall_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, 1).f.ToString();
                txtContFMedium_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, 2).f.ToString();
                txtContFLarge_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, 3).f.ToString();
                txtContFRupture_toxic2.Text = CA_CAL_TOX.getToxic(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, 4).f.ToString();
                txtToxicCASmall_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE(), 1).ToString();
                txtToxicCAMedium_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE(), 2).ToString();
                txtToxicCALarge_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE(), 3).ToString();
                txtToxicCARupture_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE(), 4).ToString();
                txtFlammalbePICA_toxic2.Text = CA_CAL_TOX.ca_inj_tox(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, CA_CAL.GET_RELEASE_PHASE()).ToString();
            }
            else if (CA_CAL_TOX.FLUID_TOXIC == "AlCl3" || CA_CAL_TOX.FLUID_TOXIC == "CO" || CA_CAL_TOX.FLUID_TOXIC == "HCl" || CA_CAL_TOX.FLUID_TOXIC == "Nitric Acid" ||
                    CA_CAL_TOX.FLUID_TOXIC == "NO2" || CA_CAL_TOX.FLUID_TOXIC == "Phosgene" || CA_CAL_TOX.FLUID_TOXIC == "TDI" || CA_CAL_TOX.FLUID_TOXIC == "EE" || CA_CAL_TOX.FLUID_TOXIC == "EO" || CA_CAL_TOX.FLUID_TOXIC == "PO")
            {
                tabToxic2.Text = CA_CAL_TOX.FLUID_TOXIC;
                txtContCSmall_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 1).c.ToString();
                txtContCMedium_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 2).c.ToString();
                txtContCLarge_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 3).c.ToString();
                txtContCRupture_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 4).c.ToString();
                txtContDSmall_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 1).d.ToString();
                txtContDMedium_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 2).d.ToString();
                txtContDLarge_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 3).d.ToString();
                txtContDRupture_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 4).d.ToString();
                txtContESmall_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 1).e.ToString();
                txtContEMedium_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 2).e.ToString();
                txtContELarge_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 3).e.ToString();
                txtContERupture_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 4).e.ToString();
                txtContFSmall_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 1).f.ToString();
                txtContFMedium_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 2).f.ToString();
                txtContFLarge_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 3).f.ToString();
                txtContFRupture_toxic2.Text = CA_CAL_TOX.getToxic513(CA_CAL_TOX.GET_RELEASE_PHASE(), CA_CAL_TOX.FLUID_TOXIC, 4).f.ToString();
                txtToxicCASmall_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_1, CA_CAL_TOX.FLUID_TOXIC, CA_CAL_TOX.GET_RELEASE_PHASE(), 1).ToString();
                txtToxicCAMedium_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_2, CA_CAL_TOX.FLUID_TOXIC, CA_CAL_TOX.GET_RELEASE_PHASE(), 2).ToString();
                txtToxicCALarge_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_3, CA_CAL_TOX.FLUID_TOXIC, CA_CAL_TOX.GET_RELEASE_PHASE(), 3).ToString();
                txtToxicCARupture_toxic2.Text = CA_CAL_TOX.ca_injn_tox(hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, CA_CAL_TOX.GET_RELEASE_PHASE(), 4).ToString();
                txtFlammalbePICA_toxic2.Text = CA_CAL_TOX.ca_inj_tox(hole.ReleaseType_1, hole.ReleaseType_2, hole.ReleaseType_3, hole.ReleaseType_4, CA_CAL_TOX.FLUID_TOXIC, CA_CAL_TOX.GET_RELEASE_PHASE()).ToString();
            }
            else
            {
                tabToxic2.PageVisible = false;
            }


            //Non F Non T
            if (CA_CAL_FLA.FLUID == "Water" || CA_CAL_FLA.FLUID == "Steam" || CA_CAL_FLA.FLUID == "Water" || CA_CAL_FLA.FLUID == "Acid" || CA_CAL_FLA.FLUID == "Caustic")
            {
                txtCONT_CA1.Text = CA_CAL_FLA.ca_injn_contnfnt(1).ToString();
                txtCONT_CA2.Text = CA_CAL_FLA.ca_injn_contnfnt(2).ToString();
                txtCONT_CA3.Text = CA_CAL_FLA.ca_injn_contnfnt(3).ToString();
                txtCONT_CA4.Text = CA_CAL_FLA.ca_injn_contnfnt(4).ToString();
                txtINST_CA1.Text = CA_CAL_FLA.ca_injn_instnfnt(1).ToString();
                txtINST_CA2.Text = CA_CAL_FLA.ca_injn_instnfnt(2).ToString();
                txtINST_CA3.Text = CA_CAL_FLA.ca_injn_instnfnt(3).ToString();
                txtINST_CA4.Text = CA_CAL_FLA.ca_injn_instnfnt(4).ToString();
                txtBlend_CA1.Text = CA_CAL_FLA.fact_n_icnfnt(1).ToString();
                txtBlend_CA2.Text = CA_CAL_FLA.fact_n_icnfnt(2).ToString();
                txtBlend_CA3.Text = CA_CAL_FLA.fact_n_icnfnt(3).ToString();
                txtBlend_CA4.Text = CA_CAL_FLA.fact_n_icnfnt(4).ToString();
                txtNonFlammableNonToxicCon.Text = CA_CAL_FLA.ca_inj_nfnt().ToString();
            }
            else
            {
                panelNonTF.Visible = false;
            }
            float cdcd_model = float.Parse(String.IsNullOrEmpty(txtFlammableCDCA_model.Text) ? "0" : txtFlammableCDCA_model.Text);
            float pica_model = float.Parse(String.IsNullOrEmpty(txtFlammablePICA_model.Text) ? "0" : txtFlammablePICA_model.Text);
            float cdcd_toxic = float.Parse(String.IsNullOrEmpty(txtFlammableCDCA_toxic.Text) ? "0" : txtFlammableCDCA_toxic.Text);
            float pica_toxic = float.Parse(String.IsNullOrEmpty(txtFlammablePICA_toxic.Text) ? "0" : txtFlammablePICA_toxic.Text);
            float pica_toxic1 =float.Parse(String.IsNullOrEmpty(txtFlammalbePICA_toxic1.Text) ? "0" : txtFlammalbePICA_toxic1.Text);
            float pica_toxic2 = float.Parse(String.IsNullOrEmpty(txtFlammalbePICA_toxic2.Text) ? "0" : txtFlammalbePICA_toxic2.Text);
            float nfnt = float.Parse(String.IsNullOrEmpty(txtNonFlammableNonToxicCon.Text) ? "0" : txtNonFlammableNonToxicCon.Text);
            float max1 = Math.Max(cdcd_model, pica_model);
            float max2 = Math.Max(cdcd_toxic, pica_toxic);
            float max3 = Math.Max(pica_toxic1, pica_toxic2);
            float max4 = Math.Max(max1, Math.Max(max2, max3));
            float ca = Math.Max(max4, nfnt);
            txtCA1.Text = ca.ToString();
            if (ca <= 9.29) txtCA2.Text = "A";
            else if (ca > 9.29 && ca <= 92.9) txtCA2.Text = "B";
            else if (ca > 92.9 && ca <= 929) txtCA2.Text = "C";
            else if (ca > 929 && ca <= 9290) txtCA2.Text = "D";
            else if (ca > 9290) txtCA2.Text = "E";

        }
        private void tabRisk_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabRisk.SelectedTabPage.Name == "TabArea")
            #region tabarea
            {
                showDataTabArea(id);
                LoadDataForControlInTabArea();
                //Model
                
            }
            #endregion
            if (tabRisk.SelectedTabPage.Name == "tabCAnormal")
            {
                
                showDataFinalCoF(id);
                LoadDataForControlInTabCANomal();
                 
            }
            
        }

        
       
        private void LoadDataForControlInTabCATankShell(int i)
        {
            RW_FULL_COF_TANK_BUS inputTankBus = new RW_FULL_COF_TANK_BUS();
            RW_FULL_COF_TANK inputCaTank = inputTankBus.getData(IDProposal);
            
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_STREAM obj = SteamBus.getData(IDProposal);
            
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS busComponentMaster = new COMPONENT_MASTER_BUS();
            COMPONENT_TYPE__BUS busComponentType = new COMPONENT_TYPE__BUS();
            API_COMPONENT_TYPE_BUS busApiComponentType = new API_COMPONENT_TYPE_BUS();

            int[] eq_comID = busAssessment.getEquipmentID_ComponentID(IDProposal);
            COMPONENT_MASTER componentMaster = busComponentMaster.getData(eq_comID[1]);
            String componentTypeName = busComponentType.getComponentTypeName(componentMaster.ComponentTypeID);
            int APICompID = componentMaster.APIComponentTypeID;
            string apiComName = busApiComponentType.getAPIComponentTypeName(APICompID);

            RW_INPUT_CA_TANK inputTank = new RW_INPUT_CA_TANK();
            RW_INPUT_CA_TANK_BUS busInputTank = new RW_INPUT_CA_TANK_BUS();
            inputTank = busInputTank.getData(IDProposal);
            MSSQL_CA_CAL CA = new MSSQL_CA_CAL();
            CA.API_COMPONENT_TYPE_NAME = apiComName;
            CA.releaseFluidPercentToxic = obj.H2SInWater / 1000000;
            CA.TANK_DIAMETER = inputTank.TANK_DIAMETTER;
            CA.FLUID_HEIGHT = inputTank.FLUID_HEIGHT;
            CA.Soil_type = inputTank.Soil_Type; 
            CA.TANK_FLUID = inputTank.TANK_FLUID; 
            CA.SHELL_COURSE_HEIGHT = inputTank.SHELL_COURSE_HEIGHT;
            CA.PREVENTION_BARRIER = inputTank.Prevention_Barrier == 1 ? true : false;
            CA.EnvironSensitivity = inputTank.Environ_Sensitivity;
            CA.P_lvdike = inputTank.P_lvdike;
            CA.P_offsite = inputTank.P_offsite;
            CA.P_onsite = inputTank.P_onsite;
            CA.COMPONENT_TYPE_NAME = "Shell";
            CA.FLUID = inputTank.API_FLUID;

            RW_CA_TANK_BUS rwCaTankBus = new RW_CA_TANK_BUS();
            RW_CA_TANK rwCaTank = rwCaTankBus.getData(IDProposal);
            CA.MATERIAL_COST = rwCaTank.Material_Factor;

            txtA1.Text = CA.getEquationConstants(0).ToString();
            txtA2.Text = CA.getEquationConstants(2).ToString();
            txtA3.Text = CA.getEquationConstants(4).ToString();
            txtA4.Text = CA.getEquationConstants(6).ToString();
            txtB1.Text = CA.getEquationConstants(1).ToString();
            txtB2.Text = CA.getEquationConstants(3).ToString();
            txtB3.Text = CA.getEquationConstants(5).ToString();
            txtB4.Text = CA.getEquationConstants(7).ToString();
            txtReleaseRateD1.Text = CA.rate_Flammable(1).ToString();
            txtReleaseRateD2.Text = CA.rate_Flammable(2).ToString();
            txtReleaseRateD3.Text = CA.rate_Flammable(3).ToString();
            txtReleaseRateD4.Text = CA.rate_Flammable(4).ToString();
            txtCONT_CMD_AINL_D1.Text = CA.AINL_Cmd(1).ToString();
            txtCONT_CMD_AINL_D2.Text = CA.AINL_Cmd(2).ToString();
            txtCONT_CMD_AINL_D3.Text = CA.AINL_Cmd(3).ToString();
            txtCONT_CMD_AINL_D4.Text = CA.AINL_Cmd(4).ToString();
            txtCONT_CMD_AIL_D1.Text = CA.AIL_Cmd(1).ToString();
            txtCONT_CMD_AIL_D2.Text = CA.AIL_Cmd(2).ToString();
            txtCONT_CMD_AIL_D3.Text = CA.AIL_Cmd(3).ToString();
            txtCONT_CMD_AIL_D4.Text = CA.AIL_Cmd(4).ToString();
            txtCONT_INJ_AINL_D1.Text = CA.AINL_Inj(1).ToString();
            txtCONT_INJ_AINL_D2.Text = CA.AINL_Inj(2).ToString();
            txtCONT_INJ_AINL_D3.Text = CA.AINL_Inj(3).ToString();
            txtCONT_INJ_AINL_D4.Text = CA.AINL_Inj(4).ToString();
            txtCONT_INJ_AIL_D1.Text = CA.AIL_Inj(1).ToString();
            txtCONT_INJ_AIL_D2.Text = CA.AIL_Inj(2).ToString();
            txtCONT_INJ_AIL_D3.Text = CA.AIL_Inj(3).ToString();
            txtCONT_INJ_AIL_D4.Text = CA.AIL_Inj(4).ToString();
            txtBlended_CMD_AINL_D1.Text = txtAIT_Blended_CMD_D1.Text = txtCONT_CMD_AINL_D1.Text;
            txtBlended_CMD_AINL_D2.Text = txtAIT_Blended_CMD_D2.Text = txtCONT_CMD_AINL_D2.Text;
            txtBlended_CMD_AINL_D3.Text = txtAIT_Blended_CMD_D3.Text = txtCONT_CMD_AINL_D3.Text;
            txtBlended_CMD_AINL_D4.Text = txtAIT_Blended_CMD_D4.Text = txtCONT_CMD_AINL_D4.Text;
            txtBlended_CMD_AIL_D1.Text = txtCONT_CMD_AIL_D1.Text;
            txtBlended_CMD_AIL_D2.Text = txtCONT_CMD_AIL_D2.Text;
            txtBlended_CMD_AIL_D3.Text = txtCONT_CMD_AIL_D3.Text;
            txtBlended_CMD_AIL_D4.Text = txtCONT_CMD_AIL_D4.Text;
            txtBlended_INJ_AINL_D1.Text = txtAIT_Blended_INJ_D1.Text = txtCONT_INJ_AINL_D1.Text;
            txtBlended_INJ_AINL_D2.Text = txtAIT_Blended_INJ_D2.Text = txtCONT_INJ_AINL_D2.Text;
            txtBlended_INJ_AINL_D3.Text = txtAIT_Blended_INJ_D3.Text = txtCONT_INJ_AINL_D3.Text;
            txtBlended_INJ_AINL_D4.Text = txtAIT_Blended_INJ_D4.Text = txtCONT_INJ_AINL_D4.Text;
            txtBlended_INJ_AIL_D1.Text = txtCONT_INJ_AIL_D1.Text;
            txtBlended_INJ_AIL_D2.Text = txtCONT_INJ_AIL_D2.Text;
            txtBlended_INJ_AIL_D3.Text = txtCONT_INJ_AIL_D3.Text;
            txtBlended_INJ_AIL_D4.Text = txtCONT_INJ_AIL_D4.Text;
            txtFlammableComponentDamage.Text = CA.ca_cmd_flame_shell().ToString();
            txtFlammablePersonelInjury.Text = CA.ca_inj_flame_shell().ToString();

            txtToxicLeakDurationD1.Text = CA.leakDurationToxic(1).ToString();
            txtToxicLeakDurationD2.Text = CA.leakDurationToxic(2).ToString();
            txtToxicLeakDurationD3.Text = CA.leakDurationToxic(3).ToString();
            txtToxicLeakDurationD4.Text = CA.leakDurationToxic(4).ToString();
            txtToxicReleaseMassD1.Text = CA.releaseRateMass(1).ToString();
            txtToxicReleaseMassD2.Text = CA.releaseRateMass(2).ToString();
            txtToxicReleaseMassD3.Text = CA.releaseRateMass(3).ToString();
            txtToxicReleaseMassD4.Text = CA.releaseRateMass(4).ToString();
            txtCinD1.Text = CA.ConstC(1).ToString();
            txtCinD2.Text = CA.ConstC(2).ToString();
            txtCinD3.Text = CA.ConstC(3).ToString();
            txtCinD4.Text = CA.ConstC(4).ToString();
            txtDinD1.Text = CA.ConstD(1).ToString();
            txtDinD2.Text = CA.ConstD(2).ToString();
            txtDinD3.Text = CA.ConstD(3).ToString();
            txtDinD4.Text = CA.ConstD(4).ToString();
            txtToxicCAD1.Text = CA.toxic_Inj(1).ToString();
            txtToxicCAD2.Text = CA.toxic_Inj(2).ToString();
            txtToxicCAD3.Text = CA.toxic_Inj(3).ToString();
            txtToxicCAD4.Text = CA.toxic_Inj(4).ToString();
            txtToxicConsequence.Text = CA.total_toxic_Inj().ToString();

            txtFinalComponentDamageShell.Text = CA.ca_cmd_shell().ToString();
            txtFinalPersonelInjuryShell.Text = CA.ca_inj_shell().ToString();
            txtFinalConsequenceShell.Text = CA.Final_consequence_shell().ToString();

            CA.EQUIPMENT_COST = inputCaTank.equipcost;// Process unit replacement costs for component
            CA.Outage_mul = inputCaTank.EquipOutageMultiplier;
            CA.PRODUCTION_COST = inputCaTank.ProdCost;
            CA.PERSON_DENSITY = inputCaTank.popdens;
            CA.INJURE_COST = inputCaTank.injcost;

            tbDamageSurroundEquipmentShell.Text = CA.fc_affa_tank().ToString();
            tbCostOfBusinessInterruptionShell.Text = CA.fc_prod_tank().ToString();
            tbCostAssociatedPersonInjury.Text = CA.fc_inj_tank().ToString();
            float FC = (float)(CA.fc_affa_tank() + CA.fc_prod_tank() + CA.fc_inj_tank()+ CA.FC_leak_environ() + CA.FC_rupture_environ() + CA.fc_cmd());
            txtTotalConsequenceShell.Text = FC.ToString();
            txtConsequenceCategoryShell.Text = CA.FC_Category(FC);
            //luu vao bang RW_FULL_COF_BUS de ve riskmatrix
            rw_full_COF_bus = new RW_FULL_COF_BUS();
            rw_full_COF = new RW_FULL_COF();
            rw_full_COF.ID = id;
            rw_full_COF.CoFValue = float.Parse(txtTotalConsequenceShell.Text);
            rw_full_COF.CoFCategory = txtConsequenceCategoryShell.Text;
            rw_full_COF.CoFMatrixValue = 0;
            if (rw_full_COF_bus.checkExistCoF(id))
            {
                rw_full_COF_bus.edit(rw_full_COF);
            }
            else rw_full_COF_bus.add(rw_full_COF);

        }

        private void txtFM_TextChanged(object sender, EventArgs e)
        {
           // getData(id);
        }

        private void cbDetectionSystem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           // getData(id);
        }

        private void cbIsolationSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
           // getData(id);
        }

        private void cbMitigationSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
           // getData(id);
        }

        private void textBox280_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPURCFC_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEOM_TextChanged(object sender, EventArgs e)
        {
           // getDataFINALCOF(id);
        }

        private void txtLoPC_TextChanged(object sender, EventArgs e)
        {
           // getDataFINALCOF(id);
        }

        private void txtTuPDoDoE_TextChanged(object sender, EventArgs e)
        {
           // getDataFINALCOF(id);
        }

        private void txtTCAWSIOFOP_TextChanged(object sender, EventArgs e)
        {
           // getDataFINALCOF(id);
        }

        private void txtECUP_TextChanged(object sender, EventArgs e)
        {
           // getDataFINALCOF(id);
        }

        private void btnUpdateNomal_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            getDataFINALCOF(id);
            LoadDataForControlInTabCANomal();
            SplashScreenManager.CloseForm();
        }

        private void btnUpdateArea_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            getData(id);
            LoadDataForControlInTabArea();
            SplashScreenManager.CloseForm();
        }

        private void btnInputBottom_Click(object sender, EventArgs e)
        {
            RW_FULL_COF_TANK inputTankBottom = new RW_FULL_COF_TANK();
            inputTankBottom.ID = IDProposal;
            inputTankBottom.EquipOutageMultiplier = txtEquipMulBottom.Text != "" ? float.Parse(txtEquipMulBottom.Text) : 0;
            inputTankBottom.ProdCost = txtCostProdBottom.Text != "" ? float.Parse(txtCostProdBottom.Text) : 0;
            RW_FULL_COF_TANK_BUS busCA_Tank = new RW_FULL_COF_TANK_BUS();
            busCA_Tank.edit(inputTankBottom);
            MessageBox.Show("Update Input", "Coterk RBI");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("555");
            frmDamageFactor frm = new frmDamageFactor(id,"");
            frm.ShowDialog();
        }
    }
}
