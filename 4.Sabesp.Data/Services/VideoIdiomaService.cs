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
    public class VideoIdiomaService
    {
        private IVideoIdiomaDAL _videoIdiomaDAL;

        public VideoIdiomaService()
        {

        }

        public IVideoIdiomaDAL VideoIdiomaDAL
        {

            get
            {
                if (_videoIdiomaDAL == null)
                    _videoIdiomaDAL = new VideoIdiomaADO();

                return _videoIdiomaDAL;
            }
            set
            {
                _videoIdiomaDAL = value;
            }
        }

        public int TotalRegistros(VideoIdiomaFH filtro)
        {
            return VideoIdiomaDAL.TotalRegistros(filtro);
        }

        public IList<VideoIdioma> RetornaTodos()
        {
            return VideoIdiomaDAL.CarregarTodos();
        }

        public VideoIdioma Carregar(VideoIdioma entidade)
        {
            return VideoIdiomaDAL.Carregar(entidade);
        }

        public void Inserir(VideoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                VideoIdiomaDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(VideoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                VideoIdiomaDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(VideoIdioma entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                VideoIdiomaDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
