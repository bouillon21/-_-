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
using покупка_билетов_рпм.Panel_top;

namespace покупка_билетов_рпм
{
    public partial class Reg : UserControl
    {
        MySqlConnection myConnection;
        public Panel Panel1;
        public Panel Panel2;
        public Panel Panel3;
        public Reg(Panel panel1, Panel panel2, Panel panel3)
        {
            InitializeComponent();

            Panel1 = panel1;
            Panel2 = panel2;
            Panel3 = panel3;
            myConnection = DBUtils.GetDBConnection();
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                MySqlCommand check_login = new MySqlCommand($"SELECT login from users where login='{textBox1.Text}'", myConnection);
                if (check_login.ExecuteScalar() == null)
                {
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO users (login, pass, email, phone) " +
                        $"VALUES ('{textBox1.Text}','{textBox4.Text}','{textBox3.Text}','{textBox2.Text}')", myConnection);
                    cmd.ExecuteNonQuery();
                    Panel2.Controls.Clear();
                    Panel3.Controls.Clear();
                    Panel1.Controls.Add(new Menu(Panel1, Panel2, Panel3, textBox1.Text));
                    Panel2.Controls.Add(new Top_start(textBox1.Text));
                    Panel3.Controls.Add(new Event());
                }
                else
                    MessageBox.Show("Такой пользователь уже есть");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
