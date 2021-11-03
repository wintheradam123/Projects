using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LaxASFilm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void OpretFilm_Click(object sender, RoutedEventArgs e)
        {
            Window1 opretfilmwin = new Window1();
            opretfilmwin.Show();

        }

        private void SletFilm_Click(object sender, RoutedEventArgs e)
        {
            Window2 sletfilmwin = new Window2();
            sletfilmwin.Show();
        }
        private void RedigerFilm_Click(object sender, RoutedEventArgs e)
        {
            Window3 redigerfilmwin = new Window3();
            redigerfilmwin.Show();
        }
    }
    public class SQLConnection
    {
        public void cnnstring()
        {
            
        }
    }
}
