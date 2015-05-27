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
    public class PodcastService
    {
        private IPodcastDAL _podcastDAL;

        public PodcastService()
        {

        }

        public IPodcastDAL PodcastDAL
        {

            get
            {
                if (_podcastDAL == null)
                    _podcastDAL = new PodcastADO();

                return _podcastDAL;
            }
            set
            {
                _podcastDAL = value;
            }
        }
        
        public int TotalRegistros(PodcastFH filtro)
        {
            return PodcastDAL.TotalRegistros(filtro);
        }

        public IList<Podcast> RetornaTodos()
        {
            return PodcastDAL.CarregarTodos();
        }

		public IList<Podcast> RetornaTodos(bool bancoAudio)
		{
			return PodcastDAL.CarregarTodos(bancoAudio);
		}

        public IList<Podcast> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, PodcastFH filtro)
        {
            return this.PodcastDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
        }
        public Podcast Carregar(Podcast entidade)
        {
            return PodcastDAL.Carregar(entidade);
        }
        public Podcast CarregarToSite(int podcastId)
        {
            return PodcastDAL.CarregarToSite(podcastId);
        }
		public Podcast CarregarToSite(int podcastId, bool bancoAudio)
		{
			return PodcastDAL.CarregarToSite(podcastId, bancoAudio);
		}
        public IList<Podcast> CarregarTagged(int tagId)
        {
            return PodcastDAL.CarregarTagged(tagId);
        }
		public IList<Podcast> CarregarTagged(int tagId, bool bancoAudio)
		{
			return PodcastDAL.CarregarTagged(tagId, bancoAudio);
		}
        public IList<Podcast> CarregarMaisVistos(int qtdPodcasts)
        {
            return PodcastDAL.CarregarMaisVistos(qtdPodcasts);
        }
		public IList<Podcast> CarregarMaisVistos(int qtdPodcasts, bool bancoAudio)
		{
			return PodcastDAL.CarregarMaisVistos(qtdPodcasts, bancoAudio);
		}
        public IList<Podcast> CarregarMaisRecentes(int qtdPodcasts)
        {
            return PodcastDAL.CarregarMaisRecentes(qtdPodcasts);
        }
		public IList<Podcast> CarregarMaisRecentes(int qtdPodcasts, bool bancoAudio)
		{
			return PodcastDAL.CarregarMaisRecentes(qtdPodcasts, bancoAudio);
		}
		public IList<Podcast> CarregarMaisRecentes(int qtdPodcasts, Podcast entidade)
		{
			return PodcastDAL.CarregarMaisRecentes(qtdPodcasts, entidade);
		} 
        public void Inserir(Podcast entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Podcast entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Podcast entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                PodcastDAL.Excluir(entidade);
                
                tScope.Complete();
            }
        }

		public List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId)
		{
			return PodcastDAL.CarregarPorRegiao(qtdPodcasts, regiaoId);
		}
		public List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId, bool bancoAudio)
		{
			return PodcastDAL.CarregarPorRegiao(qtdPodcasts, regiaoId, bancoAudio);
		}
    }
}
