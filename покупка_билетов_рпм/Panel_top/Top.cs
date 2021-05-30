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
    public partial class Top : UserControl
    {
        Panel Panel2;
        Panel Panel3;
        MySqlDataAdapter da;
        MySqlConnection myConnection;
        string name;

        public Top(string name, Panel panel2, Panel panel3)
        {
            InitializeComponent();

            this.name = name;
            myConnection = DBUtils.GetDBConnection();
            myConnection.Open();
            Panel2 = panel2;
            Panel3 = panel3;
        }



        private void Top_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string film;

            if (comboBox1.Text != "")
            {
                film = comboBox1.Text;

                Panel3.Controls.Clear();
                Panel3.Controls.Add(new Main(Panel2, Panel3, myConnection, film, name));

            }
        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            da = new MySqlDataAdapter("select *from Фильмы ", myConnection);
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "Название";// столбец для отображения
            comboBox1.SelectedIndex = -1;
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            e.Handled = true;
        }
    }
}