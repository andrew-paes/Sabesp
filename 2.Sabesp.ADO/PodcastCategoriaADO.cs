
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.94
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
	public class PodcastCategoriaADO : ADOSuper, IPodcastCategoriaDAL
	{

		/// <summary>
		/// Método que persiste um PodcastCategoria.
		/// </summary>
		/// <param name="entidade">PodcastCategoria contendo os dados a serem persistidos.</param>	
		public void Inserir(PodcastCategoria entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO PodcastCategoria ");
			sbSQL.Append(" (ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@ativo) ");

			sbSQL.Append(" ; SET @podcastCategoriaId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@podcastCategoriaId", DbType.Int32, 8);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.PodcastCategoriaId = Convert.ToInt32(_db.GetParameterValue(command, "@podcastCategoriaId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um PodcastCategoria.
		/// </summary>
		/// <param name="entidade">PodcastCategoria contendo os dados a serem atualizados.</param>
		public void Atualizar(PodcastCategoria entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE PodcastCategoria SET ");
			sbSQL.Append(" ativo=@ativo ");
			sbSQL.Append(" WHERE podcastCategoriaId=@podcastCategoriaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoriaId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um PodcastCategoria da base de dados.
		/// </summary>
		/// <param name="entidade">PodcastCategoria a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(PodcastCategoria entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM PodcastCategoria ");
			sbSQL.Append("WHERE podcastCategoriaId=@podcastCategoriaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoriaId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um PodcastCategoria.
		/// </summary>
		/// <param name="entidade">PodcastCategoria a ser carregado (somente o identificador é necessário).</param>
		/// <returns>PodcastCategoria</returns>
		public PodcastCategoria Carregar(int podcastCategoriaId)
		{
			PodcastCategoria entidade = new PodcastCategoria();
			entidade.PodcastCategoriaId = podcastCategoriaId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um PodcastCategoria.
		/// </summary>
		/// <param name="entidade">PodcastCategoria a ser carregado (somente o identificador é necessário).</param>
		/// <returns>PodcastCategoria</returns>
		public PodcastCategoria Carregar(PodcastCategoria entidade)
		{

			PodcastCategoria entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM PodcastCategoria WHERE podcastCategoriaId=@podcastCategoriaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoriaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new PodcastCategoria();
				PopulaPodcastCategoria(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de PodcastCategoria.
		/// </summary>
		/// <param name="entidade">Podcast relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de PodcastCategoria.</returns>
		public List<PodcastCategoria> Carregar(Podcast entidade)
		{
			List<PodcastCategoria> entidadesRetorno = new List<PodcastCategoria>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT PodcastCategoria.* FROM PodcastCategoria INNER JOIN Podcast ON PodcastCategoria.podcastCategoriaId=Podcast.podcastCategoriaId WHERE Podcast.podcastId=@podcastId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				PodcastCategoria entidadeRetorno = new PodcastCategoria();
				PopulaPodcastCategoria(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de PodcastCategoria.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos PodcastCategoria.</returns>
		public List<PodcastCategoria> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<PodcastCategoria> entidadesRetorno = new List<PodcastCategoria>();

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
				sbOrder.Append(" ORDER BY podcastCategoriaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM PodcastCategoria");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastCategoria WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastCategoria ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT PodcastCategoria.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM PodcastCategoria ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT PodcastCategoria.* FROM PodcastCategoria ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				PodcastCategoria entidadeRetorno = new PodcastCategoria();
				PopulaPodcastCategoria(reader, entidadeRetorno);

				PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
				entidadePodcastCategoriaIdioma.Idioma = new Idioma();
				entidadePodcastCategoriaIdioma.Idioma.IdiomaId = 1;
				entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
				entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = entidadeRetorno.PodcastCategoriaId;
				entidadePodcastCategoriaIdioma = new PodcastCategoriaIdiomaADO().Carregar(entidadePodcastCategoriaIdioma);

				entidadeRetorno.PodcastCategoriaIdiomas = new List<PodcastCategoriaIdioma>();
				entidadeRetorno.PodcastCategoriaIdiomas.Add(entidadePodcastCategoriaIdioma);

				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os PodcastCategoria existentes na base de dados.
		/// </summary>
		public List<PodcastCategoria> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastCategoria na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastCategoria na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM PodcastCategoria");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um PodcastCategoria baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">PodcastCategoria a ser populado(.</param>
		public static void PopulaPodcastCategoria(IDataReader reader, PodcastCategoria entidade)
		{
			if (reader["podcastCategoriaId"] != DBNull.Value)
				entidade.PodcastCategoriaId = Convert.ToInt32(reader["podcastCategoriaId"].ToString());

			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());


		}

	}
}
