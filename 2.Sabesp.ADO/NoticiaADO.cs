/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
'  Script criado por: Leonardo Alves Lindermann (lindermannla@ag2.com.br)
'  Gerado pelo MyGeneration versão # (???)
'
'===============================================================================
*/
using System;
using System.Data;
using System.Data.Common;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class NoticiaADO : ADOSuper, INoticiaDAL
	{

		/// <summary>
		/// Método que persiste um Noticia.
		/// </summary>
		/// <param name="entidade">Noticia contendo os dados a serem persistidos.</param>	
		public void Inserir(Noticia entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Noticia ");
			sbSQL.Append(" (noticiaId, ativa, autor, destaqueHome, destaqueNoticias, destaqueFiquePorDentro, destaqueUltimasNoticias, fonte, fonteUrl, dataHoraPublicacao, dataExibicaoInicio, dataExibicaoFim, arquivoIdThumbGrande, arquivoIdThumbMedio) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@noticiaId, @ativa, @autor, @destaqueHome, @destaqueNoticias, @destaqueFiquePorDentro, @destaqueUltimasNoticias, @fonte, @fonteUrl, @dataHoraPublicacao, @dataExibicaoInicio, @dataExibicaoFim, @arquivoIdThumbGrande, @arquivoIdThumbMedio) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativa", DbType.Int32, entidade.Ativa);

			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			_db.AddInParameter(command, "@destaqueNoticias", DbType.Int32, entidade.DestaqueNoticias);

			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			_db.AddInParameter(command, "@destaqueUltimasNoticias", DbType.Int32, entidade.DestaqueUltimasNoticias);

			if (entidade.Fonte != null)
				_db.AddInParameter(command, "@fonte", DbType.String, entidade.Fonte);
			else
				_db.AddInParameter(command, "@fonte", DbType.String, null);

			if (entidade.FonteUrl != null)
				_db.AddInParameter(command, "@fonteUrl", DbType.String, entidade.FonteUrl);
			else
				_db.AddInParameter(command, "@fonteUrl", DbType.String, null);

			if (entidade.DataHoraPublicacao != null && entidade.DataHoraPublicacao != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			else
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, null);

			if (entidade.DataExibicaoInicio != null && entidade.DataExibicaoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, entidade.DataExibicaoInicio);
			else
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, null);

			if (entidade.DataExibicaoFim != null && entidade.DataExibicaoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, entidade.DataExibicaoFim);
			else
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, null);

			if (entidade.ArquivoThumbGrande != null && entidade.ArquivoThumbGrande.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, entidade.ArquivoThumbGrande.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, null);

			if (entidade.ArquivoThumbMedio != null && entidade.ArquivoThumbMedio.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, entidade.ArquivoThumbMedio.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Noticia.
		/// </summary>
		/// <param name="entidade">Noticia contendo os dados a serem atualizados.</param>
		public void Atualizar(Noticia entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Noticia SET ");
			sbSQL.Append(" ativa=@ativa, autor=@autor, destaqueHome=@destaqueHome, destaqueNoticias=@destaqueNoticias, destaqueFiquePorDentro=@destaqueFiquePorDentro, destaqueUltimasNoticias=@destaqueUltimasNoticias, fonte=@fonte, fonteUrl=@fonteUrl, dataHoraPublicacao=@dataHoraPublicacao, dataExibicaoInicio=@dataExibicaoInicio, dataExibicaoFim=@dataExibicaoFim, arquivoIdThumbGrande=@arquivoIdThumbGrande, arquivoIdThumbMedio=@arquivoIdThumbMedio ");
			sbSQL.Append(" WHERE noticiaId=@noticiaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativa", DbType.Int32, entidade.Ativa);
			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);
			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);
			_db.AddInParameter(command, "@destaqueNoticias", DbType.Int32, entidade.DestaqueNoticias);
			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);
			_db.AddInParameter(command, "@destaqueUltimasNoticias", DbType.Int32, entidade.DestaqueUltimasNoticias);

			if (entidade.Fonte != null)
				_db.AddInParameter(command, "@fonte", DbType.String, entidade.Fonte);
			else
				_db.AddInParameter(command, "@fonte", DbType.String, null);
			if (entidade.FonteUrl != null)
				_db.AddInParameter(command, "@fonteUrl", DbType.String, entidade.FonteUrl);
			else
				_db.AddInParameter(command, "@fonteUrl", DbType.String, null);
			if (entidade.DataHoraPublicacao != null && entidade.DataHoraPublicacao != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			else
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, null);
			if (entidade.DataExibicaoInicio != null && entidade.DataExibicaoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, entidade.DataExibicaoInicio);
			else
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, null);
			if (entidade.DataExibicaoFim != null && entidade.DataExibicaoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, entidade.DataExibicaoFim);
			else
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, null);
			if (entidade.ArquivoThumbGrande != null && entidade.ArquivoThumbGrande.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, entidade.ArquivoThumbGrande.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, null);
			if (entidade.ArquivoThumbMedio != null && entidade.ArquivoThumbMedio.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, entidade.ArquivoThumbMedio.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Noticia da base de dados.
		/// </summary>
		/// <param name="entidade">Noticia a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Noticia entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Noticia ");
			sbSQL.Append("WHERE noticiaId=@noticiaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Conteudo.ConteudoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Noticia.
		/// </summary>
		/// <param name="entidade">Noticia a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Noticia</returns>
		public Noticia Carregar(Noticia entidade)
		{

			Noticia entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Noticia WHERE noticiaId=@noticiaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega uma Noticia para exibição do site
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		public Noticia CarregarToSite(int noticiaId)
		{
			Noticia entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewNoticiasSite WHERE noticiaId=@noticiaId");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, noticiaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega ultimas Noticias para exibição do site
		/// </summary>
		/// <param name="qtdNoticias"></param>
		/// <param name="origemHome">indica a origem para restringir os destaques, caso a origem for home, restringe destaqueHome, senão restringe destaqueFiquePorDentro</param>
		/// <returns></returns>
		public List<Noticia> CarregarUltimasNoticias(int qtdNoticias, IFilterHelper filtro)
		{
			List<Noticia> entidadesRetorno = new List<Noticia>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdNoticias.ToString() + " * FROM dbo.viewNoticiasSite ");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }

			//if (origemHome)
			//{                
			//    sbSQL.Append(" WHERE dbo.viewNoticiasSite.destaqueHome = 0");
			//}
			//else
			//{
			//    sbSQL.Append(" WHERE dbo.viewNoticiasSite.destaqueFiquePorDentro = 0");
			//}

			sbSQL.Append(" ORDER BY  dbo.viewNoticiasSite.dataExibicaoInicio DESC");
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega ultimas Noticias para exibição do site podendo excluir notícias já exibidas.
		/// </summary>
		/// <param name="qtdNoticias">Inteiro contendo o número de notícias a serem recuperadas.</param>
		/// <param name="noticiasJaExibidas">Coleção de Noticia que devem ser excluídas da pesquisa.</param>
		/// <returns></returns>
		public List<Noticia> CarregarUltimasNoticias(int qtdNoticias, List<Noticia> noticiasJaExibidas)
		{
			if (qtdNoticias <= 0)
			{
				throw new ArgumentException("Quantidade total de notícias não informado!");
			}

			List<Noticia> entidadesRetorno = new List<Noticia>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdNoticias.ToString() + " * FROM dbo.viewNoticiasSite WHERE destaqueUltimasNoticias=1 ");

			if (noticiasJaExibidas != null && noticiasJaExibidas.Count > 0)
			{
				var idsDeNoticia = noticiasJaExibidas.Select(p => p.Conteudo.ConteudoId.ToString()).Aggregate((current, next) => current + ", " + next);
				if (idsDeNoticia != null) sbSQL.AppendFormat("AND NoticiaId NOT IN ({0})", idsDeNoticia);
			}

			sbSQL.Append(" ORDER BY  dbo.viewNoticiasSite.dataExibicaoInicio DESC");
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega as noticias mais vistas para exibição do site
		/// </summary>
		/// <param name="qtdNoticias"></param>
		/// <returns></returns>
		public List<Noticia> CarregarMaisVistos(int qtdNoticias)
		{
			List<Noticia> entidadesRetorno = new List<Noticia>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdNoticias.ToString() + " * FROM dbo.viewNoticiasMaisVistos ORDER BY dbo.viewNoticiasMaisVistos.hits DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);


			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega as noticias relacionadas com tag exibição do site
		/// </summary>
		/// <param name="qtdNoticias"></param>
		/// <returns></returns>
		public List<Noticia> CarregarTagged(int tagId)
		{
			List<Noticia> entidadesRetorno = new List<Noticia>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM dbo.viewNoticiasTagged WHERE dbo.viewNoticiasTagged.tagId = @tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

			IDataReader reader = _db.ExecuteReader(command);


			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Noticia.
		/// </summary>
		/// <param name="entidade">NoticiaImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Noticia.</returns>
		public List<Noticia> Carregar(NoticiaImagem entidade)
		{
			List<Noticia> entidadesRetorno = new List<Noticia>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Noticia.* FROM Noticia INNER JOIN NoticiaImagem ON Noticia.noticiaId=NoticiaImagem.noticiaId WHERE NoticiaImagem.noticiaImagemId=@noticiaImagemId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagemId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quantidadeRegistros"></param>
		/// <param name="ordemColunas"></param>
		/// <param name="ordemSentidos"></param>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public List<Noticia> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Noticia> entidadesRetorno = new List<Noticia>();

			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;

			// Monta o "OrderBy"
			if (ordemColunas != null)
			{
				for (int i = 0; i < ordemColunas.Length; i++)
				{
					if (sbOrder.Length > 0) { sbOrder.Append(", "); }
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				}
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
			}
			else
			{
				sbOrder.Append(" ORDER BY noticiaId");
			}


			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			sbSQL.Append("* FROM viewNoticiasSite ");
			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
			if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Noticia.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Noticia.</returns>
		public List<Noticia> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<Noticia> entidadesRetorno = new List<Noticia>();

			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;

			// Monta o "OrderBy"
			if (ordemColunas != null)
			{
				for (int i = 0; i < ordemColunas.Length; i++)
				{
					if (sbOrder.Length > 0) { sbOrder.Append(", "); }
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				}
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
			}
			else
			{
				sbOrder.Append(" ORDER BY noticiaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Noticia");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Noticia WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Noticia ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Noticia.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Noticia ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Noticia.* FROM Noticia ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Noticia entidadeRetorno = new Noticia();
				PopulaNoticia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Noticia existentes na base de dados.
		/// </summary>
		public List<Noticia> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Noticia na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Noticia na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Noticia");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdNoticias"></param>
		/// <param name="regiaoId"></param>
		/// <returns></returns>
		public List<Noticia> CarregarPorRegiao(int qtdNoticias, int regiaoId)
		{
			List<Noticia> entidadeRetorno = new List<Noticia>();
			Noticia entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ");

			if (qtdNoticias > 0)
			{
				sbSQL.Append(String.Concat("TOP ", qtdNoticias, " "));
			}

			sbSQL.Append("viewNoticiasSite.* FROM viewNoticiasSite ");
			sbSQL.Append("INNER JOIN ConteudoRegiao ON viewNoticiasSite.noticiaId = dbo.ConteudoRegiao.conteudoId ");
			sbSQL.Append("WHERE (ConteudoRegiao.regiaoId = @regiaoId)");
			sbSQL.Append("ORDER BY dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Noticia();
				PopulaNoticia(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna popula um Noticia baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Noticia a ser populado(.</param>
		public static void PopulaNoticia(IDataReader reader, Noticia entidade)
		{
			if (reader["ativa"] != DBNull.Value)
				entidade.Ativa = Convert.ToBoolean(reader["ativa"].ToString());

			if (reader["autor"] != DBNull.Value)
				entidade.Autor = reader["autor"].ToString();

			if (reader["destaqueHome"] != DBNull.Value)
				entidade.DestaqueHome = Convert.ToBoolean(reader["destaqueHome"].ToString());

			if (reader["destaqueNoticias"] != DBNull.Value)
				entidade.DestaqueNoticias = Convert.ToBoolean(reader["destaqueNoticias"].ToString());

			if (reader["destaqueFiquePorDentro"] != DBNull.Value)
				entidade.DestaqueFiquePorDentro = Convert.ToBoolean(reader["destaqueFiquePorDentro"].ToString());

			if (reader["destaqueUltimasNoticias"] != DBNull.Value)
				entidade.DestaqueUltimasNoticias = Convert.ToBoolean(reader["destaqueUltimasNoticias"].ToString());

			if (reader["fonte"] != DBNull.Value)
				entidade.Fonte = reader["fonte"].ToString();

			if (reader["fonteUrl"] != DBNull.Value)
				entidade.FonteUrl = reader["fonteUrl"].ToString();

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["dataExibicaoInicio"] != DBNull.Value)
				entidade.DataExibicaoInicio = Convert.ToDateTime(reader["dataExibicaoInicio"].ToString());

			if (reader["dataExibicaoFim"] != DBNull.Value)
				entidade.DataExibicaoFim = Convert.ToDateTime(reader["dataExibicaoFim"].ToString());

			if (reader["noticiaId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["noticiaId"].ToString());
			}

			if (reader["arquivoIdThumbGrande"] != DBNull.Value)
			{
				entidade.ArquivoThumbGrande = new Arquivo();
				entidade.ArquivoThumbGrande.ArquivoId = Convert.ToInt32(reader["arquivoIdThumbGrande"].ToString());
			}

			if (reader["arquivoIdThumbMedio"] != DBNull.Value)
			{
				entidade.ArquivoThumbMedio = new Arquivo();
				entidade.ArquivoThumbMedio.ArquivoId = Convert.ToInt32(reader["arquivoIdThumbMedio"].ToString());
			}
		}
	}
}