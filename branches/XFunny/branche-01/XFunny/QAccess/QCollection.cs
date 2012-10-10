#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XFunny.QAccess
{    
    /// <summary>
    /// Classe coleção para armazenamento em memória de dados
    /// </summary>
    /// <typeparam name="T">Classe base</typeparam>    
    public class QCollection<T> : ICollection<T>, IList<T>, IEnumerable<T>, IEnumerable 
    {
        /// <summary>
        /// Lista com os objetos adicionados a coleção
        /// </summary>
        protected internal List<T> collection;

        /// <summary>
        /// Cria uma coleção vazia
        /// </summary>
        public QCollection() 
        {        
            collection = new List<T>();
        }

        /// <summary>
        /// Cria uma coleção de com objetos persistidos
        /// </summary>
        public QCollection(QConnect pQConnect) 
        {           
            if (pQConnect == null)
                throw new ApplicationException("Conexão não pode ser nula!");                 
            //            
            collection = new List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConnect"></param>
        /// <param name="pConditions"></param>
        public QCollection(QConnect pConnect, Conditions pConditions) 
        {
        
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
    }
}
