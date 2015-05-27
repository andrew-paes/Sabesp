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
    public class EventoIdiomaService
    {
        private IEventoIdiomaDAL _eventoIdiomaDAL;

        public EventoIdiomaService()
        {

        }

        public IEventoIdiomaDAL EventoIdiomaDAL
        {

            get
            {
                if (_eventoIdiomaDAL == null)
                    _eventoIdiomaDAL = new EventoIdiomaADO();

                return _eventoIdiomaDAL;
            }
            set
            {
                _eventoIdiomaDAL = value;
            }
        }

        public int TotalRegistros(EventoIdiomaFH filtro)
        {
            return EventoIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<EventoIdioma> RetornaTodos()
        {
            return EventoIdiomaDAL.CarregarTodos();
        }

        public EventoIdioma Carregar(EventoIdioma entidade)
        {
            return EventoIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(EventoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(EventoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(EventoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
