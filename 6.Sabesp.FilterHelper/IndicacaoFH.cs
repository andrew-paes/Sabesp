
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
	public class IndicacaoFH : IFilterHelper
	{
		private string _indicacaoId;
		public string IndicacaoId {
			get { return _indicacaoId==null?String.Empty:_indicacaoId; }
			set { _indicacaoId=value; }
		}

		private string _meio;
		public string Meio {
			get { return _meio==null?String.Empty:_meio; }
			set { _meio=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!IndicacaoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (indicacaoId="+IndicacaoId+")");
			}

			if (!Meio.Equals(String.Empty)) {
				sbWhere.Append(" AND (meio LIKE '%"+Meio+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
