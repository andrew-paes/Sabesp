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
    public class SolucaoAmbientalIdiomaService
    {
        private ISolucaoAmbientalIdiomaDAL _solucaoAmbientalIdiomaDAL;

        public SolucaoAmbientalIdiomaService()
        {

        }

        public ISolucaoAmbientalIdiomaDAL SolucaoAmbientalIdiomaDAL
        {

            get
            {
                if (_solucaoAmbientalIdiomaDAL == null)
                    _solucaoAmbientalIdiomaDAL = new SolucaoAmbientalIdiomaADO();

                return _solucaoAmbientalIdiomaDAL;
            }
            set
            {
                _solucaoAmbientalIdiomaDAL = value;
            }
        }

        public int TotalRegistros(SolucaoAmbientalIdiomaFH filtro)
        {
            return SolucaoAmbientalIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<SolucaoAmbientalIdioma> RetornaTodos()
        {
            return SolucaoAmbientalIdiomaDAL.CarregarTodos();
        }

        public SolucaoAmbientalIdioma Carregar(SolucaoAmbientalIdioma entidade)
        {
            return SolucaoAmbientalIdiomaDAL.Carregar(entidade);
        }
        public SolucaoAmbientalIdioma CarregarToSite(int infograficoId)
        {
            return SolucaoAmbientalIdiomaDAL.CarregarToSite(infograficoId);
        }
        public IList<SolucaoAmbientalIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return SolucaoAmbientalIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
        public IList<SolucaoAmbientalIdioma> RetornaTodosSite(int registrosPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return SolucaoAmbientalIdiomaDAL.RetornaTodosSite(registrosPagina, ordemColunas, ordemSentidos, filtro);
        }
        public void Inserir(SolucaoAmbientalIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SolucaoAmbientalIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(SolucaoAmbientalIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SolucaoAmbientalIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(SolucaoAmbientalIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SolucaoAmbientalIdiomaDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
