
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
	public class ConteudoAvaliacaoFH : IFilterHelper
	{
		private string _conteudoId;
		public string ConteudoId {
			get { return _conteudoId==null?String.Empty:_conteudoId; }
			set { _conteudoId=value; }
		}

		private string _totalPositivo;
		public string TotalPositivo {
			get { return _totalPositivo==null?String.Empty:_totalPositivo; }
			set { _totalPositivo=value; }
		}

		private string _totalNegativo;
		public string TotalNegativo {
			get { return _totalNegativo==null?String.Empty:_totalNegativo; }
			set { _totalNegativo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ConteudoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudoId="+ConteudoId+")");
			}

			if (!TotalPositivo.Equals(String.Empty)) {
				sbWhere.Append(" AND (totalPositivo="+TotalPositivo+")");
			}

			if (!TotalNegativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (totalNegativo="+TotalNegativo+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
