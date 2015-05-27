
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
	public class EstadoADO : ADOSuper, IEstadoDAL
	{

		/// <summary>
		/// Método que persiste um Estado.
		/// </summary>
		/// <param name="entidade">Estado contendo os dados a serem persistidos.</param>	
		public void Inserir(Estado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Estado ");
			sbSQL.Append(" (estadoId, uf, nomeEstado) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@estadoId, @uf, @nomeEstado) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.EstadoId);

			_db.AddInParameter(command, "@uf", DbType.String, entidade.Uf);

			_db.AddInParameter(command, "@nomeEstado", DbType.String, entidade.NomeEstado);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Estado.
		/// </summary>
		/// <param name="entidade">Estado contendo os dados a serem atualizados.</param>
		public void Atualizar(Estado entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Estado SET ");
			sbSQL.Append(" uf=@uf, nomeEstado=@nomeEstado ");
			sbSQL.Append(" WHERE estadoId=@estadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.EstadoId);
			_db.AddInParameter(command, "@uf", DbType.String, entidade.Uf);
			_db.AddInParameter(command, "@nomeEstado", DbType.String, entidade.NomeEstado);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Estado da base de dados.
		/// </summary>
		/// <param name="entidade">Estado a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Estado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Estado ");
			sbSQL.Append("WHERE estadoId=@estadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.EstadoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Estado.
		/// </summary>
		/// <param name="entidade">Estado a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Estado</returns>
		public Estado Carregar(int estadoId)
		{
			Estado entidade = new Estado();
			entidade.EstadoId = estadoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Estado.
		/// </summary>
		/// <param name="entidade">Estado a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Estado</returns>
		public Estado Carregar(Estado entidade)
		{

			Estado entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Estado WHERE estadoId=@estadoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.EstadoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Estado();
				PopulaEstado(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Estado.
		/// </summary>
		/// <param name="entidade">Cidade relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Estado.</returns>
		public List<Estado> Carregar(Cidade entidade)
		{
			List<Estado> entidadesRetorno = new List<Estado>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Estado.* FROM Estado INNER JOIN Cidade ON Estado.estadoId=Cidade.estadoId WHERE Cidade.cidadeId=@cidadeId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@cidadeId", DbType.Int32, entidade.CidadeId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Estado entidadeRetorno = new Estado();
				PopulaEstado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de Estado.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Estado.</returns>
		public List<Estado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Estado> entidadesRetorno = new List<Estado>();

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
				sbOrder.Append(" ORDER BY estadoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Estado");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Estado WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Estado ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Estado.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Estado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Estado.* FROM Estado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Estado entidadeRetorno = new Estado();
				PopulaEstado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Estado existentes na base de dados.
		/// </summary>
		public List<Estado> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Estado na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Estado na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Estado");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Estado baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Estado a ser populado(.</param>
		public static void PopulaEstado(IDataReader reader, Estado entidade)
		{
			if (reader["estadoId"] != DBNull.Value)
				entidade.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());

			if (reader["uf"] != DBNull.Value)
				entidade.Uf = reader["uf"].ToString();

			if (reader["nomeEstado"] != DBNull.Value)
				entidade.NomeEstado = reader["nomeEstado"].ToString();


		}

	}
}
