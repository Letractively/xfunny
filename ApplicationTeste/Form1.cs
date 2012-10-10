using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using XFunny.QAccess;

namespace XFunny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var tst = new teste();
            tst.Nome = "José";
            tst.idade = 28;
            tst.last = "teste";
            tst.Save();
            
            var coll = new QCollection<teste>(tst.Connection, Conditions.Values("", 1));
        }
    }
}
