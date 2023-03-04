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


    // MultiSelectionComboBox https://github.com/RWS/Multiselect-ComboBox?ysclid=les6rck06w664725059


    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    public partial class ServiceListWindow : Window
    {
        public ServiceListWindow()
        {
            InitializeComponent();
            GetServiceList();
            CMBFilter.ItemsSource = ClassHelper.EFClass.context.Service.ToList();
            CMBFilter.DisplayMemberPath = "Price";

            CMBOrder.ItemsSource = "От А до Я";

        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = EFClass.context.Service.ToList();

            // Поиск, фильтрация, сортировка

            // Поиск
            serviceList = serviceList.Where(s => s.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            //Фильтрация

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
    }
}
