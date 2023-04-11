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

namespace FitnessClubErmakov.Windows.Coach
{
    /// <summary>
    /// Логика взаимодействия для ShceduleWindow.xaml
    /// </summary>
    public partial class ShceduleWindow : Window
    {
        public ShceduleWindow()
        {
            InitializeComponent();
            GetClientList();
        }
        private void GetClientList()
        {
            List<Client> clientList = new List<Client>();
            clientList = EFClass.context.Client.ToList();
        }
    }
}
