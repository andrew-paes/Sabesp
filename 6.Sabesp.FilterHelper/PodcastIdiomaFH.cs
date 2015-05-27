
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
using System.Text;

namespace Sabesp.FilterHelper
{
	public class PodcastIdiomaFH : IFilterHelper
	{
		private string _podcastId;
		public string PodcastId {
			get { return _podcastId==null?String.Empty:_podcastId; }
			set { _podcastId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloPodcast;
		public string TituloPodcast {
			get { return _tituloPodcast==null?String.Empty:_tituloPodcast; }
			set { _tituloPodcast=value; }
		}

		private string _descricaoPodcast;
		public string DescricaoPodcast {
			get { return _descricaoPodcast==null?String.Empty:_descricaoPodcast; }
			set { _descricaoPodcast=value; }
		}

		private string _arquivoIdPodcast;
		public string ArquivoIdPodcast {
			get { return _arquivoIdPodcast==null?String.Empty:_arquivoIdPodcast; }
			set { _arquivoIdPodcast=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!PodcastId.Equals(String.Empty)) {
				sbWhere.Append(" AND (podcastId="+PodcastId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloPodcast.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloPodcast LIKE '%"+TituloPodcast+"%')");
			}

			if (!DescricaoPodcast.Equals(String.Empty)) {
				sbWhere.Append(" AND (descricaoPodcast LIKE '%"+DescricaoPodcast+"%')");
			}

			if (!ArquivoIdPodcast.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdPodcast="+ArquivoIdPodcast+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
