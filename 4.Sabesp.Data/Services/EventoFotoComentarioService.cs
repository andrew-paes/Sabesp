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
    public class EventoFotoComentarioService
    {
        private IEventoFotoComentarioDAL _eventoFotoComentarioDAL;

        public EventoFotoComentarioService()
        {

        }

        public IEventoFotoComentarioDAL EventoFotoComentarioDAL
        {

            get
            {
                if (_eventoFotoComentarioDAL == null)
                    _eventoFotoComentarioDAL = new EventoFotoComentarioADO();

                return _eventoFotoComentarioDAL;
            }
            set
            {
                _eventoFotoComentarioDAL = value;
            }
        }

        public int TotalRegistros(EventoFotoComentarioFH filtro)
        {
            return EventoFotoComentarioDAL.TotalRegistros(filtro);
        }

        public IList<EventoFotoComentario> RetornaTodos()
        {
            return EventoFotoComentarioDAL.CarregarTodos();
        }

        public IList<EventoFotoComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return EventoFotoComentarioDAL.CarregarTodos( registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public EventoFotoComentario Carregar(EventoFotoComentario entidade)
        {
            return EventoFotoComentarioDAL.Carregar(entidade);
        }

        public void Inserir(EventoFotoComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoComentarioDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(EventoFotoComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoComentarioDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(EventoFotoComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoFotoComentarioDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
