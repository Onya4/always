using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using always.model;
using always.servic;

namespace always
{

    public partial class MainWindow : Window
    {
        private readonly string Fi1e = $"{Environment.CurrentDirectory}\\isdate.json";
        private BindingList<mod> isdate;
        private serv srv;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            srv = new serv(Fi1e);
            try
            {
                isdate = srv.load();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dgalw.ItemsSource = isdate;
            isdate.ListChanged += Isdate_ListChanged;
        }

        private void Isdate_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    srv.saved(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
          
        }
    }
}

