using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class Corrosion_Rate
    {
        public int CorrosionID { get; set; }
        public float SoilSideCorrosionRate { get; set; }
        public float ProductSideCorrosionRate { get; set; }
        public String PotentialCorrosion { get; set; }
        public String TankPadMaterial { get; set; }
        public String TankDrainageType { get; set; }
        public String CathodicProtectionType { get; set; }
        public String TankBottomType { get; set; }
        public String SoilSideTemperature { get; set; }
        public String ProductCondition { get; set; }
        public String ProductSideTemp { get; set; }
        public String SteamCoil { get; set; }
        public String WaterDrawOff { get; set; }
        public String ProductSideBottom { get; set; }
        public float ModifiedSoilSideCorrosionRate { get; set; }
        public float ModifiedProductSideCorrosionRate { get; set; }
        public float FinalEstimatedCorrosionRate { get; set; }

        // 	Soil-Side Corrosion Rate Equation 
        private float CR_SB()
        {
            if (SoilSideCorrosionRate==0)
            {
                return 0.13f;
            }
            else
            {
                return SoilSideCorrosionRate;
            }
        }
        private float F_SR()
        {
            float SR = 0;
            if (PotentialCorrosion == "Very Corrosive (<500 Ω-cm)")
                SR = 1.5f;
            else if (PotentialCorrosion == "Corrosive (500-1000 Ω-cm)")
                SR = 1.25f;
            else if (PotentialCorrosion == "Moderately Corrosive (1000-2000 Ω-cm)")
                SR = 1.0f;
            else if (PotentialCorrosion == "Mildly Corrosive (2000-10000 Ω-cm)")
                SR = 0.83f;
            else if (PotentialCorrosion == "Progressively Less Corrosive (>10000 Ω-cm)")
                SR = 0.66f;
            else
                SR = 1.0f;
            return SR;
        }
        private float F_PA()
        {
            if (TankPadMaterial == "Soid With High Salt")
                return 1.5f;
            else if (TankPadMaterial == "Crushed Limestone")
                return 1.4f;
            else if (TankPadMaterial == "Native Soil")
                return 1.3f;
            else if (TankPadMaterial == "Construction Grade Sand")
                return 1.15f;
            else if (TankPadMaterial == "Continuous Asphalt" || TankPadMaterial == "Continuous Concrete")
                return 1.0f;
            else
                return 0.7f;
        }
        private float F_ID()
        {
            if (TankDrainageType == "One Third Frequently Underwater")
                return 3;
            else if (TankDrainageType == "Storm Water Collects At AST Base")
                return 2;
            else
                return 1;
        }
        private float F_CP()
        {
            if (CathodicProtectionType == "None")
                return 1.0f;
            else if (CathodicProtectionType == "Yes Not Per API 651")
                return 0.66f;
            else
                return 0.33f;
        }
        private float F_TB()
        {
            if (TankBottomType == "RPB Not Per API 650")
                return 1.4f;
            else
                return 1.0f;
        }

        private float F_ST()
        {
            if (SoilSideTemperature == "Temp ≤ 24" || SoilSideTemperature == "> 121")
                return 1.0f;
            else if (SoilSideTemperature == "24< Temp ≤ 66")
                return 1.1f;
            else if (SoilSideTemperature == "66 < Temp ≤ 93")
                return 1.3f;
            else
                return 1.4f;
        }
        public float CRS_Bottom()
        {
            return CR_SB() * F_SR() * F_PA() * F_ID() * F_CP() * F_TB() * F_ST();
        }

        // Product-Side Corrosion Rate Equation 
        private float CR_PB()
        {
            if (ProductSideCorrosionRate == 0)
                return 0.05f;
            else
                return ProductSideCorrosionRate;
        }
        private float F_PC()
        {
            if (ProductCondition == "Wet")
                return 2.5f;
            else
                return 1.0f;
        }
        private float F_PT()
        {
            if (ProductSideTemp == "Temp ≤ 24" || ProductSideTemp == "> 121")
                return 1.0f;
            else if (ProductSideTemp == "24< Temp ≤ 66")
                return 1.1f;
            else if (ProductSideTemp == "66 < Temp ≤ 93")
                return 1.3f;
            else
                return 1.4f;
        }
        private float F_SC()
        {
            if (SteamCoil == "No")
                return 1.0f;
            else
                return 1.15f;
        }
        private float F_WD()
        {
            if (WaterDrawOff == "No")
                return 1.0f;
            else
                return 0.7f;
        }
        public float CRP_Bottom()
        {
            return CR_PB() * F_PC() * F_PT() * F_SC() * F_WD();
            Debug.Write("a");
        }
        public float Final_CR()
        {
            if (ProductSideBottom == "Localised")
                return Math.Max(CRS_Bottom(), CRP_Bottom());
            else
                return (CRS_Bottom() + CRP_Bottom());
        }
    }
}
