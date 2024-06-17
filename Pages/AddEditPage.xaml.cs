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
using WpfApp2.Classes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public Orders currentperson = new Orders();
        public AddEditPage(Orders SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null)
                currentperson = SelectedUser;
            DataContext = currentperson;
            cmbboxman.ItemsSource = EkzamBDEntities.GetContext().Mans.ToList();
            cmbboxman.SelectedValuePath = "ID_Man";
            cmbboxman.DisplayMemberPath = "Name";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentperson.DateOrder.ToString()))
                error.AppendLine("Ploho");
            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (currentperson.ID_Order == 0)
                EkzamBDEntities.GetContext().Orders.Add(currentperson);
            try
            {
                EkzamBDEntities.GetContext().SaveChanges();
                MessageBox.Show("pobeda");
                this.NavigationService.Navigate(new Pages.StartPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
