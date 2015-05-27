
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
	public class EventoFH : IFilterHelper
	{
		private string _eventoId;
		public string EventoId {
			get { return _eventoId==null?String.Empty:_eventoId; }
			set { _eventoId=value; }
		}

		private string _ativo;
		public string Ativo {
			get { return _ativo==null?String.Empty:_ativo; }
			set { _ativo=value; }
		}

		private string _dataHoraPublicacaoPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoInicial {
			get { return _dataHoraPublicacaoPeriodoInicial==null?String.Empty:_dataHoraPublicacaoPeriodoInicial; }
			set { _dataHoraPublicacaoPeriodoInicial=value; }
		}
		private string _dataHoraPublicacaoPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoFinal {
			get { return _dataHoraPublicacaoPeriodoFinal==null?String.Empty:_dataHoraPublicacaoPeriodoFinal; }
			set { _dataHoraPublicacaoPeriodoFinal=value; }
		}

		private string _dataHoraEventoInicioPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraEventoInicioPeriodoInicial {
			get { return _dataHoraEventoInicioPeriodoInicial==null?String.Empty:_dataHoraEventoInicioPeriodoInicial; }
			set { _dataHoraEventoInicioPeriodoInicial=value; }
		}
		private string _dataHoraEventoInicioPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraEventoInicioPeriodoFinal {
			get { return _dataHoraEventoInicioPeriodoFinal==null?String.Empty:_dataHoraEventoInicioPeriodoFinal; }
			set { _dataHoraEventoInicioPeriodoFinal=value; }
		}

		private string _dataHoraEventoFimPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraEventoFimPeriodoInicial {
			get { return _dataHoraEventoFimPeriodoInicial==null?String.Empty:_dataHoraEventoFimPeriodoInicial; }
			set { _dataHoraEventoFimPeriodoInicial=value; }
		}
		private string _dataHoraEventoFimPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraEventoFimPeriodoFinal {
			get { return _dataHoraEventoFimPeriodoFinal==null?String.Empty:_dataHoraEventoFimPeriodoFinal; }
			set { _dataHoraEventoFimPeriodoFinal=value; }
		}

		private string _arquivoIdThumbGrande;
		public string ArquivoIdThumbGrande {
			get { return _arquivoIdThumbGrande==null?String.Empty:_arquivoIdThumbGrande; }
			set { _arquivoIdThumbGrande=value; }
		}

		private string _arquivoIdThumbMedio;
		public string ArquivoIdThumbMedio {
			get { return _arquivoIdThumbMedio==null?String.Empty:_arquivoIdThumbMedio; }
			set { _arquivoIdThumbMedio=value; }
		}

		private string _destaqueEventos;
		public string DestaqueEventos {
			get { return _destaqueEventos==null?String.Empty:_destaqueEventos; }
			set { _destaqueEventos=value; }
		}

		private string _local;
		public string Local {
			get { return _local==null?String.Empty:_local; }
			set { _local=value; }
		}

		private string _destaqueFiquePorDentro;
		public string DestaqueFiquePorDentro {
			get { return _destaqueFiquePorDentro==null?String.Empty:_destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EventoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (eventoId="+EventoId+")");
			}

			if (!Ativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativo LIKE '%"+Ativo+"%')");
			}

			if( !DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			} else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"')");
			} else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			}

			if( !DataHoraEventoInicioPeriodoInicial.Equals(String.Empty) && !DataHoraEventoInicioPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraEventoInicio >='"+DataHoraEventoInicioPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraEventoInicio <='"+DataHoraEventoInicioPeriodoFinal+"')");
			} else if (!DataHoraEventoInicioPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraEventoInicio >='"+DataHoraEventoInicioPeriodoInicial+"')");
			} else if (!DataHoraEventoInicioPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraEventoInicio <='"+DataHoraEventoInicioPeriodoFinal+"')");
			}

			if( !DataHoraEventoFimPeriodoInicial.Equals(String.Empty) && !DataHoraEventoFimPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraEventoFim >='"+DataHoraEventoFimPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraEventoFim <='"+DataHoraEventoFimPeriodoFinal+"')");
			} else if (!DataHoraEventoFimPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraEventoFim >='"+DataHoraEventoFimPeriodoInicial+"')");
			} else if (!DataHoraEventoFimPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraEventoFim <='"+DataHoraEventoFimPeriodoFinal+"')");
			}

			if (!ArquivoIdThumbGrande.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdThumbGrande="+ArquivoIdThumbGrande+")");
			}

			if (!ArquivoIdThumbMedio.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdThumbMedio="+ArquivoIdThumbMedio+")");
			}

			if (!DestaqueEventos.Equals(String.Empty)) {
				sbWhere.Append(" AND (destaqueEventos LIKE '%"+DestaqueEventos+"%')");
			}

			if (!Local.Equals(String.Empty)) {
				sbWhere.Append(" AND (local LIKE '%"+Local+"%')");
			}

			if (!DestaqueFiquePorDentro.Equals(String.Empty)) {
				sbWhere.Append(" AND (destaqueFiquePorDentro LIKE '%"+DestaqueFiquePorDentro+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
