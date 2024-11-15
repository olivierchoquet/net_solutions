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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        GestionnaireTaches gest = new GestionnaireTaches();
       

        public MainWindow()
        {
            InitializeComponent();
            datagrid.DataContext = gest.ListeTaches;
            IList<int> priorités = new List<int>();
            for (int i=1;i<=5;i++)
            {
                priorités.Add(i);
            }
            PrioriteValeur.DataContext = priorités;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid.SelectedItem = null;
            DescriptionValeur.Text = "";
            PrioriteValeur.SelectedItem = 3;
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                Tache nouvelleTache = new Tache(DescriptionValeur.Text);
                nouvelleTache.Priorité = (int)PrioriteValeur.SelectedItem;
                nouvelleTache.Date = (DateTime) DateValeur.SelectedDate;
                nouvelleTache.Termine = TermineValeur.IsChecked.Value;
                gest.ListeTaches.Add(nouvelleTache);
                datagrid.Items.Refresh(); 
                
            
    
            
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tache modifTache = (Tache)datagrid.SelectedItem;
            gest.ListeTaches.Remove(modifTache);
            datagrid.Items.Refresh(); 

           
        }
    }
}
