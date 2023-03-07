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

using FitnessClubErmakov.Windows;
using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.ClassHelper;

namespace FitnessClubErmakov.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegisWindow.xaml
    /// </summary>
    public partial class RegisWindow : Window
    {
        public RegisWindow()
        {
            InitializeComponent();
            CMBGender.ItemsSource = ClassHelper.EFClass.context.GenderCode.ToList();
            CMBGender.DisplayMemberPath = "Name";
        }

        // Кнопка "Уже есть аккаунт"
        private void BtnAlreadyAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow registrationClientWindow = new AuthWindow();
            registrationClientWindow.ShowDialog();
        }

        // Кнопка "Регистрация"
        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                MessageBox.Show("Поле \"фамилия\" не может быть пустыми!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Нужен пароль!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка совпедения паролей
            if (tbPassword == tbRepPassword)
            {
                // Добавление клиента
                Client client = new Client();

                client.Name = tbFirstName.Text;
                client.SecondName = tbSecondName.Text;
                client.Patronimic = tbPatronimic.Text;
                client.Phone = tbPhone.Text;
                client.Email = tbEmail.Text;
                client.GenderCode = (CMBGender.SelectedItem as GenderCode).GenderCode1;
                client.Password = tbPassword.Text;

                ClassHelper.EFClass.context.Client.Add(client);

                ClassHelper.EFClass.context.SaveChanges();

                MessageBox.Show("Регистрация успешна!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                MessageBox.Show("Пароли должны совпадать!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }            
        }
    }
}
