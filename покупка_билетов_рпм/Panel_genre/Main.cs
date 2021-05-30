using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace покупка_билетов_рпм
{
    public partial class Main : UserControl
    {
        MySqlConnection myConnection;
        Panel Panel2;
        Panel Panel3;
        string URL;
        string film;
        string name;
        public Main(Panel panel2, Panel panel3, MySqlConnection myConnection, string film, string name)
        {
            InitializeComponent();
            Panel2 = panel2;
            Panel3 = panel3;
            this.myConnection = myConnection;
            this.film = film;
            this.name = name;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MySqlCommand genre = new MySqlCommand($"SELECT Жанр FROM Фильмы WHERE Название = '{film}' ", myConnection);
            MySqlCommand description = new MySqlCommand($"SELECT Описание FROM Фильмы WHERE Название = '{film}' ", myConnection);
            MySqlCommand producer = new MySqlCommand($"SELECT Режисер FROM Фильмы WHERE Название = '{film}' ", myConnection);
            MySqlCommand year = new MySqlCommand($"SELECT Год FROM Фильмы WHERE Название = '{film}' ", myConnection);
            MySqlCommand url = new MySqlCommand($"SELECT URL FROM Фильмы WHERE Название = '{film}' ", myConnection);
            URL = url.ExecuteScalar().ToString();
            label6.Text = film;
            label7.Text = genre.ExecuteScalar().ToString();
            label8.Text = year.ExecuteScalar().ToString();
            label9.Text = producer.ExecuteScalar().ToString();
            textBox1.Text = description.ExecuteScalar().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel2.Controls.Clear();
            Panel3.Controls.Clear();

            Panel3.Controls.Add(new Hall(name, myConnection, film, Panel2, Panel3));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(URL);
            }
            catch (Exception)
            {
                MessageBox.Show("Ссылка не ведет на трейлер");
            }
        }
    }
}
