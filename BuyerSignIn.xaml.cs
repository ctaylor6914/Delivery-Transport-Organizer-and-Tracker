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
    /// Interaction logic for BuyerSignIn.xaml
    /// </summary>
    public partial class BuyerSignIn : Page
    {

        protected int signInAttemptRemain = 2;

        public BuyerSignIn()
        {
            InitializeComponent();
        }

        private void BuyerSignInButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            BuyerIdError.Text = "";
            BuyerPasswordError.Text = "";

            if (ForBuyerID.Text != "buyer")
            {
                errorCount++;
                BuyerIdError.Text = "* Incorrect User ID";
            }

            if (ForBuyerPassWord.Password != "buyer")
            {
                errorCount++;
                BuyerPasswordError.Text = "* Incorrect Password";
            }

            if (errorCount > 0)
            {
                if (signInAttemptRemain == 0)
                {
                    AdminSignInButton.Visibility = Visibility.Collapsed;
                    adminWarning.Visibility = Visibility.Visible;
                    adminLock.Visibility = Visibility.Visible;
                    adminSignInFail.Visibility = Visibility.Visible;
                }
                signInAttemptRemain--;
                AdminSingInAttemptMsg.Text = $"Sign In Attempt Remaining {signInAttemptRemain + 1}";
            }
            else
            {
                signInAttemptRemain = 0;
                AdminSingInAttemptMsg.Text = "";
                // If ID and Password match, move to the admin panel - currently it lands on the wrong page. Fix it!
                this.NavigationService.Navigate(new Uri("BuyerDashBoard.xaml", UriKind.Relative));
            }



        }

        // Go back button --- start
        private void buyer_avatar_left_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_avatar_label_left.Background = new SolidColorBrush(Color.FromRgb(239, 70, 111));
            buyer_avatar_label_left.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void buyer_avatar_left_MouseLeave(object sender, MouseEventArgs e)
        {
            buyer_avatar_label_left.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            buyer_avatar_label_left.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        private void buyer_avatar_left_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminSignIn.xaml", UriKind.Relative));
        }

        private void buyer_avatar_right_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_avatar_label_right.Background = new SolidColorBrush(Color.FromRgb(239, 70, 111));
            buyer_avatar_label_right.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void buyer_avatar_right_MouseLeave(object sender, MouseEventArgs e)
        {
            buyer_avatar_label_right.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            buyer_avatar_label_right.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        private void buyer_avatar_right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PlannerSignIn.xaml", UriKind.Relative));
        }

        private void buyer_go_back_MouseEnter(object sender, MouseEventArgs e)
        {
            buyer_go_back_avatar.Visibility = Visibility.Visible;
        }

        private void buyer_go_back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseRole.xaml", UriKind.Relative));
        }

        // Go back button --- end
    }
}
