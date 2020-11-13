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
    class RW_FULL_COF_HOLE_SIZE_ConnectUtils
    {
        public void add(int ID, double GFF_small, double GFF_medium, double GFF_large, double GFF_rupture, double A1, double A2, double A3, double A4, double W1, double W2, double W3, double W4, double t_n1, double t_n2, double t_n3, double t_n4, double ld_max_1, double ld_max_2, double ld_max_3, double ld_max_4,
                        double mass_add_1, double mass_add_2, double mass_add_3, double mass_add_4, double mass_avail_1, double mass_avail_2, double mass_avail_3, double mass_avail_4, double rate_1, double rate_2, double rate_3, double rate_4, double ld_1, double ld_2, double ld_3, double ld_4, double mass_1, double mass_2, double mass_3, double mass_4, 
                        double eneff_1, double eneff_2, double eneff_3, double eneff_4, double factIC_1, double factIC_2, double factIC_3, double factIC_4, String ReleaseType_1, String ReleaseType_2, String ReleaseType_3, String ReleaseType_4)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[RW_FULL_COF_HOLE_SIZE]" +
                        "([ID]" +
                        ",[GFF_small]" +
                        ",[GFF_medium]" +
                        ",[GFF_large]" +
                        ",[GFF_rupture]" +
                        ",[A1]" +
                        ",[A2]" +
                        ",[A3]" +
                        ",[A4]" +
                        ",[W1]" +
                        ",[W2]" +
                        ",[W3]" +
                        ",[W4]" +
                        ",[t_n1]" +
                        ",[t_n2]" +
                        ",[t_n3]" +
                        ",[t_n4]" +
                        ",[ld_max_1]" +
                        ",[ld_max_2]" +
                        ",[ld_max_3]" +
                        ",[ld_max_4]" +
                        ",[mass_add_1]" +
                        ",[mass_add_2]" +
                        ",[mass_add_3]" +
                        ",[mass_add_4]" +
                        ",[mass_avail_1]" +
                        ",[mass_avail_2]" +
                        ",[mass_avail_3]" +
                        ",[mass_avail_4]" +
                        ",[rate_1]" +
                        ",[rate_2]" +
                        ",[rate_3]" +
                        ",[rate_4]" +
                        ",[ld_1]" +
                        ",[ld_2]" +
                        ",[ld_3]" +
                        ",[ld_4]" +
                        ",[mass_1]" +
                        ",[mass_2]" +
                        ",[mass_3]" +
                        ",[mass_4]" +
                        ",[eneff_1]" +
                        ",[eneff_2]" +
                        ",[eneff_3]" +
                        ",[eneff_4]" +
                        ",[factIC_1]" +
                        ",[factIC_2]" +
                        ",[factIC_3]" +
                        ",[factIC_4]" +
                        ",[ReleaseType_1]" +
                        ",[ReleaseType_2]" +
                        ",[ReleaseType_3]" +
                        ",[ReleaseType_4])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + GFF_small + "'" +
                        ",'" + GFF_medium + "'" +
                        ",'" + GFF_large + "'" +
                        ",'" + GFF_rupture + "'" +
                        ",'" + A1 + "'" +
                        ",'" + A2 + "'" +
                        ",'" + A3 + "'" +
                        ",'" + A4 + "'" +
                        ",'" + W1 + "'" +
                        ",'" + W2 + "'" +
                        ",'" + W3 + "'" +
                        ",'" + W4 + "'" +
                        ",'" + t_n1 + "'" +
                        ",'" + t_n2 + "'" +
                        ",'" + t_n3 + "'" +
                        ",'" + t_n4 + "'" +
                        ",'" + ld_max_1 + "'" +
                        ",'" + ld_max_2 + "'" +
                        ",'" + ld_max_3 + "'" +
                        ",'" + ld_max_4 + "'" +
                        ",'" + mass_add_1 + "'" +
                        ",'" + mass_add_2 + "'" +
                        ",'" + mass_add_3 + "'" +
                        ",'" + mass_add_4 + "'" +
                        ",'" + mass_avail_1 + "'" +
                        ",'" + mass_avail_2 + "'" +
                        ",'" + mass_avail_3 + "'" +
                        ",'" + mass_avail_4 + "'" +
                        ",'" + rate_1 + "'" +
                        ",'" + rate_2 + "'" +
                        ",'" + rate_3 + "'" +
                        ",'" + rate_4 + "'" +
                        ",'" + ld_1 + "'" +
                        ",'" + ld_2 + "'" +
                        ",'" + ld_3 + "'" +
                        ",'" + ld_4 + "'" +
                        ",'" + mass_1+ "'" +
                        ",'" + mass_2 + "'" +
                        ",'" + mass_3 + "'" +
                        ",'" + mass_4 + "'" +
                        ",'" + eneff_1 + "'" +
                        ",'" + eneff_2 + "'" +
                        ",'" + eneff_3 + "'" +
                        ",'" + eneff_4 + "'" +
                        ",'" + factIC_1 + "'" +
                        ",'" + factIC_2 + "'" +
                        ",'" + factIC_3 + "'" +
                        ",'" + factIC_4 + "'" +
                        ",'" + ReleaseType_1 + "'" +
                        ",'" + ReleaseType_2 + "'" +
                        ",'" + ReleaseType_3 + "'" +
                        ",'" + ReleaseType_4 + "')" ;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //Console.WriteLine("ksad" + sql);
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
        public void edit(int ID, double GFF_small, double GFF_medium, double GFF_large, double GFF_rupture, double A1, double A2, double A3, double A4, double W1, double W2, double W3, double W4, double t_n1, double t_n2, double t_n3, double t_n4, double ld_max_1, double ld_max_2, double ld_max_3, double ld_max_4,
                        double mass_add_1, double mass_add_2, double mass_add_3, double mass_add_4, double mass_avail_1, double mass_avail_2, double mass_avail_3, double mass_avail_4, double rate_1, double rate_2, double rate_3, double rate_4, double ld_1, double ld_2, double ld_3, double ld_4, double mass_1, double mass_2, double mass_3, double mass_4,
                        double eneff_1, double eneff_2, double eneff_3, double eneff_4, double factIC_1, double factIC_2, double factIC_3, double factIC_4, String ReleaseType_1, String ReleaseType_2, String ReleaseType_3, String ReleaseType_4)
        {
            //if (float.IsNaN((float)W1)) W1 = 0;
            //if (float.IsNaN((float)W2)) W2 = 0;
            //if (float.IsNaN((float)W3)) W3 = 0;
            //if (float.IsNaN((float)W4)) W4 = 0;
            //if (float.IsNaN((float)t_n1)) t_n1 = 0;
            //if (float.IsNaN((float)t_n2)) t_n2 = 0;
            //if (float.IsNaN((float)t_n3)) t_n3 = 0;
            //if (float.IsNaN((float)t_n4)) t_n4 = 0;
            //if (float.IsNaN((float)mass_add_1)) mass_add_1 = 0;
            //if (float.IsNaN((float)mass_add_3)) mass_add_3 = 0;
            //if (float.IsNaN((float)mass_add_4)) mass_add_4 = 0;
            //if (float.IsNaN((float)mass_add_2)) mass_add_2 = 0;
            //if (float.IsNaN((float)mass_avail_1)) mass_avail_1 = 0;
            //if (float.IsNaN((float)mass_avail_2)) mass_avail_2 = 0;
            //if (float.IsNaN((float)mass_avail_3)) mass_avail_3 = 0;
            //if (float.IsNaN((float)mass_avail_4)) mass_avail_4 = 0;
            //if (float.IsNaN((float)rate_1)) rate_1 = 0;
            //if (float.IsNaN((float)rate_2)) rate_2 = 0;
            //if (float.IsNaN((float)rate_3)) rate_3= 0;
            //if (float.IsNaN((float)rate_4)) rate_4 = 0;
            //if (float.IsNaN((float)ld_1)) ld_1 = 0;
            //if (float.IsNaN((float)ld_2)) ld_2 = 0;
            //if (float.IsNaN((float)ld_3)) ld_3 = 0;
            //if (float.IsNaN((float)ld_4)) ld_4 = 0;
            //if (float.IsNaN((float)mass_1)) mass_1 = 0;
            //if (float.IsNaN((float)mass_2)) mass_2 = 0;
            //if (float.IsNaN((float)mass_3)) mass_3 = 0;
            //if (float.IsNaN((float)mass_4)) mass_4 = 0;
            //if (float.IsNaN((float)eneff_1)) eneff_1 = 0;
            //if (float.IsNaN((float)eneff_2)) eneff_2 = 0;
            //if (float.IsNaN((float)eneff_3)) eneff_3 = 0;
            //if (float.IsNaN((float)eneff_4)) eneff_4 = 0;
            //if (float.IsNaN((float)factIC_1)) factIC_1 = 0;
            //if (float.IsNaN((float)factIC_2)) factIC_2 = 0;
            //if (float.IsNaN((float)factIC_3)) factIC_3 = 0;
            //if (float.IsNaN((float)factIC_4)) factIC_4 = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_COF_HOLE_SIZE]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[GFF_small] = '" + GFF_small + "'" +
                        ",[GFF_medium] = '" + GFF_medium + "'" +
                        ",[GFF_large] = '" + GFF_large + "'" +
                        ",[GFF_rupture] = '" + GFF_rupture + "'" +
                        ",[A1] = '" + A1 + "'" +
                        ",[A2] = '" + A2 + "'" +
                        ",[A3] = '" + A3 + "'" +
                        ",[A4] = '" + A4 + "'" +
                        ",[W1] = '" + W1 + "'" +
                        ",[W2] = '" + W2 + "'" +
                        ",[W3] = '" + W3 + "'" +
                        ",[W4] = '" + W4 + "'" +
                        ",[t_n1] = '" + t_n1 + "'" +
                        ",[t_n2] = '" + t_n2 + "'" +
                        ",[t_n3] = '" + t_n3 + "'" +
                        ",[t_n4] = '" + t_n4 + "'" +
                        ",[ld_max_1] = '" + ld_max_1 + "'" +
                        ",[ld_max_2] = '" + ld_max_2 + "'" +
                        ",[ld_max_3] = '" + ld_max_3 + "'" +
                        ",[ld_max_4] = '" + ld_max_4 + "'" +
                        ",[mass_add_1] = '" + mass_add_1 + "'" +
                        ",[mass_add_2] = '" + mass_add_2 + "'" +
                        ",[mass_add_3] = '" + mass_add_3 + "'" +
                        ",[mass_add_4] = '" + mass_add_4 + "'" +
                        ",[mass_avail_1] = '" + mass_avail_1 + "'" +
                        ",[mass_avail_2] = '" + mass_avail_2 + "'" +
                        ",[mass_avail_3] = '" + mass_avail_3 + "'" +
                        ",[mass_avail_4] = '" + mass_avail_4 + "'" +
                        ",[rate_1] = '" + rate_1 + "'" +
                        ",[rate_2] = '" + rate_2 + "'" +
                        ",[rate_3] = '" + rate_3 + "'" +
                        ",[rate_4] = '" + rate_4 + "'" +
                        ",[ld_1] = '" + ld_1 + "'" +
                        ",[ld_2] = '" + ld_2 + "'" +
                        ",[ld_3] = '" + ld_3 + "'" +
                        ",[ld_4] = '" + ld_4 + "'" +
                        ",[mass_1] = '" + mass_1 + "'" +
                        ",[mass_2] = '" + mass_2 + "'" +
                        ",[mass_3] = '" + mass_3 + "'" +
                        ",[mass_4] = '" + mass_4 + "'" +
                        ",[eneff_1] = '" + eneff_1 + "'" +
                        ",[eneff_2] = '" + eneff_2 + "'" +
                        ",[eneff_3] = '" + eneff_3 + "'" +
                        ",[eneff_4] = '" + eneff_4 + "'" +
                        ",[factIC_1] = '" + factIC_1 + "'" +
                        ",[factIC_2] = '" + factIC_2 + "'" +
                        ",[factIC_3] = '" + factIC_3 + "'" +
                        ",[factIC_4] = '" + factIC_4 + "'" +
                        ",[ReleaseType_1] = '" + ReleaseType_1 + "'" +
                        ",[ReleaseType_2] = '" + ReleaseType_2 + "'" +
                        ",[ReleaseType_3] = '" + ReleaseType_3 + "'" +
                        ",[ReleaseType_4] = '" + ReleaseType_4 + "'" +

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
                        "DELETE FROM [dbo].[RW_FULL_COF_HOLE_SIZE]" +
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
        // get Datasource
        public List<RW_FULL_COF_HOLE_SIZE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_COF_HOLE_SIZE> list = new List<RW_FULL_COF_HOLE_SIZE>();
            RW_FULL_COF_HOLE_SIZE obj = null;
            String sql = "Use[rbi] "+
                        "Select [ID]" +
                        ",[GFF_small]" +
                        ",[GFF_medium]" +
                        ",[GFF_large]" +
                        ",[GFF_rupture]" +
                        ",[A1]" +
                        ",[A2]" +
                        ",[A3]" +
                        ",[A4]" +
                        ",[W1]" +
                        ",[W2]" +
                        ",[W3]" +
                        ",[W4]" +
                        ",[t_n1]" +
                        ",[t_n2]" +
                        ",[t_n3]" +
                        ",[t_n4]" +
                        ",[ld_max_1]" +
                        ",[ld_max_2]" +
                        ",[ld_max_3]" +
                        ",[ld_max_4]" +
                        ",[mass_add_1]" +
                        ",[mass_add_2]" +
                        ",[mass_add_3]" +
                        ",[mass_add_4]" +
                        ",[mass_avail_1]" +
                        ",[mass_avail_2]" +
                        ",[mass_avail_3]" +
                        ",[mass_avail_4]" +
                        ",[rate_1]" +
                        ",[rate_2]" +
                        ",[rate_3]" +
                        ",[rate_4]" +
                        ",[ld_1]" +
                        ",[ld_2]" +
                        ",[ld_3]" +
                        ",[ld_4]" +
                        ",[mass_1]" +
                        ",[mass_2]" +
                        ",[mass_3]" +
                        ",[mass_4]" +
                        ",[eneff_1]" +
                        ",[eneff_2]" +
                        ",[eneff_3]" +
                        ",[eneff_4]" +
                        ",[factIC_1]" +
                        ",[factIC_2]" +
                        ",[factIC_3]" +
                        ",[factIC_4]" +
                        ",[ReleaseType_1]" +
                        ",[ReleaseType_2]" +
                        ",[ReleaseType_3]" +
                        ",[ReleaseType_4])" +
                          "From [dbo].[RW_FULL_COF_HOLE_SIZE] ";
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
                            obj = new RW_FULL_COF_HOLE_SIZE();
                            obj.ID = reader.GetInt32(0);
                            obj.GFF_small = reader.GetDouble(1);
                            obj.GFF_medium = reader.GetDouble(2);
                            obj.GFF_large = reader.GetDouble(3);
                            obj.GFF_rupture = reader.GetDouble(4);
                            if (!reader.IsDBNull(5))
                            {
                                obj.A1 = reader.GetFloat(5);

                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.A2 = reader.GetFloat(7);

                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.A3 = reader.GetFloat(8);

                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.A4 = reader.GetFloat(9);

                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.W1 = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.W2 = reader.GetFloat(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.W3 = reader.GetFloat(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.W4 = reader.GetFloat(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.t_n1 = reader.GetFloat(14);

                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.t_n2 = reader.GetFloat(15);

                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.t_n3 = reader.GetFloat(16);

                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.t_n4 = reader.GetFloat(17);

                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.ld_max_1 = reader.GetFloat(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.ld_max_2 = reader.GetFloat(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ld_max_3 = reader.GetFloat(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.ld_max_4 = reader.GetFloat(21);
                            }
                            if (!reader.IsDBNull(22))
                            {
                                obj.mass_add_1 = reader.GetFloat(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.mass_add_2 = reader.GetFloat(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.mass_add_3 = reader.GetFloat(24);
                            }
                            if (!reader.IsDBNull(25))
                            {
                                obj.mass_add_4 = reader.GetFloat(25);
                            }
                            if (!reader.IsDBNull(26))
                            {
                                obj.mass_avail_1 = reader.GetFloat(26);
                            }
                            if (!reader.IsDBNull(27))
                            {
                                obj.mass_avail_2 = reader.GetFloat(27);
                            }
                            if (!reader.IsDBNull(28))
                            {
                                obj.mass_avail_3 = reader.GetFloat(28);
                            }
                            if (!reader.IsDBNull(29))
                            {
                                obj.mass_avail_4 = reader.GetFloat(29);
                            }
                            if (!reader.IsDBNull(30))
                            {
                                obj.rate_1 = reader.GetFloat(30);
                            }
                            if (!reader.IsDBNull(31))
                            {
                                obj.rate_2 = reader.GetFloat(31);
                            }
                            if (!reader.IsDBNull(32))
                            {
                                obj.rate_3 = reader.GetFloat(32);
                            }
                            if (!reader.IsDBNull(33))
                            {
                                obj.rate_4 = reader.GetFloat(33);
                            }
                            if (!reader.IsDBNull(34))
                            {
                                obj.ld_1 = reader.GetFloat(34);
                            }
                            if (!reader.IsDBNull(35))
                            {
                                obj.ld_2 = reader.GetFloat(35);
                            }
                            if (!reader.IsDBNull(36))
                            {
                                obj.ld_3 = reader.GetFloat(36);
                            }
                            if (!reader.IsDBNull(37))
                            {
                                obj.ld_4 = reader.GetFloat(37);
                            }
                            if (!reader.IsDBNull(38))
                            {
                                obj.mass_1 = reader.GetFloat(38);
                            }
                            if (!reader.IsDBNull(39))
                            {
                                obj.mass_2 = reader.GetFloat(39);
                            }
                            if (!reader.IsDBNull(40))
                            {
                                obj.mass_3 = reader.GetFloat(40);
                            }
                            if (!reader.IsDBNull(41))
                            {
                                obj.mass_4 = reader.GetFloat(41);
                            }
                            if (!reader.IsDBNull(42))
                            {
                                obj.eneff_1 = reader.GetFloat(42);
                            }
                            if (!reader.IsDBNull(43))
                            {
                                obj.eneff_2 = reader.GetFloat(43);
                            }
                            if(!reader.IsDBNull(44))
                            {
                                obj.eneff_3 = reader.GetFloat(44);
                            }
                            if (!reader.IsDBNull(45))
                            {
                                obj.eneff_4 = reader.GetFloat(45);
                            }
                            if (!reader.IsDBNull(46))
                            {
                                obj.factIC_1 = reader.GetFloat(46);
                            }
                            if (!reader.IsDBNull(47))
                            {
                                obj.factIC_2 = reader.GetFloat(47);
                            }
                            if (!reader.IsDBNull(48))
                            {
                                obj.factIC_3 = reader.GetFloat(48);
                            }
                            if (!reader.IsDBNull(49))
                            {
                                obj.factIC_4 = reader.GetFloat(49);
                            }
                            if (!reader.IsDBNull(50))
                            {
                                obj.ReleaseType_1 = reader.GetString(50);
                            }
                            if (!reader.IsDBNull(51))
                            {
                                obj.ReleaseType_2 = reader.GetString(51);
                            }
                            if (!reader.IsDBNull(52))
                            {
                                obj.ReleaseType_3 = reader.GetString(52);
                            }
                            if (!reader.IsDBNull(53))
                            {
                                obj.ReleaseType_4 = reader.GetString(53);
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
        public RW_FULL_COF_HOLE_SIZE getData(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            RW_FULL_COF_HOLE_SIZE obj = new RW_FULL_COF_HOLE_SIZE();
            String sql = "Use[rbi] "+
                        " Select [ID]" +
                        ",[GFF_small]" +
                        ",[GFF_medium]" +
                        ",[GFF_large]" +
                        ",[GFF_rupture]" +
                        ",[A1]" +
                        ",[A2]" +
                        ",[A3]" +
                        ",[A4]" +
                        ",[W1]" +
                        ",[W2]" +
                        ",[W3]" +
                        ",[W4]" +
                        ",[t_n1]" +
                        ",[t_n2]" +
                        ",[t_n3]" +
                        ",[t_n4]" +
                        ",[ld_max_1]" +
                        ",[ld_max_2]" +
                        ",[ld_max_3]" +
                        ",[ld_max_4]" +
                        ",[mass_add_1]" +
                        ",[mass_add_2]" +
                        ",[mass_add_3]" +
                        ",[mass_add_4]" +
                        ",[mass_avail_1]" +
                        ",[mass_avail_2]" +
                        ",[mass_avail_3]" +
                        ",[mass_avail_4]" +
                        ",[rate_1]" +
                        ",[rate_2]" +
                        ",[rate_3]" +
                        ",[rate_4]" +
                        ",[ld_1]" +
                        ",[ld_2]" +
                        ",[ld_3]" +
                        ",[ld_4]" +
                        ",[mass_1]" +
                        ",[mass_2]" +
                        ",[mass_3]" +
                        ",[mass_4]" +
                        ",[eneff_1]" +
                        ",[eneff_2]" +
                        ",[eneff_3]" +
                        ",[eneff_4]" +
                        ",[factIC_1]" +
                        ",[factIC_2]" +
                        ",[factIC_3]" +
                        ",[factIC_4]" +
                        ",[ReleaseType_1]" +
                        ",[ReleaseType_2]" +
                        ",[ReleaseType_3]" +
                        ",[ReleaseType_4]" +
                          "From [dbo].[RW_FULL_COF_HOLE_SIZE] WHERE [ID] = '" + ID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //Console.WriteLine("hehe= " + sql);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_FULL_COF_HOLE_SIZE();
                            obj.ID = reader.GetInt32(0);
                            obj.GFF_small = reader.GetDouble(1);
                            obj.GFF_medium = reader.GetDouble(2);
                            obj.GFF_large = reader.GetDouble(3);
                            obj.GFF_rupture = reader.GetDouble(4);
                            if (!reader.IsDBNull(5))
                            {
                                obj.A1 = (float)reader.GetDouble(5);

                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.A2 = (float)reader.GetDouble(6);

                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.A3 = (float)reader.GetDouble(7);

                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.A4 = (float)reader.GetDouble(8);

                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.W1 = (float)reader.GetDouble(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.W2 = (float)reader.GetDouble(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.W3 = (float)reader.GetDouble(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.W4 = (float)reader.GetDouble(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.t_n1 = (float)reader.GetDouble(13);

                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.t_n2 = (float)reader.GetDouble(14);

                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.t_n3 = (float)reader.GetDouble(15);

                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.t_n4 = (float)reader.GetDouble(16);

                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.ld_max_1 = (float)reader.GetDouble(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.ld_max_2 = (float)reader.GetDouble(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.ld_max_3 = (float)reader.GetDouble(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ld_max_4 = (float)reader.GetDouble(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.mass_add_1 = (float)reader.GetDouble(21);
                            }
                            if (!reader.IsDBNull(22))
                            {
                                obj.mass_add_2 = (float)reader.GetDouble(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.mass_add_3 = (float)reader.GetDouble(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.mass_add_4 = (float)reader.GetDouble(24);
                            }
                            if (!reader.IsDBNull(25))
                            {
                                obj.mass_avail_1 = (float)reader.GetDouble(25);
                            }
                            if (!reader.IsDBNull(26))
                            {
                                obj.mass_avail_2 = (float)reader.GetDouble(26);
                            }
                            if (!reader.IsDBNull(27))
                            {
                                obj.mass_avail_3 = (float)reader.GetDouble(27);
                            }
                            if (!reader.IsDBNull(28))
                            {
                                obj.mass_avail_4 = (float)reader.GetDouble(28);
                            }
                            if (!reader.IsDBNull(29))
                            {
                                obj.rate_1 = (float)reader.GetDouble(29);
                            }
                            if (!reader.IsDBNull(30))
                            {
                                obj.rate_2 = (float)reader.GetDouble(30);
                            }
                            if (!reader.IsDBNull(31))
                            {
                                obj.rate_3 = (float)reader.GetDouble(31);
                            }
                            if (!reader.IsDBNull(32))
                            {
                                obj.rate_4 = (float)reader.GetDouble(32);
                            }
                            if (!reader.IsDBNull(33))
                            {
                                obj.ld_1 = (float)reader.GetDouble(33);
                            }
                            if (!reader.IsDBNull(34))
                            {
                                obj.ld_2 = (float)reader.GetDouble(34);
                            }
                            if (!reader.IsDBNull(35))
                            {
                                obj.ld_3 = (float)reader.GetDouble(35);
                            }
                            if (!reader.IsDBNull(36))
                            {
                                obj.ld_4 = (float)reader.GetDouble(36);
                            }
                            if (!reader.IsDBNull(37))
                            {
                                obj.mass_1 = (float)reader.GetDouble(37);
                            }
                            if (!reader.IsDBNull(38))
                            {
                                obj.mass_2 = (float)reader.GetDouble(38);
                            }
                            if (!reader.IsDBNull(39))
                            {
                                obj.mass_3 = (float)reader.GetDouble(39);
                            }
                            if (!reader.IsDBNull(40))
                            {
                                obj.mass_4 = (float)reader.GetDouble(40);
                            }
                            if (!reader.IsDBNull(41))
                            {
                                obj.eneff_1 = (float)reader.GetDouble(41);
                            }
                            if (!reader.IsDBNull(42))
                            {
                                obj.eneff_2 = (float)reader.GetDouble(42);
                            }
                            if (!reader.IsDBNull(43))
                            {
                                obj.eneff_3 = (float)reader.GetDouble(43);
                            }
                            if (!reader.IsDBNull(44))
                            {
                                obj.eneff_4 = (float)reader.GetDouble(44);
                            }
                            if (!reader.IsDBNull(45))
                            {
                                obj.factIC_1 = (float)reader.GetDouble(45);
                            }
                            if (!reader.IsDBNull(46))
                            {
                                obj.factIC_2 = (float)reader.GetDouble(46);
                            }
                            if (!reader.IsDBNull(47))
                            {
                                obj.factIC_3 = (float)reader.GetDouble(47);
                            }
                            if (!reader.IsDBNull(48))
                            {
                                obj.factIC_4 = (float)reader.GetDouble(48);
                            }
                            if (!reader.IsDBNull(49))
                            {
                                obj.ReleaseType_1 = reader.GetString(49);
                            }
                            if (!reader.IsDBNull(50))
                            {
                                obj.ReleaseType_2 = reader.GetString(50);
                            }
                            if (!reader.IsDBNull(51))
                            {
                                obj.ReleaseType_3 = reader.GetString(51);
                            }
                            if (!reader.IsDBNull(52))
                            {
                                obj.ReleaseType_4 = reader.GetString(52);
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
        public Boolean checkExistCoFHS(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select GFF_small from rbi.dbo.RW_FULL_COF_HOLE_SIZE where ID = '" + ID + "'";
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