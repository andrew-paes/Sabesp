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
    public class PodcastIdiomaService
    {
        private IPodcastIdiomaDAL _podcastIdiomaDAL;

        public PodcastIdiomaService()
        {

        }

        public IPodcastIdiomaDAL PodcastIdiomaDAL
        {

            get
            {
                if (_podcastIdiomaDAL == null)
                    _podcastIdiomaDAL = new PodcastIdiomaADO();

                return _podcastIdiomaDAL;
            }
            set
            {
                _podcastIdiomaDAL = value;
            }
        }

        public int TotalRegistros(PodcastIdiomaFH filtro)
        {
            return PodcastIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<PodcastIdioma> RetornaTodos()
        {
            return PodcastIdiomaDAL.CarregarTodos();
        }

        public IList<PodcastIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
        {
            return PodcastIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public PodcastIdioma Carregar(PodcastIdioma entidade)
        {
            return PodcastIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(PodcastIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(PodcastIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(PodcastIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
