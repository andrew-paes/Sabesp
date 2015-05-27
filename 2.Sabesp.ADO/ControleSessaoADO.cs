
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
	public class ControleSessaoADO : ADOSuper, IControleSessaoDAL
	{

		/// <summary>
		/// Método que persiste um ControleSessao.
		/// </summary>
		/// <param name="entidade">ControleSessao contendo os dados a serem persistidos.</param>	
		public void Inserir(ControleSessao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ControleSessao ");
			sbSQL.Append(" (secaoId, controleId, coluna, posicao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@secaoId, @controleId, @coluna, @posicao) ");

			sbSQL.Append(" ; SET @controleSessaoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@controleSessaoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.SecaoId);

			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.Controle.ControleId);

			_db.AddInParameter(command, "@coluna", DbType.Int32, entidade.Coluna);

			if (entidade.Posicao != null)
				_db.AddInParameter(command, "@posicao", DbType.Int32, entidade.Posicao);
			else
				_db.AddInParameter(command, "@posicao", DbType.Int32, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ControleSessaoId = Convert.ToInt32(_db.GetParameterValue(command, "@controleSessaoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um ControleSessao.
		/// </summary>
		/// <param name="entidade">ControleSessao contendo os dados a serem atualizados.</param>
		public void Atualizar(ControleSessao entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ControleSessao SET ");
			sbSQL.Append(" secaoId=@secaoId, controleId=@controleId, coluna=@coluna, posicao=@posicao ");
			sbSQL.Append(" WHERE controleSessaoId=@controleSessaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@controleSessaoId", DbType.Int32, entidade.ControleSessaoId);
			_db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.SecaoId);
			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.Controle.ControleId);
			_db.AddInParameter(command, "@coluna", DbType.Int32, entidade.Coluna);
			if (entidade.Posicao != null)
				_db.AddInParameter(command, "@posicao", DbType.Int32, entidade.Posicao);
			else
				_db.AddInParameter(command, "@posicao", DbType.Int32, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um ControleSessao da base de dados.
		/// </summary>
		/// <param name="entidade">ControleSessao a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ControleSessao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleSessao ");
			sbSQL.Append("WHERE controleSessaoId=@controleSessaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleSessaoId", DbType.Int32, entidade.ControleSessaoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um ControleSessao da base de dados.
		/// </summary>
		/// <param name="entidade">ControleSessao a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Secao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleSessao ");

			sbSQL.Append("WHERE ");

			if (entidade.SecaoId > 0)
			{
				if (!sbSQL.ToString().EndsWith("WHERE "))
				{
					sbSQL.Append("AND ");
				}
				sbSQL.Append("SecaoId=@SecaoId ");
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			if (entidade.SecaoId > 0)
				_db.AddInParameter(command, "@SecaoId", DbType.Int32, entidade.SecaoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um ControleSessao.
		/// </summary>
		/// <param name="entidade">ControleSessao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleSessao</returns>
		public ControleSessao Carregar(int controleSessaoId)
		{
			ControleSessao entidade = new ControleSessao();
			entidade.ControleSessaoId = controleSessaoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um ControleSessao.
		/// </summary>
		/// <param name="entidade">ControleSessao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleSessao</returns>
		public ControleSessao Carregar(ControleSessao entidade)
		{

			ControleSessao entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ControleSessao WHERE controleSessaoId=@controleSessaoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleSessaoId", DbType.Int32, entidade.ControleSessaoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleSessao();
				PopulaControleSessao(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega uma ControleSessao para exibição do site
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		public ControleSessao CarregarToSite(int controleSessaoId)
		{
			ControleSessao entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewControleSessaoSite WHERE controleSessaoId=@controleSessaoId");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleSessaoId", DbType.Int32, controleSessaoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleSessao();
				PopulaControleSessao(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de ControleSessao.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ControleSessao.</returns>
		public List<ControleSessao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<ControleSessao> entidadesRetorno = new List<ControleSessao>();

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
				sbOrder.Append(" ORDER BY controleSessaoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ControleSessao");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleSessao WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleSessao ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ControleSessao.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ControleSessao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT ControleSessao.* FROM ControleSessao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleSessao entidadeRetorno = new ControleSessao();
				PopulaControleSessao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os ControleSessao existentes na base de dados.
		/// </summary>
		public List<ControleSessao> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		public List<ControleSessao> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<ControleSessao> entidadesRetorno = new List<ControleSessao>();

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
				sbOrder.Append(" ORDER BY controleSessaoId");
			}


			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			sbSQL.Append("* FROM viewControleSessaoSite ");
			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
			if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleSessao entidadeRetorno = new ControleSessao();
				PopulaControleSessao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna o total de ControleSessao na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ControleSessao na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ControleSessao");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ControleSessao baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ControleSessao a ser populado(.</param>
		public static void PopulaControleSessao(IDataReader reader, ControleSessao entidade)
		{
			if (reader["controleSessaoId"] != DBNull.Value)
				entidade.ControleSessaoId = Convert.ToInt32(reader["controleSessaoId"].ToString());

			if (reader["secaoId"] != DBNull.Value)
				entidade.SecaoId = Convert.ToInt32(reader["secaoId"].ToString());

			if (reader["coluna"] != DBNull.Value)
				entidade.Coluna = Convert.ToInt32(reader["coluna"].ToString());

			if (reader["posicao"] != DBNull.Value)
				entidade.Posicao = Convert.ToInt32(reader["posicao"].ToString());

			if (reader["controleId"] != DBNull.Value)
			{
				entidade.Controle = new Controle();
				entidade.Controle.ControleId = Convert.ToInt32(reader["controleId"].ToString());
			}


		}

	}
}
