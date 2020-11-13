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
    class INSPECTION_DETAIL_TECHNIQUE_ConnectUtils
    {
        public void add(int CoverageID, int IMItemID, int IMTypeID, int InspectionType, int Coverage, string NDTMethod)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = //"USE [rbi]" +
                        //"INSERT INTO [dbo].[INSPECTION_DETAIL_TECHNIQUE]" +
                        //"(" +
                        //"[CoverageID]" +
                        //"," +
                        //"[IMItemID]" +
                        //",[IMTypeID]" +
                       // ",[InspectionType]" +
                        //",[Coverage])" +
                        //"VALUES" +
                        //"('" 
                        //+ CoverageID + "'" +
                        //",'" 
                       // + IMItemID + "'" +
                       // ",'" + IMTypeID + "'" +
                       // ",'" + InspectionType + "'" +
                        //",'" + Coverage +
                       // "')";
            "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_DETAIL_TECHNIQUE]" +
                        "([CoverageID]" +
                        ",[IMItemID]" +
                        ",[NDTMethod]" +
                        ",[IMTypeID]" +
                        ",[InspectionType]" +
                        ",[Coverage])" +
                        "VALUES" +
                        "('" + CoverageID + "'" +
                        ",'" + IMItemID + "'" +
                        ",'" + NDTMethod + "'" +
                        ",'" + IMTypeID + "'" +
                        ",'" + InspectionType + "'" +
                        ",'" + Coverage + "')";
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
        public void edit(int ID, int CoverageID, int IMItemID, int IMTypeID, int InspectionType, int Coverage)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[INSPECTION_DETAIL_TECHNIQUE]" +
                        "SET [CoverageID] = '" + CoverageID + "'" +
                        ",[IMItemID] = '" + IMItemID + "'" +
                        ",[IMTypeID] = '" + IMTypeID + "'" +
                        ",[InspectionType] = '" + InspectionType + "'" +
                        ",[Coverage] = '" + Coverage + "'" +
                        "WHERE [ID] = '" + ID + "'";

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
                        "DELETE FROM [dbo].[INSPECTION_DETAIL_TECHNIQUE]" +
                        "WHERE [ID] = '" + ID + "'";
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
        public void deletebyCoverageID(int CoverageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[INSPECTION_DETAIL_TECHNIQUE]" +
                        "WHERE [CoverageID] = '" + CoverageID + "'";
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
        public List<INSPECTION_DETAIL_TECHNIQUE> getDataSource(int CoverageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_DETAIL_TECHNIQUE> list = new List<INSPECTION_DETAIL_TECHNIQUE>();
            INSPECTION_DETAIL_TECHNIQUE obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[IMItemID]" +
                          ",[NDTMethod]" +
                          ",[IMTypeID]" +
                          ",[InspectionType]" +
                          ",[Coverage]" +
                          "From [rbi].[dbo].[INSPECTION_DETAIL_TECHNIQUE] Where [CoverageID] ='" + CoverageID + "'";
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
                            obj = new INSPECTION_DETAIL_TECHNIQUE();
                            obj.ID = (int)reader.GetInt64(0);
                            obj.IMItemID = reader.GetInt32(1);
                            obj.NDTMethod = reader.GetString(2);
                            obj.IMTypeID = reader.GetInt32(3);
                            obj.InspectionType = reader.GetInt32(4);
                            obj.Coverage = reader.GetInt32(5);
                            list.Add(obj);
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
            return list;
        }
        public List<INSPECTION_DETAIL_TECHNIQUE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_DETAIL_TECHNIQUE> list = new List<INSPECTION_DETAIL_TECHNIQUE>();
            INSPECTION_DETAIL_TECHNIQUE obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[CoverageID]" +
                          ",[IMItemID]" +
                        
                          ",[IMTypeID]" +
                          ",[InspectionType]" +
                          ",[Coverage]" +
                          "From [dbo].[INSPECTION_DETAIL_TECHNIQUE]";
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
                            obj = new INSPECTION_DETAIL_TECHNIQUE();
                            obj.ID = (int)reader.GetInt64(0);
                            obj.CoverageID = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.IMItemID = reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.IMTypeID = reader.GetInt32(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.InspectionType = reader.GetInt32(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Coverage = reader.GetInt32(5);
                            }
                            list.Add(obj);
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
            return list;
        }

    }
}
