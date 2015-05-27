
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
	public class EventoCategoriaFH : IFilterHelper
	{
		private string _eventoCategoriaId;
		public string EventoCategoriaId {
			get { return _eventoCategoriaId==null?String.Empty:_eventoCategoriaId; }
			set { _eventoCategoriaId=value; }
		}

		private string _arquivoIcone;
		public string ArquivoIcone {
			get { return _arquivoIcone==null?String.Empty:_arquivoIcone; }
			set { _arquivoIcone=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EventoCategoriaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (eventoCategoriaId="+EventoCategoriaId+")");
			}

			if (!ArquivoIcone.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIcone LIKE '%"+ArquivoIcone+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
