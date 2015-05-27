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
    public class ControleSessaoService
    {
        private IControleSessaoDAL _controleSessaoDAL;

        public ControleSessaoService()
        {

        }

        public IControleSessaoDAL ControleSessaoDAL
        {
            get
            {
                if (_controleSessaoDAL == null)
                    _controleSessaoDAL = new ControleSessaoADO();

                return _controleSessaoDAL;
            }
            set
            {
                _controleSessaoDAL = value;
            }
        }

        public int TotalRegistros(ControleSessaoFH filtro)
        {
            return ControleSessaoDAL.TotalRegistros(filtro);
        }

        public IList<ControleSessao> RetornaTodos()
        {
            return ControleSessaoDAL.CarregarTodos();
        }

		public IList<ControleSessao> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, ControleSessaoFH filtro)
		{
			return ControleSessaoDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
		}

        public IList<ControleSessao> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, ControleSessaoFH filtro)
        {
            return ControleSessaoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public ControleSessao Carregar(ControleSessao entidade)
        {
            return ControleSessaoDAL.Carregar(entidade);
        }

		public ControleSessao CarregarToSite(int controleSessaoId)
		{
			return ControleSessaoDAL.CarregarToSite(controleSessaoId);
		}

        public void Inserir(ControleSessao entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleSessaoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ControleSessao entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleSessaoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ControleSessao entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleSessaoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Secao entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleSessaoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}