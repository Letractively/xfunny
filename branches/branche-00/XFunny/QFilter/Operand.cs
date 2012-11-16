using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace XFunny.QFilter
{
    public class Operand
    {
        protected internal object valor;
        protected internal string key;

        public string Left { get { return key; } set { key = value; } }
        public CSTyteOperator OperandType { get; set; }
        public object Right { get { return valor; } set { valor = value; } }

        /// <summary>
        /// Monta condições 
        /// </summary>
        /// <returns>condião</returns>
        public string Join() 
        {
            return string.Format("{0} {1} {2}", this.Left, GetDescription(this.OperandType), this.Right);
        }

        /// <summary>
        /// Pega a descrição do enum 
        /// </summary>
        /// <param name="value">valor do enum</param>
        /// <returns>Descrição do enum</returns>
          internal string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = 
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), 
                false);
            
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }             
    }
}
