
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
	public class ReleaseImagemADO : ADOSuper, IReleaseImagemDAL
	{

		/// <summary>
		/// Método que persiste um ReleaseImagem.
		/// </summary>
		/// <param name="entidade">ReleaseImagem contendo os dados a serem persistidos.</param>	
		public void Inserir(ReleaseImagem entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ReleaseImagem ");
			sbSQL.Append(" (arquivoId, ordem, releaseId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@arquivoId, @ordem, @releaseId) ");

			sbSQL.Append(" ; SET @releaseImagemID = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@releaseImagemID", DbType.Int32, 8);

			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);

			_db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ReleaseImagemID = Convert.ToInt32(_db.GetParameterValue(command, "@releaseImagemID"));

		}

		/// <summary>
		/// Método que atualiza os dados de um ReleaseImagem.
		/// </summary>
		/// <param name="entidade">ReleaseImagem contendo os dados a serem atualizados.</param>
		public void Atualizar(ReleaseImagem entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ReleaseImagem SET ");
			sbSQL.Append(" arquivoId=@arquivoId, ordem=@ordem, releaseId=@releaseId ");
			sbSQL.Append(" WHERE releaseImagemID=@releaseImagemID ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@releaseImagemID", DbType.Int32, entidade.ReleaseImagemID);
			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);
			_db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);
			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um ReleaseImagem da base de dados.
		/// </summary>
		/// <param name="entidade">ReleaseImagem a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ReleaseImagem entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ReleaseImagem ");
			sbSQL.Append("WHERE releaseImagemID=@releaseImagemID ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseImagemID", DbType.Int32, entidade.ReleaseImagemID);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um ReleaseImagem.
		/// </summary>
		/// <param name="entidade">ReleaseImagem a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ReleaseImagem</returns>
		public ReleaseImagem Carregar(int releaseImagemID)
		{
			ReleaseImagem entidade = new ReleaseImagem();
			entidade.ReleaseImagemID = releaseImagemID;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um ReleaseImagem.
		/// </summary>
		/// <param name="entidade">ReleaseImagem a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ReleaseImagem</returns>
		public ReleaseImagem Carregar(ReleaseImagem entidade)
		{

			ReleaseImagem entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ReleaseImagem WHERE releaseImagemID=@releaseImagemID");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseImagemID", DbType.Int32, entidade.ReleaseImagemID);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ReleaseImagem();
				PopulaReleaseImagem(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de ReleaseImagem.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ReleaseImagem.</returns>
		public List<ReleaseImagem> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<ReleaseImagem> entidadesRetorno = new List<ReleaseImagem>();

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
				sbOrder.Append(" ORDER BY releaseImagemID");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ReleaseImagem");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseImagem WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseImagem ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ReleaseImagem.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ReleaseImagem ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT ReleaseImagem.* FROM ReleaseImagem ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ReleaseImagem entidadeRetorno = new ReleaseImagem();
				PopulaReleaseImagem(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os ReleaseImagem existentes na base de dados.
		/// </summary>
		public List<ReleaseImagem> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de ReleaseImagem na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ReleaseImagem na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ReleaseImagem");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ReleaseImagem baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ReleaseImagem a ser populado(.</param>
		public static void PopulaReleaseImagem(IDataReader reader, ReleaseImagem entidade)
		{
			if (reader["releaseImagemID"] != DBNull.Value)
				entidade.ReleaseImagemID = Convert.ToInt32(reader["releaseImagemID"].ToString());

			if (reader["ordem"] != DBNull.Value)
				entidade.Ordem = Convert.ToInt32(reader["ordem"].ToString());

			if (reader["arquivoId"] != DBNull.Value)
			{
				entidade.Arquivo = new Arquivo();
				entidade.Arquivo.ArquivoId = Convert.ToInt32(reader["arquivoId"].ToString());
			}

			if (reader["releaseId"] != DBNull.Value)
			{
				entidade.Release = new Release();
				entidade.Release.Conteudo = new Conteudo();
				entidade.Release.Conteudo.ConteudoId = Convert.ToInt32(reader["releaseId"].ToString());
			}
		}

		/// <summary>
		/// Método que remove um ReleaseImagem da base de dados.
		/// </summary>
		/// <param name="entidade">ReleaseImagem a ser excluído (somente o identificador é necessário).</param>		
		public void ExcluirRelacionado(Release entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ReleaseImagem ");
			sbSQL.Append("WHERE releaseID=@releaseID ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseID", DbType.Int32, entidade.Conteudo.ConteudoId);


			_db.ExecuteNonQuery(command);
		}
	}
}