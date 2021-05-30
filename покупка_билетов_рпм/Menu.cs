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
using покупка_билетов_рпм.SQL;

namespace покупка_билетов_рпм
{
    public partial class Menu : UserControl
    {
        MySqlConnection myConnection;
        public Panel Panel1;
        public Panel Panel2;
        public Panel Panel3;
        string name;

        public Menu(Panel panel1, Panel panel2, Panel panel3, string name)
        {
            InitializeComponent();

            Panel1 = panel1;
            Panel2 = panel2;
            Panel3 = panel3;
            myConnection = DBUtils.GetDBConnection();
            myConnection.Open();
            this.name = name;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Panel2.Controls.Clear();
            Panel3.Controls.Clear();
            Panel2.Controls.Add(new Top(name, Panel2, Panel3));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Panel2.Controls.Clear();
            Panel3.Controls.Clear();

            Panel2.Controls.Add(new Top_AddFilm(name));
            Panel3.Controls.Add(new AddFilm(myConnection));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel2.Controls.Clear();
            Panel3.Controls.Clear();

            Panel3.Controls.Add(new Event());
        }
    }
}
