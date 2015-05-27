
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
	public class LocalCursoADO : ADOSuper, ILocalCursoDAL
	{

		/// <summary>
		/// Método que persiste um LocalCurso.
		/// </summary>
		/// <param name="entidade">LocalCurso contendo os dados a serem persistidos.</param>	
		public void Inserir(LocalCurso entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO LocalCurso ");
			sbSQL.Append(" (localCursoId, local, email, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@localCursoId, @local, @email, @ativo) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCursoId);

			_db.AddInParameter(command, "@local", DbType.String, entidade.Local);

			if (entidade.Email != null)
				_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			else
				_db.AddInParameter(command, "@email", DbType.String, null);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um LocalCurso.
		/// </summary>
		/// <param name="entidade">LocalCurso contendo os dados a serem atualizados.</param>
		public void Atualizar(LocalCurso entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE LocalCurso SET ");
			sbSQL.Append(" local=@local, email=@email, ativo=@ativo ");
			sbSQL.Append(" WHERE localCursoId=@localCursoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCursoId);
			_db.AddInParameter(command, "@local", DbType.String, entidade.Local);
			if (entidade.Email != null)
				_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			else
				_db.AddInParameter(command, "@email", DbType.String, null);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um LocalCurso da base de dados.
		/// </summary>
		/// <param name="entidade">LocalCurso a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(LocalCurso entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM LocalCurso ");
			sbSQL.Append("WHERE localCursoId=@localCursoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCursoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um LocalCurso.
		/// </summary>
		/// <param name="entidade">LocalCurso a ser carregado (somente o identificador é necessário).</param>
		/// <returns>LocalCurso</returns>
		public LocalCurso Carregar(int localCursoId)
		{
			LocalCurso entidade = new LocalCurso();
			entidade.LocalCursoId = localCursoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um LocalCurso.
		/// </summary>
		/// <param name="entidade">LocalCurso a ser carregado (somente o identificador é necessário).</param>
		/// <returns>LocalCurso</returns>
		public LocalCurso Carregar(LocalCurso entidade)
		{

			LocalCurso entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM LocalCurso WHERE localCursoId=@localCursoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCursoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new LocalCurso();
				PopulaLocalCurso(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de LocalCurso.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de LocalCurso.</returns>
		public List<LocalCurso> Carregar(FormularioCursoVazamento entidade)
		{
			List<LocalCurso> entidadesRetorno = new List<LocalCurso>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT LocalCurso.* FROM LocalCurso INNER JOIN FormularioCursoVazamento ON LocalCurso.localCursoId=FormularioCursoVazamento.localCursoId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				LocalCurso entidadeRetorno = new LocalCurso();
				PopulaLocalCurso(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de LocalCurso.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos LocalCurso.</returns>
		public List<LocalCurso> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<LocalCurso> entidadesRetorno = new List<LocalCurso>();

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
				sbOrder.Append(" ORDER BY localCursoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM LocalCurso");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM LocalCurso WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM LocalCurso ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT LocalCurso.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM LocalCurso ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT LocalCurso.* FROM LocalCurso ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				LocalCurso entidadeRetorno = new LocalCurso();
				PopulaLocalCurso(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os LocalCurso existentes na base de dados.
		/// </summary>
		public List<LocalCurso> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de LocalCurso na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de LocalCurso na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM LocalCurso");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um LocalCurso baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">LocalCurso a ser populado(.</param>
		public static void PopulaLocalCurso(IDataReader reader, LocalCurso entidade)
		{
			if (reader["localCursoId"] != DBNull.Value)
				entidade.LocalCursoId = Convert.ToInt32(reader["localCursoId"].ToString());

			if (reader["local"] != DBNull.Value)
				entidade.Local = reader["local"].ToString();

			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();

			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());


		}

	}
}
