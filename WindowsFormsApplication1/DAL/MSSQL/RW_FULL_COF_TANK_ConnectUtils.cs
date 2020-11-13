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
    class RW_FULL_COF_TANK_ConnectUtils
    {
        public void add(int ID, double CoFValue, String CoFCategory, double ProdCost, float EquipOutageMultiplier, float equipcost, float popdens, float injcost, double CoFMatrixValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_FULL_COF_TANK]" +
                        "([ID]" +
                        ",[CoFValue]" +
                        ",[CoFCategory]" +
                        ",[ProdCost]" +
                        ",[EquipOutageMultiplier]" +
                        ",[equipcost]" +
                        ",[popdens]" +
                        ",[injcost]" +
                        ",[CoFMatrixValue])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + CoFValue + "'" +
                        ",'" + CoFCategory + "'" +
                        ",'" + ProdCost + "'" +
                        ",'" + EquipOutageMultiplier + "'" +
                        ",'" + equipcost + "'" +
                        ",'" + popdens + "'" +
                        ",'" + injcost + "'" +
                        ",'" + CoFMatrixValue + "')" +
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
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, double CoFValue, String CoFCategory, double ProdCost, float EquipOutageMultiplier, float equipcost, float popdens, float injcost, double CoFMatrixValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_COF_TANK]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[CoFValue] = '" + CoFValue + "'" +
                        ",[CoFCategory] = '" + CoFCategory + "'" +
                        ",[ProdCost] = '" + ProdCost + "'" +
                        ",[EquipOutageMultiplier] = '" + EquipOutageMultiplier + "'" +
                        ",[equipcost] = '" + equipcost + "'" +
                        ",[popdens] = '" + popdens + "'" +
                        ",[injcost] = '" + injcost + "'" +
                        ",[CoFMatrixValue] = '" + CoFMatrixValue + "'" +                     
                        " WHERE [ID] = '" + ID + "'" +
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
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
                //MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void editInput(int ID, double ProdCost, float EquipOutageMultiplier, float equipcost, float popdens, float injcost, double CoFMatrixValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_COF_TANK]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[ProdCost] = '" + ProdCost + "'" +
                        ",[EquipOutageMultiplier] = '" + EquipOutageMultiplier + "'" +
                        ",[equipcost] = '" + equipcost + "'" +
                        ",[popdens] = '" + popdens + "'" +
                        ",[injcost] = '" + injcost + "'" +
                        ",[CoFMatrixValue] = '" + CoFMatrixValue + "'" +
                        " WHERE [ID] = '" + ID + "'" +
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
                MessageBox.Show(e.ToString(), "EDIT INPUT FAIL!");
                //MessageBox.Show(e.ToString());
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
                        "DELETE FROM [dbo].[RW_FULL_COF_TANK]" +
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
        public RW_FULL_COF_TANK getData(int ID)
        {
            RW_FULL_COF_TANK obj = new RW_FULL_COF_TANK();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "" +
                        "SELECT [ID]" +
                        ",[CoFValue]" +
                        ",[CoFCategory]" +
                        ",[ProdCost]" +
                        ",[EquipOutageMultiplier]" +
                        ",[equipcost]" +
                        ",[popdens]" +
                        ",[injcost]" +
                        ",[CoFMatrixValue]" +
                          "From [dbo].[RW_FULL_COF_TANK] WHERE [ID] ='" + ID + "'";

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
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.CoFValue = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.CoFCategory = reader.GetString(2);

                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.ProdCost = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.EquipOutageMultiplier = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.equipcost = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.popdens = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.injcost = (float)reader.GetDouble(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.CoFMatrixValue = (float)reader.GetDouble(8);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        // get datasource
        public List<RW_FULL_COF_TANK> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_COF_TANK> list = new List<RW_FULL_COF_TANK>();
            RW_FULL_COF_TANK obj = null;
            String sql = " Use [rbi] Select [ID]" +
                        ",[CoFValue]" +
                        ",[CoFCategory]" +
                        ",[ProdCost]" +
                        ",[EquipOutageMultiplier]" +
                        ",[equipcost]" +
                        ",[popdens]" +
                        ",[injcost]" +
                        ",[CoFMatrixValue]" +
                          "From [dbo].[RW_FULL_COF_TANK]  ";
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
                            obj = new RW_FULL_COF_TANK();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.CoFValue = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.CoFCategory = reader.GetString(2);

                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.ProdCost = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.EquipOutageMultiplier = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.equipcost = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.popdens = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.injcost = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.CoFMatrixValue = reader.GetFloat(8);
                            }
                            list.Add(obj);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
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
