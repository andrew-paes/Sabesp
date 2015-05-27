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
    public class ComunicadoIdiomaService
    {
        private IComunicadoIdiomaDAL _comunicadoIdiomaDAL;

        public ComunicadoIdiomaService()
        {

        }

        public IComunicadoIdiomaDAL ComunicadoIdiomaDAL
        {

            get
            {
                if (_comunicadoIdiomaDAL == null)
                    _comunicadoIdiomaDAL = new ComunicadoIdiomaADO();

                return _comunicadoIdiomaDAL;
            }
            set
            {
                _comunicadoIdiomaDAL = value;
            }
        }

        public int TotalRegistros(ComunicadoIdiomaFH filtro)
        {
            return ComunicadoIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<ComunicadoIdioma> RetornaTodos()
        {
            return ComunicadoIdiomaDAL.CarregarTodos();
        }

        public ComunicadoIdioma Carregar(ComunicadoIdioma entidade)
        {
            return ComunicadoIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(ComunicadoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ComunicadoIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ComunicadoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ComunicadoIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ComunicadoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ComunicadoIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
