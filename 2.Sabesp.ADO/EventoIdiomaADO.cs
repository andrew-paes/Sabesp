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
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class EventoIdiomaADO : ADOSuper, IEventoIdiomaDAL
	{
		/// <summary>
		/// Método que persiste um EventoIdioma.
		/// </summary>
		/// <param name="entidade">EventoIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(EventoIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO EventoIdioma ");
			sbSQL.Append(" (eventoId, idiomaId, nomeEvento, descricaoEvento, chamadaEvento) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@eventoId, @idiomaId, @nomeEvento, @descricaoEvento, @chamadaEvento) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@nomeEvento", DbType.String, entidade.NomeEvento);

			if (entidade.DescricaoEvento != null)
				_db.AddInParameter(command, "@descricaoEvento", DbType.String, entidade.DescricaoEvento);
			else
				_db.AddInParameter(command, "@descricaoEvento", DbType.String, null);

			if (entidade.ChamadaEvento != null)
				_db.AddInParameter(command, "@chamadaEvento", DbType.String, entidade.ChamadaEvento);
			else
				_db.AddInParameter(command, "@chamadaEvento", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um EventoIdioma.
		/// </summary>
		/// <param name="entidade">EventoIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(EventoIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE EventoIdioma SET ");
			sbSQL.Append(" nomeEvento=@nomeEvento, descricaoEvento=@descricaoEvento, chamadaEvento=@chamadaEvento ");
			sbSQL.Append(" WHERE eventoId=@eventoId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@nomeEvento", DbType.String, entidade.NomeEvento);
			if (entidade.DescricaoEvento != null)
				_db.AddInParameter(command, "@descricaoEvento", DbType.String, entidade.DescricaoEvento);
			else
				_db.AddInParameter(command, "@descricaoEvento", DbType.String, null);
			if (entidade.ChamadaEvento != null)
				_db.AddInParameter(command, "@chamadaEvento", DbType.String, entidade.ChamadaEvento);
			else
				_db.AddInParameter(command, "@chamadaEvento", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um EventoIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">EventoIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(EventoIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM EventoIdioma ");
			sbSQL.Append("WHERE eventoId=@eventoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um EventoIdioma.
		/// </summary>
		/// <param name="entidade">EventoIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>EventoIdioma</returns>
		public EventoIdioma Carregar(EventoIdioma entidade)
		{
			EventoIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM EventoIdioma WHERE eventoId=@eventoId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Evento.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new EventoIdioma();
				PopulaEventoIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de EventoIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos EventoIdioma.</returns>
		public List<EventoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<EventoIdioma> entidadesRetorno = new List<EventoIdioma>();

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
				sbOrder.Append(" ORDER BY eventoId, idiomaId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM EventoIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT EventoIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM EventoIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT EventoIdioma.* FROM EventoIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				EventoIdioma entidadeRetorno = new EventoIdioma();
				PopulaEventoIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os EventoIdioma existentes na base de dados.
		/// </summary>
		public List<EventoIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de EventoIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de EventoIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM EventoIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um EventoIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">EventoIdioma a ser populado(.</param>
		public static void PopulaEventoIdioma(IDataReader reader, EventoIdioma entidade)
		{
			if (reader["nomeEvento"] != DBNull.Value)
				entidade.NomeEvento = reader["nomeEvento"].ToString();

			if (reader["descricaoEvento"] != DBNull.Value)
				entidade.DescricaoEvento = reader["descricaoEvento"].ToString();

			if (reader["chamadaEvento"] != DBNull.Value)
				entidade.ChamadaEvento = reader["chamadaEvento"].ToString();

			if (reader["eventoId"] != DBNull.Value)
			{
				entidade.Evento = new Evento();
				entidade.Evento.Conteudo = new Conteudo();
				entidade.Evento.Conteudo.ConteudoId = Convert.ToInt32(reader["eventoId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}
		}
	}
}