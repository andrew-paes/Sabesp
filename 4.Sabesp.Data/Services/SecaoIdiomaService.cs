using System;
using System.Collections.Generic;
using System.Transactions;
using Sabesp.BO;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.FilterHelper;

namespace Sabesp.Data.Services
{
    public class SecaoIdiomaService
    {
        private ISecaoIdiomaDAL _secaoIdiomaDAL;

        public SecaoIdiomaService()
        {

        }

        public ISecaoIdiomaDAL SecaoIdiomaDAL
        {
            get
            {
                if (_secaoIdiomaDAL == null)
                    _secaoIdiomaDAL = new SecaoIdiomaADO();

                return _secaoIdiomaDAL;
            }
            set
            {
                _secaoIdiomaDAL = value;
            }
        }

        public int TotalRegistros(SecaoIdiomaFH filtro)
        {
            return SecaoIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<SecaoIdioma> RetornaTodos()
        {
            return SecaoIdiomaDAL.CarregarTodos();
        }

        public SecaoIdioma Carregar(SecaoIdioma entidade)
        {
            return SecaoIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(SecaoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SecaoIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(SecaoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SecaoIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(SecaoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                SecaoIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
