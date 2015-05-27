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
    public class NoticiaIdiomaService
    {
        private INoticiaIdiomaDAL _noticiaIdiomaDAL;

        public NoticiaIdiomaService()
        {

        }

        public INoticiaIdiomaDAL NoticiaIdiomaDAL
        {

            get
            {
                if (_noticiaIdiomaDAL == null)
                    _noticiaIdiomaDAL = new NoticiaIdiomaADO();

                return _noticiaIdiomaDAL;
            }
            set
            {
                _noticiaIdiomaDAL = value;
            }
        }

        public int TotalRegistros(NoticiaIdiomaFH filtro)
        {
            return NoticiaIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<NoticiaIdioma> RetornaTodos()
        {
            return NoticiaIdiomaDAL.CarregarTodos();
        }

        public NoticiaIdioma Carregar(NoticiaIdioma entidade)
        {
            return NoticiaIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(NoticiaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(NoticiaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(NoticiaIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
