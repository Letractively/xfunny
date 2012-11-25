using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Data;
using XFunny.QAccess;
using XFunny.QConnecting;

namespace XFunny.QFilter
{
    public class Collection<T> : IEnumerator 
    {
        T[] _Objects;
        int _Index = -1;
        public Collection(T[] pObjects) 
        {
            _Objects = pObjects;
        }

        public bool MoveNext()
        {
            _Index++;
            return (_Index < _Objects.Length);
        }

        public void Reset()
        {
            _Index = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _Objects[_Index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
 

    /// <summary>
    /// Classe coleção para armazenamento em memória de dados
    /// </summary>
    /// <typeparam name="T">Classe base</typeparam>    
    public class QCollection<T> : IEnumerable where T : class, new()
    {
        protected int _Position = -1;

        /// <summary>
        /// Provedor de conexão com a base de dados
        /// </summary>
        protected internal QConnect _Connect;
        
        /// <summary>
        /// Lista com os objetos adicionados a coleção
        /// </summary>
        protected internal List<T> collection;
               

        public QCollection() 
        {
            this.collection = new List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConnect"></param>
        /// <param name="pConditions"></param>
        public QCollection(QConnect pConnect, Conditions pConditions)
        {
            this._Connect = pConnect;

            var tarefa = Task<string>.Factory.StartNew(() =>
            {
                return pConditions.GetQuery<T>();
            });

            tarefa.Wait();

            ConvetDataTable(this._Connect.ExcuteQuery(tarefa.Result));
        }

        private void ConvetDataTable(System.Data.DataTable dataTable)
        {
            collection = new List<T>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();
                foreach (var proper in obj.GetType().GetProperties())
                {
                    if (proper.GetCustomAttributes(typeof(NonPersistentAttribute), false).Count() == 0)
                    {
                        if (proper.PropertyType.IsGenericType && proper.PropertyType.GetGenericTypeDefinition().Equals(typeof(QCollection<>)))
                        {
                            Type tipo = proper.PropertyType;
                            var sonprop = proper.PropertyType.GetGenericArguments()[0].GetProperties()
                                .Where(p => p.GetCustomAttributes(typeof(NonPersistentAttribute), true).Count() == 0 &&
                                                        p.GetCustomAttributes(typeof(AssociationAttribute), true).Count() > 0 &&
                                                        p.PropertyType == typeof(T)).FirstOrDefault();
                            var coll = Activator.CreateInstance(tipo, this._Connect, Conditions.Values(string.Format("{0} = '?'", sonprop.Name), row["OCod"]));
                            proper.SetValue(obj, coll, null);                            
                        }
                        else
                        {
                            if (!proper.PropertyType.IsSubclassOf(typeof(QObjectBase)))
                                proper.SetValue(obj, row[proper.Name], null);                            
                        }
                    }
                }

                collection.Add(obj);
            }            
        }

        /// <summary>
        /// Total de itens na lista
        /// </summary>
        public int Count
        {
            get { return collection.Count; }
        }

        /// <summary>
        /// Retona o item na posição definida
        /// </summary>
        /// <param name="index">Índice na lista</param>
        /// <returns>Retorna o objeto no índice na lista</returns>
        public T this[int index]
        {
            get
            {
                return this.collection[index];
            }

            set { this.collection[index] = value; }
        }

        /// <summary>
        /// adiciona um item na coleção
        /// </summary>
        /// <param name="pItem">Novo item da coleção</param>
        public void Add(T pItem)
        {
            this.collection.Add(pItem);
        }

        /// <summary>
        /// Lima a coleção
        /// </summary>
        public void Clear()
        {
            this.collection.Clear();
        }

        /// <summary>
        /// Verifica se contém o item na coleção
        /// </summary>
        /// <param name="pItem">Item a da coleção</param>
        /// <returns>verdadeiro quando um item é encontrado na coleção</returns>
        public bool Contains(T pItem)
        {
            return this.collection.Contains(pItem);
        }
        
        /// <summary>
        /// Remove o item da coleção
        /// </summary>
        /// <param name="item">Item a ser removido</param>
        /// <returns>Verdadeiro quando removido</returns>
        public bool Remove(T item)
        {
            return this.collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return (IEnumerator)GetEnumerator();
        }

        public Collection<T> GetEnumerator() 
        {
            return new Collection<T>(collection.ToArray());
        }
    }
}
