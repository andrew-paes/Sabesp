using System;
using System.Collections.Generic;
using System.Transactions;
using Sabesp.BO;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.FilterHelper;

namespace Sabesp.Data.Services
{
	public class SecaoService
	{
		private ISecaoDAL _secaoDAL;

		public SecaoService() { }

		public ISecaoDAL SecaoDAL
		{
			get
			{
				if (_secaoDAL == null)
					_secaoDAL = new SecaoADO();

				return _secaoDAL;
			}
			set
			{
				_secaoDAL = value;
			}
		}

		public int TotalRegistros(SecaoFH filtro)
		{
			return SecaoDAL.TotalRegistros(filtro);
		}

		public IList<Secao> RetornaTodos()
		{
			return SecaoDAL.CarregarTodos();
		}

		public Secao Carregar(Secao entidade)
		{
			return SecaoDAL.Carregar(entidade);
		}

		public void Inserir(Secao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				SecaoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Secao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				SecaoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Secao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				SecaoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public List<Secao> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, SecaoFH filtro)
		{
			return SecaoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public List<Secao> CarregarFilhos(int secaoIdPai)
		{
			return SecaoDAL.CarregarFilhos(secaoIdPai);
		}

		public List<Secao> CarregarFilhos(int secaoIdPai, bool exibeNoMenu)
		{
			return SecaoDAL.CarregarFilhos(secaoIdPai, exibeNoMenu);
		}

		/// <summary>
		/// Return the Secao object that is a root node
		/// </summary>
		/// <param name="secaoId"></param>
		/// <returns></returns>
		public Secao GetRoot(int secaoId)
		{
			Secao secao = Carregar(new Secao() { SecaoId = secaoId });
			if (secao != null)
			{
				if (secao.SecaoPai != null)
				{
					Secao secaoPai = Carregar(secao.SecaoPai);

					if (secaoPai.SecaoPai == null)
					{
						return secao;
					}
					else
					{
						return GetRoot(secao.SecaoPai.SecaoId);
					}
				}
				else
				{
					return secao;
				}
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Returns the depth of 'Secao'
		/// </summary>
		/// <param name="secaoId">the current secaoId</param>
		/// <returns></returns>
		public int GetDepth(int secaoId)
		{
			int depth = 0;
			Secao secao = Carregar(new Secao() { SecaoId = secaoId });
			if (secao != null)
			{
				while (secao.SecaoPai != null)
				{
					secao = Carregar(new Secao() { SecaoId = secao.SecaoPai.SecaoId });
					depth++;
				}
			}

			return depth;
		}

		public List<Secao> ObterCaminho(Secao secao, Idioma idioma)
		{
			List<Secao> retorno = new List<Secao>();
			SecaoService secaoService = new SecaoService();
			SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
			ModeloService modeloService = new ModeloService();
			secao.ExibeNoMenu = true;

			if (secao.SecaoPai == null)
			{
				secao = secaoService.Carregar(secao);
				if (secao != null)
				{
					SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Ativo = true, Secao = secao, Idioma = idioma });
					if (secaoIdioma != null)
					{
						secao.SecaoIdiomas = new List<SecaoIdioma>();
						secao.SecaoIdiomas.Add(secaoIdioma);
					}
				}
			}

			if (secao != null)
			{
				secao.Modelo = modeloService.Carregar(new Modelo() { ModeloId = secao.Modelo.ModeloId });
				retorno.Add(secao);

				while (secao.SecaoPai != null && secao.SecaoPai.SecaoId != 0)
				{
					secao.SecaoPai.ExibeNoMenu = true;
					secao = secaoService.Carregar(secao.SecaoPai);
					if (secao != null)
					{
						SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Ativo = true, Secao = secao, Idioma = idioma });
						if (secaoIdioma != null)
						{
							secao.SecaoIdiomas = new List<SecaoIdioma>();
							secao.SecaoIdiomas.Add(secaoIdioma);
						}
					}
					secao.Modelo = modeloService.Carregar(new Modelo() { ModeloId = secao.Modelo.ModeloId });
					retorno.Add(secao);
				}
			}

			return retorno;
		}
	}
}