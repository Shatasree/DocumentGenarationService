using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using DemoUsers.Models;
using System.Data;
namespace DemoUsers.DAL
{
    public class UserDetailsDAL
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["DemoADO"].ConnectionString;
        public int insertData(UserDetails userDetails)
        {
            var con = new OracleConnection(conn);
            try
            {                
                con.Open();
                OracleCommand cmd = new OracleCommand("INSERT into DemoUser(USERNAME,PASSWORD,PHONE)values('" + userDetails.userName + "','" + userDetails.password + "','"+userDetails.phone+"')", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }           
        }
        public int UpdateData(UserDetails userDetails)
        {
            var con = new OracleConnection(conn);
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("Update DemoUser SET USERNAME='"+userDetails.userName+"',PHONE='"+userDetails.phone+"',PASSWORD='"+userDetails.password+"' WHERE ID="+userDetails.Id+"", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GetUserList()
        {
            var con = new OracleConnection(conn);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM DEMOUSER",con);
                OracleDataAdapter odp = new OracleDataAdapter(cmd);
                //OracleCommandBuilder bd = new OracleCommandBuilder(odp);
                odp.Fill(ds);               
                con.Close();
                return ds;
            }
            catch (Exception e)
            {
                return ds;
            }
            finally { con.Close(); }
            
            
        }
        public DataSet GetUser(int id)
        {
            var con = new OracleConnection(conn);
            DataSet ds = new DataSet();
            
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM DEMOUSER WHERE ID='"+id+"'", con);
                OracleDataAdapter odp = new OracleDataAdapter(cmd);
                //OracleCommandBuilder bd = new OracleCommandBuilder(odp);
                odp.Fill(ds);
                
                con.Close();
                return ds;
            }
            catch (Exception e)
            {
                return ds;
            }


        }
        public int RemoveData(int id)
        {
            var con = new OracleConnection(conn);
            try
            {

                con.Open();
                OracleCommand cmd = new OracleCommand("DELETE DEMOUSER WHERE ID='"+id+"'", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }

        }
    }

    public static class Connection
    {

    }
}