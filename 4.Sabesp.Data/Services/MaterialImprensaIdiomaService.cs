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
    public class MaterialImprensaIdiomaService
    {
        private IMaterialImprensaIdiomaDAL _materialImprensaIdiomaDAL;

        public MaterialImprensaIdiomaService()
        {

        }

        public IMaterialImprensaIdiomaDAL MaterialImprensaIdiomaDAL
        {

            get
            {
                if (_materialImprensaIdiomaDAL == null)
                    _materialImprensaIdiomaDAL = new MaterialImprensaIdiomaADO();

                return _materialImprensaIdiomaDAL;
            }
            set
            {
                _materialImprensaIdiomaDAL = value;
            }
        }

        public int TotalRegistros(MaterialImprensaIdiomaFH filtro)
        {
            return MaterialImprensaIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<MaterialImprensaIdioma> RetornaTodos()
        {
            return MaterialImprensaIdiomaDAL.CarregarTodos();
        }

        public MaterialImprensaIdioma Carregar(MaterialImprensaIdioma entidade)
        {
            return MaterialImprensaIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(MaterialImprensaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(MaterialImprensaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(MaterialImprensaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MaterialImprensaIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
