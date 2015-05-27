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
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class PodcastADO : ADOSuper, IPodcastDAL
	{
		/// <summary>
		/// Método que persiste um Podcast.
		/// </summary>
		/// <param name="entidade">Podcast contendo os dados a serem persistidos.</param>	
		public void Inserir(Podcast entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Podcast ");
			sbSQL.Append(" (podcastId, ativo, dataHoraPublicacao, destaqueHome, destaqueFiquePorDentro, destaquePodcasts, autor, bancoAudio, podcastCategoriaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@podcastId, @ativo, @dataHoraPublicacao, @destaqueHome, @destaqueFiquePorDentro, @destaquePodcasts, @autor, @bancoAudio, @podcastCategoriaId) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);

			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);

			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			_db.AddInParameter(command, "@destaquePodcasts", DbType.Int32, entidade.DestaquePodcasts);

			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			_db.AddInParameter(command, "@bancoAudio", DbType.Int32, entidade.BancoAudio);

			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um Podcast.
		/// </summary>
		/// <param name="entidade">Podcast contendo os dados a serem atualizados.</param>
		public void Atualizar(Podcast entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Podcast SET ");
			sbSQL.Append(" ativo=@ativo, dataHoraPublicacao=@dataHoraPublicacao, destaqueHome=@destaqueHome, destaqueFiquePorDentro=@destaqueFiquePorDentro, destaquePodcasts=@destaquePodcasts, autor=@autor, bancoAudio=@bancoAudio, podcastCategoriaId=@podcastCategoriaId ");
			sbSQL.Append(" WHERE podcastId=@podcastId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			_db.AddInParameter(command, "@destaqueHome", DbType.Int32, entidade.DestaqueHome);
			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);
			_db.AddInParameter(command, "@destaquePodcasts", DbType.Int32, entidade.DestaquePodcasts);

			if (entidade.Autor != null)
				_db.AddInParameter(command, "@autor", DbType.String, entidade.Autor);
			else
				_db.AddInParameter(command, "@autor", DbType.String, null);

			_db.AddInParameter(command, "@bancoAudio", DbType.Int32, entidade.BancoAudio);
			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Podcast da base de dados.
		/// </summary>
		/// <param name="entidade">Podcast a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Podcast entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Podcast ");
			sbSQL.Append("WHERE podcastId=@podcastId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Podcast.
		/// </summary>
		/// <param name="entidade">Podcast a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Podcast</returns>
		public Podcast Carregar(Podcast entidade)
		{
			Podcast entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Podcast WHERE podcastId=@podcastId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Podcast.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Podcast.</returns>
		public List<Podcast> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<Podcast> entidadesRetorno = new List<Podcast>();

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
				sbOrder.Append(" ORDER BY podcastId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Podcast");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Podcast WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Podcast ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Podcast.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Podcast ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT Podcast.* FROM Podcast ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Retorna todos os podcasts para o site que estao aprovados para publicacao
		/// </summary>
		/// <param name="quantidadeRegistros"></param>
		/// <param name="ordemColunas"></param>
		/// <param name="ordemSentidos"></param>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public List<Podcast> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			//variavel utilizada para retorna a lista de podcasts
			List<Podcast> entidadesRetorno = new List<Podcast>();

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
					if (sbOrder.Length > 0)
					{
						sbOrder.Append(", ");
					}
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				}
				if (sbOrder.Length > 0)
				{
					sbOrder.Insert(0, " ORDER BY ");
				}
			}
			else
			{
				sbOrder.Append(" ORDER BY podcastId");
			}

			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}

			if (!String.IsNullOrEmpty(((PodcastFH)filtro).BancoAudio) && ((PodcastFH)filtro).BancoAudio.Equals("1"))
			{
				// Acessa a view de podcasts
				sbSQL.Append("* FROM viewBancoAudioSite ");
			}
			else
			{
				// Acessa a view de podcasts
				sbSQL.Append("* FROM viewPodcastsSite ");
			}

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
			{
				sbSQL.Append("WHERE" + filtro.GetWhereString() + " ");
			}

			if (sbOrder.Length > 0)
			{
				sbSQL.Append(sbOrder.ToString());
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			// Adiciona na lista
			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tagId"></param>
		/// <returns></returns>
		public List<Podcast> CarregarTagged(int tagId)
		{
			return this.CarregarTagged(tagId, false);
		}

		/// <summary>
		/// Método que carrega as podcasts relacionadas com tag exibição do site
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <returns></returns>
		public List<Podcast> CarregarTagged(int tagId, bool bancoAudio)
		{
			List<Podcast> entidadesRetorno = new List<Podcast>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ");

			if (bancoAudio)
			{
				sbSQL.Append(" dbo.viewBancoAudioTagged ");
			}
			else
			{
				sbSQL.Append(" dbo.viewPodcastsTagged ");
			}

			sbSQL.Append(" WHERE tagId = @tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="podcastId"></param>
		/// <returns></returns>
		public Podcast CarregarToSite(int podcastId)
		{
			return this.CarregarToSite(podcastId, false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="podcastId">Identificador do envento a ser carregado</param>
		/// <returns></returns>
		public Podcast CarregarToSite(int podcastId, bool bancoAudio)
		{
			Podcast entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();
			//Acessa a view que contem os conteudos publicados
			sbSQL.Append("SELECT * FROM ");

			if (bancoAudio)
			{
				sbSQL.Append("[viewBancoAudioSite] ");
			}
			else
			{
				sbSQL.Append("[viewPodcastsSite] ");
			}

			sbSQL.Append(" WHERE podcastId=@podcastId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@podcastId", DbType.Int32, podcastId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <returns></returns>
		public List<Podcast> CarregarMaisRecentes(int qtdPodcasts)
		{
			return this.CarregarMaisRecentes(qtdPodcasts, false);
		}

		/// <summary>
		/// Método que carrega ultimas Podcasts para exibição do site
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <param name="origemHome">indica a origem para restringir os destaques, caso a origem for home, restringe destaqueHome, senão restringe destaqueFiquePorDentro</param>
		/// <returns></returns>
		public List<Podcast> CarregarMaisRecentes(int qtdPodcasts, bool bancoAudio)
		{
			List<Podcast> entidadesRetorno = new List<Podcast>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP ");
			sbSQL.Append(qtdPodcasts.ToString());
			sbSQL.Append(" * FROM ");

			if (bancoAudio)
			{
				sbSQL.Append("[viewBancoAudioSite] ");
			}
			else
			{
				sbSQL.Append("[viewPodcastsSite] ");
			}

			sbSQL.Append(" ORDER BY  dataHoraPublicacao DESC");
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		public List<Podcast> CarregarMaisRecentes(int qtdPodcasts, Podcast entidade)
		{
			List<Podcast> entidadesRetorno = new List<Podcast>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP ");
			sbSQL.Append(qtdPodcasts.ToString());
			sbSQL.Append(" * FROM ");
			sbSQL.Append("[viewPodcastsSite] ");
			sbSQL.Append("WHERE podcastCategoriaId = @podcastCategoriaId ");

			if(entidade.DestaqueHome)
				sbSQL.Append("AND destaqueHome = 1 ");
			
			if (entidade.DestaqueFiquePorDentro)
				sbSQL.Append("AND destaqueFiquePorDentro = 1 ");

			if (entidade.DestaquePodcasts)
				sbSQL.Append("AND destaquePodcasts = 1 ");

			sbSQL.Append("ORDER BY  dataHoraPublicacao DESC ");
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@podcastCategoriaId", DbType.Int32, entidade.PodcastCategoria.PodcastCategoriaId);
			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <returns></returns>
		public List<Podcast> CarregarMaisVistos(int qtdPodcasts)
		{
			return this.CarregarMaisVistos(qtdPodcasts, false);
		}

		/// <summary>
		/// Método que carrega as podcasts mais vistas para exibição do site
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <returns></returns>
		public List<Podcast> CarregarMaisVistos(int qtdPodcasts, bool bancoAudio)
		{
			List<Podcast> entidadesRetorno = new List<Podcast>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP ");
			sbSQL.Append(qtdPodcasts.ToString());
			sbSQL.Append(" * FROM ");

			if (bancoAudio)
			{
				sbSQL.Append("[viewBancoAudioMaisVistos] ");
			}
			else
			{
				sbSQL.Append("[viewPodcastsMaisVistos] ");
			}

			sbSQL.Append(" ORDER BY hits DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Podcast entidadeRetorno = new Podcast();
				PopulaPodcast(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os Podcast existentes na base de dados.
		/// </summary>
		public List<Podcast> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, new PodcastFH() { BancoAudio = "0" });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bancoAudio"></param>
		/// <returns></returns>
		public List<Podcast> CarregarTodos(bool bancoAudio)
		{
			string strBancoAudio = bancoAudio ? "1" : "0";
			return CarregarTodos(0, 0, null, null, new PodcastFH() { BancoAudio = strBancoAudio });
		}

		/// <summary>
		/// Método que retorna o total de Podcast na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Podcast na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Podcast");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Podcast baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Podcast a ser populado(.</param>
		public static void PopulaPodcast(IDataReader reader, Podcast entidade)
		{
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["destaqueHome"] != DBNull.Value)
				entidade.DestaqueHome = Convert.ToBoolean(reader["destaqueHome"].ToString());

			if (reader["destaqueFiquePorDentro"] != DBNull.Value)
				entidade.DestaqueFiquePorDentro = Convert.ToBoolean(reader["destaqueFiquePorDentro"].ToString());

			if (reader["destaquePodcasts"] != DBNull.Value)
				entidade.DestaquePodcasts = Convert.ToBoolean(reader["destaquePodcasts"].ToString());

			if (reader["autor"] != DBNull.Value)
				entidade.Autor = reader["autor"].ToString();

			if (reader["bancoAudio"] != DBNull.Value)
				entidade.BancoAudio = Convert.ToBoolean(reader["bancoAudio"].ToString());

			if (reader["podcastId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["podcastId"].ToString());
			}

			if (reader["podcastCategoriaId"] != DBNull.Value)
			{
				entidade.PodcastCategoria = new PodcastCategoria();
				entidade.PodcastCategoria.PodcastCategoriaId = Convert.ToInt32(reader["podcastCategoriaId"].ToString());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <param name="regiaoId"></param>
		/// <returns></returns>
		public List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId)
		{
			return this.CarregarPorRegiao(qtdPodcasts, regiaoId, false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdPodcasts"></param>
		/// <param name="regiaoId"></param>
		/// <param name="bancoAudio"></param>
		/// <returns></returns>
		public List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId, bool bancoAudio)
		{
			List<Podcast> entidadeRetorno = new List<Podcast>();
			Podcast entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ");

			if (qtdPodcasts > 0)
			{
				sbSQL.Append(String.Concat("TOP ", qtdPodcasts, " "));
			}

			string tabela = string.Empty;

			if (bancoAudio)
			{
				tabela = "viewPodcastsSite ";
			}
			else
			{
				tabela = "viewBancoAudioSite ";
			}

			sbSQL.Append(String.Concat(tabela, ".* FROM ", tabela));
			sbSQL.Append(" INNER JOIN ConteudoRegiao ON ");
			sbSQL.Append(String.Concat(tabela, ".podcastId = dbo.ConteudoRegiao.conteudoId "));
			sbSQL.Append("WHERE (ConteudoRegiao.regiaoId = @regiaoId) ");
			sbSQL.Append("ORDER BY dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Podcast();
				PopulaPodcast(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}
	}
}