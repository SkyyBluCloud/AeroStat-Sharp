using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AeroStat_Sharp.Models;
using Dapper;

namespace AeroStat_Sharp
{
    public class DataAccess
    {
        public List<PPR> getCurrentDayPPRs(bool sample = false)
        {
            using IDbConnection conn = new SqlConnection(SQLHelper.cnnVal());
            var output = conn.Query<PPR>("dbo.getCurrentDayPPR @day", new { day = sample ? new DateTime(2022,6,23) : DateTime.Now.Date });
            return output.ToList();
        }
        public long getLastPPR(string initials)
        {
            using (IDbConnection conn = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = conn.QueryFirst<long>("dbo.getLastPPR @initials", initials);
                return output;
            }
        }
        public bool pprExists(string pprNumber)
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = connection.ExecuteScalar<bool>("SELECT COUNT(1) FROM dbo.tblPPR WHERE pprNumber = @ppr", new { ppr = pprNumber });
                return output;
            }
        }
        public PPR getPPR(string pprNumber)
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = connection.QueryFirst<PPR>("dbo.getPPR @ppr", new { ppr = pprNumber });
                return output;
            }
            
        }
        public List<PPR> getPPRs()
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = connection.Query<PPR>("dbo.getPPRs");
                return output.ToList();
            }
        }
        public List<PPRService> getPPRServices ()
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = connection.Query<PPRService>("dbo.getPPRServices");
                return output.ToList();
            }
        }
        public List<Traffic> getFlights (string dir, bool hasPPR)
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                //SELECT ID, flightRule, Callsign, 
                var output = connection.Query<Traffic>($"SELECT * FROM tblTraffic WHERE direction = '{ dir }' AND (PPR Is Not Null) = { hasPPR }").ToList();
                return output;
            }
        }
        public List<User> getUsers()
        {
            using (IDbConnection connection = new SqlConnection(SQLHelper.cnnVal()))
            {
                var output = connection.Query<User>($"SELECT * FROM tblUserAuth;").ToList();
                return output;
            }
        }

        public static DataTable getDataTable(String table)
        {
            using (SqlConnection conn = new SqlConnection(SQLHelper.cnnVal()))
            {
                string select = $"SELECT * FROM { table }";
                SqlDataAdapter da = new SqlDataAdapter(select, conn);
                DataTable output = new DataTable();
                da.Fill(output);
                return output;
            }
        }
    }
}
