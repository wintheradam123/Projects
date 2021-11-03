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
using System.Windows.Shapes;

namespace LaxASFilm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void opretbtn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = "Data Source=DESKTOP-MBP26GM;Initial Catalog=Movies;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            

            try
            {
                cnn.Open();

                String query = "INSERT INTO dbo.movie (Name_,DMY,AgeRating,Category) VALUES (@Name_,@DMY,@AgeRating, @Category)";

                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@Name_", navn.Text);
                command.Parameters.AddWithValue("@DMY", dato.Text);
                command.Parameters.AddWithValue("@AgeRating", alder.Text);
                command.Parameters.AddWithValue("@Category", kategori.Text);

                command.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Film oprettet");
            }
            catch 
            {

                return;
            }

        }
    }
}
