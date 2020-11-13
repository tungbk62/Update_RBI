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
    class INSPECTION_COVERAGE_BUS
    {
        INSPECTION_COVERAGE_ConnectUtils DAL = new INSPECTION_COVERAGE_ConnectUtils();
        public void add(INSPECTION_COVERAGE obj)
        {
            DAL.add(obj.PlanID, obj.EquipmentID, obj.ComponentID, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void edit(INSPECTION_COVERAGE obj)
        {
            DAL.edit(obj.ID, obj.PlanID, obj.EquipmentID, obj.ComponentID, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void delete(INSPECTION_COVERAGE obj)
        {
            DAL.delete(obj.ID);
        }
        public void deletebyComponentID(int ComponentID)
        {
            DAL.deletebyComponentID(ComponentID);
        }
        public void deletebyPlanID(int PlanID)//xoa du lieu tu PlanID
        {
            DAL.deletebyPlanID(PlanID);
        }
        public List<INSPECTION_COVERAGE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public List<INSPECTION_COVERAGE> getDataID(int PlanID)
        {
            return DAL.getDataID(PlanID);
        }
        public List<int> getIDbyPlanID(int PlanID)
        {
            return DAL.getIDbyPlanID(PlanID);//HaiK61
        }
        public List<int> getIDbyComponentID(int ComponentID)
        {
            return DAL.getIDbyComponentID(ComponentID);
        }
        public int getPlanIDbyID(int ID)
        {
            return DAL.getPlanIDbyID(ID);//HaiK61
        }
        public int getEquipmentID(int ID)
        {
            return DAL.getEquipmentID(ID);
        }
        public int getComponentID(int ID)
        {
            return DAL.getComponentID(ID);
        }

        public int getIDbyEquipmentIDandComponentIDandPlanID(int EquipmentID,int ComponentID,int PlanID)
        {
            return DAL.getIDbyEquipmentIDandComponentID(EquipmentID, ComponentID, PlanID);//HaiK61
        }
        public List<int> getlistIDbyEquipmentIDandComponentID(int EquipmentID, int ComponentID)
        {
            return DAL.getlistIDbyEquipmentIDandComponentID(EquipmentID, ComponentID);
        }

    }
}
