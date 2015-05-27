
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
	public class VideoIdiomaFH : IFilterHelper
	{
		private string _videoId;
		public string VideoId {
			get { return _videoId==null?String.Empty:_videoId; }
			set { _videoId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloVideo;
		public string TituloVideo {
			get { return _tituloVideo==null?String.Empty:_tituloVideo; }
			set { _tituloVideo=value; }
		}

		private string _descricaoVideo;
		public string DescricaoVideo {
			get { return _descricaoVideo==null?String.Empty:_descricaoVideo; }
			set { _descricaoVideo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!VideoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (videoId="+VideoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloVideo.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloVideo LIKE '%"+TituloVideo+"%')");
			}

			if (!DescricaoVideo.Equals(String.Empty)) {
				sbWhere.Append(" AND (descricaoVideo LIKE '%"+DescricaoVideo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
