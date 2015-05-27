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
    public class NoticiaImagemService
    {
        private INoticiaImagemDAL _noticiaImagemDAL;

        public NoticiaImagemService()
        {

        }

        public INoticiaImagemDAL NoticiaImagemDAL
        {

            get
            {
                if (_noticiaImagemDAL == null)
                    _noticiaImagemDAL = new NoticiaImagemADO();

                return _noticiaImagemDAL;
            }
            set
            {
                _noticiaImagemDAL = value;
            }
        }

        public int TotalRegistros(NoticiaImagemFH filtro)
        {
            return NoticiaImagemDAL.TotalRegistros(filtro);
        }

        public IList<NoticiaImagem> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordem, string orientacao, NoticiaImagemFH filtro)
        {
            return NoticiaImagemDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
        }

        public NoticiaImagem Carregar(NoticiaImagem entidade)
        {
            return NoticiaImagemDAL.Carregar(entidade);
        }

        public void Inserir(NoticiaImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(NoticiaImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(NoticiaImagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                NoticiaImagemDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }

		public List<NoticiaImagem> CarregarToSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, NoticiaImagemFH filtro)
		{
			return NoticiaImagemDAL.CarregarToSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
		}


    }
}
