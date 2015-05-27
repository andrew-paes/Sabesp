
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
	public class NoticiaFH : IFilterHelper
	{
		private string _noticiaId;
		public string NoticiaId
		{
			get { return _noticiaId == null ? String.Empty : _noticiaId; }
			set { _noticiaId = value; }
		}

		private string _ativa;
		public string Ativa
		{
			get { return _ativa == null ? String.Empty : _ativa; }
			set { _ativa = value; }
		}

		private string _autor;
		public string Autor
		{
			get { return _autor == null ? String.Empty : _autor; }
			set { _autor = value; }
		}

		private string _destaqueHome;
		public string DestaqueHome
		{
			get { return _destaqueHome == null ? String.Empty : _destaqueHome; }
			set { _destaqueHome = value; }
		}

		private string _destaqueNoticias;
		public string DestaqueNoticias
		{
			get { return _destaqueNoticias == null ? String.Empty : _destaqueNoticias; }
			set { _destaqueNoticias = value; }
		}

		private string _destaqueFiquePorDentro;
		public string DestaqueFiquePorDentro
		{
			get { return _destaqueFiquePorDentro == null ? String.Empty : _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		private string _destaqueUltimasNoticias;
		public string DestaqueUltimasNoticias
		{
			get { return _destaqueUltimasNoticias == null ? String.Empty : _destaqueUltimasNoticias; }
			set { _destaqueUltimasNoticias = value; }
		}

		private string _fonte;
		public string Fonte
		{
			get { return _fonte == null ? String.Empty : _fonte; }
			set { _fonte = value; }
		}

		private string _fonteUrl;
		public string FonteUrl
		{
			get { return _fonteUrl == null ? String.Empty : _fonteUrl; }
			set { _fonteUrl = value; }
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

		private string _dataExibicaoInicioPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataExibicaoInicioPeriodoInicial
		{
			get { return _dataExibicaoInicioPeriodoInicial == null ? String.Empty : _dataExibicaoInicioPeriodoInicial; }
			set { _dataExibicaoInicioPeriodoInicial = value; }
		}
		private string _dataExibicaoInicioPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataExibicaoInicioPeriodoFinal
		{
			get { return _dataExibicaoInicioPeriodoFinal == null ? String.Empty : _dataExibicaoInicioPeriodoFinal; }
			set { _dataExibicaoInicioPeriodoFinal = value; }
		}

		private string _dataExibicaoFimPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataExibicaoFimPeriodoInicial
		{
			get { return _dataExibicaoFimPeriodoInicial == null ? String.Empty : _dataExibicaoFimPeriodoInicial; }
			set { _dataExibicaoFimPeriodoInicial = value; }
		}
		private string _dataExibicaoFimPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataExibicaoFimPeriodoFinal
		{
			get { return _dataExibicaoFimPeriodoFinal == null ? String.Empty : _dataExibicaoFimPeriodoFinal; }
			set { _dataExibicaoFimPeriodoFinal = value; }
		}

		private string _arquivoIdThumbGrande;
		public string ArquivoIdThumbGrande
		{
			get { return _arquivoIdThumbGrande == null ? String.Empty : _arquivoIdThumbGrande; }
			set { _arquivoIdThumbGrande = value; }
		}

		private string _arquivoIdThumbMedio;
		public string ArquivoIdThumbMedio
		{
			get { return _arquivoIdThumbMedio == null ? String.Empty : _arquivoIdThumbMedio; }
			set { _arquivoIdThumbMedio = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!NoticiaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (noticiaId=" + NoticiaId + ")");
			}

			if (!Ativa.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (ativa=", Ativa, ")"));
			}

			if (!Autor.Equals(String.Empty))
			{
				sbWhere.Append(" AND (autor LIKE '%" + Autor + "%')");
			}

			if (!DestaqueHome.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueHome=", DestaqueHome, ")"));
			}

			if (!DestaqueNoticias.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueNoticias=", DestaqueNoticias, ")"));
			}

			if (!DestaqueFiquePorDentro.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueFiquePorDentro=", DestaqueFiquePorDentro, ")"));
			}

			if (!DestaqueUltimasNoticias.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueUltimasNoticias=", DestaqueUltimasNoticias, ")"));
			}

			if (!Fonte.Equals(String.Empty))
			{
				sbWhere.Append(" AND (fonte LIKE '%" + Fonte + "%')");
			}

			if (!FonteUrl.Equals(String.Empty))
			{
				sbWhere.Append(" AND (fonteUrl LIKE '%" + FonteUrl + "%')");
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

			if (!DataExibicaoInicioPeriodoInicial.Equals(String.Empty) && !DataExibicaoInicioPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoInicio >='", DataExibicaoInicioPeriodoInicial, "'"));
				sbWhere.Append(String.Concat(" AND dataExibicaoInicio <='", DataExibicaoInicioPeriodoFinal, "')"));
			}
			else if (!DataExibicaoInicioPeriodoInicial.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoInicio >='", DataExibicaoInicioPeriodoInicial, "')"));
			}
			else if (!DataExibicaoInicioPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoInicio <='", DataExibicaoInicioPeriodoFinal, "')"));
			}

			if (!DataExibicaoFimPeriodoInicial.Equals(String.Empty) && !DataExibicaoFimPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoFim >='", DataExibicaoFimPeriodoInicial, "'"));
				sbWhere.Append(String.Concat(" AND dataExibicaoFim <='", DataExibicaoFimPeriodoFinal, "')"));
			}
			else if (!DataExibicaoFimPeriodoInicial.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoFim >='", DataExibicaoFimPeriodoInicial, "')"));
			}
			else if (!DataExibicaoFimPeriodoFinal.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (dataExibicaoFim <='", DataExibicaoFimPeriodoFinal, "')"));
			}

			if (!ArquivoIdThumbGrande.Equals(String.Empty))
			{
				sbWhere.Append(" AND (arquivoIdThumbGrande=" + ArquivoIdThumbGrande + ")");
			}

			if (!ArquivoIdThumbMedio.Equals(String.Empty))
			{
				sbWhere.Append(" AND (arquivoIdThumbMedio=" + ArquivoIdThumbMedio + ")");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
