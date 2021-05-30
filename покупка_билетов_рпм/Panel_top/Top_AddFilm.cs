using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace покупка_билетов_рпм
{
    public partial class Top_AddFilm : UserControl
    {
        string name;
        
        public Top_AddFilm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void Top_AddFilm_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }
    }
}
