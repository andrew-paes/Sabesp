
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
using System.Text;

namespace Sabesp.FilterHelper
{
	public class PodcastFH : IFilterHelper
	{
		private string _podcastId;
		public string PodcastId
		{
			get { return _podcastId == null ? String.Empty : _podcastId; }
			set { _podcastId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}

		private string _bancoAudio;
		public string BancoAudio
		{
			get { return _bancoAudio == null ? String.Empty : _bancoAudio; }
			set { _bancoAudio = value; }
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

		private string _destaqueHome;
		public string DestaqueHome
		{
			get { return _destaqueHome == null ? String.Empty : _destaqueHome; }
			set { _destaqueHome = value; }
		}

		private string _destaqueFiquePorDentro;
		public string DestaqueFiquePorDentro
		{
			get { return _destaqueFiquePorDentro == null ? String.Empty : _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		private string _destaquePodcasts;
		public string DestaquePodcasts
		{
			get { return _destaquePodcasts == null ? String.Empty : _destaquePodcasts; }
			set { _destaquePodcasts = value; }
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

			if (!PodcastId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (podcastId=" + PodcastId + ")");
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ativo LIKE '%" + Ativo + "%')");
			}

			if (!BancoAudio.Equals(String.Empty))
			{
				sbWhere.Append(" AND (bancoAudio=" + BancoAudio + ")");
			}


			if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(" AND (dataHoraPublicacao >='" + DataHoraPublicacaoPeriodoInicial + "'");
				sbWhere.Append(" AND dataHoraPublicacao <='" + DataHoraPublicacaoPeriodoFinal + "')");
			}
			else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty))
			{
				sbWhere.Append(" AND (dataHoraPublicacao >='" + DataHoraPublicacaoPeriodoInicial + "')");
			}
			else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(" AND (dataHoraPublicacao <='" + DataHoraPublicacaoPeriodoFinal + "')");
			}

			if (!DestaqueHome.Equals(String.Empty))
			{
				sbWhere.Append(" AND (destaqueHome LIKE '%" + DestaqueHome + "%')");
			}

			if (!DestaqueFiquePorDentro.Equals(String.Empty))
			{
				sbWhere.Append(" AND (destaqueFiquePorDentro LIKE '%" + DestaqueFiquePorDentro + "%')");
			}

			if (!DestaquePodcasts.Equals(String.Empty))
			{
				sbWhere.Append(" AND (destaquePodcasts LIKE '%" + DestaquePodcasts + "%')");
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