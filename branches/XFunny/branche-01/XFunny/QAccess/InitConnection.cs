using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace XFunny.QAccess
{
    /// <summary>
    /// Inicializa a conexão com a base de dados
    /// </summary>
    static class InitConnection
    {
        /// <summary>
        /// Conexão usada por toda aplicação
        /// </summary>
        private static QConnect _Connect;

        /// <summary>
        /// Conexão usada por toda aplicação
        /// </summary>
        public static QConnect Connect { get { return _Connect; } set { _Connect = value; } }

        /// <summary>
        /// Cria uma conexão
        /// </summary>
        internal static void CreateConnection() 
        {
            Assembly module = Assembly.GetEntryAssembly();
            Type setting = module.GetTypes().Where(p => p.Name.Equals("Settings")).FirstOrDefault();
            var obj = Activator.CreateInstance(setting);
            var proper = setting.GetProperty("ConnectionString");
            var value = proper.GetValue(obj, null).ToString();
            _Connect = new QConnect(value);
        }
    }
}
