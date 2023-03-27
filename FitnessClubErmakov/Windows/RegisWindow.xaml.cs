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
using System.IO;

using FitnessClubErmakov.Windows;
using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.ClassHelper;
using Microsoft.Win32;

namespace FitnessClubErmakov.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegisWindow.xaml
    /// </summary>
    public partial class RegisWindow : Window
    {
        private string pathImage = null;
        private bool isEdit = false;
        private Client editClient;

        public RegisWindow()
        {
            InitializeComponent();
            CMBGender.ItemsSource = ClassHelper.EFClass.context.GenderCode.ToList();
            CMBGender.DisplayMemberPath = "Name";

            isEdit = false;
        }
        public RegisWindow(Client client) 
        {
            // Конструктор для редактирования

            InitializeComponent();

            // Изменения заголовка и текста кнопки
            TblockTitle.Text = "Редактирование клиента";
            BtnRegistration.Content = "Сохранить изменения";

            // Заполнение текстовых полей 
            tbFirstName.Text = client.Name.ToString();
            tbSecondName.Text = client.SecondName.ToString();
            tbPatronimic.Text = client.Patronimic.ToString();
            tbPhone.Text = client.Phone.ToString();
            tbEmail.Text = client.Email.ToString();
            CMBGender.SelectedItem = client.GenderCode.ToString();


            // Вывод изображения

            if (client.PhotoPath != null)
            {
                using (MemoryStream stream = new MemoryStream(client.PhotoPath))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    ImgClient.Source = bitmapImage;
                }
            }

            isEdit = true;
            editClient = client;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {

            // Выбор фото 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgClient.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
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
            if (isEdit == true)
            {

            }
            else 
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
                    MessageBox.Show("Пароли должны совпадать!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;                    
                }
                else
                {
                    // Добавление клиента
                    Client client = new Client();

                    client.Name = tbFirstName.Text;
                    client.SecondName = tbSecondName.Text;
                    client.Patronimic = tbPatronimic.Text;
                    client.Phone = tbPhone.Text;
                    client.Email = tbEmail.Text;
                    client.GenderCode = (CMBGender.SelectedItem as GenderCode).GenderCode1;
                    client.IdTag = 1;
                    client.PhotoPath = File.ReadAllBytes(pathImage);

                    EFClass.context.Client.Add(client);
                    EFClass.context.SaveChanges();
                    MessageBox.Show("Регистрация успешна!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
            }
           
        }
    }
}
