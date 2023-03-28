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

using FitnessClubErmakov.Windows;
using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.ClassHelper;

namespace FitnessClubErmakov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // авторизация
            // 1. получить всех пользователей!
            // 2. выбрать пользователей по условию 
            // 3. из итогового списка выбрать одну запись 

            var authUser = ClassHelper.EFClass.context.UserAuth.ToList()
               .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text)
               .FirstOrDefault();

            if (authUser != null)
            {

                ClassHelper.UserClass.AuthUser = authUser;

                // переход на нужное окно
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        private void BtnNoAccount_Click(object sender, RoutedEventArgs e)
        {
            RegisWindow registrationClientWindow = new RegisWindow();
            registrationClientWindow.ShowDialog();
        }
    }
}
