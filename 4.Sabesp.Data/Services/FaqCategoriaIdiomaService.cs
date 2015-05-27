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
    public class FaqCategoriaIdiomaService
    {
        private IFaqCategoriaIdiomaDAL _faqCategoriaIdiomaDAL;

        public FaqCategoriaIdiomaService()
        {

        }

        public IFaqCategoriaIdiomaDAL FaqCategoriaIdiomaDAL
        {

            get
            {
                if (_faqCategoriaIdiomaDAL == null)
                    _faqCategoriaIdiomaDAL = new FaqCategoriaIdiomaADO();

                return _faqCategoriaIdiomaDAL;
            }
            set
            {
                _faqCategoriaIdiomaDAL = value;
            }
        }

        public int TotalRegistros(FaqCategoriaIdiomaFH filtro)
        {
            return FaqCategoriaIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<FaqCategoriaIdioma> RetornaTodos()
        {
            return FaqCategoriaIdiomaDAL.CarregarTodos();
        }

        public IList<FaqCategoriaIdioma> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, FaqCategoriaIdiomaFH filtro)
        {
            return FaqCategoriaIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public FaqCategoriaIdioma Carregar(FaqCategoriaIdioma entidade)
        {
            return FaqCategoriaIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(FaqCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqCategoriaIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(FaqCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqCategoriaIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(FaqCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                FaqCategoriaIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
