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
    /// Interaction logic for PlannerDashBoard.xaml
    /// </summary>
    public partial class PlannerDashBoard : Page
    {
        public PlannerDashBoard()
        {
            InitializeComponent();
        }

        private void planner_menu1_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu1.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }

        private void planner_menu1_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu1.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu1_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }

        private void planner_menu2_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu2.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }

        private void planner_menu2_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu2.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu2_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }

        private void planner_menu3_MouseEnter(object sender, MouseEventArgs e)
        {
            planner_menu3.Background = new SolidColorBrush(Color.FromRgb(69, 177, 107));
            planner_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(236, 255, 243));
        }

        private void planner_menu3_MouseLeave(object sender, MouseEventArgs e)
        {
            planner_menu3.Background = new SolidColorBrush(Color.FromRgb(236, 255, 243));
            planner_menu3_label.Foreground = new SolidColorBrush(Color.FromRgb(69, 177, 107));
        }

        private void PlannerBackToMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }

    }
}
