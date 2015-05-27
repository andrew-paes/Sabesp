
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
	public class EscolaridadeFH : IFilterHelper
	{
		private string _escolaridadeId;
		public string EscolaridadeId {
			get { return _escolaridadeId==null?String.Empty:_escolaridadeId; }
			set { _escolaridadeId=value; }
		}

		private string _nomeEscolaridade;
		public string NomeEscolaridade {
			get { return _nomeEscolaridade==null?String.Empty:_nomeEscolaridade; }
			set { _nomeEscolaridade=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EscolaridadeId.Equals(String.Empty)) {
				sbWhere.Append(" AND (escolaridadeId="+EscolaridadeId+")");
			}

			if (!NomeEscolaridade.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeEscolaridade LIKE '%"+NomeEscolaridade+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
