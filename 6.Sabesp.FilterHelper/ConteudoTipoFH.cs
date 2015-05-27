
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
	public class ConteudoTipoFH : IFilterHelper
	{
		private string _conteudoTipoId;
		public string ConteudoTipoId {
			get { return _conteudoTipoId==null?String.Empty:_conteudoTipoId; }
			set { _conteudoTipoId=value; }
		}

		private string _tipo;
		public string Tipo {
			get { return _tipo==null?String.Empty:_tipo; }
			set { _tipo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ConteudoTipoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudoTipoId="+ConteudoTipoId+")");
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
