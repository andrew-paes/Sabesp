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
    public class EventoFotoService
    {
        private IEventoFotoDAL _eventoFotoDAL;

        public EventoFotoService()
        {

        }

        public IEventoFotoDAL EventoFotoDAL
        {

            get
            {
                if (_eventoFotoDAL == null)
                    _eventoFotoDAL = new EventoFotoADO();

                return _eventoFotoDAL;
            }
            set
            {
                _eventoFotoDAL = value;
            }
        }

        public int TotalRegistros(EventoFotoFH filtro)
        {
            return EventoFotoDAL.TotalRegistros(filtro);
        }

        public IList<EventoFoto> RetornaTodos(int registrosPorPagina, int numeroPagina, string[] ordem, string[] orientacao, EventoFotoFH filtro)
        {
            return EventoFotoDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
        }

        public EventoFoto Carregar(EventoFoto entidade)
        {
            return EventoFotoDAL.Carregar(entidade);
        }

		public List<EventoFoto> CarregarFotos(int eventoId)
		{
			return EventoFotoDAL.CarregarFotos(eventoId);
		}

        public void Inserir(EventoFoto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(EventoFoto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(EventoFoto entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
