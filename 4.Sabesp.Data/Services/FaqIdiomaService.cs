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
    public class FaqItemIdiomaService
    {
        private IFaqItemIdiomaDAL _faqItemIdiomaDAL;

        public FaqItemIdiomaService()
        {

        }

        public IFaqItemIdiomaDAL FaqItemIdiomaDAL
        {

            get
            {
                if (_faqItemIdiomaDAL == null)
                    _faqItemIdiomaDAL = new FaqItemIdiomaADO();

                return _faqItemIdiomaDAL;
            }
            set
            {
                _faqItemIdiomaDAL = value;
            }
        }

        public int TotalRegistros(FaqItemIdiomaFH filtro)
        {
            return FaqItemIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<FaqItemIdioma> RetornaTodos()
        {
            return FaqItemIdiomaDAL.CarregarTodos();
        }

        public FaqItemIdioma Carregar(FaqItemIdioma entidade)
        {
            return FaqItemIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(FaqItemIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqItemIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(FaqItemIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqItemIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(FaqItemIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqItemIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
