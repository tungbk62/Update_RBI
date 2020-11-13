using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class INSPECTION_COVERAGE_DETAIL_BUS
    {
        INSPECTION_COVERAGE_DETAIL_ConnectUtils DAL = new INSPECTION_COVERAGE_DETAIL_ConnectUtils();
        public void add(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.add(obj.CoverageID, obj.DMItemID, obj.InspectionDate, obj.EffectivenessCode, obj.InspectionSummary, obj.IsCarriedOut,obj.CarriedOutDate);
        }
        public void edit(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.edit(obj.ID,obj.CoverageID, obj.DMItemID, obj.InspectionDate, obj.EffectivenessCode, obj.InspectionSummary, obj.IsCarriedOut, obj.CarriedOutDate);
        }
        public void delete(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.delete(obj.ID);
        }
        public List<INSPECTION_COVERAGE_DETAIL> getDataSource()
        {
            return DAL.getDataSource();
        }
        public INSPECTION_COVERAGE_DETAIL getDataSourcebyID(int ID)
        {
            return DAL.getDataSourcebyID(ID);
        }
        public String getEffectivenessCodebyCoverageIDandDMItemID(int CoverageID, int DMItemID)
        {
            return DAL.getEffectivenessCodebyCoverageIDandDMItemID(CoverageID, DMItemID);
        }
        public List<int> getIDbyCoverageID(int CoverageID )
        {
            return DAL.getIDbyCoverageID(CoverageID);
        }
        public void deletebyCoverageID(int CoverageID)
        {
            DAL.deletebyCoverageID(CoverageID);
        }

    }
}
