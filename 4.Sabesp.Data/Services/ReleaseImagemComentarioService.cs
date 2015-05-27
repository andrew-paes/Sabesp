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
    public class ReleaseImagemComentarioService
    {
        private IReleaseImagemComentarioDAL _releaseImagemComentarioDAL;

        public ReleaseImagemComentarioService()
        {

        }

        public IReleaseImagemComentarioDAL ReleaseImagemComentarioDAL
        {

            get
            {
                if (_releaseImagemComentarioDAL == null)
                    _releaseImagemComentarioDAL = new ReleaseImagemComentarioADO();

                return _releaseImagemComentarioDAL;
            }
            set
            {
                _releaseImagemComentarioDAL = value;
            }
        }

        public int TotalRegistros(ReleaseImagemComentarioFH filtro)
        {
            return ReleaseImagemComentarioDAL.TotalRegistros(filtro);
        }

        public IList<ReleaseImagemComentario> RetornaTodos()
        {
            return ReleaseImagemComentarioDAL.CarregarTodos();
        }

        public ReleaseImagemComentario Carregar(ReleaseImagemComentario entidade)
        {
            return ReleaseImagemComentarioDAL.Carregar(entidade);
        }

        public void Inserir(ReleaseImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseImagemComentarioDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ReleaseImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseImagemComentarioDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ReleaseImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ReleaseImagemComentarioDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
