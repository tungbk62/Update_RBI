using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class InspectionPlanDetail
    {
        //ASSESSMENT
        public int ID { get; set; }
        public int EquipmentID { get; set; }
        public int ComponentID { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int AssessmentMethod { get; set; }
        public int RiskAnalysisPeriod { get; set; }
        public int IsEquipmentLinked { get; set; }
        public String RecordType { get; set; }
        public int ProposalNo { get; set; } //sua Number thanh String Name
        public String ProposalName { set; get; }
        public int RevisionNo { get; set; }
        public int IsRecommend { get; set; }
        public String ProposalOrRevision { get; set; }
        public String AdoptedBy { get; set; }
        public DateTime AdoptedDate { get; set; }
        public String RecommendedBy { get; set; }
        public DateTime RecommendedDate { get; set; }
        public int AddByExcel { set; get; }
        //EQUIPMENT
        public DateTime CommissionDate { get; set; }
        public int AdminUpsetManagement { get; set; }
        public int ContainsDeadlegs { get; set; }
        public int CyclicOperation { get; set; }
        public int HighlyDeadlegInsp { get; set; }
        public int DowntimeProtectionUsed { get; set; }
        public String ExternalEnvironment { get; set; }
        public int HeatTraced { get; set; }
        public int InterfaceSoilWater { get; set; }
        public int LinerOnlineMonitoring { get; set; }
        public int MaterialExposedToClExt { get; set; }
        public float MinReqTemperaturePressurisation { get; set; }
        public String OnlineMonitoring { get; set; }
        public int PresenceSulphidesO2 { get; set; }
        public int PresenceSulphidesO2Shutdown { get; set; }
        public int PressurisationControlled { get; set; }
        public int PWHT { get; set; }
        public int SteamOutWaterFlush { get; set; }
        public float ManagementFactor { get; set; }
        public String ThermalHistory { get; set; }
        public int YearLowestExpTemp { get; set; }
        public float Volume { get; set; }
        public String TypeOfSoil { get; set; }//6 truong nay chua duoc gan
        public String EnvironmentSensitivity { get; set; }
        public float DistanceToGroundWater { get; set; }
        public String AdjustmentSettle { get; set; }
        public int ComponentIsWelded { get; set; }
        public int TankIsMaintained { get; set; }
        //COMPONENT
        public float NominalDiameter { get; set; }
        public float NominalThickness { get; set; }
        public float CurrentThickness { get; set; }
        public float MinReqThickness { get; set; }
        public float CurrentCorrosionRate { get; set; }
        public String BranchDiameter { get; set; }
        public String BranchJointType { get; set; }
        public String BrinnelHardness { get; set; }
        public int ChemicalInjection { get; set; } //ko ro
        public int HighlyInjectionInsp { get; set; }
        public String ComplexityProtrusion { get; set; }
        public String CorrectiveAction { get; set; }
        public int CracksPresent { get; set; }
        public String CyclicLoadingWitin15_25m { get; set; }
        public int DamageFoundInspection { get; set; }
        public float DeltaFATT { get; set; }
        public String NumberPipeFittings { get; set; }
        public String PipeCondition { get; set; }
        public String PreviousFailures { get; set; }
        public String ShakingAmount { get; set; }
        public int ShakingDetected { get; set; }
        public String ShakingTime { get; set; }
        public String SeverityOfVibration { get; set; }
        public int ReleasePreventionBarrier { get; set; }
        public int ConcreteFoundation { get; set; }
        public float ShellHeight { get; set; }
        public float AllowableStress { get; set; }
        public float WeldJointEfficiency { get; set; }
        public float ComponentVolume { get; set; }
        public String ConfidenceCorrosionRate { get; set; }
        public int MinimumStructuralThicknessGoverns { get; set; }
        public float StructuralThickness { get; set; }
        public String CracksCurrentCondition { get; set; }
        public int FabricatedSteel { get; set; }
        public int EquipmentSatisfied { get; set; }
        public int NominalOperatingConditions { get; set; }
        public int CETGreaterOrEqual { get; set; }
        public int CyclicServiceFatigueVibration { get; set; }
        public int EquipmentCircuitShock { get; set; }
        public int HTHADamageObserved { get; set; }
        public float BrittleFractureThickness { get; set; }
        //STREAM
        public String AmineSolution { set; get; }
        public int AqueousOperation { set; get; }
        public int AqueousShutdown { set; get; }
        public int ToxicConstituent { set; get; }
        public int Caustic { set; get; }
        public float Chloride { set; get; }
        public float CO3Concentration { set; get; }
        public int Cyanide { set; get; }
        public int ExposedToGasAmine { set; get; }
        public int ExposedToSulphur { set; get; }
        public String ExposureToAmine { set; get; }
        public int FlammableFluidID { set; get; }
        public float FlowRate { set; get; } //nằm ở file Operating
        public int H2S { set; get; }
        public float H2SInWater { set; get; }
        public int Hydrogen { set; get; } //??
        public float H2SPartialPressure { set; get; }//??
        public int Hydrofluoric { set; get; }
        public int MaterialExposedToClInt { set; get; }
        public float MaxOperatingPressure { set; get; }
        public float MaxOperatingTemperature { set; get; }
        public float MinOperatingPressure { set; get; }
        public float MinOperatingTemperature { set; get; }
        public float CriticalExposureTemperature { set; get; } //ben file Operating
        public int ModelFluidID { set; get; }
        public float NaOHConcentration { set; get; }
        public int NonFlameToxicFluidID { set; get; }
        public float LiquidLevel { set; get; }
        public float ReleaseFluidPercentToxic { set; get; }
        public String StoragePhase { set; get; } //??
        public int ToxicFluidID { set; get; }
        public float WaterpH { set; get; }
        public String TankFluidName { set; get; }//??
        public float FluidHeight { set; get; }
        public float FluidLeaveDikePercent { set; get; }
        public float FluidLeaveDikeRemainOnSitePercent { set; get; }
        public float FluidGoOffSitePercent { set; get; }
        public float CUI_PERCENT_1 { set; get; }// % Operating at -12 °C to -8 °C
        public float CUI_PERCENT_2 { set; get; }// % Operating at -8 °C to 6 °C
        public float CUI_PERCENT_3 { set; get; }// % Operating at 6 °C to 32 °C
        public float CUI_PERCENT_4 { set; get; }// % Operating at 32 °C to 71 °C
        public float CUI_PERCENT_5 { set; get; }// % Operating at 71 °C to 107 °C
        public float CUI_PERCENT_6 { set; get; }// % Operating at 107 °C to 121 °C
        public float CUI_PERCENT_7 { set; get; }// % Operating at 121 °C to 135 °C
        public float CUI_PERCENT_8 { set; get; }// % Operating at 135 °C to 162 °C
        public float CUI_PERCENT_9 { set; get; }// % Operating at 162 °C to 176 °C
        public float CUI_PERCENT_10 { set; get; }// % Operating at 176 °C or above
        //MATERIAL
        public String MaterialName { set; get; }
        public float DesignPressure { set; get; }
        public float DesignTemperature { set; get; }
        public float MinDesignTemperature { set; get; }
        public float BrittleFractureThickness { set; get; }
        public float CorrosionAllowance { set; get; }
        public float SigmaPhase { set; get; }
        public String SulfurContent { set; get; }
        public String HeatTreatment { set; get; }
        public String SteelProductForm { get; set; }
        public float ReferenceTemperature { set; get; }
        public String PTAMaterialCode { set; get; }
        public String HTHAMaterialCode { set; get; }
        public int IsPTA { set; get; }
        public int IsHTHA { set; get; }
        public int Austenitic { set; get; }
        public int Temper { set; get; }
        public int CarbonLowAlloy { set; get; }
        public int NickelBased { set; get; }
        public int ChromeMoreEqual12 { set; get; }
        public float AllowableStress { set; get; }
        public float YieldStrength { set; get; }
        public float TensileStrength { set; get; }
        public float CostFactor { set; get; }
        //COATING
        public int ExternalCoating { get; set; }
        public int ExternalInsulation { get; set; }
        public int InternalCladding { get; set; }
        public int InternalCoating { get; set; }
        public int InternalLining { get; set; }
        public DateTime ExternalCoatingDate { get; set; }
        public String ExternalCoatingQuality { get; set; }
        public String ExternalInsulationType { get; set; }
        public String InsulationCondition { get; set; }
        public int InsulationContainsChloride { get; set; }
        public String InternalLinerCondition { get; set; }
        public String InternalLinerType { get; set; }
        public float CladdingThickness { get; set; }
        public float CladdingCorrosionRate { get; set; }
        public int SupportConfigNotAllowCoatingMaint { get; set; }
    }
}
