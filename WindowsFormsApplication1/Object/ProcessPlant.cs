using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class ProcessPlant
    {
        public String EquipmentNumber { set; get; }
        public String Component { set; get; }
        public String ComponentNumber { set; get; }
        public String Site { set; get; }
        public String Facility { set; get; }
        public String AP1 { set; get; }
        public String AP2 { set; get; }
        public  String AP3 { set; get; }
        public String RLI { set; get; }
        public String AssessmentName { set; get; }
        public String AssessmentDate { set; get; }
        public String CommissionDate { set; get; }
        public String RiskAnalysisPeriod { set; get; }
        public String EquipmentType { set; get; }
        public String ComponentType { set; get; }
        String InspectionDueDate { set; get; }//?
        public  String DesignCode { set; get; }
        public String AdministrativeControl { set; get; }
        public String ContainsDeadlegs { set; get; }
        public String PresenceofSulphidesOperation { set; get; }
        public String SteamedOut { set; get; }
        public String ThermalHistory { set; get; }
        public String SystemManagementFactor { set; get; }
        public String PWHT { set; get; }
        public String PressurisarionControlledbyAdmin { set; get; }
        public String PresenceofSulphidesShutdown { set; get; }
        public String OnlineMonitoring { set; get; }
        public String MinRequiredTemperature { set; get; }
        public String MaterialisExposedtoFluids { set; get; }
        public String CyclicOperation { set; get; }
        public String LinerOnlineMonitoring { set; get; }
        public String DowntimeProtectionUsed { set; get; }
        public String EquipmentisOperating { set; get; }
        public String EquipmentVolume { set; get; }
        public String InterfaceatSoilorWater { set; get; }
        public String ExternalEnvironment { set; get; }
        public String HeatTraced { set; get; }
        public String HighlyEffectiveInspection { set; get; }
        public String TypeofSoil { set; get; }
        public String  EnvironmentalSensitivity { set; get; }
        public String DistanceToGroundWater { set; get; }

        //component 
        public String MinimumMeasuredThickness { set; get; }
        public String NominalThickness { set; get; }
        public String NominalDiameter { set; get; }
        public String MinRequiredThickness { set; get; }
        public String CurrentCorrosionRate { set; get; }
        public String PresenceofCracks { set; get; }
        public String PreviousFailures { set; get; }
        public String DamageFoundDuringInspection { set; get; }
        public String PresenceofInjectionMixPoint { set; get; }//?
        public String HighlyEffectiveInspectionCom { set; get; }
        public String TrampElements { set; get; }//?
        public String DeltaFATT { set; get; }
        public String CyclicLoadingConnected { set; get; }
        public String MaximumBrinnellHardness { set; get; }
        public String NumberofFitting { set; get; }
        public String JointTypeofBranch { set; get; }
        public String PipeCondition { set; get; }
        public String VisibleorAudible { set; get; }
        public String AccummlatedTimeShaking { set; get; }
        public String AmountofShaking { set; get; }
        public String CorrectAction { set; get; }
        public String BranchDiameter { set; get; }
        public String ComplexityofProtrusions { set; get; }
        public String  ReleasePreventionBarrier{ set; get; }
       public String ShellHeight { set; get; }
        public String ConcreteorAsphaltFoundation{ set; get; }
     public String SeverityofVibration { set; get; }

    //stream
    public String MaximumOperatingTemperature { set; get; }
        public String MinimumOperatingTemperature { set; get; }
        public String MaximumOperatingPressure { set; get; }
        public String MinimumOperatingPressure { set; get; }
        public String CriticalExposureTemperature { set; get; }
        public String AmineSolutionComposition { set; get; }
        public String NAOHConcentration { set; get; }
        public String H2Scontent { set; get; }
        public String MaterialFluidsMistsSolids { set; get; }
        public String FlowRate { set; get; }
        public String pHofWater { set; get; }
        public String ToxicConsitituents { set; get; }
        public String ReleaseFluidPercentToxic { set; get; }
        public String ProcessContainsHydrogen { set; get; }
        public String PresenceofHydrofluoric { set; get; }
        public String ExposuretoAmine { set; get; }
        public String PresenceofCyanides { set; get; }
        public String OperatingHydrogenPartialPressure { set; get; }
        public String ExposedSulphurBearing { set; get; }
        public String ExposedAcidGas { set; get; }
        public String EnvironmentContainsH2S { set; get; }
        public String EnvironmentContainsCaustic { set; get; }
        public String CO3Concentration { set; get; }
        public String ChlorideIon { set; get; }
        public String AqueousPhaseDuringOper { set; get; }
        public String AqueousPhaseDuringShut { set; get; }
        public String FluidHeight{ set; get; }
    public String PercentageofFluidLeavingtheDike{ set; get; }
public String PercentageofFluidLeavingtheDikebutRemainsonSite{ set; get; }
public String PercentageofFluidGoingOffsite { set; get; }

//material
public String DesignTemperature { set; get; }
        public String AllowableStress { set; get; }
        public String DesignPressure { set; get; }
        public String SusceptibletoTemper { set; get; }
        public String SulfurContent { set; get; }
        public String SigmaPhase { set; get; }
        public String ReferenceTemperature { set; get; }
        public String NickelAlloy { set; get; }
        public String MaterialCostFactor { set; get; }
        public String HeatTreatment { set; get; }
        public String CorrosionAllowance { set; get; }
        public String Chromium { set; get; }
        public String CacbonorLow { set; get; }
        public String AusteniticSteel { set; get; }
        //coating
        public String InternalCoating { set; get; }
        public String ExternalCoating { set; get; }
        public String ExternalCoatingInstallationDate { set; get; }
        public String ExternalCoatingQuality { set; get; }
        public String SupportConfiguration { set; get; }
        public String InternalLining { set; get; }
        public String InternalLinerType { set; get; }
        public String InternalLinerCondition { set; get; }
        public String InternalCladding { set; get; }
        public String CladdingCorrosionRate { set; get; }
        public String ExternalInsulation { set; get; }
        public String ExternalInsulationType { set; get; }
        public String InsulationCondition { set; get; }
        public String InsulationContainsChlorides { set; get; }

        public ProcessPlant()
        {

        }
    }
}
