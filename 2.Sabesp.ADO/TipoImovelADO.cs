
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
	public class TipoImovelADO : ADOSuper, ITipoImovelDAL
	{

		/// <summary>
		/// Método que persiste um TipoImovel.
		/// </summary>
		/// <param name="entidade">TipoImovel contendo os dados a serem persistidos.</param>	
		public void Inserir(TipoImovel entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO TipoImovel ");
			sbSQL.Append(" (tipoImovelId, tipo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@tipoImovelId, @tipo) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovelId);

			_db.AddInParameter(command, "@tipo", DbType.String, entidade.Tipo);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um TipoImovel.
		/// </summary>
		/// <param name="entidade">TipoImovel contendo os dados a serem atualizados.</param>
		public void Atualizar(TipoImovel entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE TipoImovel SET ");
			sbSQL.Append(" tipo=@tipo ");
			sbSQL.Append(" WHERE tipoImovelId=@tipoImovelId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovelId);
			_db.AddInParameter(command, "@tipo", DbType.String, entidade.Tipo);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um TipoImovel da base de dados.
		/// </summary>
		/// <param name="entidade">TipoImovel a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(TipoImovel entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM TipoImovel ");
			sbSQL.Append("WHERE tipoImovelId=@tipoImovelId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovelId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um TipoImovel.
		/// </summary>
		/// <param name="entidade">TipoImovel a ser carregado (somente o identificador é necessário).</param>
		/// <returns>TipoImovel</returns>
		public TipoImovel Carregar(int tipoImovelId)
		{
			TipoImovel entidade = new TipoImovel();
			entidade.TipoImovelId = tipoImovelId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um TipoImovel.
		/// </summary>
		/// <param name="entidade">TipoImovel a ser carregado (somente o identificador é necessário).</param>
		/// <returns>TipoImovel</returns>
		public TipoImovel Carregar(TipoImovel entidade)
		{

			TipoImovel entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM TipoImovel WHERE tipoImovelId=@tipoImovelId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovelId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new TipoImovel();
				PopulaTipoImovel(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de TipoImovel.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de TipoImovel.</returns>
		public List<TipoImovel> Carregar(FormularioCursoVazamento entidade)
		{
			List<TipoImovel> entidadesRetorno = new List<TipoImovel>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TipoImovel.* FROM TipoImovel INNER JOIN FormularioCursoVazamento ON TipoImovel.tipoImovelId=FormularioCursoVazamento.tipoImovelId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				TipoImovel entidadeRetorno = new TipoImovel();
				PopulaTipoImovel(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de TipoImovel.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos TipoImovel.</returns>
		public List<TipoImovel> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<TipoImovel> entidadesRetorno = new List<TipoImovel>();

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
				sbOrder.Append(" ORDER BY tipoImovelId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM TipoImovel");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM TipoImovel WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM TipoImovel ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT TipoImovel.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM TipoImovel ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT TipoImovel.* FROM TipoImovel ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				TipoImovel entidadeRetorno = new TipoImovel();
				PopulaTipoImovel(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os TipoImovel existentes na base de dados.
		/// </summary>
		public List<TipoImovel> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de TipoImovel na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de TipoImovel na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM TipoImovel");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um TipoImovel baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">TipoImovel a ser populado(.</param>
		public static void PopulaTipoImovel(IDataReader reader, TipoImovel entidade)
		{
			if (reader["tipoImovelId"] != DBNull.Value)
				entidade.TipoImovelId = Convert.ToInt32(reader["tipoImovelId"].ToString());

			if (reader["tipo"] != DBNull.Value)
				entidade.Tipo = reader["tipo"].ToString();


		}

	}
}
