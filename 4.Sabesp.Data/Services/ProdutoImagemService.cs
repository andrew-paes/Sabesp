using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
    public class ProdutoImagemService
    {
        /// <summary>
        /// 
        /// </summary>
        private IProdutoImagemDAL _produtoImagemDAL;
        /// <summary>
        /// 
        /// </summary>
        public ProdutoImagemService()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public IProdutoImagemDAL ProdutoImagemDAL
        {
            get
            {
                if (_produtoImagemDAL == null)
                    _produtoImagemDAL = new ProdutoImagemADO();

                return _produtoImagemDAL;
            }
            set
            {
                _produtoImagemDAL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int TotalRegistros(ProdutoImagemFH filtro)
        {
            return ProdutoImagemDAL.TotalRegistros(filtro);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrosPorPagina"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="ordem"></param>
        /// <param name="orientacao"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public IList<ProdutoImagem> RetornaTodos(int registrosPorPagina, int numeroPagina, string[] ordem, string[] orientacao, ProdutoImagemFH filtro)
        {
            return ProdutoImagemDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public ProdutoImagem Carregar(ProdutoImagem entidade)
        {
            return ProdutoImagemDAL.Carregar(entidade);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public void Inserir(ProdutoImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoImagemDAL.Inserir(entidade);

                tScope.Complete();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public void Atualizar(ProdutoImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoImagemDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public void Excluir(ProdutoImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoImagemDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }       

    }
}
