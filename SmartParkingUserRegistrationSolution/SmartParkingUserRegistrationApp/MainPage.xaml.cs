using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.SqlClient;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartParkingUserRegistrationApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void FirstName1Input_TextChanged(object sender, TextChangedEventArgs e) { }
        private void FirstName2Input_TextChanged(object sender, TextChangedEventArgs e) { }
        private void LastNameInput_TextChanged(object sender, TextChangedEventArgs e) { }

        private void SendInfo(object sender, RoutedEventArgs e)
        {

            string[] name = new string[3];
            name[0] = FirstName1Input.Text;
            name[1] = FirstName2Input.Text;
            name[2] = LastNameInput.Text;

            SqlConnectionStringBuilder settingsBuilder = new SqlConnectionStringBuilder();


            settingsBuilder.UserID = "morillo";
            settingsBuilder.Password = "Intec@1234";
            settingsBuilder.InitialCatalog = "lemes";
            settingsBuilder.DataSource = "tcp:morillo.database.windows.net";
            settingsBuilder.ConnectTimeout = 30;
            settingsBuilder.ApplicationIntent = ApplicationIntent.ReadWrite;
            string query = "INSERT lemes.UserData(UserFName1, UserFName2, UserLName, AuthorizationStatus)" +
                           "VALUES('" + name[0] + "', " + name[1] + ", '" + name[2] + "', 1)" +
                           "GO";

            using (SqlConnection connection = new SqlConnection("Server=tcp:sparking.database.windows.net,1433;Initial Catalog=ParkingDatabse;Persist Security Info=False;User ID=parkingAdmin;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                //connection.OpenAsync();
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
