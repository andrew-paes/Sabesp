
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
	public class EventoFotoComentarioADO : ADOSuper, IEventoFotoComentarioDAL
	{

		/// <summary>
		/// Método que persiste um EventoFotoComentario.
		/// </summary>
		/// <param name="entidade">EventoFotoComentario contendo os dados a serem persistidos.</param>	
		public void Inserir(EventoFotoComentario entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO EventoFotoComentario ");
			sbSQL.Append(" (eventoFotoId, idiomaId, comentarioImagem) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@eventoFotoId, @idiomaId, @comentarioImagem) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFoto.EventoFotoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um EventoFotoComentario.
		/// </summary>
		/// <param name="entidade">EventoFotoComentario contendo os dados a serem atualizados.</param>
		public void Atualizar(EventoFotoComentario entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE EventoFotoComentario SET ");
			sbSQL.Append(" comentarioImagem=@comentarioImagem ");
			sbSQL.Append(" WHERE eventoFotoId=@eventoFotoId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFoto.EventoFotoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um EventoFotoComentario da base de dados.
		/// </summary>
		/// <param name="entidade">EventoFotoComentario a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(EventoFotoComentario entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM EventoFotoComentario ");
			sbSQL.Append("WHERE eventoFotoId=@eventoFotoId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFoto.EventoFotoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um EventoFotoComentario.
		/// </summary>
		/// <param name="entidade">EventoFotoComentario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>EventoFotoComentario</returns>
		public EventoFotoComentario Carregar(EventoFotoComentario entidade)
		{

			EventoFotoComentario entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM EventoFotoComentario WHERE eventoFotoId=@eventoFotoId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFoto.EventoFotoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new EventoFotoComentario();
				PopulaEventoFotoComentario(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de EventoFotoComentario.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos EventoFotoComentario.</returns>
		public List<EventoFotoComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<EventoFotoComentario> entidadesRetorno = new List<EventoFotoComentario>();

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
				sbOrder.Append(" ORDER BY eventoFotoId, idiomaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM EventoFotoComentario");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoFotoComentario WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoFotoComentario ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT EventoFotoComentario.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM EventoFotoComentario ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT EventoFotoComentario.* FROM EventoFotoComentario ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				EventoFotoComentario entidadeRetorno = new EventoFotoComentario();
				PopulaEventoFotoComentario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os EventoFotoComentario existentes na base de dados.
		/// </summary>
		public List<EventoFotoComentario> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de EventoFotoComentario na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de EventoFotoComentario na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM EventoFotoComentario");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um EventoFotoComentario baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">EventoFotoComentario a ser populado(.</param>
		public static void PopulaEventoFotoComentario(IDataReader reader, EventoFotoComentario entidade)
		{
			if (reader["comentarioImagem"] != DBNull.Value)
				entidade.ComentarioImagem = reader["comentarioImagem"].ToString();

			if (reader["eventoFotoId"] != DBNull.Value)
			{
				entidade.EventoFoto = new EventoFoto();
				entidade.EventoFoto.EventoFotoId = Convert.ToInt32(reader["eventoFotoId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}

	}
}
