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
	public class ReleaseADO : ADOSuper, IReleaseDAL
	{
		/// <summary>
		/// Método que persiste um Release.
		/// </summary>
		/// <param name="entidade">Release contendo os dados a serem persistidos.</param>	
		public void Inserir(Release entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Release ");
			sbSQL.Append(" (releaseId, ativa, dataHoraPublicacao, autor, destaqueHome) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@releaseId, @ativa, @dataHoraPublicacao, @autor, @destaqueHome) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativa", DbType.Int32, entidade.Ativa);

			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);

			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um Release.
		/// </summary>
		/// <param name="entidade">Release contendo os dados a serem atualizados.</param>
		public void Atualizar(Release entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Release SET ");
			sbSQL.Append(" ativa=@ativa, dataHoraPublicacao=@dataHoraPublicacao, autor=@autor, destaqueHome=@destaqueHome ");
			sbSQL.Append(" WHERE releaseId=@releaseId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativa", DbType.Int32, entidade.Ativa);
			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Release da base de dados.
		/// </summary>
		/// <param name="entidade">Release a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Release entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Release ");
			sbSQL.Append("WHERE releaseId=@releaseId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Release.
		/// </summary>
		/// <param name="entidade">Release a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Release</returns>
		public Release Carregar(Release entidade)
		{
			Release entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Release WHERE releaseId=@releaseId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Release.
		/// </summary>
		/// <param name="entidade">ReleaseImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Release.</returns>
		public List<Release> Carregar(ReleaseImagem entidade)
		{
			List<Release> entidadesRetorno = new List<Release>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Release.* FROM Release INNER JOIN ReleaseImagem ON Release.releaseId=ReleaseImagem.releaseId WHERE ReleaseImagem.releaseImagemID=@releaseImagemID");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@releaseImagemID", DbType.Int32, entidade.ReleaseImagemID);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Release entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Release.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Release.</returns>
		public List<Release> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Release> entidadesRetorno = new List<Release>();

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
				sbOrder.Append(" ORDER BY releaseId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Release");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Release WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Release ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Release.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Release ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT Release.* FROM Release ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Release entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega uma Release para exibição do site
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		public Release CarregarToSite(int releaseId)
		{
			Release entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewReleasesSite WHERE releaseId=@releaseId");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, releaseId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega as releases mais vistas para exibição do site
		/// </summary>
		/// <param name="qtdReleases"></param>
		/// <returns></returns>
		public List<Release> CarregarOutros(int qtdReleases, int releaseId)
		{
			List<Release> entidadesRetorno = new List<Release>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdReleases.ToString() + " * FROM dbo.viewReleasesSite WHERE releaseId <> @releaseId ORDER BY dbo.viewReleasesSite.dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@releaseId", DbType.Int32, releaseId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Release entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quantidadeRegistros"></param>
		/// <param name="ordemColunas"></param>
		/// <param name="ordemSentidos"></param>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public List<Release> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Release> entidadesRetorno = new List<Release>();

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
				sbOrder.Append(" ORDER BY releaseId");
			}

			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			sbSQL.Append("* FROM viewReleasesSite ");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
			if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Release entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega as releases relacionadas com tag exibição do site
		/// </summary>
		/// <param name="qtdReleases"></param>
		/// <returns></returns>
		public List<Release> CarregarTagged(int tagId)
		{
			List<Release> entidadesRetorno = new List<Release>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM dbo.viewReleasesTagged WHERE dbo.viewReleasesTagged.tagId = @tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

			IDataReader reader = _db.ExecuteReader(command);


			while (reader.Read())
			{
				Release entidadeRetorno = new Release();
				PopulaRelease(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os Release existentes na base de dados.
		/// </summary>
		public List<Release> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Release na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Release na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Release");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Release baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Release a ser populado(.</param>
		public static void PopulaRelease(IDataReader reader, Release entidade)
		{
			if (reader["ativa"] != DBNull.Value)
				entidade.Ativa = Convert.ToBoolean(reader["ativa"].ToString());

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["autor"] != DBNull.Value)
				entidade.Autor = reader["autor"].ToString();

			if (reader["releaseId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["releaseId"].ToString());
			}

			if (reader["destaqueHome"] != DBNull.Value)
			{
				entidade.DestaqueHome = Convert.ToBoolean(reader["destaqueHome"].ToString());
			}
		}
	}
}