using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.MSSQL
{
    class RW_FULL_FINALCOF_ConnectUtils
    {
        public void add(int ID, double ComponentDamageCosts, double EquipmentOutageMultiplier, double LossProductCost, double PopDen, double InjCost, double EnviCost)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_FULL_FINALCOF]" +
                        "([ID]" +
                        ",[ComponentDamageCosts]" +
                        ",[EquipmentOutageMultiplier]" +
                        ",[LossProductCost]" +
                        ",[PopDen]" +
                        ",[InjCost]" +
                        ",[EnviCost])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + ComponentDamageCosts + "'" +
                        ",'" + EquipmentOutageMultiplier + "'" +
                        ",'" + LossProductCost + "'" +
                        ",'" + PopDen + "'" +
                        ",'" + InjCost + "'" +
                        ",'" + EnviCost + "')" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //Console.WriteLine("sql= " + sql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, double ComponentDamageCosts, double EquipmentOutageMultiplier, double LossProductCost, double PopDen, double InjCost, double EnviCost)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_FINALCOF]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[ComponentDamageCosts] = '" + ComponentDamageCosts + "'" +
                        ",[EquipmentOutageMultiplier] = '" + EquipmentOutageMultiplier + "'" +
                        ",[LossProductCost] = '" + LossProductCost + "'" +
                        ",[PopDen] = '" + PopDen + "'" +
                        ",[InjCost] = '" + InjCost + "'" +
                        ",[EnviCost] = '" + EnviCost + "'" +
                        " WHERE [ID] = '" + ID + "'" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                Console.WriteLine("sqledit= " + sql);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[RW_FULL_FINALCOF]" +
                        " WHERE [ID] ='" + ID + "'" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        ///get datasource
        ///
        public RW_FULL_FINALCOF getData(int ID)
        {
            RW_FULL_FINALCOF obj = new RW_FULL_FINALCOF();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use[rbi] Select[ID]" +
                        ",[ComponentDamageCosts]" +
                        ",[EquipmentOutageMultiplier]" +
                        ",[LossProductCost]" +
                        ",[PopDen]" +
                        ",[InjCost]" +
                        ",[EnviCost]" +
                          "From [dbo].[RW_FULL_FINALCOF] WHERE [ID] ='" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj.ID = ID;
                            obj.ComponentDamageCosts = (float)reader.GetDouble(1);
                            obj.EquipmentOutageMultiplier = (float)reader.GetDouble(2);
                            obj.LossProductCost = (float)reader.GetDouble(3);
                            obj.PopDen = (float)reader.GetDouble(4);
                            obj.InjCost = (float)reader.GetDouble(5);
                            obj.EnviCost = (float)reader.GetDouble(6);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                obj.ID = -1;
                MessageBox.Show("GET DATA FAIL!",e.ToString() );
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public List<RW_FULL_FINALCOF> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_FINALCOF> list = new List<RW_FULL_FINALCOF>();
            RW_FULL_FINALCOF obj = null;
            String sql = " Use[rbi] Select[ID]" +
                        ",[ComponentDamageCosts]" +
                        ",[EquipmentOutageMultiplier]" +
                        ",[LossProductCost]" +
                        ",[PopDen]" +
                        ",[InjCost]" +
                        ",[EnviCost])" +
                          "From [dbo].[RW_FULL_FINALCOF]  ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_FULL_FINALCOF();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.ComponentDamageCosts = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.EquipmentOutageMultiplier = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.LossProductCost = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.PopDen = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.InjCost = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.EnviCost = reader.GetFloat(6);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
    }
}
