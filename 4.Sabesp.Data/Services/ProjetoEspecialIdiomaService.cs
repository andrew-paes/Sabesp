using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.FilterHelper;
using Sabesp.BO;
using System.Transactions;

namespace Sabesp.Data.Services
{
    public class ProjetoEspecialIdiomaService
    {        
        private IProjetoEspecialIdiomaDAL _projetoEspecialIdiomaDAL;

        public ProjetoEspecialIdiomaService()
        {

        }

        public IProjetoEspecialIdiomaDAL ProjetoEspecialIdiomaDAL
        {
            get
            {
                if (_projetoEspecialIdiomaDAL == null)
                    _projetoEspecialIdiomaDAL = new ProjetoEspecialIdiomaADO();

                return _projetoEspecialIdiomaDAL;
            }
            set
            {
                _projetoEspecialIdiomaDAL = value;
            }
        }

        public int TotalRegistros(ProjetoEspecialIdiomaFH filtro)
        {
            return ProjetoEspecialIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<ProjetoEspecialIdioma> RetornaTodos()
        {
            return ProjetoEspecialIdiomaDAL.CarregarTodos();
        }

        public IList<ProjetoEspecialIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
        {
            return ProjetoEspecialIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public ProjetoEspecialIdioma Carregar(ProjetoEspecialIdioma entidade)
        {
            return ProjetoEspecialIdiomaDAL.Carregar(entidade);
        }


        public void Inserir(ProjetoEspecialIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ProjetoEspecialIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ProjetoEspecialIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
