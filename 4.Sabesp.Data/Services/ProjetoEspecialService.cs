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
    public class ProjetoEspecialService
    {
        private IProjetoEspecialDAL _projetoEspecialDAL;

        public ProjetoEspecialService()
        {

        }

        public IProjetoEspecialDAL ProjetoEspecialDAL
        {

            get
            {
                if (_projetoEspecialDAL == null)
                    _projetoEspecialDAL = new ProjetoEspecialADO();

                return _projetoEspecialDAL;
            }
            set
            {
                _projetoEspecialDAL = value;
            }
        }

        public int TotalRegistros(ProjetoEspecialFH filtro)
        {
            return ProjetoEspecialDAL.TotalRegistros(filtro);
        }

        public IList<ProjetoEspecial> RetornaTodos()
        {
            return ProjetoEspecialDAL.CarregarTodos();
        }

        public IList<ProjetoEspecial> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return ProjetoEspecialDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public ProjetoEspecial Carregar(ProjetoEspecial entidade)
        {
            return ProjetoEspecialDAL.Carregar(entidade);
        }


        public void Inserir(ProjetoEspecial entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ProjetoEspecial entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ProjetoEspecial entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ProjetoEspecialDAL.Excluir(entidade);

                tScope.Complete();
            }
        }

    }
}
