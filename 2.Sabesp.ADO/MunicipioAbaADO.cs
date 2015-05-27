
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
	public class MunicipioAbaADO : ADOSuper, IMunicipioAbaDAL
	{

		/// <summary>
		/// Método que persiste um MunicipioAba.
		/// </summary>
		/// <param name="entidade">MunicipioAba contendo os dados a serem persistidos.</param>	
		public void Inserir(MunicipioAba entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO MunicipioAba ");
            sbSQL.Append(" (municipioId, tituloAba, imagemAba, textoAba, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@municipioId, @tituloAba, @imagemAba, @textoAba, @ativo) ");

			sbSQL.Append(" ; SET @municipioAbaId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@municipioAbaId", DbType.Int32, 8);

			_db.AddInParameter(command, "@municipioId", DbType.Int32, entidade.Municipio.MunicipioId);

			_db.AddInParameter(command, "@tituloAba", DbType.String, entidade.TituloAba);

            _db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			if (entidade.ImagemAba != null)
				_db.AddInParameter(command, "@imagemAba", DbType.String, entidade.ImagemAba);
			else
				_db.AddInParameter(command, "@imagemAba", DbType.String, null);

			if (entidade.TextoAba != null)
				_db.AddInParameter(command, "@textoAba", DbType.String, entidade.TextoAba);
			else
				_db.AddInParameter(command, "@textoAba", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.MunicipioAbaId = Convert.ToInt32(_db.GetParameterValue(command, "@municipioAbaId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um MunicipioAba.
		/// </summary>
		/// <param name="entidade">MunicipioAba contendo os dados a serem atualizados.</param>
		public void Atualizar(MunicipioAba entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE MunicipioAba SET ");            
            sbSQL.Append(" municipioId=@municipioId, tituloAba=@tituloAba, imagemAba=@imagemAba, textoAba=@textoAba, ativo=@ativo ");
			sbSQL.Append(" WHERE municipioAbaId=@municipioAbaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@municipioAbaId", DbType.Int32, entidade.MunicipioAbaId);
			_db.AddInParameter(command, "@municipioId", DbType.Int32, entidade.Municipio.MunicipioId);
			_db.AddInParameter(command, "@tituloAba", DbType.String, entidade.TituloAba);
            _db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			if (entidade.ImagemAba != null)
				_db.AddInParameter(command, "@imagemAba", DbType.String, entidade.ImagemAba);
			else
				_db.AddInParameter(command, "@imagemAba", DbType.String, null);
			if (entidade.TextoAba != null)
				_db.AddInParameter(command, "@textoAba", DbType.String, entidade.TextoAba);
			else
				_db.AddInParameter(command, "@textoAba", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um MunicipioAba da base de dados.
		/// </summary>
		/// <param name="entidade">MunicipioAba a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(MunicipioAba entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM MunicipioAba ");
			sbSQL.Append("WHERE municipioAbaId=@municipioAbaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@municipioAbaId", DbType.Int32, entidade.MunicipioAbaId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um MunicipioAba.
		/// </summary>
		/// <param name="entidade">MunicipioAba a ser carregado (somente o identificador é necessário).</param>
		/// <returns>MunicipioAba</returns>
		public MunicipioAba Carregar(int municipioAbaId)
		{
			MunicipioAba entidade = new MunicipioAba();
			entidade.MunicipioAbaId = municipioAbaId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um MunicipioAba.
		/// </summary>
		/// <param name="entidade">MunicipioAba a ser carregado (somente o identificador é necessário).</param>
		/// <returns>MunicipioAba</returns>
		public MunicipioAba Carregar(MunicipioAba entidade)
		{

			MunicipioAba entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM MunicipioAba WHERE municipioAbaId=@municipioAbaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@municipioAbaId", DbType.Int32, entidade.MunicipioAbaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new MunicipioAba();
				PopulaMunicipioAba(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de MunicipioAba.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos MunicipioAba.</returns>
		public List<MunicipioAba> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<MunicipioAba> entidadesRetorno = new List<MunicipioAba>();

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
				sbOrder.Append(" ORDER BY municipioAbaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM MunicipioAba");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MunicipioAba WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MunicipioAba ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT MunicipioAba.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM MunicipioAba ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT MunicipioAba.* FROM MunicipioAba ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				MunicipioAba entidadeRetorno = new MunicipioAba();
				PopulaMunicipioAba(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os MunicipioAba existentes na base de dados.
		/// </summary>
		public List<MunicipioAba> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de MunicipioAba na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de MunicipioAba na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM MunicipioAba");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um MunicipioAba baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">MunicipioAba a ser populado(.</param>
		public static void PopulaMunicipioAba(IDataReader reader, MunicipioAba entidade)
		{
            if (reader["ativo"] != DBNull.Value)
                entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["municipioAbaId"] != DBNull.Value)
				entidade.MunicipioAbaId = Convert.ToInt32(reader["municipioAbaId"].ToString());

			if (reader["tituloAba"] != DBNull.Value)
				entidade.TituloAba = reader["tituloAba"].ToString();

			if (reader["imagemAba"] != DBNull.Value)
				entidade.ImagemAba = reader["imagemAba"].ToString();

			if (reader["textoAba"] != DBNull.Value)
				entidade.TextoAba = reader["textoAba"].ToString();

			if (reader["municipioId"] != DBNull.Value)
			{
				entidade.Municipio = new Municipio();
				entidade.Municipio.MunicipioId = Convert.ToInt32(reader["municipioId"].ToString());
			}


		}

		/// <summary>
		/// Método que remove um MunicipioAba da base de dados.
		/// </summary>
		/// <param name="entidade">MunicipioAba a ser excluído (somente o identificador é necessário).</param>		
		public void ExcluirRelacionados(Municipio entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM MunicipioAba ");
			sbSQL.Append("WHERE municipioId=@municipioId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@municipioId", DbType.Int32, entidade.MunicipioId);

			_db.ExecuteNonQuery(command);
		}
	}
}