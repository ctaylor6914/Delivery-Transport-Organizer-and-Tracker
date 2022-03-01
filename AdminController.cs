using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;



namespace Group2
{
    /// <summary>
    /// Static class for Admin
    /// </summary>
    /// 
    /// \class  AdminController
    /// 
    /// \brief  The purpose of this class is to allow the admin specific controls
    ///         to be able to review log record log and connect to the Database
    /// 
    /// Attributes:
    ///     -Record                       : Attribute for storing the event log
    ///     -LogFileDirectory             : Attribute to store the local location
    ///                                   : of the log file
    ///     -ConnectionStringForTMS       : Stores the connection string for the 
    ///                                   : TMS database
    /// 
    /// Methods:
    ///     -addLog(string msg)
    ///     -readLog(string msg)
    ///     -connectToDb()
    ///     -changeCarrierData()
    ///     -changeRouteTable()
    ///     -changeRateFeeTable()
    ///     
    /// \author <i>Colby Taylor & Sohaib Sheikh & Seungjae Lee & Parichehr Moghanloo</i>
    ///         
    /// </summary>
    /// 

    public static class AdminController
    {

        public static string PresetLogFile = "c:\\Users\\lsj27\\documents\\TMS_LogFile.log";
        public static string LogFileDirectory;
        public static string LogFileName;
        public static string LogWithDateTime;   // variable to store eventlogs
        public static string ConnectionStringForTMS = "Server=localhost;Uid=testuser;Pwd=12345;database=test";  // connection string for TMS Database

        // Backup
        public static string BackupFile;


        // Logger 4.5.2.1.2  -------- write with append / read 
        public static void addLog(string logMsg)
        {
            DateTime tsmTime = DateTime.Now;
            LogWithDateTime = $"[ {tsmTime} ] - {logMsg}";

            if (!File.Exists(LogFileName))
            {
                LogFileName = PresetLogFile;
               
                using (StreamWriter sw = File.CreateText(LogFileName))
                {
                    DateTime createFileTime = DateTime.Now;
                    sw.WriteLine($"[ {createFileTime} ] - File Created");
                }
            }

            using (StreamWriter sw = File.AppendText(LogFileName))
            {
                sw.WriteLine(LogWithDateTime);
            }

        }

        public static void readLog(string logMsg)
        {
            // it will display on the admin review log page
            // This is implemented as a list box.
        }

        // connectToDB() -> 4.5.2.1.1

        public static string InitialConnectToDB()
        {
            string mySqlVersion = "";
            try
            {                
                // Connection String
                var connstr = ConnectionStringForTMS;                

                using (var conn = new MySqlConnection(connstr))
                {
                    // Open connection
                    conn.Open();
                    mySqlVersion =$"Connected to MySql {conn.ServerVersion}";

                    conn.Close(); // Close connection
                }         
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);               
            }
           
            return mySqlVersion;
        }

        public static void ConnectToDB(string mySqlCommand)
        {
            try
            {
                // Connection String
                var connstr = ConnectionStringForTMS;

                using (var conn = new MySqlConnection(connstr))
                {
                    // Open connection
                    conn.Open();                    

                    // Create a command
                    using (var cmd = conn.CreateCommand())
                    {
                        // This a command text
                        cmd.CommandText = mySqlCommand;

                        // execute
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close connection
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // localBackup() -> 4.5.2.1.4
        public static void localBackup(string ConnectionStringForTMS, string BackupFile)
        {

            // https://www.nuget.org/packages/MySqlBackup.NET/

            using (MySqlConnection conn = new MySqlConnection(ConnectionStringForTMS))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(BackupFile);
                        conn.Close();
                    }
                }
            }
        }

        public static void localRestore(string ConnectionStringForTMS, string BackupFile)
        {
            // https://www.nuget.org/packages/MySqlBackup.NET/

            using (MySqlConnection conn = new MySqlConnection(ConnectionStringForTMS))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(BackupFile);
                        conn.Close();
                    }
                }
            }
        }



        // changeCarrierData() -> 4.5.2.1.3

        // changeRouteTable() -> 4.5.2.1.3

        // changeRateFeeTable() -> 4.5.2.1.3





        // MySQL --- id : group2 / password : group2password




        //buyer methods
        //getContract() -> 4.5.2.2.1
        //reviewCust() -> 4.5.2.2.2
        //acceptNewCust() -> 4.5.2.2.2
        //startOrder() -> 4.5.2.2.3
        //selectCity() -> 4.5.2.2.4
        //createInvoice()-> 4.5.2.2.5
        //create invoice generates invoice in a file and updates TMS database


        //planner methods
        //getOrder() -> 4.5.2.3.1  get orders from Buyer
        //selectCarrier() 4.5.2.3.2 also must be able to add trip if capacity is reached for a carrier
        //incrementDat() 4.5.2.3.4
        //markForFollowUp() 4.5.2.3.5 confirm an order is completed. 
        //Completed Orders are marked for follow-up from the Buyer

        //summarizeActiceOrders() 4.5.2.3.6 viewed on status screen
        //generateReport() 4.5.2.3.8 all-time or past 2 weeks. 

    }
}
