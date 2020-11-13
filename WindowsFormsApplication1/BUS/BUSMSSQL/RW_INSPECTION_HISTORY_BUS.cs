using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_INSPECTION_HISTORY_BUS
    {
        RW_INSPECTION_DETAIL_ConnUtils DAL = new RW_INSPECTION_DETAIL_ConnUtils();
        public void add(RW_INSPECTION_DETAIL obj)
        {
            DAL.add( obj.ID, obj.EquipmentID, obj.ComponentID, obj.Coverage_DetailID, obj.InspPlanName, obj.InspectionDate, obj.DMItemID, obj.EffectivenessCode, obj.InspectionSummary, obj.IsCarriedOut, obj.CarriedOutDate, obj.IsActive);
        }
        public void edit(RW_INSPECTION_DETAIL obj)
        {
            DAL.edit(obj.ID, obj.DetailID, obj.EquipmentID, obj.ComponentID, obj.Coverage_DetailID, obj.InspPlanName, obj.InspectionDate, obj.DMItemID, obj.EffectivenessCode, obj.InspectionSummary, obj.IsCarriedOut, obj.CarriedOutDate, obj.IsActive);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_INSPECTION_DETAIL> getDataSource()
        {
            return DAL.getDataSource();
        }
        public List<RW_INSPECTION_DETAIL> getDataSourcebyID(int ID)
        {
            return DAL.getDataSourcebyID(ID);
        }
        public List<RW_INSPECTION_DETAIL> getDataComp(int CompID)
        {
            return DAL.getDataComp(CompID);
        }
        public Boolean checkExist(RW_INSPECTION_DETAIL obj)
        {
            return DAL.checkExist(obj.ComponentID, obj.DMItemID, obj.InspectionDate);
        }
        public DateTime getLastInsp(int compID, int DMItemID, DateTime comissionDate)
        {
            return DAL.getLastInspDate(compID, DMItemID, comissionDate);
        }
        public float getAge(int compID, int DMItemID, DateTime comissionDate, DateTime AssessmentDate)
        {
            TimeSpan TICK_SPAN = AssessmentDate.Subtract(DAL.getLastInspDate(compID, DMItemID, comissionDate));
            float DATA = (float)Math.Round((double)TICK_SPAN.Days / 365, 2);
            return DATA;
        }
        public String getHighestInspEffec(int compID, int DMItemID)
        {
            return DAL.getMaxInspEffec(compID, DMItemID);
        }
        public int InspectionNumber(int compID, int DMItemID)
        {
            return DAL.InspectionNumber(compID, DMItemID);
        }
        public int InspectionTypeNumber(int compID,int DMItemID, String type)
        {
            return DAL.InspectionTypeNumber(compID, DMItemID, type);
        }
    }
}
