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
    public partial class Hall : UserControl
    {
        Panel Panel2;
        Panel Panel3;
        MySqlConnection myConnection;

        string name;
        string row1;
        string row2;
        string row3;
        int cost;
        bool flag = false;
        string title;

        public Hall(string name, MySqlConnection myConnection, string title, Panel panel2, Panel panel3)
        {
            InitializeComponent();
            this.name = name;
            this.myConnection = myConnection;
            this.title = title;
            Panel2 = panel2;
            Panel3 = panel3;
        }


        private void button37_Click(object sender, EventArgs e)
        {
            #region
            if (checkBox1.Checked)
            {
                row1 += " 1";
                cost++;
                flag = true;
            }
            if (checkBox2.Checked)
            {
                row1 += " 2";
                cost++;
                flag = true;
            }
            if (checkBox3.Checked)
            {
                row1 += " 3";
                cost++;
                flag = true;
            }  
            if (checkBox4.Checked)
            {
                row1 += " 4";
                cost++;
                flag = true;
            }   
            if (checkBox5.Checked)
            {
                row1 += " 5";
                cost++;
                flag = true;
            }  
            if (checkBox6.Checked)
            {
                row1 += " 6";
                cost++;
                flag = true;
            }
            #endregion // // 


            #region
            if (checkBox10.Checked)
            {
                row2 += " 1";
                cost++;
                flag = true;
            }
            if (checkBox18.Checked)
            {
                row2 += " 2";
                cost++;
                flag = true;
            }
            if (checkBox17.Checked)
            {
                row2 += " 3";
                cost++;
                flag = true;
            }
            if (checkBox16.Checked)
            {
                row2 += " 4";
                cost++;
                flag = true;
            }
            if (checkBox15.Checked)
            {
                row2 += " 5";
                cost++;
                flag = true;
            }
            if (checkBox14.Checked)
            {
                row2 += " 6";
                cost++;
                flag = true;
            }
            #endregion


            #region
            if (checkBox36.Checked)
            {
                row3 += " 1";
                cost++;
                flag = true;
            }
            if (checkBox35.Checked)
            {
                row3 += " 2";
                cost++;
                flag = true;
            }   
            if (checkBox34.Checked)
            {
                row3 += " 3";
                cost++;
                flag = true;
            } 
            if (checkBox33.Checked)
            {
                row3 += " 4";
                cost++;
                flag = true;
            }
            if (checkBox32.Checked)
            {
                row3 += " 5";
                cost++;
                flag = true;
            }
            if (checkBox31.Checked)
            {
                row3 += " 6";
                cost++;
                flag = true;
            }
            #endregion


            if (flag)
            {
                Panel2.Controls.Clear();
                Panel3.Controls.Clear();
                Panel3.Controls.Add(new Store(title,name, row1, row2, row3, myConnection, cost));
            }
            else
                MessageBox.Show("Выберите места");
        }
    }
}
