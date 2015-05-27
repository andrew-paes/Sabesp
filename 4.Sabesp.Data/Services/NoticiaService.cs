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
	public class NoticiaService
	{
		private INoticiaDAL _noticiaDAL;

		public NoticiaService()
		{

		}

		public INoticiaDAL NoticiaDAL
		{

			get
			{
				if (_noticiaDAL == null)
					_noticiaDAL = new NoticiaADO();

				return _noticiaDAL;
			}
			set
			{
				_noticiaDAL = value;
			}
		}

		public int TotalRegistros(NoticiaFH filtro)
		{
			return NoticiaDAL.TotalRegistros(filtro);
		}

		public IList<Noticia> RetornaTodos()
		{
			return NoticiaDAL.CarregarTodos();
		}

		public IList<Noticia> CarregarUltimasNoticias(int qtdNoticias, IFilterHelper filtro)
		{
			return NoticiaDAL.CarregarUltimasNoticias(qtdNoticias, filtro);
		}

        /// <summary>
        /// Método que recupera as últimas notícias podendo excluir uma coleção de determinadas notícias.
        /// </summary>
        /// <param name="qtdNoticias">quantidade total a ser recuperada.</param>
        /// <param name="noticiasJaExibidas">coleção de Noticia que deverão ser excluídas.</param>
        /// <returns></returns>
        public IList<Noticia> CarregarUltimasNoticias(int qtdNoticias, List<Noticia> noticiasJaExibidas)
        {
            return NoticiaDAL.CarregarUltimasNoticias(qtdNoticias, noticiasJaExibidas);
        }

		public IList<Noticia> CarregarMaisVistos(int qtdNoticias)
		{
			return NoticiaDAL.CarregarMaisVistos(qtdNoticias);
		}
		public IList<Noticia> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			return NoticiaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Noticia Carregar(Noticia entidade)
		{
			return NoticiaDAL.Carregar(entidade);
		}

		public Noticia CarregarToSite(int noticiaId)
		{
			return NoticiaDAL.CarregarToSite(noticiaId);
		}
		public IList<Noticia> CarregarTagged(int tagId)
		{
			return NoticiaDAL.CarregarTagged(tagId);
		}
		public IList<Noticia> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, NoticiaFH filtro)
		{
			return NoticiaDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
		}
		public void Inserir(Noticia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				NoticiaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Noticia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				NoticiaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Noticia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				NoticiaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public List<Noticia> CarregarPorRegiao(int qtdNoticias, int regiaoId)
		{
			return NoticiaDAL.CarregarPorRegiao(qtdNoticias, regiaoId);
		}
	}
}
