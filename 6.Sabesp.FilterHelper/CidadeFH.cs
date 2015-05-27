
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
	public class CidadeFH : IFilterHelper
	{
		private string _cidadeId;
		public string CidadeId {
			get { return _cidadeId==null?String.Empty:_cidadeId; }
			set { _cidadeId=value; }
		}

		private string _nomeCidade;
		public string NomeCidade {
			get { return _nomeCidade==null?String.Empty:_nomeCidade; }
			set { _nomeCidade=value; }
		}

		private string _estadoId;
		public string EstadoId {
			get { return _estadoId==null?String.Empty:_estadoId; }
			set { _estadoId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!CidadeId.Equals(String.Empty)) {
				sbWhere.Append(" AND (cidadeId="+CidadeId+")");
			}

			if (!NomeCidade.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeCidade LIKE '%"+NomeCidade+"%')");
			}

			if (!EstadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (estadoId="+EstadoId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
