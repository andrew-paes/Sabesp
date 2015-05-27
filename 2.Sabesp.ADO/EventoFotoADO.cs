
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
	public class EventoFotoADO : ADOSuper, IEventoFotoDAL
	{

		/// <summary>
		/// Método que persiste um EventoFoto.
		/// </summary>
		/// <param name="entidade">EventoFoto contendo os dados a serem persistidos.</param>	
		public void Inserir(EventoFoto entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO EventoFoto ");
			sbSQL.Append(" (arquivoId, eventoId, ordem) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@arquivoId, @eventoId, @ordem) ");

			sbSQL.Append(" ; SET @eventoFotoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@eventoFotoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.EventoFotoId = Convert.ToInt32(_db.GetParameterValue(command, "@eventoFotoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um EventoFoto.
		/// </summary>
		/// <param name="entidade">EventoFoto contendo os dados a serem atualizados.</param>
		public void Atualizar(EventoFoto entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE EventoFoto SET ");
			sbSQL.Append(" arquivoId=@arquivoId, eventoId=@eventoId, ordem=@ordem ");
			sbSQL.Append(" WHERE eventoFotoId=@eventoFotoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFotoId);
			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);
			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um EventoFoto da base de dados.
		/// </summary>
		/// <param name="entidade">EventoFoto a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(EventoFoto entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM EventoFoto ");
			sbSQL.Append("WHERE eventoFotoId=@eventoFotoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFotoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um EventoFoto.
		/// </summary>
		/// <param name="entidade">EventoFoto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>EventoFoto</returns>
		public EventoFoto Carregar(int eventoFotoId)
		{
			EventoFoto entidade = new EventoFoto();
			entidade.EventoFotoId = eventoFotoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um EventoFoto.
		/// </summary>
		/// <param name="entidade">EventoFoto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>EventoFoto</returns>
		public EventoFoto Carregar(EventoFoto entidade)
		{

			EventoFoto entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM EventoFoto WHERE eventoFotoId=@eventoFotoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoFotoId", DbType.Int32, entidade.EventoFotoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new EventoFoto();
				PopulaEventoFoto(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de EventoFoto.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos EventoFoto.</returns>
		public List<EventoFoto> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<EventoFoto> entidadesRetorno = new List<EventoFoto>();

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
				sbOrder.Append(" ORDER BY eventoFotoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM EventoFoto");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoFoto WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoFoto ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT EventoFoto.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM EventoFoto ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT EventoFoto.* FROM EventoFoto ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				EventoFoto entidadeRetorno = new EventoFoto();
				PopulaEventoFoto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}
		/// <summary>
		/// Método que retorna uma coleção de Fotos relacionadas ao Evento.
		/// </summary>
		public List<EventoFoto> CarregarFotos(int eventoId)
		{

			List<EventoFoto> entidadesRetorno = new List<EventoFoto>();

			StringBuilder sbSQL = new StringBuilder();
			IDataReader reader;

			sbSQL.Append("SELECT EventoFoto.* FROM EventoFoto INNER JOIN Evento ON Evento.eventoId=EventoFoto.eventoId WHERE Evento.eventoId=@eventoId ORDER BY eventoFoto.ordem");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@eventoId", DbType.Int32, eventoId);
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				EventoFoto entidadeRetorno = new EventoFoto();
				PopulaEventoFoto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}
		/// <summary>
		/// Método que retorna todas os EventoFoto existentes na base de dados.
		/// </summary>
		public List<EventoFoto> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de EventoFoto na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de EventoFoto na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM EventoFoto");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um EventoFoto baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">EventoFoto a ser populado(.</param>
		public static void PopulaEventoFoto(IDataReader reader, EventoFoto entidade)
		{
			if (reader["eventoFotoId"] != DBNull.Value)
				entidade.EventoFotoId = Convert.ToInt32(reader["eventoFotoId"].ToString());

			if (reader["ordem"] != DBNull.Value)
				entidade.Ordem = Convert.ToInt32(reader["ordem"].ToString());

			if (reader["arquivoId"] != DBNull.Value)
			{
				entidade.Arquivo = new Arquivo();
				entidade.Arquivo.ArquivoId = Convert.ToInt32(reader["arquivoId"].ToString());
			}

			if (reader["eventoId"] != DBNull.Value)
			{
				entidade.Evento = new Evento();
				entidade.Evento.Conteudo = new Conteudo(Convert.ToInt32(reader["eventoId"]));
			}
		}
	}
}
