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
    public class NoticiaImagemComentarioService
    {
        private INoticiaImagemComentarioDAL _noticiaImagemComentarioDAL;

        public NoticiaImagemComentarioService()
        {

        }

        public INoticiaImagemComentarioDAL NoticiaImagemComentarioDAL
        {

            get
            {
                if (_noticiaImagemComentarioDAL == null)
                    _noticiaImagemComentarioDAL = new NoticiaImagemComentarioADO();

                return _noticiaImagemComentarioDAL;
            }
            set
            {
                _noticiaImagemComentarioDAL = value;
            }
        }

        public int TotalRegistros(NoticiaImagemComentarioFH filtro)
        {
            return NoticiaImagemComentarioDAL.TotalRegistros(filtro);
        }

        public IList<NoticiaImagemComentario> RetornaTodos()
        {
            return NoticiaImagemComentarioDAL.CarregarTodos();
        }

        public IList<NoticiaImagemComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return NoticiaImagemComentarioDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public NoticiaImagemComentario Carregar(NoticiaImagemComentario entidade)
        {
            return NoticiaImagemComentarioDAL.Carregar(entidade);
        }

        public void Inserir(NoticiaImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemComentarioDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(NoticiaImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemComentarioDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(NoticiaImagemComentario entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemComentarioDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }


    }
}
