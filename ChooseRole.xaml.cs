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

namespace Group2
{
    /// <summary>
    /// Interaction logic for ChooseRole.xaml
    /// </summary>
    public partial class ChooseRole : Page
    {
        public ChooseRole()
        {
            InitializeComponent();
        }

        private void StartAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminSignin.xaml", UriKind.Relative));

            AdminController.addLog("Choose Admin as Your Role");
        }

        private void StartBuyer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("BuyerSignin.xaml", UriKind.Relative));
        }

        private void StartPlanner_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PlannerSignin.xaml", UriKind.Relative));
        }
    }
}
