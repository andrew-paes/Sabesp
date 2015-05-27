
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
	public class ControleIdiomaDadoADO : ADOSuper, IControleIdiomaDadoDAL
	{

		/// <summary>
		/// Método que persiste um ControleIdiomaDado.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado contendo os dados a serem persistidos.</param>	
		public void Inserir(ControleIdiomaDado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ControleIdiomaDado ");
			sbSQL.Append(" (controleIdiomaId, subtitulo, link, target, imagemNome, imagemTexto, textoChamada, arquivoNome, arquivoTamanho, arquivoExtensao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@controleIdiomaId, @subtitulo, @link, @target, @imagemNome, @imagemTexto, @textoChamada, @arquivoNome, @arquivoTamanho, @arquivoExtensao) ");

			sbSQL.Append(" ; SET @controleIdiomaDadoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@controleIdiomaDadoId", DbType.Int32, 8);

			if (entidade.ControleIdioma != null)
				_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdioma.ControleIdiomaId);
			else
				_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, null);

			if (entidade.Subtitulo != null)
				_db.AddInParameter(command, "@subtitulo", DbType.String, entidade.Subtitulo);
			else
				_db.AddInParameter(command, "@subtitulo", DbType.String, null);

			if (entidade.Link != null)
				_db.AddInParameter(command, "@link", DbType.String, entidade.Link);
			else
				_db.AddInParameter(command, "@link", DbType.String, null);

			if (entidade.Target != null)
				_db.AddInParameter(command, "@target", DbType.String, entidade.Target);
			else
				_db.AddInParameter(command, "@target", DbType.String, null);

			if (entidade.ImagemNome != null)
				_db.AddInParameter(command, "@imagemNome", DbType.String, entidade.ImagemNome);
			else
				_db.AddInParameter(command, "@imagemNome", DbType.String, null);

			if (entidade.ImagemTexto != null)
				_db.AddInParameter(command, "@imagemTexto", DbType.String, entidade.ImagemTexto);
			else
				_db.AddInParameter(command, "@imagemTexto", DbType.String, null);

			if (entidade.TextoChamada != null)
				_db.AddInParameter(command, "@textoChamada", DbType.String, entidade.TextoChamada);
			else
				_db.AddInParameter(command, "@textoChamada", DbType.String, null);

			if (entidade.ArquivoNome != null)
				_db.AddInParameter(command, "@arquivoNome", DbType.String, entidade.ArquivoNome);
			else
				_db.AddInParameter(command, "@arquivoNome", DbType.String, null);

			if (entidade.ArquivoTamanho != null)
				_db.AddInParameter(command, "@arquivoTamanho", DbType.Int32, entidade.ArquivoTamanho);
			else
				_db.AddInParameter(command, "@arquivoTamanho", DbType.Int32, null);

			if (entidade.ArquivoExtensao != null)
				_db.AddInParameter(command, "@arquivoExtensao", DbType.String, entidade.ArquivoExtensao);
			else
				_db.AddInParameter(command, "@arquivoExtensao", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ControleIdiomaDadoId = Convert.ToInt32(_db.GetParameterValue(command, "@controleIdiomaDadoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um ControleIdiomaDado.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado contendo os dados a serem atualizados.</param>
		public void Atualizar(ControleIdiomaDado entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ControleIdiomaDado SET ");
			sbSQL.Append(" controleIdiomaId=@controleIdiomaId, subtitulo=@subtitulo, link=@link, target=@target, imagemNome=@imagemNome, imagemTexto=@imagemTexto, textoChamada=@textoChamada, arquivoNome=@arquivoNome, arquivoTamanho=@arquivoTamanho, arquivoExtensao=@arquivoExtensao ");
			sbSQL.Append(" WHERE controleIdiomaDadoId=@controleIdiomaDadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDadoId);
			if (entidade.ControleIdioma != null)
				_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdioma.ControleIdiomaId);
			else
				_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, null);
			if (entidade.Subtitulo != null)
				_db.AddInParameter(command, "@subtitulo", DbType.String, entidade.Subtitulo);
			else
				_db.AddInParameter(command, "@subtitulo", DbType.String, null);
			if (entidade.Link != null)
				_db.AddInParameter(command, "@link", DbType.String, entidade.Link);
			else
				_db.AddInParameter(command, "@link", DbType.String, null);
			if (entidade.Target != null)
				_db.AddInParameter(command, "@target", DbType.String, entidade.Target);
			else
				_db.AddInParameter(command, "@target", DbType.String, null);
			if (entidade.ImagemNome != null)
				_db.AddInParameter(command, "@imagemNome", DbType.String, entidade.ImagemNome);
			else
				_db.AddInParameter(command, "@imagemNome", DbType.String, null);
			if (entidade.ImagemTexto != null)
				_db.AddInParameter(command, "@imagemTexto", DbType.String, entidade.ImagemTexto);
			else
				_db.AddInParameter(command, "@imagemTexto", DbType.String, null);
			if (entidade.TextoChamada != null)
				_db.AddInParameter(command, "@textoChamada", DbType.String, entidade.TextoChamada);
			else
				_db.AddInParameter(command, "@textoChamada", DbType.String, null);
			if (entidade.ArquivoNome != null)
				_db.AddInParameter(command, "@arquivoNome", DbType.String, entidade.ArquivoNome);
			else
				_db.AddInParameter(command, "@arquivoNome", DbType.String, null);
			if (entidade.ArquivoTamanho != null)
				_db.AddInParameter(command, "@arquivoTamanho", DbType.Int32, entidade.ArquivoTamanho);
			else
				_db.AddInParameter(command, "@arquivoTamanho", DbType.Int32, null);
			if (entidade.ArquivoExtensao != null)
				_db.AddInParameter(command, "@arquivoExtensao", DbType.String, entidade.ArquivoExtensao);
			else
				_db.AddInParameter(command, "@arquivoExtensao", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um ControleIdiomaDado da base de dados.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ControleIdiomaDado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleIdiomaDado ");
			sbSQL.Append("WHERE controleIdiomaDadoId=@controleIdiomaDadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDadoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um ControleIdiomaDado.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdiomaDado</returns>
		public ControleIdiomaDado Carregar(int controleIdiomaDadoId)
		{
			ControleIdiomaDado entidade = new ControleIdiomaDado();
			entidade.ControleIdiomaDadoId = controleIdiomaDadoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um ControleIdiomaDado.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDado a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleIdiomaDado</returns>
		public ControleIdiomaDado Carregar(ControleIdiomaDado entidade)
		{

			ControleIdiomaDado entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ControleIdiomaDado WHERE controleIdiomaDadoId=@controleIdiomaDadoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaDadoId", DbType.Int32, entidade.ControleIdiomaDadoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ControleIdiomaDado();
				PopulaControleIdiomaDado(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de ControleIdiomaDado.
		/// </summary>
		/// <param name="entidade">ControleIdiomaDadoArquivo relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de ControleIdiomaDado.</returns>
		public List<ControleIdiomaDado> Carregar(ControleIdiomaDadoArquivo entidade)
		{
			List<ControleIdiomaDado> entidadesRetorno = new List<ControleIdiomaDado>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ControleIdiomaDado.* FROM ControleIdiomaDado INNER JOIN ControleIdiomaDadoArquivo ON ControleIdiomaDado.controleIdiomaDadoId=ControleIdiomaDadoArquivo.controleIdiomaDadoId WHERE ControleIdiomaDadoArquivo.controleIdiomaDadoArquivoId=@controleIdiomaDadoArquivoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleIdiomaDadoArquivoId", DbType.Int32, entidade.ControleIdiomaDadoArquivoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleIdiomaDado entidadeRetorno = new ControleIdiomaDado();
				PopulaControleIdiomaDado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de ControleIdiomaDado.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ControleIdiomaDado.</returns>
		public List<ControleIdiomaDado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<ControleIdiomaDado> entidadesRetorno = new List<ControleIdiomaDado>();

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
				sbOrder.Append(" ORDER BY controleIdiomaDadoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ControleIdiomaDado");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdiomaDado WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleIdiomaDado ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ControleIdiomaDado.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ControleIdiomaDado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT ControleIdiomaDado.* FROM ControleIdiomaDado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ControleIdiomaDado entidadeRetorno = new ControleIdiomaDado();
				PopulaControleIdiomaDado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os ControleIdiomaDado existentes na base de dados.
		/// </summary>
		public List<ControleIdiomaDado> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdiomaDado na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ControleIdiomaDado na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ControleIdiomaDado");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ControleIdiomaDado baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ControleIdiomaDado a ser populado(.</param>
		public static void PopulaControleIdiomaDado(IDataReader reader, ControleIdiomaDado entidade)
		{
			if (reader["controleIdiomaDadoId"] != DBNull.Value)
				entidade.ControleIdiomaDadoId = Convert.ToInt32(reader["controleIdiomaDadoId"].ToString());

			if (reader["subtitulo"] != DBNull.Value)
				entidade.Subtitulo = reader["subtitulo"].ToString();

			if (reader["link"] != DBNull.Value)
				entidade.Link = reader["link"].ToString();

			if (reader["target"] != DBNull.Value)
				entidade.Target = reader["target"].ToString();

			if (reader["imagemNome"] != DBNull.Value)
				entidade.ImagemNome = reader["imagemNome"].ToString();

			if (reader["imagemTexto"] != DBNull.Value)
				entidade.ImagemTexto = reader["imagemTexto"].ToString();

			if (reader["textoChamada"] != DBNull.Value)
				entidade.TextoChamada = reader["textoChamada"].ToString();

			if (reader["arquivoNome"] != DBNull.Value)
				entidade.ArquivoNome = reader["arquivoNome"].ToString();

			if (reader["arquivoTamanho"] != DBNull.Value)
				entidade.ArquivoTamanho = Convert.ToInt32(reader["arquivoTamanho"].ToString());

			if (reader["arquivoExtensao"] != DBNull.Value)
				entidade.ArquivoExtensao = reader["arquivoExtensao"].ToString();

			if (reader["controleIdiomaId"] != DBNull.Value)
			{
				entidade.ControleIdioma = new ControleIdioma();
				entidade.ControleIdioma.ControleIdiomaId = Convert.ToInt32(reader["controleIdiomaId"].ToString());
			}
		}

		/// <summary>
		/// Método que remove uma lista ControleIdiomaDado da base de dados.
		/// </summary>
		/// <param name="entidade">ControleIdioma (somente o identificador é necessário).</param>
		public void ExcluirRelacionados(ControleIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleIdiomaDado ");
			sbSQL.Append("WHERE controleIdiomaId=@controleIdiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@controleIdiomaId", DbType.Int32, entidade.ControleIdiomaId);

			_db.ExecuteNonQuery(command);
		}
	}
}