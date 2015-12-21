using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LoggerApp.Logging
{
    public class DBLogger : Logger, ILogger
    {
        public DBLogger() : base()
        {

        }

        public void LogError(string message)
        {
            if (!this.ErrorEnabled)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    //Assume we have stored procedure: InsertLog (@message varchar(max), @eventType tinyint, @date datetime)
                    string spName = "InsertLog";
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@message", message));
                        command.Parameters.Add(new SqlParameter("@eventType", (int)EventType.Error));
                        command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                        command.CommandText = spName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Decide what to do when logger fails. Try logging into a file? Do nothing?
                //Try to log to event viewer??
            }
        }

        public void LogInfo(string message)
        {
            if (!this.InfoEnabled)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    //Assume we have stored procedure: InsertLog (@message varchar(max), @eventType tinyint, @date datetime)
                    string spName = "InsertLog";
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@message", message));
                        command.Parameters.Add(new SqlParameter("@eventType", (int)EventType.Info));
                        command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                        command.CommandText = spName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Decide what to do when logger fails. Try logging into a file? Do nothing?
                //Try to log to event viewer??
            }
        }

        public void LogWarning(string message)
        {
            if (!this.WarningEnabled)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    //Assume we have stored procedure: InsertLog (@message varchar(max), @eventType tinyint, @date datetime)
                    string spName = "InsertLog";
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@message", message));
                        command.Parameters.Add(new SqlParameter("@eventType", (int)EventType.Warning));
                        command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                        command.CommandText = spName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Decide what to do when logger fails. Try logging into a file? Do nothing?
                //Try to log to event viewer??
            }
        }
    }
}
