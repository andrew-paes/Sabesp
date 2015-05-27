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
    public class ControleService
    {
        private IControleDAL _controleDAL;

        public ControleService()
        {

        }

        public IControleDAL ControleDAL
        {
            get
            {
                if (_controleDAL == null)
                    _controleDAL = new ControleADO();

                return _controleDAL;
            }
            set
            {
                _controleDAL = value;
            }
        }

        public int TotalRegistros(ControleFH filtro)
        {
            return ControleDAL.TotalRegistros(filtro);
        }

        public IList<Controle> RetornaTodos()
        {
            return ControleDAL.CarregarTodos();
        }

        public Controle Carregar(Controle entidade)
        {
            return ControleDAL.Carregar(entidade);
        }

        public void Inserir(Controle entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Controle entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Controle entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}