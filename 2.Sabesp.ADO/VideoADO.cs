
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
	public class VideoADO : ADOSuper, IVideoDAL
	{

		/// <summary>
		/// Método que persiste um Video.
		/// </summary>
		/// <param name="entidade">Video contendo os dados a serem persistidos.</param>	
		public void Inserir(Video entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Video ");
			sbSQL.Append(" (videoId, ativo, destaqueHome, destaqueVideos, destaqueFiquePorDentro, dataHoraPublicacao, urlYoutube, autor) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@videoId, @ativo, @destaqueHome, @destaqueVideos, @destaqueFiquePorDentro, @dataHoraPublicacao, @urlYoutube, @autor) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			_db.AddInParameter(command, "@destaqueVideos", DbType.Int32, entidade.DestaqueVideos);

			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);

			if (entidade.UrlYoutube != null)
				_db.AddInParameter(command, "@urlYoutube", DbType.String, entidade.UrlYoutube);
			else
				_db.AddInParameter(command, "@urlYoutube", DbType.String, null);

			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um Video.
		/// </summary>
		/// <param name="entidade">Video contendo os dados a serem atualizados.</param>
		public void Atualizar(Video entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Video SET ");
			sbSQL.Append(" ativo=@ativo, destaqueHome=@destaqueHome, destaqueVideos=@destaqueVideos, destaqueFiquePorDentro=@destaqueFiquePorDentro, dataHoraPublicacao=@dataHoraPublicacao, urlYoutube=@urlYoutube, autor=@autor ");
			sbSQL.Append(" WHERE videoId=@videoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);
			_db.AddInParameter(command, "@destaqueVideos", DbType.Int32, entidade.DestaqueVideos);
			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);
			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			if (entidade.UrlYoutube != null)
				_db.AddInParameter(command, "@urlYoutube", DbType.String, entidade.UrlYoutube);
			else
				_db.AddInParameter(command, "@urlYoutube", DbType.String, null);
			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Video da base de dados.
		/// </summary>
		/// <param name="entidade">Video a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Video entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Video ");
			sbSQL.Append("WHERE videoId=@videoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Conteudo.ConteudoId);


			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um Video.
		/// </summary>
		/// <param name="entidade">Video a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Video</returns>
		public Video Carregar(Video entidade)
		{

			Video entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Video WHERE videoId=@videoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Video();
				PopulaVideo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que carrega um Vídeo para exibição do site
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		public Video CarregarToSite(int videoId)
		{
			Video entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM viewVideosSite WHERE videoId=@videoId");


			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@videoId", DbType.Int32, videoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Video();
				PopulaVideo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}
        /// <summary>
        /// Método que carrega as videos relacionadas com tag exibição do site
        /// </summary>
        /// <param name="qtdVideos"></param>
        /// <returns></returns>
        public List<Video> CarregarTagged(int tagId)
        {
            List<Video> entidadesRetorno = new List<Video>(); ;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM dbo.viewVideosTagged WHERE dbo.viewVideosTagged.tagId = @tagId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

            IDataReader reader = _db.ExecuteReader(command);


            while (reader.Read())
            {
                Video entidadeRetorno = new Video();
                PopulaVideo(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }
        /// <summary>
        /// Método que carrega as videos relacionadas com tag exibição do site
        /// </summary>
        /// <param name="qtdVideos"></param>
        /// <returns></returns>
        public List<Video> CarregarTagged(int qtdRegistros, string palavra)
        {
            List<Video> entidadesRetorno = new List<Video>(); ;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT TOP " + qtdRegistros + " * FROM dbo.viewVideosTagged WHERE dbo.viewVideosTagged.palavra = @palavra");
            sbSQL.Append(" ORDER BY dbo.viewVideosTagged.dataHoraPublicacao DESC");
            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@palavra", DbType.String, palavra);

            IDataReader reader = _db.ExecuteReader(command);


            while (reader.Read())
            {
                Video entidadeRetorno = new Video();
                PopulaVideo(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }
        /// <summary>
        /// Método que carrega as videos mais vistas para exibição do site
        /// </summary>
        /// <param name="qtdVideos"></param>
        /// <returns></returns>
        public List<Video> CarregarMaisVistos(int qtdVideos)
        {
            List<Video> entidadesRetorno = new List<Video>(); ;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT TOP " + qtdVideos.ToString() + " * FROM dbo.viewVideosMaisVistos ORDER BY dbo.viewVideosMaisVistos.hits DESC");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            IDataReader reader = _db.ExecuteReader(command);


            while (reader.Read())
            {
                Video entidadeRetorno = new Video();
                PopulaVideo(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }

		/// <summary>
		/// Método que retorna uma coleção de Video.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Video.</returns>
		public List<Video> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{

			List<Video> entidadesRetorno = new List<Video>();

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
				sbOrder.Append(" ORDER BY videoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Video");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Video WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Video ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Video.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Video ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Video.* FROM Video ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Video entidadeRetorno = new Video();
				PopulaVideo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Video existentes na base de dados.
		/// </summary>
		public List<Video> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		public List<Video> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Video> entidadesRetorno = new List<Video>();

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
				sbOrder.Append(" ORDER BY videoId");
			}


			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			sbSQL.Append("* FROM viewVideosSite ");
			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
			if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Video entidadeRetorno = new Video();
				PopulaVideo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna o total de Video na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Video na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Video");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Video baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Video a ser populado(.</param>
		public static void PopulaVideo(IDataReader reader, Video entidade)
		{
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["destaqueHome"] != DBNull.Value)
				entidade.DestaqueHome = Convert.ToBoolean(reader["destaqueHome"].ToString());

			if (reader["destaqueVideos"] != DBNull.Value)
				entidade.DestaqueVideos = Convert.ToBoolean(reader["destaqueVideos"].ToString());

			if (reader["destaqueFiquePorDentro"] != DBNull.Value)
				entidade.DestaqueFiquePorDentro = Convert.ToBoolean(reader["destaqueFiquePorDentro"].ToString());

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["urlYoutube"] != DBNull.Value)
				entidade.UrlYoutube = reader["urlYoutube"].ToString();

			if (reader["autor"] != DBNull.Value)
				entidade.Autor = reader["autor"].ToString();

			if (reader["videoId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["videoId"].ToString());
			}


		}

		public List<Video> CarregarPorRegiao(int qtdVideos, int regiaoId)
		{
			List<Video> entidadeRetorno = new List<Video>();
			Video entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ");

			if (qtdVideos > 0)
			{
				sbSQL.Append(String.Concat("TOP ", qtdVideos, " "));
			}

			sbSQL.Append("viewVideosSite.* FROM viewVideosSite ");
			sbSQL.Append("INNER JOIN ConteudoRegiao ON viewVideosSite.videoId = dbo.ConteudoRegiao.conteudoId ");
			sbSQL.Append("WHERE (ConteudoRegiao.regiaoId = @regiaoId)");
			sbSQL.Append("ORDER BY dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Video();
				PopulaVideo(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}

	}
}
