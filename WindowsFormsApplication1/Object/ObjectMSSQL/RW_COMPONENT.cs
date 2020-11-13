﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_COMPONENT
    {
        public int ID { get; set; }
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
    }
}
