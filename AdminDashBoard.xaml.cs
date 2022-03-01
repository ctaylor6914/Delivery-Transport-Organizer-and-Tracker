using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using Path = System.IO.Path;

namespace Group2
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Page
    {
        public AdminDashBoard()
        {
            InitializeComponent();
        }


        // ------------------------- These are for hover effect [start] ---------------------

        private void menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            menu1.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            menu2.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            menu3.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        private void menu5_MouseEnter(object sender, MouseEventArgs e)
        {
            menu5.Background = new SolidColorBrush(Color.FromRgb(151, 86, 217));
            menu5_label.Foreground = new SolidColorBrush(Color.FromRgb(247, 239, 255));
        }

        private void menu5_MouseLeave(object sender, MouseEventArgs e)
        {
            menu5.Background = new SolidColorBrush(Color.FromRgb(247, 239, 255));
            menu5_label.Foreground = new SolidColorBrush(Color.FromRgb(151, 86, 217));
        }

        // ------------------------- These are for hover effect [end] ---------------------


        // ------------------------- These are for Menu Items Click Events [start] ---------------------

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardMain.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;
            admin_dashboard_review_log.Visibility = Visibility.Collapsed;
            admin_dashboard_backup.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("Admin dashboard home button clicked");
        }


        private void menu1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardDirectory.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;
            admin_dashboard_review_log.Visibility = Visibility.Collapsed;
            admin_dashboard_backup.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("Directory setting menu clicked");
        }

        private void menu2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminDashBoardIpPort.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;
            admin_dashboard_review_log.Visibility = Visibility.Collapsed;
            admin_dashboard_backup.Visibility = Visibility.Collapsed;

            // log
            AdminController.addLog("DB Connection setting button clicked");
        }

        private void menu3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            admin_log_listbox.Items.Clear();

            if (AdminController.LogFileName == null)
            {
                AdminController.LogFileName = AdminController.PresetLogFile;
            }

            using (StreamReader sr = File.OpenText(AdminController.LogFileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    admin_log_listbox.Items.Add(s);
                }
            }

            admin_dashboard_review_log.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;
            admin_dashboard_backup.Visibility = Visibility.Collapsed;
        }

        private void menu5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            admin_dashboard_backup.Visibility = Visibility.Visible;

            // Hide the other parts
            AdminDashBoardMain.Visibility = Visibility.Collapsed;
            AdminDashBoardIpPort.Visibility = Visibility.Collapsed;
            AdminDashBoardDirectory.Visibility = Visibility.Collapsed;
            admin_dashboard_review_log.Visibility = Visibility.Collapsed;
        }

        private void AdminBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }



        // ------------------------- These are for Menu Items Click Events [end] ---------------------

        private void ChangeLogFilePath_Click(object sender, RoutedEventArgs e)
        {
            // Initial directory set up required during installation(?)

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\Users\\lsj27\\documents";
            ofd.Filter = "Log Files (*.log) | *.log";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            bool? openResult = ofd.ShowDialog();

            if (openResult == true)
            {
                LogFilePath.Text = Path.GetDirectoryName(ofd.FileName);
                AdminController.LogFileName = ofd.FileName;
                AdminController.LogFileDirectory = LogFilePath.Text;
            }        

            // log
            AdminController.addLog("Change directory button clicked");
        }
                      

        private void TmsConnect_Click(object sender, RoutedEventArgs e)
        {         
            AdminController.ConnectionStringForTMS = $"Server={TmsIpAddress.Text};Uid={TmsUserName.Text};Pwd={TmsDbPassword.Password};database=test";

            connection_result.Content = AdminController.InitialConnectToDB();

            // log
            AdminController.addLog("TMS database connection button clicked");
        }        

        private void backup_button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MySql Database (*.sql) | *.sql";
            bool? saveResult = sfd.ShowDialog();

            if (saveResult == true)
            {
                AdminController.BackupFile = sfd.FileName;
                backup_file_path.Text = AdminController.BackupFile;
                AdminController.localBackup(AdminController.ConnectionStringForTMS, AdminController.BackupFile);
            }

            // log
            AdminController.addLog("Backup File Created : " + AdminController.BackupFile);
        }

        private void restore_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MySql Database (*.sql) | *.sql";
            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                restore_file_path.Text = ofd.FileName;
                if(ofd.FileName == AdminController.BackupFile)
                {
                    AdminController.localRestore(AdminController.ConnectionStringForTMS, AdminController.BackupFile);
                }
                else
                {
                    MessageBox.Show("You chose the wrong file! - Only a backup file can be restored.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            // log
            AdminController.addLog("Backup File Restored : " + AdminController.BackupFile);
        }

    }
}
