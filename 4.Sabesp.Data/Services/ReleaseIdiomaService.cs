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
    public class ReleaseIdiomaService
    {
        private IReleaseIdiomaDAL _releaseIdiomaDAL;

        public ReleaseIdiomaService()
        {

        }

        public IReleaseIdiomaDAL ReleaseIdiomaDAL
        {

            get
            {
                if (_releaseIdiomaDAL == null)
                    _releaseIdiomaDAL = new ReleaseIdiomaADO();

                return _releaseIdiomaDAL;
            }
            set
            {
                _releaseIdiomaDAL = value;
            }
        }

        public int TotalRegistros(ReleaseIdiomaFH filtro)
        {
            return ReleaseIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<ReleaseIdioma> RetornaTodos()
        {
            return ReleaseIdiomaDAL.CarregarTodos();
        }

        public ReleaseIdioma Carregar(ReleaseIdioma entidade)
        {
            return ReleaseIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(ReleaseIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ReleaseIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ReleaseIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
