using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XFunny.QFilter;
using ApplicationTeste;

namespace XFunny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var tst = new Pessoa();
            tst.Braco = true;
            tst.Cabeca = false;
            tst.Perna = false;
            tst.Filhos = new QCollection<Filho>();
            tst.Filhos.Add(new Filho() { Idade = 22, Nome = "Filho", pai = tst });
            tst.Save();

            var coll = new QCollection<teste>(tst.Connection, Conditions.Values("OCod = 'F0EA6007-E8FD-4CE5-88F2-5F9EE697300E'", 28));
            coll[0].Nome = "Maria";
            coll[0].Save();
        }
    }
}
