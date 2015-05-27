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
    public class ControleTipoService
    {
        private IControleTipoDAL _ControleTipoDAL;

        public ControleTipoService()
        {

        }

        public IControleTipoDAL ControleTipoDAL
        {
            get
            {
                if (_ControleTipoDAL == null)
                    _ControleTipoDAL = new ControleTipoADO();

                return _ControleTipoDAL;
            }
            set
            {
                _ControleTipoDAL = value;
            }
        }

		public int TotalRegistros(ControleTipoFH filtro)
        {
            return ControleTipoDAL.TotalRegistros(filtro);
        }

        public IList<ControleTipo> RetornaTodos()
        {
            return ControleTipoDAL.CarregarTodos();
        }

		public ControleTipo Carregar(ControleTipo entidade)
        {
            return ControleTipoDAL.Carregar(entidade);
        }

		public void Inserir(ControleTipo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleTipoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

		public void Atualizar(ControleTipo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleTipoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

		public void Excluir(ControleTipo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ControleTipoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}