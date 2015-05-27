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
	public class ConteudoADO : ADOSuper, IConteudoDAL
	{
		/// <summary>
		/// Método que persiste um Conteudo.
		/// </summary>
		/// <param name="entidade">Conteudo contendo os dados a serem persistidos.</param>	
		public void Inserir(Conteudo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Conteudo ");
			sbSQL.Append(" (conteudoTipoId, dataHoraCadastro, workflowId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@conteudoTipoId, @dataHoraCadastro, @workflowId) ");

			sbSQL.Append(" ; SET @conteudoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@conteudoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@conteudoTipoId", DbType.Int32, entidade.ConteudoTipo.ConteudoTipoId);

			_db.AddInParameter(command, "@dataHoraCadastro", DbType.DateTime, entidade.DataHoraCadastro);

			if (entidade.Workflow != null)
				_db.AddInParameter(command, "@workflowId", DbType.Int32, entidade.Workflow.WorkflowId);
			else
				_db.AddInParameter(command, "@workflowId", DbType.Int32, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ConteudoId = Convert.ToInt32(_db.GetParameterValue(command, "@conteudoId"));

		}

		/// <summary>
		/// Método que persiste um Conteudo X regiao.
		/// </summary>
		/// <param name="entidade">Conteudo contendo os dados a serem persistidos.</param>	
		public void InserirRelacionado(Conteudo entidade, int regiaoId)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ConteudoRegiao ");
			sbSQL.Append(" (conteudoId, regiaoId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@conteudoId, @regiaoId) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Conteudo.
		/// </summary>
		/// <param name="entidade">Conteudo contendo os dados a serem atualizados.</param>
		public void Atualizar(Conteudo entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Conteudo SET ");
			sbSQL.Append(" conteudoTipoId=@conteudoTipoId, dataHoraCadastro=@dataHoraCadastro, workflowId=@workflowId ");
			sbSQL.Append(" WHERE conteudoId=@conteudoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);
			_db.AddInParameter(command, "@conteudoTipoId", DbType.Int32, entidade.ConteudoTipo.ConteudoTipoId);
			_db.AddInParameter(command, "@dataHoraCadastro", DbType.DateTime, entidade.DataHoraCadastro);
			if (entidade.Workflow != null)
				_db.AddInParameter(command, "@workflowId", DbType.Int32, entidade.Workflow.WorkflowId);
			else
				_db.AddInParameter(command, "@workflowId", DbType.Int32, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Conteudo da base de dados.
		/// </summary>
		/// <param name="entidade">Conteudo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Conteudo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Conteudo ");
			sbSQL.Append("WHERE conteudoId=@conteudoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Conteudo X regiao da base de dados.
		/// </summary>
		/// <param name="entidade">Conteudo a ser excluído (somente o identificador é necessário).</param>		
		public void ExcluirRelacionado(Conteudo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ConteudoRegiao ");
			sbSQL.Append("WHERE conteudoId=@conteudoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um Conteudo.
		/// </summary>
		/// <param name="entidade">Conteudo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Conteudo</returns>
		public Conteudo Carregar(int conteudoId)
		{
			Conteudo entidade = new Conteudo();
			entidade.ConteudoId = conteudoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Conteudo.
		/// </summary>
		/// <param name="entidade">Conteudo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Conteudo</returns>
		public Conteudo Carregar(Conteudo entidade)
		{

			Conteudo entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Conteudo WHERE conteudoId=@conteudoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Conteudo();
				PopulaConteudo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Conteudo.
		/// </summary>
		/// <param name="entidade">Tag relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Conteudo.</returns>
		public List<Conteudo> Carregar(Tag entidade)
		{
			List<Conteudo> entidadesRetorno = new List<Conteudo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Conteudo.* FROM Conteudo INNER JOIN ConteudoTag ON Conteudo.conteudoId=ConteudoTag.conteudoId WHERE ConteudoTag.tagId=@tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, entidade.TagId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Conteudo entidadeRetorno = new Conteudo();
				PopulaConteudo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de Conteudo.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Conteudo.</returns>
		public List<Conteudo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Conteudo> entidadesRetorno = new List<Conteudo>();

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
				sbOrder.Append(" ORDER BY conteudoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Conteudo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Conteudo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Conteudo ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Conteudo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Conteudo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Conteudo.* FROM Conteudo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Conteudo entidadeRetorno = new Conteudo();
				PopulaConteudo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Conteudo existentes na base de dados.
		/// </summary>
		public List<Conteudo> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Conteudo na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Conteudo na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Conteudo");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Conteudo baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Conteudo a ser populado(.</param>
		public static void PopulaConteudo(IDataReader reader, Conteudo entidade)
		{
			if (reader["conteudoId"] != DBNull.Value)
				entidade.ConteudoId = Convert.ToInt32(reader["conteudoId"].ToString());

			if (reader["dataHoraCadastro"] != DBNull.Value)
				entidade.DataHoraCadastro = Convert.ToDateTime(reader["dataHoraCadastro"].ToString());

			if (reader["conteudoTipoId"] != DBNull.Value)
			{
				entidade.ConteudoTipo = new ConteudoTipo();
				entidade.ConteudoTipo.ConteudoTipoId = Convert.ToInt32(reader["conteudoTipoId"].ToString());
			}

			if (reader["workflowId"] != DBNull.Value)
			{
				entidade.Workflow = new Workflow();
				entidade.Workflow.WorkflowId = Convert.ToInt32(reader["workflowId"].ToString());
			}
		}
		/// <summary>
		/// Get related content by content Id
		/// </summary>
		/// <param name="conteudoIdPai"></param>
		/// <returns></returns>
		public DataTable RetornaConteudoRelacionado(int conteudoIdPai)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(" SELECT Conteudo.*, workflow.*, status.* ");
			sbSQL.Append(" FROM Conteudo ");
			sbSQL.Append(" JOIN workflow ON workflow.workflowId = Conteudo.workflowId ");
			sbSQL.Append(" JOIN status ON status.statusid = workflow.statusid  ");
			sbSQL.Append(" WHERE ");
			sbSQL.Append(" ( Conteudo.ConteudoId IN (SELECT ConteudoIdPai FROM ConteudoRelacionado CR  ");
			sbSQL.Append(" WHERE CR.ConteudoIdRelacionado = @conteudoId )  ");
			sbSQL.Append(" OR ");
			sbSQL.Append(" Conteudo.ConteudoId IN (SELECT ConteudoIdRelacionado FROM ConteudoRelacionado CR  ");
			sbSQL.Append(" WHERE CR.ConteudoIdPai = @conteudoId)  ");
			sbSQL.Append(" AND status.mostrarNoSite = 1 ");
			sbSQL.Append(" ) ");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@conteudoId", DbType.Int32, conteudoIdPai);

			return _db.ExecuteDataSet(command).Tables[0];
		}
	}
}