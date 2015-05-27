
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
	public class ControleIdiomaDadoArquivoADO : ADOSuper, IControleIdiomaDadoArquivoDAL
	{

		/// <summary>
		/// Método que persiste um ControleIdiomaDadoArquivo.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo contendo os dados a serem persistidos.</param>	
		public void Inserir(ControleIdiomaDadoArquivo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ControleIdiomaDadoArquivo ");
			sbSQL.Append(" (controleIdiomaDadoId, nome, tamanho, extensao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@controleIdiomaDadoId, @nome, @tamanho, @extensao) ");

			sbSQL.Append(" ; SET @controleIdiomaDadoArquivoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@controleIdiomaDadoArquivoId", DbType.Int32, 8);

			if (entidade.ControleIdiomaDado != null)
				_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDado.ControleIdiomaDadoId);
			else
				_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, null);

			if (entidade.Nome != null)
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);

			if (entidade.Tamanho != null)
				_db.AddInParameter(command, "@tamanho", DbType.Int32, entidade.Tamanho);
			else
				_db.AddInParameter(command, "@tamanho", DbType.Int32, null);

			if (entidade.Extensao != null)
				_db.AddInParameter(command, "@extensao", DbType.String, entidade.Extensao);
			else
				_db.AddInParameter(command, "@extensao", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ControleIdiomaDadoArquivoId = Convert.ToInt32(_db.GetParameterValue(command, "@controleIdiomaDadoArquivoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um ControleIdiomaDadoArquivo.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo contendo os dados a serem atualizados.</param>
		public void Atualizar(ControleIdiomaDadoArquivo entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ControleIdiomaDadoArquivo SET ");
			sbSQL.Append(" controleIdiomaDadoId=@controleIdiomaDadoId, nome=@nome, tamanho=@tamanho, extensao=@extensao ");
			sbSQL.Append(" WHERE controleIdiomaDadoArquivoId=@controleIdiomaDadoArquivoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@controleIdiomaDadoArquivoId", DbType.Int32, entidade.ControleIdiomaDadoArquivoId);
			if (entidade.ControleIdiomaDado != null)
				_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDado.ControleIdiomaDadoId);
			else
				_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, null);
			if (entidade.Nome != null)
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);
			if (entidade.Tamanho != null)
				_db.AddInParameter(command, "@tamanho", DbType.Int32, entidade.Tamanho);
			else
				_db.AddInParameter(command, "@tamanho", DbType.Int32, null);
			if (entidade.Extensao != null)
				_db.AddInParameter(command, "@extensao", DbType.String, entidade.Extensao);
			else
				_db.AddInParameter(command, "@extensao", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um ControleIdiomaDadoArquivo da base de dados.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ControleIdiomaDadoArquivo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleIdiomaDadoArquivo ");
			sbSQL.Append("WHERE controleIdiomaDadoArquivoId=@controleIdiomaDadoArquivoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaDadoArquivoId", DbType.Int32, entidade.ControleIdiomaDadoArquivoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um ControleIdiomaDadoArquivo.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdiomaDadoArquivo</returns>
		public ControleIdiomaDadoArquivo Carregar(int controleIdiomaDadoArquivoId)
		{
			ControleIdiomaDadoArquivo entidade = new ControleIdiomaDadoArquivo();
			entidade.ControleIdiomaDadoArquivoId = controleIdiomaDadoArquivoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um ControleIdiomaDadoArquivo.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdiomaDadoArquivo</returns>
		public ControleIdiomaDadoArquivo Carregar(ControleIdiomaDadoArquivo entidade)
		{

			ControleIdiomaDadoArquivo entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ControleIdiomaDadoArquivo WHERE controleIdiomaDadoArquivoId=@controleIdiomaDadoArquivoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaDadoArquivoId", DbType.Int32, entidade.ControleIdiomaDadoArquivoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleIdiomaDadoArquivo();
				PopulaControleIdiomaDadoArquivo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de ControleIdiomaDadoArquivo.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ControleIdiomaDadoArquivo.</returns>
		public List<ControleIdiomaDadoArquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<ControleIdiomaDadoArquivo> entidadesRetorno = new List<ControleIdiomaDadoArquivo>();

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
				sbOrder.Append(" ORDER BY controleIdiomaDadoArquivoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ControleIdiomaDadoArquivo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdiomaDadoArquivo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdiomaDadoArquivo ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ControleIdiomaDadoArquivo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ControleIdiomaDadoArquivo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT ControleIdiomaDadoArquivo.* FROM ControleIdiomaDadoArquivo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleIdiomaDadoArquivo entidadeRetorno = new ControleIdiomaDadoArquivo();
				PopulaControleIdiomaDadoArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os ControleIdiomaDadoArquivo existentes na base de dados.
		/// </summary>
		public List<ControleIdiomaDadoArquivo> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdiomaDadoArquivo na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdiomaDadoArquivo na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ControleIdiomaDadoArquivo");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ControleIdiomaDadoArquivo baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ControleIdiomaDadoArquivo a ser populado(.</param>
		public static void PopulaControleIdiomaDadoArquivo(IDataReader reader, ControleIdiomaDadoArquivo entidade)
		{
			if (reader["controleIdiomaDadoArquivoId"] != DBNull.Value)
				entidade.ControleIdiomaDadoArquivoId = Convert.ToInt32(reader["controleIdiomaDadoArquivoId"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["tamanho"] != DBNull.Value)
				entidade.Tamanho = Convert.ToInt32(reader["tamanho"].ToString());

			if (reader["extensao"] != DBNull.Value)
				entidade.Extensao = reader["extensao"].ToString();

			if (reader["controleIdiomaDadoId"] != DBNull.Value)
			{
				entidade.ControleIdiomaDado = new ControleIdiomaDado();
				entidade.ControleIdiomaDado.ControleIdiomaDadoId = Convert.ToInt32(reader["controleIdiomaDadoId"].ToString());
			}


		}

	}
}
