using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
using RBI.DAL.MSSQL;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class RW_FULL_FINALCOF_BUS
    {
            RW_FULL_FINALCOF_ConnectUtils DAL = new RW_FULL_FINALCOF_ConnectUtils();
            public void add(RW_FULL_FINALCOF obj)
            {
                DAL.add(obj.ID, obj.ComponentDamageCosts, obj.EquipmentOutageMultiplier, obj.LossProductCost, obj.PopDen, obj.InjCost, obj.EnviCost);
            }
            public void edit(RW_FULL_FINALCOF obj)
            {
                DAL.edit(obj.ID, obj.ComponentDamageCosts, obj.EquipmentOutageMultiplier, obj.LossProductCost, obj.PopDen, obj.InjCost, obj.EnviCost);
            }
            public void delete(RW_FULL_FINALCOF obj)
            {
                DAL.delete(obj.ID);
            }
            public RW_FULL_FINALCOF getData(int ID)
            {
                return DAL.getData(ID);
            }
            public List<RW_FULL_FINALCOF> getDataSource()
            {
                return DAL.getDataSource();
            }
        
    }
}
