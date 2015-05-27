
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
	public class TipoImovelFH : IFilterHelper
	{
		private string _tipoImovelId;
		public string TipoImovelId {
			get { return _tipoImovelId==null?String.Empty:_tipoImovelId; }
			set { _tipoImovelId=value; }
		}

		private string _tipo;
		public string Tipo {
			get { return _tipo==null?String.Empty:_tipo; }
			set { _tipo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!TipoImovelId.Equals(String.Empty)) {
				sbWhere.Append(" AND (tipoImovelId="+TipoImovelId+")");
			}

			if (!Tipo.Equals(String.Empty)) {
				sbWhere.Append(" AND (tipo LIKE '%"+Tipo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
