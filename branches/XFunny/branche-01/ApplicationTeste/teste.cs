using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFunny.QAccess;

namespace XFunny
{
    public class teste: QObjectBase
    {

        public string Nome { get; set; }

        public int idade { get; set; }

        [NonPersistent]
        public string last { get; set; }

        public teste() 
        {
           // global::ApplicationTeste.Properties.Resources.ResourceManager.  
        }
    }
}
