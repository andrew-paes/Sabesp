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
    public class ProdutoIdiomaService
    {
        private IProdutoIdiomaDAL _produtoIdiomaDAL;

        public ProdutoIdiomaService()
        {

        }

        public IProdutoIdiomaDAL ProdutoIdiomaDAL
        {

            get
            {
                if (_produtoIdiomaDAL == null)
                    _produtoIdiomaDAL = new ProdutoIdiomaADO();

                return _produtoIdiomaDAL;
            }
            set
            {
                _produtoIdiomaDAL = value;
            }
        }

        public int TotalRegistros(ProdutoIdiomaFH filtro)
        {
            return ProdutoIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<ProdutoIdioma> RetornaTodos()
        {
            return ProdutoIdiomaDAL.CarregarTodos();
        }

        public ProdutoIdioma Carregar(ProdutoIdioma entidade)
        {
            return ProdutoIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(ProdutoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ProdutoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ProdutoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProdutoIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
