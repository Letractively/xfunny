using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFunny.QAccess;
using XFunny.QFilter;

namespace ApplicationTeste
{
    public class Pessoa: QObjectBase
    {
        public bool Cabeca { get; set; }
        public bool Braco { get; set; }
        public bool Perna { get; set; }
                
        public QCollection<Filho> Filhos { get; set; }
    }
}
