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
using System.Text;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class PodcastIdiomaADO : ADOSuper, IPodcastIdiomaDAL
	{
		/// <summary>
		/// Método que persiste um PodcastIdioma.
		/// </summary>
		/// <param name="entidade">PodcastIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(PodcastIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO PodcastIdioma ");
			sbSQL.Append(" (podcastId, idiomaId, tituloPodcast, descricaoPodcast, arquivoIdPodcast) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@podcastId, @idiomaId, @tituloPodcast, @descricaoPodcast, @arquivoIdPodcast) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Podcast.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@tituloPodcast", DbType.String, entidade.TituloPodcast);

			if (entidade.DescricaoPodcast != null)
				_db.AddInParameter(command, "@descricaoPodcast", DbType.String, entidade.DescricaoPodcast);
			else
				_db.AddInParameter(command, "@descricaoPodcast", DbType.String, null);

			_db.AddInParameter(command, "@arquivoIdPodcast", DbType.Int32, entidade.ArquivoPodcast.ArquivoId);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um PodcastIdioma.
		/// </summary>
		/// <param name="entidade">PodcastIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(PodcastIdioma entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE PodcastIdioma SET ");
			sbSQL.Append(" tituloPodcast=@tituloPodcast, descricaoPodcast=@descricaoPodcast, arquivoIdPodcast=@arquivoIdPodcast ");
			sbSQL.Append(" WHERE podcastId=@podcastId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Podcast.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@tituloPodcast", DbType.String, entidade.TituloPodcast);
			if (entidade.DescricaoPodcast != null)
				_db.AddInParameter(command, "@descricaoPodcast", DbType.String, entidade.DescricaoPodcast);
			else
				_db.AddInParameter(command, "@descricaoPodcast", DbType.String, null);
			_db.AddInParameter(command, "@arquivoIdPodcast", DbType.Int32, entidade.ArquivoPodcast.ArquivoId);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um PodcastIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">PodcastIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(PodcastIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM PodcastIdioma ");
			sbSQL.Append("WHERE podcastId=@podcastId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Podcast.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um PodcastIdioma.
		/// </summary>
		/// <param name="entidade">PodcastIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>PodcastIdioma</returns>
		public PodcastIdioma Carregar(PodcastIdioma entidade)
		{

			PodcastIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM PodcastIdioma WHERE podcastId=@podcastId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Podcast.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new PodcastIdioma();
				PopulaPodcastIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de PodcastIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos PodcastIdioma.</returns>
		public List<PodcastIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<PodcastIdioma> entidadesRetorno = new List<PodcastIdioma>();

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
				sbOrder.Append(" ORDER BY podcastId, idiomaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM PodcastIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT PodcastIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM PodcastIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT PodcastIdioma.* FROM PodcastIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				PodcastIdioma entidadeRetorno = new PodcastIdioma();
				PopulaPodcastIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os PodcastIdioma existentes na base de dados.
		/// </summary>
		public List<PodcastIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM PodcastIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um PodcastIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">PodcastIdioma a ser populado(.</param>
		public static void PopulaPodcastIdioma(IDataReader reader, PodcastIdioma entidade)
		{
			if (reader["tituloPodcast"] != DBNull.Value)
				entidade.TituloPodcast = reader["tituloPodcast"].ToString();

			if (reader["descricaoPodcast"] != DBNull.Value)
				entidade.DescricaoPodcast = reader["descricaoPodcast"].ToString();

			if (reader["podcastId"] != DBNull.Value)
			{
				entidade.Podcast = new Podcast();
				entidade.Podcast.Conteudo = new Conteudo();
				entidade.Podcast.Conteudo.ConteudoId = Convert.ToInt32(reader["podcastId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}

			if (reader["arquivoIdPodcast"] != DBNull.Value)
			{
				entidade.ArquivoPodcast = new Arquivo();
				entidade.ArquivoPodcast.ArquivoId = Convert.ToInt32(reader["arquivoIdPodcast"].ToString());
			}


		}

	}
}
