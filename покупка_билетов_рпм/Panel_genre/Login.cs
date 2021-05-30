using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using покупка_билетов_рпм.SQL;
using MySql.Data.MySqlClient;
using покупка_билетов_рпм.Panel_top;
using покупка_билетов_рпм.Panel_genre;

namespace покупка_билетов_рпм
{
    public partial class Login : UserControl
    {
        MySqlConnection myConnection;
        public Panel Panel1;
        public Panel Panel2;
        public Panel Panel3;

        public Login(Panel panel1, Panel panel2, Panel panel3)
        {
            InitializeComponent();

            Panel1 = panel1;
            Panel2 = panel2;
            Panel3 = panel3;
            myConnection = DBUtils.GetDBConnection();
            myConnection.Open();
        }

        private bool user
        {
            get
            {
                MySqlCommand entrance = new MySqlCommand($"SELECT login from users where login='{textBox1.Text}' and pass='{textBox4.Text}' ", myConnection);
                if (entrance.ExecuteScalar() != null)
                    return true;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "")
                MessageBox.Show("Введите данные!");
            else if (user)
            {
                Panel2.Controls.Clear();
                Panel3.Controls.Clear();
                Panel1.Controls.Add(new Menu(Panel1, Panel2, Panel3, textBox1.Text));
                Panel2.Controls.Add(new Top_start(textBox1.Text));
                Panel3.Controls.Add(new Event());
            }
            else if (MessageBox.Show("Неправильно введен логин или пароль, хотите пройти регистрацию"
                , "Внимание!" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Panel3.Controls.Clear();
                Panel3.Controls.Add(new Reg(Panel1, Panel2, Panel3));
            }
        }
    }
}
