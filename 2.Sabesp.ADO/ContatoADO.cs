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
	public class ContatoADO : ADOSuper, IContatoDAL
	{
		/// <summary>
		/// Método que persiste um Contato.
		/// </summary>
		/// <param name="entidade">Contato contendo os dados a serem persistidos.</param>	
		public void Inserir(Contato entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Contato ");
			sbSQL.Append(" (nomeContato, emailContato) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@nomeContato, @emailContato) ");

			sbSQL.Append(" ; SET @contatoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@contatoId", DbType.Int32, 8);
			_db.AddInParameter(command, "@nomeContato", DbType.String, entidade.NomeContato);
			_db.AddInParameter(command, "@emailContato", DbType.String, entidade.EmailContato);

			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ContatoId = Convert.ToInt32(_db.GetParameterValue(command, "@contatoId"));
		}

		/// <summary>
		/// Método que atualiza os dados de um Contato.
		/// </summary>
		/// <param name="entidade">Contato contendo os dados a serem atualizados.</param>
		public void Atualizar(Contato entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Contato SET ");
			sbSQL.Append(" nomeContato=@nomeContato, emailContato=@emailContato ");
			sbSQL.Append(" WHERE contatoId=@contatoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@contatoId", DbType.Int32, entidade.ContatoId);
			_db.AddInParameter(command, "@nomeContato", DbType.String, entidade.NomeContato);
			_db.AddInParameter(command, "@emailContato", DbType.String, entidade.EmailContato);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Contato da base de dados.
		/// </summary>
		/// <param name="entidade">Contato a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Contato entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Contato ");
			sbSQL.Append("WHERE contatoId=@contatoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@contatoId", DbType.Int32, entidade.ContatoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Contato.
		/// </summary>
		/// <param name="entidade">Contato a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Contato</returns>
		public Contato Carregar(int contatoId)
		{
			Contato entidade = new Contato();
			entidade.ContatoId = contatoId;
			return Carregar(entidade);
		}

		/// <summary>
		/// Método que carrega um Contato.
		/// </summary>
		/// <param name="entidade">Contato a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Contato</returns>
		public Contato Carregar(Contato entidade)
		{
			Contato entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Contato WHERE contatoId=@contatoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@contatoId", DbType.Int32, entidade.ContatoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Contato();
				PopulaContato(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Contato.
		/// </summary>
		/// <param name="entidade">Formulario relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Contato.</returns>
		public List<Contato> Carregar(Formulario entidade)
		{
			List<Contato> entidadesRetorno = new List<Contato>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Contato.* FROM Contato INNER JOIN FormularioContato ON Contato.contatoId=FormularioContato.contatoId WHERE FormularioContato.formularioId=@formularioId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.FormularioId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Contato entidadeRetorno = new Contato();
				PopulaContato(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Contato.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Contato.</returns>
		public List<Contato> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<Contato> entidadesRetorno = new List<Contato>();

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
				sbOrder.Append(" ORDER BY contatoId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Contato");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Contato WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Contato ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Contato.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Contato ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT Contato.* FROM Contato ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Contato entidadeRetorno = new Contato();
				PopulaContato(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os Contato existentes na base de dados.
		/// </summary>
		public List<Contato> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Contato na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Contato na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Contato");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Contato baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Contato a ser populado(.</param>
		public static void PopulaContato(IDataReader reader, Contato entidade)
		{
			if (reader["contatoId"] != DBNull.Value)
				entidade.ContatoId = Convert.ToInt32(reader["contatoId"].ToString());

			if (reader["nomeContato"] != DBNull.Value)
				entidade.NomeContato = reader["nomeContato"].ToString();

			if (reader["emailContato"] != DBNull.Value)
				entidade.EmailContato = reader["emailContato"].ToString();
		}
	}
}