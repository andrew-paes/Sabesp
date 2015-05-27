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
    public class EventoCategoriaService
    {
        private IEventoCategoriaDAL _eventoCategoriaDAL;

        public EventoCategoriaService()
        {

        }

        public IEventoCategoriaDAL EventoCategoriaDAL
        {

            get
            {
                if (_eventoCategoriaDAL == null)
                    _eventoCategoriaDAL = new EventoCategoriaADO();

                return _eventoCategoriaDAL;
            }
            set
            {
                _eventoCategoriaDAL = value;
            }
        }

        public int TotalRegistros(EventoCategoriaFH filtro)
        {
            return EventoCategoriaDAL.TotalRegistros(filtro);
        }

        public IList<EventoCategoria> RetornaTodos()
        {
            return EventoCategoriaDAL.CarregarTodos();
        }

        public EventoCategoria Carregar(EventoCategoria entidade)
        {
            return EventoCategoriaDAL.Carregar(entidade);
        }

        public void Inserir(EventoCategoria entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(EventoCategoria entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(EventoCategoria entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoCategoriaDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
