
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
	public class ModeloADO : ADOSuper, IModeloDAL
	{

		/// <summary>
		/// Método que persiste um Modelo.
		/// </summary>
		/// <param name="entidade">Modelo contendo os dados a serem persistidos.</param>	
		public void Inserir(Modelo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Modelo ");
			sbSQL.Append(" (nome, arquivo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@nome, @arquivo) ");

			sbSQL.Append(" ; SET @modeloId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@modeloId", DbType.Int32, 8);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@arquivo", DbType.String, entidade.Arquivo);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ModeloId = Convert.ToInt32(_db.GetParameterValue(command, "@modeloId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um Modelo.
		/// </summary>
		/// <param name="entidade">Modelo contendo os dados a serem atualizados.</param>
		public void Atualizar(Modelo entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Modelo SET ");
			sbSQL.Append(" nome=@nome, arquivo=@arquivo ");
			sbSQL.Append(" WHERE modeloId=@modeloId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@modeloId", DbType.Int32, entidade.ModeloId);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@arquivo", DbType.String, entidade.Arquivo);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Modelo da base de dados.
		/// </summary>
		/// <param name="entidade">Modelo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Modelo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Modelo ");
			sbSQL.Append("WHERE modeloId=@modeloId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@modeloId", DbType.Int32, entidade.ModeloId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Modelo.
		/// </summary>
		/// <param name="entidade">Modelo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Modelo</returns>
		public Modelo Carregar(int modeloId)
		{
			Modelo entidade = new Modelo();
			entidade.ModeloId = modeloId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Modelo.
		/// </summary>
		/// <param name="entidade">Modelo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Modelo</returns>
		public Modelo Carregar(Modelo entidade)
		{

			Modelo entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Modelo WHERE modeloId=@modeloId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@modeloId", DbType.Int32, entidade.ModeloId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Modelo();
				PopulaModelo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de Modelo.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Modelo.</returns>
		public List<Modelo> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<Modelo> entidadesRetorno = new List<Modelo>();

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
				sbOrder.Append(" ORDER BY modeloId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Modelo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Modelo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Modelo ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Modelo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Modelo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Modelo.* FROM Modelo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Modelo entidadeRetorno = new Modelo();
				PopulaModelo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Modelo existentes na base de dados.
		/// </summary>
		public List<Modelo> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Modelo na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Modelo na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Modelo");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Modelo baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Modelo a ser populado(.</param>
		public static void PopulaModelo(IDataReader reader, Modelo entidade)
		{
			if (reader["modeloId"] != DBNull.Value)
				entidade.ModeloId = Convert.ToInt32(reader["modeloId"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["arquivo"] != DBNull.Value)
				entidade.Arquivo = reader["arquivo"].ToString();


		}

	}
}
