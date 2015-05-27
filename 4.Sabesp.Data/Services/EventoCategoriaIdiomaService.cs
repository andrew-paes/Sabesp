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
    public class EventoCategoriaIdiomaService
    {
        private IEventoCategoriaIdiomaDAL _eventoCategoriaIdiomaDAL;

        public EventoCategoriaIdiomaService()
        {

        }

        public IEventoCategoriaIdiomaDAL EventoCategoriaIdiomaDAL
        {

            get
            {
                if (_eventoCategoriaIdiomaDAL == null)
                    _eventoCategoriaIdiomaDAL = new EventoCategoriaIdiomaADO();

                return _eventoCategoriaIdiomaDAL;
            }
            set
            {
                _eventoCategoriaIdiomaDAL = value;
            }
        }

        public int TotalRegistros(EventoCategoriaIdiomaFH filtro)
        {
            return EventoCategoriaIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<EventoCategoriaIdioma> RetornaTodos()
        {
            return EventoCategoriaIdiomaDAL.CarregarTodos();
        }

        public IList<EventoCategoriaIdioma> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordem, string orientacao, EventoCategoriaIdiomaFH filtro)
        {
            return EventoCategoriaIdiomaDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
        }

        public EventoCategoriaIdioma Carregar(EventoCategoriaIdioma entidade)
        {
            return EventoCategoriaIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(EventoCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(EventoCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(EventoCategoriaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
