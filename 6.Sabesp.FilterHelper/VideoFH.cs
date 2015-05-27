
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
	public class VideoFH : IFilterHelper
	{
		private string _videoId;
		public string VideoId
		{
			get { return _videoId == null ? String.Empty : _videoId; }
			set { _videoId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}

		private string _destaqueHome;
		public string DestaqueHome
		{
			get { return _destaqueHome == null ? String.Empty : _destaqueHome; }
			set { _destaqueHome = value; }
		}

		private string _destaqueVideos;
		public string DestaqueVideos
		{
			get { return _destaqueVideos == null ? String.Empty : _destaqueVideos; }
			set { _destaqueVideos = value; }
		}

		private string _destaqueFiquePorDentro;
		public string DestaqueFiquePorDentro
		{
			get { return _destaqueFiquePorDentro == null ? String.Empty : _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		private string _dataHoraPublicacaoPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoInicial
		{
			get { return _dataHoraPublicacaoPeriodoInicial == null ? String.Empty : _dataHoraPublicacaoPeriodoInicial; }
			set { _dataHoraPublicacaoPeriodoInicial = value; }
		}
		private string _dataHoraPublicacaoPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoFinal
		{
			get { return _dataHoraPublicacaoPeriodoFinal == null ? String.Empty : _dataHoraPublicacaoPeriodoFinal; }
			set { _dataHoraPublicacaoPeriodoFinal = value; }
		}

		private string _urlYoutube;
		public string UrlYoutube
		{
			get { return _urlYoutube == null ? String.Empty : _urlYoutube; }
			set { _urlYoutube = value; }
		}

		private string _autor;
		public string Autor
		{
			get { return _autor == null ? String.Empty : _autor; }
			set { _autor = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!VideoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (videoId=" + VideoId + ")");
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (ativo=", Ativo, ")"));
			}

			if (!DestaqueHome.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueHome=", DestaqueHome, ")"));
			}

			if (!DestaqueVideos.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueVideos=", DestaqueVideos, ")"));
			}

			if (!DestaqueFiquePorDentro.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueFiquePorDentro=", DestaqueFiquePorDentro, ")"));
			}

			if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataHoraPublicacao >='", DataHoraPublicacaoPeriodoInicial, "'"));
				sbWhere.Append(String.Concat(" AND dataHoraPublicacao <='", DataHoraPublicacaoPeriodoFinal, "')"));
			}
			else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataHoraPublicacao >='", DataHoraPublicacaoPeriodoInicial, "')"));
			}
			else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataHoraPublicacao <='", DataHoraPublicacaoPeriodoFinal, "')"));
			}


			if (!UrlYoutube.Equals(String.Empty))
			{
				sbWhere.Append(" AND (urlYoutube LIKE '%" + UrlYoutube + "%')");
			}

			if (!Autor.Equals(String.Empty))
			{
				sbWhere.Append(" AND (autor LIKE '%" + Autor + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
