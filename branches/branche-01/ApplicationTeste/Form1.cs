using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XFunny.QFilter;
using ApplicationTeste;
using XFunny.QConnecting;

namespace XFunny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
/*
            var tst = new Pessoa();
            tst.Braco = true;
            tst.Cabeca = false;
            tst.Perna = false;
            tst.Filhos = new QCollection<Filho>();
            tst.Filhos.Add(new Filho() { Idade = 22, Nome = "Filho", pai = tst });
            tst.Save();
            */            
            var coll = new QCollection<Pessoa>(new QConnect(global::ApplicationTeste.Properties.Settings.Default.ConnectionString), new Conditions());

            foreach (var item in coll.Cast<Pessoa>().Where(p => p.Filhos.Count > 0))
            {
                
            }
            //coll[0].Nome = "Maria";
            //coll[0].Save();
        }
    }
}
