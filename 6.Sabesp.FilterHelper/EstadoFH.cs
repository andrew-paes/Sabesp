
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
	public class EstadoFH : IFilterHelper
	{
		private string _estadoId;
		public string EstadoId {
			get { return _estadoId==null?String.Empty:_estadoId; }
			set { _estadoId=value; }
		}

		private string _uf;
		public string Uf {
			get { return _uf==null?String.Empty:_uf; }
			set { _uf=value; }
		}

		private string _nomeEstado;
		public string NomeEstado {
			get { return _nomeEstado==null?String.Empty:_nomeEstado; }
			set { _nomeEstado=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EstadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (estadoId="+EstadoId+")");
			}

			if (!Uf.Equals(String.Empty)) {
				sbWhere.Append(" AND (uf LIKE '%"+Uf+"%')");
			}

			if (!NomeEstado.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeEstado LIKE '%"+NomeEstado+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
