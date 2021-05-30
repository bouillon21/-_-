using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;
using покупка_билетов_рпм.SQL;

namespace покупка_билетов_рпм
{
    public partial class Store : UserControl
    {
        string cheque;
        string title;
        string name;
        string row1;
        string row2;
        string row3;
        string eat;
        int cost;
        MySqlConnection myConnection;

        public Store(string title, string name, string row1, string row2, string row3, MySqlConnection myConnection, int cost)
        {
            InitializeComponent();
            this.title = title;
            this.name = name;
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.myConnection = myConnection;
            this.cost = cost;
        }


        public string phone;
        public string mail;
        string basket;
        private void button37_Click(object sender, EventArgs e)
        {
            cheque += $"{name} купил(а) билеты на фильм: {title}\nДеньги будут списаны с телефона: {phone}\nМеста:\n";

            if (row1 != null)
                basket += $"Ряд 1: {row1}\n";
            if (row2 != null)
                basket += $"Ряд 2: {row2}\n";
            if (row3 != null)
                basket += $"Ряд 3: {row3}\n";

            cost *= 250;

            if (radioButton1.Checked)
            {
                eat = "Маленький попкорн";
                cost += 150;
            }
                
            if (radioButton2.Checked)
            {
                eat = "Средний попкорн";
                cost += 270;
            }
                
            if (radioButton3.Checked)
            {
                eat = "Большой попкорн";
                cost += 350;
            }
            cheque += basket;
            cheque += $"Так же вы купили: {eat}\n";
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO orders (login,basket,cost) VALUES ('{name}','фильм :{title} места: {basket} еда: {eat}','{cost}')", myConnection);
            cmd.ExecuteNonQuery();
            cheque += $"Общая стоимость заказа составила: {cost}р.";

            try
            {
                MySqlCommand check_mail = new MySqlCommand($"SELECT email from users where login='{name}'", myConnection);
                if (check_mail.ExecuteScalar() != null)
                    mail = check_mail.ExecuteScalar().ToString();
                MailAddress from = new MailAddress("4232g@mail.ru", "FilmHub");
                MailAddress to = new MailAddress(mail);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Чек";
                m.Body = cheque;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("4232g@mail.ru", "Qwe123asd45");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show($"Чек отправлен на почту {mail}\nПрограмма по покупки билета автоматически закроется");
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка во время покупки\nПрограмма автоматически закроется");
                Application.Exit();
            }
        }
    }
}
