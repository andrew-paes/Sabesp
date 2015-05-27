
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
	public class IdiomaADO : ADOSuper, IIdiomaDAL
	{

		/// <summary>
		/// Método que persiste um Idioma.
		/// </summary>
		/// <param name="entidade">Idioma contendo os dados a serem persistidos.</param>	
		public void Inserir(Idioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Idioma ");
			sbSQL.Append(" (idiomaId, name, active, default, flag) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@idiomaId, @name, @active, @default, @flag) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.IdiomaId);

			_db.AddInParameter(command, "@name", DbType.String, entidade.Name);

			_db.AddInParameter(command, "@active", DbType.Int32, entidade.Active);

			_db.AddInParameter(command, "@default", DbType.Int32, entidade.Default);

			if (entidade.Flag != null)
				_db.AddInParameter(command, "@flag", DbType.String, entidade.Flag);
			else
				_db.AddInParameter(command, "@flag", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Idioma.
		/// </summary>
		/// <param name="entidade">Idioma contendo os dados a serem atualizados.</param>
		public void Atualizar(Idioma entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Idioma SET ");
			sbSQL.Append(" name=@name, active=@active, default=@default, flag=@flag ");
			sbSQL.Append(" WHERE idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.IdiomaId);
			_db.AddInParameter(command, "@name", DbType.String, entidade.Name);
			_db.AddInParameter(command, "@active", DbType.Int32, entidade.Active);
			_db.AddInParameter(command, "@default", DbType.Int32, entidade.Default);
			if (entidade.Flag != null)
				_db.AddInParameter(command, "@flag", DbType.String, entidade.Flag);
			else
				_db.AddInParameter(command, "@flag", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Idioma da base de dados.
		/// </summary>
		/// <param name="entidade">Idioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Idioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Idioma ");
			sbSQL.Append("WHERE idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.IdiomaId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Idioma.
		/// </summary>
		/// <param name="entidade">Idioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Idioma</returns>
		public Idioma Carregar(int idiomaId)
		{
			Idioma entidade = new Idioma();
			entidade.IdiomaId = idiomaId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Idioma.
		/// </summary>
		/// <param name="entidade">Idioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Idioma</returns>
		public Idioma Carregar(Idioma entidade)
		{

			Idioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Idioma WHERE idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Idioma();
				PopulaIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Idioma.
		/// </summary>
		/// <param name="entidade">ControleIdioma relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Idioma.</returns>
		public List<Idioma> Carregar(ControleIdioma entidade)
		{
			List<Idioma> entidadesRetorno = new List<Idioma>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Idioma.* FROM Idioma INNER JOIN ControleIdioma ON Idioma.idiomaId=ControleIdioma.idiomaId WHERE ControleIdioma.controleIdiomaId=@controleIdiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Idioma entidadeRetorno = new Idioma();
				PopulaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Idioma.
		/// </summary>
		/// <param name="entidade">Tag relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Idioma.</returns>
		public List<Idioma> Carregar(Tag entidade)
		{
			List<Idioma> entidadesRetorno = new List<Idioma>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Idioma.* FROM Idioma INNER JOIN Tag ON Idioma.idiomaId=Tag.idiomaId WHERE Tag.tagId=@tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, entidade.TagId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Idioma entidadeRetorno = new Idioma();
				PopulaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Idioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Idioma.</returns>
		public List<Idioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<Idioma> entidadesRetorno = new List<Idioma>();

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
				sbOrder.Append(" ORDER BY idiomaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Idioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Idioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Idioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Idioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Idioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Idioma.* FROM Idioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Idioma entidadeRetorno = new Idioma();
				PopulaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Idioma existentes na base de dados.
		/// </summary>
		public List<Idioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Idioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Idioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Idioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Idioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Idioma a ser populado(.</param>
		public static void PopulaIdioma(IDataReader reader, Idioma entidade)
		{
			if (reader["idiomaId"] != DBNull.Value)
				entidade.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());

			if (reader["name"] != DBNull.Value)
				entidade.Name = reader["name"].ToString();

			if (reader["active"] != DBNull.Value)
				entidade.Active = Convert.ToBoolean(reader["active"].ToString());

			if (reader["default"] != DBNull.Value)
				entidade.Default = Convert.ToBoolean(reader["default"].ToString());

			if (reader["flag"] != DBNull.Value)
				entidade.Flag = reader["flag"].ToString();


		}
        /// <summary>
        /// Método que carrega idiomas que não estão em SolucaoAmbiental para exibição do site
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public List<Idioma> CarregarIdiomasSemSolucaoAmbiental()
        {
            List<Idioma> entidadesRetorno = new List<Idioma>();

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT idioma.* FROM Idioma WHERE idiomaId NOT IN");

            sbSQL.Append("(SELECT idioma.idiomaId FROM Idioma INNR JOIN SolucaoAmbientalIdioma ON SolucaoAmbientalIdioma.idiomaId = Idioma.idiomaId )");


            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            IDataReader reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Idioma entidadeRetorno = new Idioma();
                PopulaIdioma(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }

	}
}
