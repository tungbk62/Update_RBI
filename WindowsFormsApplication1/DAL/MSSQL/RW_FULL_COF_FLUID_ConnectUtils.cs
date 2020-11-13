using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class RW_FULL_COF_FLUID_ConnectUtils
    {
        public void add(int ID, double Cp, double k, double GFFTotal,double Kv_n,String ReleasePhase, double W_max8, double Cd,double Ptrans,double NBP,double Density, double MW,double R, double Ps,double Ts,double Patm, double fact_di, double fact_mit, double fact_AIT, double g, double h, String ambient)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[RW_FULL_COF_FLUID]" +
                        "([ID]" +
                        ",[Cp]" +
                        ",[k]" +
                        ",[GFFTotal]" +
                        ",[Kv_n]" +
                        ",[ReleasePhase]" +
                        ",[W_max8]"+
                        ",[Cd]" +
                        ",[Ptrans]" +
                        ",[NBP]" +
                        ",[Density]" +
                        ",[MW]" +
                        ",[R]" +
                        ",[Ps]" +
                        ",[Ts]" +
                        ",[Patm]" +
                        ",[fact_di]" +
                        ",[fact_mit]" +
                        ",[fact_AIT]" +
                        ",[g]" +
                        ",[h]" +
                        ",[ambient])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + Cp + "'" +
                        ",'" + k + "'" +
                        ",'" + GFFTotal + "'" +
                        ",'" + Kv_n + "'" +
                        ",'" + ReleasePhase + "'" +
                        ",'" + W_max8+"'"+
                        ",'" + Cd + "'" +
                        ",'" + Ptrans + "'" +
                        ",'" + NBP + "'" +
                        ",'" + Density + "'" +
                        ",'" + MW + "'" +
                        ",'" + R + "'" +
                        ",'" + Ps + "'" +
                        ",'" + Ts + "'" +
                        ",'" + Patm + "'" +
                        ",'" + fact_di + "'" +
                        ",'" + fact_mit + "'" +
                        ",'" + fact_AIT + "'" +
                        ",'" + g + "'" +
                        ",'" + h + "'" +
                        ",'" + ambient + "')";
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
        public void edit(int ID, double Cp, double k, double GFFTotal, double Kv_n, String ReleasePhase, double W_max8, double Cd, double Ptrans, double NBP, double Density, double MW, double R, double Ps, double Ts, double Patm, double fact_di, double fact_mit, double fact_AIT, double g, double h, String ambient)
        {
            if (float.IsNaN((float)W_max8)) W_max8 = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_COF_FLUID]" +
                        "SET [ID] ='" + ID + "'" +
                        ",[Cp] ='" + Cp + "'" +
                        ",[k] ='" + k + "'" +
                        ",[GFFTotal] ='" + GFFTotal + "'" +
                        ",[Kv_n] ='" + Kv_n + "'" +
                        ",[ReleasePhase] ='" + ReleasePhase + "'" +
                        ",[W_max8]='"+W_max8+"'"+
                        ",[Cd] ='" + Cd + "'" +
                        ",[Ptrans] ='" + Ptrans + "'" +
                        ",[NBP] ='" + NBP + "'" +
                        ",[Density] ='" + Density + "'" +
                        ",[MW] ='" + MW + "'" +
                        ",[R] ='" + R + "'" +
                        ",[Ps] ='" + Ps + "'" +
                        ",[Ts] ='" + Ts + "'" +
                        ",[Patm] ='" + Patm + "'" +
                        ",[fact_di] ='" + fact_di + "'" +
                        ",[fact_mit] ='" + fact_mit + "'" +
                        ",[fact_AIT] ='" + fact_AIT + "'" +
                        ",[g] ='" + g + "'" +
                        ",[h] ='" + h + "'" +
                        ",[ambient] ='" + ambient + "'" +
                        " WHERE [ID] = '" + ID + "'" +
                        " ";
            //Console.WriteLine("sql= " + sql);
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
                        "DELETE FROM [dbo].[RW_FULL_COF_FLUID]" +
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
        // get datasource
        public List<RW_FULL_COF_FLUID> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_COF_FLUID> list = new List<RW_FULL_COF_FLUID>();
            RW_FULL_COF_FLUID obj = null;
            String sql = "Use[rbi]"+
                        "Select[ID]" +
                        ",[Cp]" +
                        ",[k]" +
                        ",[GFFTotal]" +
                        ",[Kv_n]" +
                        ",[ReleasePhase]" +
                        ",[W_max8]"+
                        ",[Cd]" +
                        ",[Ptrans]" +
                        ",[NBP]" +
                        ",[Density]" +
                        ",[MW]" +
                        ",[R]" +
                        ",[Ps]" +
                        ",[Ts]" +
                        ",[Patm]" +
                        ",[fact_di]" +
                        ",[fact_mit]" +
                        ",[fact_AIT]" +
                        ",[g]" +
                        ",[h]" +
                        ",[ambient]" +
                        "From [dbo].[RW_FULL_COF_FLUID]  ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_FULL_COF_FLUID();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.Cp = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.k = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.GFFTotal = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.Kv_n = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.ReleasePhase = reader.GetString(5);
                            }
                            if(!reader.IsDBNull(6))
                            {
                                obj.W_max8 = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Cd = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.Ptrans = reader.GetFloat(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.NBP = reader.GetFloat(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.Density = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.MW = reader.GetFloat(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.R = reader.GetFloat(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.Ps = reader.GetFloat(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.Ts = reader.GetFloat(14);
                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.Patm = reader.GetFloat(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.fact_di = reader.GetFloat(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.fact_mit = reader.GetFloat(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.fact_AIT = reader.GetFloat(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.g = reader.GetFloat(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.h = reader.GetFloat(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.ambient = reader.GetString(21);
                            }
                            list.Add(obj);

                        }
                    }
                }
            }
            catch(Exception e)
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
        public RW_FULL_COF_FLUID getData(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            RW_FULL_COF_FLUID obj = new RW_FULL_COF_FLUID();
            String sql = "Use[rbi] " + 
                        "Select [ID]" +
                        ",[Cp]" +
                        ",[k]" +
                        ",[GFFTotal]" +
                        ",[Kv_n]" +
                        ",[ReleasePhase]" +
                        ",[W_max8]" +
                        ",[Cd]" +
                        ",[Ptrans]" +
                        ",[NBP]" +
                        ",[Density]" +
                        ",[MW]" +
                        ",[R]" +
                        ",[Ps]" +
                        ",[Ts]" +
                        ",[Patm]" +
                        ",[fact_di]" +
                        ",[fact_mit]" +
                        ",[fact_AIT]" +
                        ",[g]" +
                        ",[h]" +
                        ",[ambient]" +
                         "From [dbo].[RW_FULL_COF_FLUID] WHERE [ID] = '" + ID +"' ";
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
                            obj = new RW_FULL_COF_FLUID();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.Cp = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.k = (float)reader.GetDouble(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.GFFTotal = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.Kv_n = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.ReleasePhase = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.W_max8 = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Cd = (float)reader.GetDouble(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.Ptrans = (float)reader.GetDouble(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.NBP = (float)reader.GetDouble(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.Density = (float)reader.GetDouble(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.MW = (float)reader.GetDouble(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.R = (float)reader.GetDouble(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.Ps = (float)reader.GetDouble(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.Ts = (float)reader.GetDouble(14);
                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.Patm = (float)reader.GetDouble(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.fact_di = (float)reader.GetDouble(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.fact_mit = (float)reader.GetDouble(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.fact_AIT = (float)reader.GetDouble(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.g = (float)reader.GetDouble(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.h = (float)reader.GetDouble(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.ambient = reader.GetString(21);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL !");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public Boolean checkExistCoFFLUID(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select Cp from rbi.dbo.RW_FULL_COF_FLUID where ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                            IsExist = false;
                        else
                            IsExist = true;
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
            return IsExist;
        }
    }
}
