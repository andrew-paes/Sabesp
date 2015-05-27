
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
	public class ControleADO : ADOSuper, IControleDAL
	{

		/// <summary>
		/// Método que persiste um Controle.
		/// </summary>
		/// <param name="entidade">Controle contendo os dados a serem persistidos.</param>	
		public void Inserir(Controle entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Controle ");
			sbSQL.Append(" (controleTipoId, nome, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@controleTipoId, @nome, @ativo) ");

			sbSQL.Append(" ; SET @controleId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@controleId", DbType.Int32, 8);

			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipo.ControleTipoId);

			if (entidade.Nome != null)
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);

			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ControleId = Convert.ToInt32(_db.GetParameterValue(command, "@controleId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um Controle.
		/// </summary>
		/// <param name="entidade">Controle contendo os dados a serem atualizados.</param>
		public void Atualizar(Controle entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Controle SET ");
			sbSQL.Append(" controleTipoId=@controleTipoId, nome=@nome, ativo=@ativo ");
			sbSQL.Append(" WHERE controleId=@controleId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.ControleId);
			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipo.ControleTipoId);
			if (entidade.Nome != null)
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);
			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Controle da base de dados.
		/// </summary>
		/// <param name="entidade">Controle a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Controle entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Controle ");
			sbSQL.Append("WHERE controleId=@controleId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.ControleId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Controle.
		/// </summary>
		/// <param name="entidade">Controle a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Controle</returns>
		public Controle Carregar(int controleId)
		{
			Controle entidade = new Controle();
			entidade.ControleId = controleId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Controle.
		/// </summary>
		/// <param name="entidade">Controle a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Controle</returns>
		public Controle Carregar(Controle entidade)
		{

			Controle entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Controle WHERE controleId=@controleId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.ControleId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Controle();
				PopulaControle(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Controle.
		/// </summary>
		/// <param name="entidade">ControleIdioma relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Controle.</returns>
		public List<Controle> Carregar(ControleIdioma entidade)
		{
			List<Controle> entidadesRetorno = new List<Controle>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Controle.* FROM Controle INNER JOIN ControleIdioma ON Controle.controleId=ControleIdioma.controleId WHERE ControleIdioma.controleIdiomaId=@controleIdiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Controle entidadeRetorno = new Controle();
				PopulaControle(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Controle.
		/// </summary>
		/// <param name="entidade">ControleSessao relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Controle.</returns>
		public List<Controle> Carregar(ControleSessao entidade)
		{
			List<Controle> entidadesRetorno = new List<Controle>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Controle.* FROM Controle INNER JOIN ControleSessao ON Controle.controleId=ControleSessao.controleId WHERE ControleSessao.controleSessaoId=@controleSessaoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleSessaoId", DbType.Int32, entidade.ControleSessaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Controle entidadeRetorno = new Controle();
				PopulaControle(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de Controle.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Controle.</returns>
		public List<Controle> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Controle> entidadesRetorno = new List<Controle>();

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
				sbOrder.Append(" ORDER BY controleId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Controle");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Controle WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Controle ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Controle.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Controle ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Controle.* FROM Controle ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Controle entidadeRetorno = new Controle();
				PopulaControle(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Controle existentes na base de dados.
		/// </summary>
		public List<Controle> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Controle na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Controle na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Controle");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Controle baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Controle a ser populado(.</param>
		public static void PopulaControle(IDataReader reader, Controle entidade)
		{
			if (reader["controleId"] != DBNull.Value)
				entidade.ControleId = Convert.ToInt32(reader["controleId"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["controleTipoId"] != DBNull.Value)
			{
				entidade.ControleTipo = new ControleTipo();
				entidade.ControleTipo.ControleTipoId = Convert.ToInt32(reader["controleTipoId"].ToString());
			}


		}

	}
}
