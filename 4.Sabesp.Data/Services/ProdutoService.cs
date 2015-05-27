using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
    public class ProdutoService
    {
        private IProdutoDAL _produtoDAL;

        public ProdutoService()
        {

        }

        public IProdutoDAL ProdutoDAL
        {

            get
            {
                if (_produtoDAL == null)
                    _produtoDAL = new ProdutoADO();

                return _produtoDAL;
            }
            set
            {
                _produtoDAL = value;
            }
        }

        public int TotalRegistros(ProdutoFH filtro)
        {
            return ProdutoDAL.TotalRegistros(filtro);
        }

        public IList<Produto> RetornaTodos()
        {
            return ProdutoDAL.CarregarTodos();
        }

        public IList<Produto> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return ProdutoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public Produto Carregar(Produto entidade)
        {
            return ProdutoDAL.Carregar(entidade);
        }


        public void Inserir(Produto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Produto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Produto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }


    }
}
