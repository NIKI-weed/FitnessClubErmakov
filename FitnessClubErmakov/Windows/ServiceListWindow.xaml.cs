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

using FitnessClubErmakov.ClassHelper;
using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.Windows;

namespace FitnessClubErmakov.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    /// 
    public partial class ServiceListWindow : Window
    {
        public List<string> listOrder = new List<string>()
        {
        "По умолчанию",
        "По названию (А - Я)",
        "По названию (Я - А)",
        "По цене (возрастание)",
        "По цене (убывание)"
        };

        List<string> listFilter = new List<string>()
        {
            "Без фильтра",
            "С фото",
            "Без фото"
        };
        public ServiceListWindow()
        {
            InitializeComponent();
            GetServiceList();

            CMBOrder.ItemsSource = listOrder;
            CMBOrder.SelectedIndex = 0;

            CMBFilter.ItemsSource = listFilter;
            CMBFilter.SelectedIndex = 0;
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = EFClass.context.Service.ToList();

            // Поиск, фильтрация, сортировка

            // Поиск
            serviceList = serviceList.Where(s => s.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            // Сортировка
            switch (CMBOrder.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.OrderBy(s => s.IdService).ToList();
                    break;
                case 1:
                    serviceList = serviceList.OrderBy(s => s.Name).ToList();
                    break;
                case 2:
                    serviceList = serviceList.OrderByDescending(s => s.Name).ToList();
                    break;
                case 3:
                    serviceList = serviceList.OrderBy(s => s.Price).ToList();
                    break;
                case 4:
                    serviceList = serviceList.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    serviceList = serviceList.OrderBy(s => s.IdService).ToList();
                    break;
            }
            // Фильтрация


            lvService.ItemsSource = serviceList;
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;


            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetServiceList();
        }

        private void CMBOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;

            ClassHelper.CartClass.serviceCart.Add(service);
            MessageBox.Show($"Услуга \"{service.Name.ToString()}\" добавлена");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.ShowDialog();
        }
    }
}