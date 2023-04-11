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
    /// Логика взаимодействия для ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        public List<string> listOrder = new List<string>()
        {
        "По умолчанию",
        "По имени (А - Я)",
        "По имени (Я - А)",
        "По возстрасту (возрастание)",
        "По возстрасту (убывание)"
        };
        List<string> listFilter = new List<string>()
        {
        "Без фильтра",
        "С фото",
        "Без фото"
        };
        public ClientListWindow()
        {
            InitializeComponent();
            GetClientList();

            CMBOrder.ItemsSource = listOrder;
            CMBOrder.SelectedIndex = 0;

            CMBFilter.ItemsSource = listFilter;
            CMBFilter.SelectedIndex = 0;
        }

        private void GetClientList()
        {
            List<Client> clientList = new List<Client>();

            clientList = EFClass.context.Client.ToList();

            // Поиск, фильтрация, сортировка

            // Поиск
            clientList = clientList.Where(s => s.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            // Сортировка
            switch (CMBOrder.SelectedIndex)
            {
                case 0:
                    clientList = clientList.OrderBy(s => s.IdClient).ToList();
                    break;
                case 1:
                    clientList = clientList.OrderBy(s => s.Name).ToList();
                    break;
                case 2:
                    clientList = clientList.OrderByDescending(s => s.Name).ToList();
                    break;
                case 3:
                    clientList = clientList.OrderBy(s => s.BirthdayDate).ToList();
                    break;
                case 4:
                    clientList = clientList.OrderByDescending(s => s.BirthdayDate).ToList();
                    break;
                default:
                    clientList = clientList.OrderBy(s => s.IdClient).ToList();
                    break;
            }
            // Фильтрация


            lvClient.ItemsSource = clientList;
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var client = button.DataContext as Client;

            
            RegisWindow regisWindow = new RegisWindow(client);
            regisWindow.ShowDialog();

            GetClientList();

        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            RegisWindow regisWindow = new RegisWindow();
            regisWindow.ShowDialog();

            GetClientList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetClientList();
        }

        private void CMBOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetClientList();
        }

        private void lvClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
