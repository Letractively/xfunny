using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XFunny.QAccess
{
    /// <summary>
    /// Classe base para objetos que representam a estrutura de dados
    /// </summary>
    public abstract class QObjectBase : IObject, IDisposable
    {
        /// <summary>
        /// Objeto de connexão com a base de dados
        /// </summary>
        private QConnect _Connection;

        /// <summary>
        /// Identificador do objeto
        /// </summary>
        private Guid _OCod;

        /// <summary>
        /// Conexão com a base de dados
        /// </summary>
        [NonPersistent]
        public QConnect Connection { get { return _Connection; } }

        /// <summary>
        /// Identificador do objeto
        /// </summary>
        public Guid OCod { get { return _OCod; } }

        /// <summary>
        /// Construtor
        /// </summary>
        public QObjectBase()
        {
            if (InitConnection.Connect == null)
            {
                InitConnection.CreateConnection();;
                _Connection = InitConnection.Connect;                
            }
            else _Connection = InitConnection.Connect;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="pConnect">Conexão</param>
        public QObjectBase(QConnect pConnect)
        {
            _Connection = pConnect;
        }

        /// <summary>
        /// Destroi o objeto
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        

        /// <summary>
        /// Define valores nulos para o objeto
        /// </summary>
        /// <param name="disposing">descatar</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (Connection != null)
                {
                    Connection.Dispose();
                    _Connection = null;
                }
        }

        /// <summary>
        /// Desconstrutor
        /// </summary>
        ~QObjectBase()
        {
            Dispose(false);
        }
        
        public virtual void OnSaving()
        {
            
        }

        public virtual void OnSalved()
        {
            
        }

        public virtual void OnDeleting()
        {
            
        }

        public virtual void OnDeleted()
        {
            
        }

        /// <summary>
        /// Salva o objeto
        /// </summary>
        public void Save()
        {
            try
            {
                _Connection.Open();

                OnSaving();

                if (_OCod.Equals(Guid.Empty))
                {
                    _OCod = Guid.NewGuid();
                    var v = this.GetType().GetProperty("Nome").GetValue(this, null);
                    this._Connection.Insert(this);

                }
                else this._Connection.Update(this);

                OnSalved();
            }
            finally { _Connection.Close(); }
        }
        
        /// <summary>
        /// Retorna o identificador do objeto
        /// </summary>
        /// <returns>Código do objeto</returns>
        public override string ToString()
        {
            return OCod.ToString();
        }
    }
}
