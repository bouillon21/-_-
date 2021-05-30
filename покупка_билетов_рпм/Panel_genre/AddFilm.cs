using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using покупка_билетов_рпм.SQL;

namespace покупка_билетов_рпм
{
    public partial class AddFilm : UserControl
    {
        MySqlConnection myConnection;

        public AddFilm(MySqlConnection myConnection)
        {
            InitializeComponent();

            this.myConnection = myConnection;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                MySqlCommand check_film = new MySqlCommand($"SELECT Название from Фильмы where Название='{textBox1.Text}'", myConnection);
                if (check_film.ExecuteScalar() == null)
                {
                    MySqlCommand genre = new MySqlCommand($"INSERT INTO Фильмы (Название,Жанр,Описание,Режисер,Год,URL) VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox5.Text}','{textBox4.Text}','{textBox3.Text}','{textBox6.Text}')", myConnection);
                    genre.ExecuteNonQuery();
                    MessageBox.Show("Фильм создан !");
                }
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }
    }
}
