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
    public class EventoService
    {
        private IEventoDAL _eventoDAL;

        public EventoService()
        {

        }

        public IEventoDAL EventoDAL
        {

            get
            {
                if (_eventoDAL == null)
                    _eventoDAL = new EventoADO();

                return _eventoDAL;
            }
            set
            {
                _eventoDAL = value;
            }
        }
        
        public int TotalRegistros(EventoFH filtro)
        {
            return EventoDAL.TotalRegistros(filtro);
        }

        public int TotalRegistrosRelacionado(int eventoId, int eventoCategoriaId)
        {
            return EventoDAL.TotalRegistrosRelacionado(eventoId, eventoCategoriaId);
        }

        public IList<Evento> RetornaTodos()
        {
            return EventoDAL.CarregarTodos();
        }
        /// <summary>
        /// Retorna todos os Registros relacionados aos eventos aprovados
        /// </summary>
        /// <param name="quantidadeRegistros"></param>
        /// <param name="ordemColunas"></param>
        /// <param name="ordemSentidos"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public IList<Evento> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, 
                                            string[] ordemSentidos, EventoFH filtro)
        {
            return this.EventoDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
        }

        public IList<Evento> CarregarMaisVistos(int qtdEventos)
        {
            return EventoDAL.CarregarMaisVistos(qtdEventos);
        }
        public IList<Evento> CarregarProxEventos(int qtdRegistros)
        {
            return EventoDAL.CarregarProxEventos(qtdRegistros);
        } 
        public Evento CarregarToSite(int eventoId)
        {
            return EventoDAL.CarregarToSite(eventoId);
        }
        public IList<Evento> CarregarTagged(int tagId)
        {
            return EventoDAL.CarregarTagged(tagId);
        }

        public Evento Carregar(Evento entidade)
        {
            return EventoDAL.Carregar(entidade);
        }

        public void Inserir(Evento entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void InserirRelacionado(EventoCategoria entidade, int eventoId, int IdiomaId)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoDAL.InserirRelacionado(entidade, eventoId, IdiomaId);

                tScope.Complete();
            }
        }

        public void Atualizar(Evento entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Evento entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }

        public void ExcluirRelacionado(int entidade, int idiomaId)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                EventoDAL.ExcluirRelacionado(entidade, idiomaId);

                tScope.Complete();
            }
        }

		public List<Evento> CarregarPorRegiao(int qtdEventos, int regiaoId)
		{
			return EventoDAL.CarregarPorRegiao(qtdEventos, regiaoId);
		}
    }
}
