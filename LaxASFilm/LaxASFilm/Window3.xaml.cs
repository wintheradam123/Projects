using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Søgbtn_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString;
            SqlConnection cnn;
            connectionString = "Data Source=DESKTOP-MBP26GM;Initial Catalog=Movies;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlDataReader myReader = null;

            try
            {
                cnn.Open();

                SqlCommand command = new SqlCommand("select * from movie where Name_ = @Name", cnn);
                command.Parameters.AddWithValue("@Name", Snavn.Text);
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    navn.Text = myReader.GetValue(1).ToString();
                    dato.Text = myReader.GetValue(2).ToString();
                    alder.Text = myReader.GetValue(3).ToString();
                    kategori.Text = myReader.GetValue(4).ToString();
                }
                cnn.Close();

                
            }
            catch
            {
                throw;
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = "Data Source=DESKTOP-MBP26GM;Initial Catalog=Movies;Integrated Security=True";
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();

                SqlCommand command = new SqlCommand("UPDATE movie SET Name_ = @Name_, DMY = @DMY, AgeRating = @AgeRating, Category = @Category WHERE Name_ = @SName", cnn);
                command.Parameters.AddWithValue("@Name_", navn.Text);
                command.Parameters.AddWithValue("@DMY", dato.Text);
                command.Parameters.AddWithValue("@AgeRating", alder.Text);
                command.Parameters.AddWithValue("@Category", kategori.Text);
                command.Parameters.AddWithValue("@SName", Snavn.Text);

                command.ExecuteNonQuery();
                cnn.Close();

                MessageBox.Show("Film opdateret");
            }
            catch 
            {

                throw;
            }
        }
    }
}
