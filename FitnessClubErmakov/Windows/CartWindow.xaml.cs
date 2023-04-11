using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FitnessClubErmakov.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetServices();
        }
        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as DataBase.Service;
            ClassHelper.CartClass.serviceCart.Remove(service);

            MessageBox.Show($"Услуга \"{service.Name.ToString()}\" удалена");
            GetServices();
        }

        private void GetServices()
        {
            ObservableCollection<Service> source = new ObservableCollection<Service>(ClassHelper.CartClass.serviceCart);
            lvCartService.ItemsSource = source;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.IdClient = 1;
            order.IdEmploye = 1;
            order.DateOrder = DateTime.Now;

            EFClass.context.Order.Add(order);
            //EFClass.context.SaveChanges();

            OrderService orderService = new OrderService();
            orderService.IdOrder = 1;
            orderService.IdService = 1;
            orderService.Quantity = 1;
            orderService.Summary = 1;

            EFClass.context.OrderService.Add(orderService);
            //EFClass.context.SaveChanges();


            MessageBox.Show("Покупка успешно совершена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}