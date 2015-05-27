
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
	public class SecaoIdiomaADO : ADOSuper, ISecaoIdiomaDAL
	{

		/// <summary>
		/// Método que persiste um SecaoIdioma.
		/// </summary>
		/// <param name="entidade">SecaoIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(SecaoIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO SecaoIdioma ");
			sbSQL.Append(" (idiomaId, secaoId, titulo, tituloMenu, ativo, palavraChave, texto, tituloArquivos, textoArquivos) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@idiomaId, @secaoId, @titulo, @tituloMenu, @ativo, @palavraChave, @texto, @tituloArquivos, @textoArquivos) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.Secao.SecaoId);

			if (entidade.Titulo != null)
				_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);
			else
				_db.AddInParameter(command, "@titulo", DbType.String, null);

			if (entidade.TituloMenu != null)
				_db.AddInParameter(command, "@tituloMenu", DbType.String, entidade.TituloMenu);
			else
				_db.AddInParameter(command, "@tituloMenu", DbType.String, null);

			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);

			if (entidade.PalavraChave != null)
				_db.AddInParameter(command, "@palavraChave", DbType.String, entidade.PalavraChave);
			else
				_db.AddInParameter(command, "@palavraChave", DbType.String, null);

			if (entidade.Texto != null)
				_db.AddInParameter(command, "@texto", DbType.String, entidade.Texto);
			else
				_db.AddInParameter(command, "@texto", DbType.String, null);

			if (entidade.TituloArquivos != null)
				_db.AddInParameter(command, "@tituloArquivos", DbType.String, entidade.TituloArquivos);
			else
				_db.AddInParameter(command, "@tituloArquivos", DbType.String, null);

			if (entidade.TextoArquivos != null)
				_db.AddInParameter(command, "@textoArquivos", DbType.String, entidade.TextoArquivos);
			else
				_db.AddInParameter(command, "@textoArquivos", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um SecaoIdioma.
		/// </summary>
		/// <param name="entidade">SecaoIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(SecaoIdioma entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE SecaoIdioma SET ");
			sbSQL.Append(" idiomaId=@idiomaId, secaoId=@secaoId, titulo=@titulo, tituloMenu=@tituloMenu, ativo=@ativo, palavraChave=@palavraChave, texto=@texto, tituloArquivos=@tituloArquivos, textoArquivos=@textoArquivos ");
			sbSQL.Append(" WHERE  ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.Secao.SecaoId);
			if (entidade.Titulo != null)
				_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);
			else
				_db.AddInParameter(command, "@titulo", DbType.String, null);
			if (entidade.TituloMenu != null)
				_db.AddInParameter(command, "@tituloMenu", DbType.String, entidade.TituloMenu);
			else
				_db.AddInParameter(command, "@tituloMenu", DbType.String, null);
			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);
			if (entidade.PalavraChave != null)
				_db.AddInParameter(command, "@palavraChave", DbType.String, entidade.PalavraChave);
			else
				_db.AddInParameter(command, "@palavraChave", DbType.String, null);
			if (entidade.Texto != null)
				_db.AddInParameter(command, "@texto", DbType.String, entidade.Texto);
			else
				_db.AddInParameter(command, "@texto", DbType.String, null);
			if (entidade.TituloArquivos != null)
				_db.AddInParameter(command, "@tituloArquivos", DbType.String, entidade.TituloArquivos);
			else
				_db.AddInParameter(command, "@tituloArquivos", DbType.String, null);
			if (entidade.TextoArquivos != null)
				_db.AddInParameter(command, "@textoArquivos", DbType.String, entidade.TextoArquivos);
			else
				_db.AddInParameter(command, "@textoArquivos", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um SecaoIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">SecaoIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(SecaoIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM SecaoIdioma ");
			sbSQL.Append("WHERE  ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());



			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um SecaoIdioma.
		/// </summary>
		/// <param name="entidade">SecaoIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>SecaoIdioma</returns>
		public SecaoIdioma Carregar(SecaoIdioma entidade)
		{

			SecaoIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM SecaoIdioma WHERE secaoId=@secaoId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.Secao != null ? entidade.Secao.SecaoId : 0);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new SecaoIdioma();
				PopulaSecaoIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de SecaoIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos SecaoIdioma.</returns>
		public List<SecaoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<SecaoIdioma> entidadesRetorno = new List<SecaoIdioma>();

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
				sbOrder.Append(" ORDER BY ");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM SecaoIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM SecaoIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM SecaoIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT SecaoIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM SecaoIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT SecaoIdioma.* FROM SecaoIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				SecaoIdioma entidadeRetorno = new SecaoIdioma();
				PopulaSecaoIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os SecaoIdioma existentes na base de dados.
		/// </summary>
		public List<SecaoIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de SecaoIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de SecaoIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM SecaoIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um SecaoIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">SecaoIdioma a ser populado(.</param>
		public static void PopulaSecaoIdioma(IDataReader reader, SecaoIdioma entidade)
		{
			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}

			if (reader["secaoId"] != DBNull.Value)
			{
				entidade.Secao = new Secao();
				entidade.Secao.SecaoId = Convert.ToInt32(reader["secaoId"].ToString());
			}

			if (reader["titulo"] != DBNull.Value)
				entidade.Titulo = reader["titulo"].ToString();

			if (reader["tituloMenu"] != DBNull.Value)
				entidade.TituloMenu = reader["tituloMenu"].ToString();

			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["palavraChave"] != DBNull.Value)
				entidade.PalavraChave = reader["palavraChave"].ToString();

			if (reader["texto"] != DBNull.Value)
				entidade.Texto = reader["texto"].ToString();

			if (reader["tituloArquivos"] != DBNull.Value)
				entidade.TituloArquivos = reader["tituloArquivos"].ToString();

			if (reader["textoArquivos"] != DBNull.Value)
				entidade.TextoArquivos = reader["textoArquivos"].ToString();


		}

	}
}
