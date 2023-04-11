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
using System.Windows.Shapes;


using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.ClassHelper;

namespace FitnessClubErmakov.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            TxtNameUser.Text = "Пользователь: " + ClassHelper.UserClass.AuthUser.Login + " Роль: " + ClassHelper.UserClass.AuthUser.Role.RoleName;
        }
        private void BtnServiceListGo_Click(object sender, RoutedEventArgs e)
        {
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            serviceListWindow.Show();
            this.Close();
        }

        private void BtnClientListGo_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
            this.Close();
        }
    }
}
