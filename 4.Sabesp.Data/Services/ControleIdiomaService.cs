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
    public class ControleIdiomaService
    {
        private IControleIdiomaDAL _controleIdiomaDAL;

        public ControleIdiomaService()
        {

        }

        public IControleIdiomaDAL ControleIdiomaDAL
        {
            get
            {
                if (_controleIdiomaDAL == null)
                    _controleIdiomaDAL = new ControleIdiomaADO();

                return _controleIdiomaDAL;
            }
            set
            {
                _controleIdiomaDAL = value;
            }
        }

        public int TotalRegistros(ControleIdiomaFH filtro)
        {
            return ControleIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<ControleIdioma> RetornaTodos()
        {
            return ControleIdiomaDAL.CarregarTodos();
        }

		public IList<ControleIdioma> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return ControleIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemColunas, filtro);
		}

		public ControleIdioma Carregar(ControleIdioma entidade)
        {
            return ControleIdiomaDAL.Carregar(entidade);
        }

		public void Inserir(ControleIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

		public void Atualizar(ControleIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

		public void Excluir(ControleIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }

		public ControleIdioma CarregarToSite(int controleIdiomaId, int idiomaId)
		{
			return ControleIdiomaDAL.CarregarToSite(controleIdiomaId, idiomaId);
		}
    }
}