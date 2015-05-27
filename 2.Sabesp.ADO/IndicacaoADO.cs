
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
	public class IndicacaoADO : ADOSuper, IIndicacaoDAL
	{

		/// <summary>
		/// Método que persiste um Indicacao.
		/// </summary>
		/// <param name="entidade">Indicacao contendo os dados a serem persistidos.</param>	
		public void Inserir(Indicacao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Indicacao ");
			sbSQL.Append(" (indicacaoId, meio) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@indicacaoId, @meio) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.IndicacaoId);

			_db.AddInParameter(command, "@meio", DbType.String, entidade.Meio);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Indicacao.
		/// </summary>
		/// <param name="entidade">Indicacao contendo os dados a serem atualizados.</param>
		public void Atualizar(Indicacao entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Indicacao SET ");
			sbSQL.Append(" meio=@meio ");
			sbSQL.Append(" WHERE indicacaoId=@indicacaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.IndicacaoId);
			_db.AddInParameter(command, "@meio", DbType.String, entidade.Meio);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Indicacao da base de dados.
		/// </summary>
		/// <param name="entidade">Indicacao a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Indicacao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Indicacao ");
			sbSQL.Append("WHERE indicacaoId=@indicacaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.IndicacaoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Indicacao.
		/// </summary>
		/// <param name="entidade">Indicacao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Indicacao</returns>
		public Indicacao Carregar(int indicacaoId)
		{
			Indicacao entidade = new Indicacao();
			entidade.IndicacaoId = indicacaoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Indicacao.
		/// </summary>
		/// <param name="entidade">Indicacao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Indicacao</returns>
		public Indicacao Carregar(Indicacao entidade)
		{

			Indicacao entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Indicacao WHERE indicacaoId=@indicacaoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.IndicacaoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Indicacao();
				PopulaIndicacao(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Indicacao.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Indicacao.</returns>
		public List<Indicacao> Carregar(FormularioCursoVazamento entidade)
		{
			List<Indicacao> entidadesRetorno = new List<Indicacao>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Indicacao.* FROM Indicacao INNER JOIN FormularioCursoVazamento ON Indicacao.indicacaoId=FormularioCursoVazamento.indicacaoId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Indicacao entidadeRetorno = new Indicacao();
				PopulaIndicacao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Indicacao.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Indicacao.</returns>
		public List<Indicacao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Indicacao> entidadesRetorno = new List<Indicacao>();

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
				sbOrder.Append(" ORDER BY indicacaoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Indicacao");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Indicacao WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Indicacao ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Indicacao.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Indicacao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Indicacao.* FROM Indicacao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Indicacao entidadeRetorno = new Indicacao();
				PopulaIndicacao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os Indicacao existentes na base de dados.
		/// </summary>
		public List<Indicacao> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Indicacao na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Indicacao na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Indicacao");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Indicacao baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Indicacao a ser populado(.</param>
		public static void PopulaIndicacao(IDataReader reader, Indicacao entidade)
		{
			if (reader["indicacaoId"] != DBNull.Value)
				entidade.IndicacaoId = Convert.ToInt32(reader["indicacaoId"].ToString());

			if (reader["meio"] != DBNull.Value)
				entidade.Meio = reader["meio"].ToString();


		}

	}
}
