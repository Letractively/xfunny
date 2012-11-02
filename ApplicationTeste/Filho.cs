using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFunny.QAccess;

namespace ApplicationTeste
{
    public class Filho: QObjectBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        
        [Association("Pai_Filho", AssociationAttribute.CSTypeAssociate.Composition)]
        public Pessoa pai { get; set; }
    }
}
