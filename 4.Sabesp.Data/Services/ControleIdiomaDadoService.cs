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
    public class ControleIdiomaDadoService
    {
        private IControleIdiomaDadoDAL _controleIdiomaDadoDAL;

        public ControleIdiomaDadoService()
        {

        }

        public IControleIdiomaDadoDAL ControleIdiomaDadoDAL
        {
            get
            {
                if (_controleIdiomaDadoDAL == null)
                    _controleIdiomaDadoDAL = new ControleIdiomaDadoADO();

                return _controleIdiomaDadoDAL;
            }
            set
            {
                _controleIdiomaDadoDAL = value;
            }
        }

        public int TotalRegistros(ControleIdiomaDadoFH filtro)
        {
			return ControleIdiomaDadoDAL.TotalRegistros(filtro);
        }

        public IList<ControleIdiomaDado> RetornaTodos()
        {
			return ControleIdiomaDadoDAL.CarregarTodos();
        }

		public IList<ControleIdiomaDado> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return ControleIdiomaDadoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemColunas, filtro);
		}

		public ControleIdiomaDado Carregar(ControleIdiomaDado entidade)
        {
			return ControleIdiomaDadoDAL.Carregar(entidade);
        }

		public void Inserir(ControleIdiomaDado entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
				ControleIdiomaDadoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

		public void Atualizar(ControleIdiomaDado entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
				ControleIdiomaDadoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

		public void Excluir(ControleIdiomaDado entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
				ControleIdiomaDadoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }

		public void ExcluirRelacionados(ControleIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ControleIdiomaDadoDAL.ExcluirRelacionados(entidade);

				tScope.Complete();
			}
		}
    }
}