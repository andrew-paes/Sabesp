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
    public class MaterialImprensaService
    {
        private IMaterialImprensaDAL _materialImprensaDAL;

        public MaterialImprensaService()
        {

        }

        public IMaterialImprensaDAL MaterialImprensaDAL
        {

            get
            {
                if (_materialImprensaDAL == null)
                    _materialImprensaDAL = new MaterialImprensaADO();

                return _materialImprensaDAL;
            }
            set
            {
                _materialImprensaDAL = value;
            }
        }

        public int TotalRegistros(MaterialImprensaFH filtro)
        {
            return MaterialImprensaDAL.TotalRegistros(filtro);
        }

        public IList<MaterialImprensa> RetornaTodos()
        {
            return MaterialImprensaDAL.CarregarTodos();
        }

        public MaterialImprensa Carregar(MaterialImprensa entidade)
        {
            return MaterialImprensaDAL.Carregar(entidade);
        }
        public IList<MaterialImprensa> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return MaterialImprensaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
        public void Inserir(MaterialImprensa entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(MaterialImprensa entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(MaterialImprensa entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
