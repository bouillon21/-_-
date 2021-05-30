using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace покупка_билетов_рпм.Panel_top
{
    public partial class Top_start : UserControl
    {
        public Top_start(string name)
        {
            InitializeComponent();
            label1.Text = name;
        }
    }
}
