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

using FitnessClubErmakov.ClassHelper;
using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.Windows;
using Microsoft.Win32;

namespace FitnessClubErmakov.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditServiceWindow.xaml
    /// </summary>
    public partial class AddEditServiceWindow : Window
    {
        private string pathImage = null;
        private bool isEdit = false;
        private Service editService;

        public AddEditServiceWindow()
        {
            InitializeComponent();

            isEdit = false;
        }
        public AddEditServiceWindow(Service service)
        {
            // Конструктор для редактирования

            InitializeComponent();


            // Изменения заголовка и текста кнопки
            TblockTitle.Text = "Редактирование услуги";
            BtnAddEditService.Content = "Сохранить изменения";

            // Заполнение текстовых полей 
            TbNameService.Text = service.Name.ToString();
            TbPriceService.Text = service.Price.ToString();
            TbTimeService.Text = service.DurationInMin.ToString();
            TbDescription.Text = service.Description.ToString();

            // Вывод изображения

            if (service.PhotoPath != null)
            {
                using (MemoryStream stream = new MemoryStream(service.PhotoPath))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    ImgService.Source = bitmapImage;
                }
            }

            isEdit = true;
            editService = service;

        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // Выбор фото 

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddEditService_Click(object sender, RoutedEventArgs e)
        {
            // Валидация
            if (isEdit == true)
            {
                // Изменение
                editService.Name = TbNameService.Text;
                editService.Price = Convert.ToDecimal(TbPriceService.Text);
                editService.DurationInMin = Convert.ToInt32(TbTimeService.Text);
                editService.Description = TbDescription.Text;
                if (pathImage != null)
                {
                    editService.PhotoPath = File.ReadAllBytes(pathImage);
                }
                EFClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно изменена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                // Добавление
                Service service = new Service();
                service.Name = TbNameService.Text;
                service.Price = Convert.ToDecimal(TbPriceService.Text);
                service.DurationInMin = Convert.ToInt32(TbTimeService.Text);
                service.Description = TbDescription.Text;
                service.PhotoPath = File.ReadAllBytes(pathImage);

                EFClass.context.Service.Add(service);
                EFClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно добавлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Close();
        }

    }
}
