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
    public class ReleaseService
    {
        private IReleaseDAL _releaseDAL;

        public ReleaseService()
        {

        }

        public IReleaseDAL ReleaseDAL
        {

            get
            {
                if (_releaseDAL == null)
                    _releaseDAL = new ReleaseADO();

                return _releaseDAL;
            }
            set
            {
                _releaseDAL = value;
            }
        }

        public int TotalRegistros(ReleaseFH filtro)
        {
            return ReleaseDAL.TotalRegistros(filtro);
        }

        public IList<Release> RetornaTodos()
        {
            return ReleaseDAL.CarregarTodos();
        }

        public Release Carregar(Release entidade)
        {
            return ReleaseDAL.Carregar(entidade);
        }
        public Release CarregarToSite(int releaseId)
        {
            return ReleaseDAL.CarregarToSite(releaseId);
        }
        public IList<Release> CarregarTagged(int tagId)
        {
            return ReleaseDAL.CarregarTagged(tagId);
        }
        public IList<Release> CarregarOutros(int qtdRegistros, int releaseId)
        {
            return ReleaseDAL.CarregarOutros(qtdRegistros, releaseId);
        }
        public IList<Release> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return ReleaseDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
        public IList<Release> CarregarTodosSite(int qtdRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return ReleaseDAL.CarregarTodosSite(qtdRegistros, ordemColunas, ordemSentidos, filtro);
        }
        public void Inserir(Release entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Release entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Release entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
