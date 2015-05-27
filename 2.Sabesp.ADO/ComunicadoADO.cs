
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
	public class ComunicadoADO : ADOSuper, IComunicadoDAL
	{

		/// <summary>
		/// Método que persiste um Comunicado.
		/// </summary>
		/// <param name="entidade">Comunicado contendo os dados a serem persistidos.</param>	
		public void Inserir(Comunicado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Comunicado ");
			sbSQL.Append(" (comunicadoId, ativo, destaqueHome, destaqueFiquePorDentro, dataHoraPublicacao, dataExibicaoInicio, dataExibicaoFim) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@comunicadoId, @ativo, @destaqueHome, @destaqueFiquePorDentro, @dataHoraPublicacao, @dataExibicaoInicio, @dataExibicaoFim) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);

			if (entidade.DataExibicaoInicio != null && entidade.DataExibicaoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, entidade.DataExibicaoInicio);
			else
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, null);

			if (entidade.DataExibicaoFim != null && entidade.DataExibicaoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, entidade.DataExibicaoFim);
			else
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Comunicado.
		/// </summary>
		/// <param name="entidade">Comunicado contendo os dados a serem atualizados.</param>
		public void Atualizar(Comunicado entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Comunicado SET ");
			sbSQL.Append(" ativo=@ativo, destaqueHome=@destaqueHome, destaqueFiquePorDentro=@destaqueFiquePorDentro, dataHoraPublicacao=@dataHoraPublicacao, dataExibicaoInicio=@dataExibicaoInicio, dataExibicaoFim=@dataExibicaoFim ");
			sbSQL.Append(" WHERE comunicadoId=@comunicadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);
			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);
			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			if (entidade.DataExibicaoInicio != null && entidade.DataExibicaoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, entidade.DataExibicaoInicio);
			else
				_db.AddInParameter(command, "@dataExibicaoInicio", DbType.DateTime, null);
			if (entidade.DataExibicaoFim != null && entidade.DataExibicaoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, entidade.DataExibicaoFim);
			else
				_db.AddInParameter(command, "@dataExibicaoFim", DbType.DateTime, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Comunicado da base de dados.
		/// </summary>
		/// <param name="entidade">Comunicado a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Comunicado entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Comunicado ");
			sbSQL.Append("WHERE comunicadoId=@comunicadoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Conteudo.ConteudoId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um Comunicado.
		/// </summary>
		/// <param name="entidade">Comunicado a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Comunicado</returns>
		public Comunicado Carregar(Comunicado entidade)
		{

			Comunicado entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Comunicado WHERE comunicadoId=@comunicadoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Comunicado();
				PopulaComunicado(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega um Comunicado para exibição do site
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		public Comunicado CarregarToSite(int comunicadoId)
		{
			Comunicado entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewComunicadosSite WHERE comunicadoId=@comunicadoId");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@comunicadoId", DbType.Int32, comunicadoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Comunicado();
				PopulaComunicado(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

        /// <summary>
        /// Método que carrega as comunicados relacionadas com tag exibição do site
        /// </summary>
        /// <param name="qtdComunicados"></param>
        /// <returns></returns>
        public List<Comunicado> CarregarTagged(int tagId)
        {
            List<Comunicado> entidadesRetorno = new List<Comunicado>(); ;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM dbo.viewComunicadosTagged WHERE dbo.viewComunicadosTagged.tagId = @tagId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

            IDataReader reader = _db.ExecuteReader(command);


            while (reader.Read())
            {
                Comunicado entidadeRetorno = new Comunicado();
                PopulaComunicado(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }
		public List<Comunicado> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Comunicado> entidadesRetorno = new List<Comunicado>();

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
				sbOrder.Append(" ORDER BY comunicadoId");
			}


			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			sbSQL.Append("* FROM viewComunicadosSite ");
			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
			if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Comunicado entidadeRetorno = new Comunicado();
				PopulaComunicado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Comunicado.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Comunicado.</returns>
		public List<Comunicado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Comunicado> entidadesRetorno = new List<Comunicado>();

			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;

			// Monta o "OrderBy"
			if (!String.IsNullOrEmpty(ordemColunas))
			{
				string[] arrayordemColunas = ordemColunas.Split(",".ToCharArray());
				string[] arrayOrdemSentidos = ordemSentidos.Split(",".ToCharArray());

				for (int i = 0; i < arrayordemColunas.Length; i++)
				{
					if (sbOrder.Length > 0) { sbOrder.Append(", "); }
					sbOrder.Append(arrayordemColunas[i] + " " + arrayOrdemSentidos[i]);
				}
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
			}
			else
			{
				sbOrder.Append(" ORDER BY comunicadoId ");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Comunicado");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Comunicado WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Comunicado ORDER BY " + orderBy + ")");				
				//}	

				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Comunicado.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Comunicado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				{
					sbSQL.Append("WHERE" + filtro.GetWhereString() + " ");

				}
			}
			else
			{
				sbSQL.Append("SELECT Comunicado.* FROM Comunicado ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}


			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Comunicado entidadeRetorno = new Comunicado();
				PopulaComunicado(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Comunicado existentes na base de dados.
		/// </summary>
		public List<Comunicado> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Comunicado na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Comunicado na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Comunicado");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Comunicado baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Comunicado a ser populado(.</param>
		public static void PopulaComunicado(IDataReader reader, Comunicado entidade)
		{
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["destaqueHome"] != DBNull.Value)
				entidade.DestaqueHome = Convert.ToBoolean(reader["destaqueHome"].ToString());

			if (reader["destaqueFiquePorDentro"] != DBNull.Value)
				entidade.DestaqueFiquePorDentro = Convert.ToBoolean(reader["destaqueFiquePorDentro"].ToString());

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["dataExibicaoInicio"] != DBNull.Value)
				entidade.DataExibicaoInicio = Convert.ToDateTime(reader["dataExibicaoInicio"].ToString());

			if (reader["dataExibicaoFim"] != DBNull.Value)
				entidade.DataExibicaoFim = Convert.ToDateTime(reader["dataExibicaoFim"].ToString());

			if (reader["comunicadoId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["comunicadoId"].ToString());
			}


		}

		public List<Comunicado> CarregarPorRegiao(int qtdComunicados, int regiaoId)
		{
			List<Comunicado> entidadeRetorno = new List<Comunicado>();
			Comunicado entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ");

			if (qtdComunicados > 0)
			{
				sbSQL.Append(String.Concat("TOP ", qtdComunicados, " "));
			}

			sbSQL.Append("viewComunicadosSite.* FROM viewComunicadosSite ");
			sbSQL.Append("INNER JOIN ConteudoRegiao ON viewComunicadosSite.comunicadoId = dbo.ConteudoRegiao.conteudoId ");
			sbSQL.Append("WHERE (ConteudoRegiao.regiaoId = @regiaoId)");
			sbSQL.Append("ORDER BY dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Comunicado();
				PopulaComunicado(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}

	}
}
