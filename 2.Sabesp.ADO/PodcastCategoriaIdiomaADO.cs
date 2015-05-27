
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
	public class PodcastCategoriaIdiomaADO : ADOSuper, IPodcastCategoriaIdiomaDAL
	{

		/// <summary>
		/// Método que persiste um PodcastCategoriaIdioma.
		/// </summary>
		/// <param name="entidade">PodcastCategoriaIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(PodcastCategoriaIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO PodcastCategoriaIdioma ");
			sbSQL.Append(" (podcastCategoriaId, idiomaId, descricao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@podcastCategoriaId, @idiomaId, @descricao) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@descricao", DbType.String, entidade.Descricao);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um PodcastCategoriaIdioma.
		/// </summary>
		/// <param name="entidade">PodcastCategoriaIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(PodcastCategoriaIdioma entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE PodcastCategoriaIdioma SET ");
			sbSQL.Append(" descricao=@descricao ");
			sbSQL.Append(" WHERE podcastCategoriaId=@podcastCategoriaId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@descricao", DbType.String, entidade.Descricao);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um PodcastCategoriaIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">PodcastCategoriaIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(PodcastCategoriaIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM PodcastCategoriaIdioma ");
			sbSQL.Append("WHERE podcastCategoriaId=@podcastCategoriaId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um PodcastCategoriaIdioma.
		/// </summary>
		/// <param name="entidade">PodcastCategoriaIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>PodcastCategoriaIdioma</returns>
		public PodcastCategoriaIdioma Carregar(PodcastCategoriaIdioma entidade)
		{

			PodcastCategoriaIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM PodcastCategoriaIdioma WHERE podcastCategoriaId=@podcastCategoriaId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new PodcastCategoriaIdioma();
				PopulaPodcastCategoriaIdioma(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de PodcastCategoriaIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos PodcastCategoriaIdioma.</returns>
		public List<PodcastCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<PodcastCategoriaIdioma> entidadesRetorno = new List<PodcastCategoriaIdioma>();

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
				sbOrder.Append(" ORDER BY podcastCategoriaId, idiomaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM PodcastCategoriaIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastCategoriaIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM PodcastCategoriaIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT PodcastCategoriaIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM PodcastCategoriaIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT PodcastCategoriaIdioma.* FROM PodcastCategoriaIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				PodcastCategoriaIdioma entidadeRetorno = new PodcastCategoriaIdioma();
				PopulaPodcastCategoriaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os PodcastCategoriaIdioma existentes na base de dados.
		/// </summary>
		public List<PodcastCategoriaIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastCategoriaIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de PodcastCategoriaIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM PodcastCategoriaIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um PodcastCategoriaIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">PodcastCategoriaIdioma a ser populado(.</param>
		public static void PopulaPodcastCategoriaIdioma(IDataReader reader, PodcastCategoriaIdioma entidade)
		{
			if (reader["descricao"] != DBNull.Value)
				entidade.Descricao = reader["descricao"].ToString();

			if (reader["podcastCategoriaId"] != DBNull.Value)
			{
				entidade.PodcastCategoria = new PodcastCategoria();
				entidade.PodcastCategoria.PodcastCategoriaId = Convert.ToInt32(reader["podcastCategoriaId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}

	}
}
