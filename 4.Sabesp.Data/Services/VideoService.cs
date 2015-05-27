using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
	public class VideoService
	{
		private IVideoDAL _videoDAL;

		public VideoService()
		{

		}

		public IVideoDAL VideoDAL
		{

			get
			{
				if (_videoDAL == null)
					_videoDAL = new VideoADO();

				return _videoDAL;
			}
			set
			{
				_videoDAL = value;
			}
		}

		public int TotalRegistros(VideoFH filtro)
		{
			return VideoDAL.TotalRegistros(filtro);
		}

		public IList<Video> RetornaTodos()
		{
			return VideoDAL.CarregarTodos();
		}

		public IList<Video> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, VideoFH filtro)
		{
			return VideoDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
		}

		public Video Carregar(Video entidade)
		{
			return VideoDAL.Carregar(entidade);
		}

		public Video CarregarToSite(int videoId)
		{
			return VideoDAL.CarregarToSite(videoId);
		}
        public IList<Video> CarregarTagged(int tagId)
        {
            return VideoDAL.CarregarTagged(tagId);
        }
        public IList<Video> CarregarTagged(int qtdRegistros, string palavra)
        {
            return VideoDAL.CarregarTagged(qtdRegistros, palavra);
        }
        public IList<Video> CarregarMaisVistos(int qtdVideos)
        {
            return VideoDAL.CarregarMaisVistos(qtdVideos);
        } 
		public void Inserir(Video entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				VideoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Video entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				VideoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Video entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				VideoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public List<Video> CarregarPorRegiao(int qtdVideos, int regiaoId)
		{
			return VideoDAL.CarregarPorRegiao(qtdVideos, regiaoId);
		}
	}
}
