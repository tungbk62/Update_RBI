using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_FULL_COF_TANK_BUS
    {
        RW_FULL_COF_TANK_ConnectUtils DAL = new RW_FULL_COF_TANK_ConnectUtils();
        public void add(RW_FULL_COF_TANK obj)
        {
            DAL.add(obj.ID, obj.CoFValue, obj.CoFCategory, obj.ProdCost, obj.EquipOutageMultiplier, obj.equipcost, obj.popdens, obj.injcost, obj.CoFMatrixValue);
        }
        public void edit(RW_FULL_COF_TANK obj)
        {
            DAL.edit(obj.ID, obj.CoFValue, obj.CoFCategory, obj.ProdCost, obj.EquipOutageMultiplier, obj.equipcost, obj.popdens, obj.injcost, obj.CoFMatrixValue);
        }
        public void editInput(RW_FULL_COF_TANK obj)
        {
            DAL.editInput(obj.ID, obj.ProdCost, obj.EquipOutageMultiplier, obj.equipcost, obj.popdens, obj.injcost, obj.CoFMatrixValue);
        }
        public void delete(RW_FULL_COF_TANK obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_COF_TANK> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_FULL_COF_TANK getData(int ID)
        {
            return DAL.getData(ID);
        }

    }
}
