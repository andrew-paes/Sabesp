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
    public class InfograficoService
    {
        private IInfograficoDAL _infograficoDAL;

        public InfograficoService()
        {

        }

        public IInfograficoDAL InfograficoDAL
        {

            get
            {
                if (_infograficoDAL == null)
                    _infograficoDAL = new InfograficoADO();

                return _infograficoDAL;
            }
            set
            {
                _infograficoDAL = value;
            }
        }

        public int TotalRegistros(InfograficoFH filtro)
        {
            return InfograficoDAL.TotalRegistros(filtro);
        }

        public IList<Infografico> RetornaTodos()
        {
            return InfograficoDAL.CarregarTodos();
        }

        public Infografico Carregar(Infografico entidade)
        {
            return InfograficoDAL.Carregar(entidade);
        }
        public Infografico CarregarToSite(int infograficoId)
        {
            return InfograficoDAL.CarregarToSite(infograficoId);
        }
        public IList<Infografico> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return InfograficoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
        public IList<Infografico> RetornaTodosSite(int registrosPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return InfograficoDAL.RetornaTodosSite(registrosPagina, ordemColunas, ordemSentidos, filtro);
        }
        public void Inserir(Infografico entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                InfograficoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Infografico entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                InfograficoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Infografico entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                InfograficoDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
