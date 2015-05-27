
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
	public class ControleIdiomaADO : ADOSuper, IControleIdiomaDAL
	{

		/// <summary>
		/// Método que persiste um ControleIdioma.
		/// </summary>
		/// <param name="entidade">ControleIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(ControleIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ControleIdioma ");
			sbSQL.Append(" (controleId, idiomaId, workflowId, titulo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@controleId, @idiomaId, @workflowId, @titulo) ");

			sbSQL.Append(" ; SET @controleIdiomaId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@controleIdiomaId", DbType.Int32, 8);

			if (entidade.Controle != null)
				_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.Controle.ControleId);
			else
				_db.AddInParameter(command, "@controleId", DbType.Int32, null);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			if (entidade.Workflow != null)
				_db.AddInParameter(command, "@workflowId", DbType.Int32, entidade.Workflow.WorkflowId);
			else
				_db.AddInParameter(command, "@workflowId", DbType.Int32, null);

			_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ControleIdiomaId = Convert.ToInt32(_db.GetParameterValue(command, "@controleIdiomaId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um ControleIdioma.
		/// </summary>
		/// <param name="entidade">ControleIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(ControleIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ControleIdioma SET ");
			sbSQL.Append(" controleId=@controleId, idiomaId=@idiomaId, titulo=@titulo ");
			sbSQL.Append(" WHERE controleIdiomaId=@controleIdiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);
			if (entidade.Controle != null)
				_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.Controle.ControleId);
			else
				_db.AddInParameter(command, "@controleId", DbType.Int32, null);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
	
			_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um ControleIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">ControleIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ControleIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleIdioma ");
			sbSQL.Append("WHERE controleIdiomaId=@controleIdiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um ControleIdioma.
		/// </summary>
		/// <param name="entidade">ControleIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdioma</returns>
		public ControleIdioma Carregar(int controleIdiomaId)
		{
			ControleIdioma entidade = new ControleIdioma();
			entidade.ControleIdiomaId = controleIdiomaId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um ControleIdioma.
		/// </summary>
		/// <param name="entidade">ControleIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdioma</returns>
		public ControleIdioma Carregar(ControleIdioma entidade)
		{

			ControleIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ControleIdioma WHERE controleIdiomaId=@controleIdiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleIdioma();
				PopulaControleIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de ControleIdioma.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de ControleIdioma.</returns>
		public List<ControleIdioma> Carregar(ControleIdiomaDado entidade)
		{
			List<ControleIdioma> entidadesRetorno = new List<ControleIdioma>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ControleIdioma.* FROM ControleIdioma INNER JOIN ControleIdiomaDado ON ControleIdioma.controleIdiomaId=ControleIdiomaDado.controleIdiomaId WHERE ControleIdiomaDado.controleIdiomaDadoId=@controleIdiomaDadoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDadoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleIdioma entidadeRetorno = new ControleIdioma();
				PopulaControleIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de ControleIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ControleIdioma.</returns>
		public List<ControleIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<ControleIdioma> entidadesRetorno = new List<ControleIdioma>();

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
				sbOrder.Append(" ORDER BY controleIdiomaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ControleIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ControleIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ControleIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT ControleIdioma.* FROM ControleIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleIdioma entidadeRetorno = new ControleIdioma();
				PopulaControleIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os ControleIdioma existentes na base de dados.
		/// </summary>
		public List<ControleIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ControleIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ControleIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ControleIdioma a ser populado(.</param>
		public static void PopulaControleIdioma(IDataReader reader, ControleIdioma entidade)
		{
			if (reader["controleIdiomaId"] != DBNull.Value)
				entidade.ControleIdiomaId = Convert.ToInt32(reader["controleIdiomaId"].ToString());

			if (reader["titulo"] != DBNull.Value)
				entidade.Titulo = reader["titulo"].ToString();

			if (reader["controleId"] != DBNull.Value)
			{
				entidade.Controle = new Controle();
				entidade.Controle.ControleId = Convert.ToInt32(reader["controleId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}

			if (reader["workflowId"] != DBNull.Value)
			{
				entidade.Workflow = new Workflow();
				entidade.Workflow.WorkflowId = Convert.ToInt32(reader["workflowId"].ToString());
			}
		}

		public ControleIdioma CarregarToSite(int controleId, int idiomaId)
		{
			ControleIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewControleIdioma WHERE controleId=@controleId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleId", DbType.Int32, controleId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, idiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleIdioma();
				PopulaControleIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}
	}
}