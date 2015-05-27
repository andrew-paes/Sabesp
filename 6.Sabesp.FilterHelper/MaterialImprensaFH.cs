
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
	public class MaterialImprensaFH : IFilterHelper
	{
		private string _materialImprensaId;
		public string MaterialImprensaId {
			get { return _materialImprensaId==null?String.Empty:_materialImprensaId; }
			set { _materialImprensaId=value; }
		}

		private string _ativo;
		public string Ativo {
			get { return _ativo==null?String.Empty:_ativo; }
			set { _ativo=value; }
		}

		private string _arquivoIdThumb;
		public string ArquivoIdThumb {
			get { return _arquivoIdThumb==null?String.Empty:_arquivoIdThumb; }
			set { _arquivoIdThumb=value; }
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

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!MaterialImprensaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (materialImprensaId="+MaterialImprensaId+")");
			}

			if (!Ativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativo LIKE '%"+Ativo+"%')");
			}

			if (!ArquivoIdThumb.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdThumb="+ArquivoIdThumb+")");
			}

			if( !DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			} else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"')");
			} else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
