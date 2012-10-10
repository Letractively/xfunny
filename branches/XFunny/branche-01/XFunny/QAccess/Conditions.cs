using System;
using System.Collections.Generic;
using System.Linq;

namespace XFunny.QAccess
{
    /// <summary>
    /// Classe que define as condições para busca
    /// </summary>
    public abstract class Conditions: ICloneable
    {
        /// <summary>
        /// Campos do objeto
        /// </summary>
        protected internal string[] _Fields;

        /// <summary>
        /// Valores dos campos
        /// </summary>
        protected internal object[] _values;

        /// <summary>
        /// Construtor
        /// </summary>
        protected Conditions() 
        {
        
        }

        /// <summary>
        /// Valores de condição da consulta
        /// </summary>
        /// <param name="pCondition">Condição de consulta</param>
        /// <param name="argsobj">Valores</param>
        /// <returns>Condição</returns>
        public static Conditions Values(string pCondition, params object[] argsobj) 
        {

            return null;
        }

        protected object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
