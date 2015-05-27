
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
	public class ControleIdiomaFH : IFilterHelper
	{
		private string _controleIdiomaId;
		public string ControleIdiomaId {
			get { return _controleIdiomaId==null?String.Empty:_controleIdiomaId; }
			set { _controleIdiomaId=value; }
		}

		private string _controleId;
		public string ControleId {
			get { return _controleId==null?String.Empty:_controleId; }
			set { _controleId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _workflowId;
		public string WorkflowId {
			get { return _workflowId==null?String.Empty:_workflowId; }
			set { _workflowId=value; }
		}

		private string _titulo;
		public string Titulo {
			get { return _titulo==null?String.Empty:_titulo; }
			set { _titulo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleIdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleIdiomaId="+ControleIdiomaId+")");
			}

			if (!ControleId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleId="+ControleId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!WorkflowId.Equals(String.Empty)) {
				sbWhere.Append(" AND (workflowId="+WorkflowId+")");
			}

			if (!Titulo.Equals(String.Empty)) {
				sbWhere.Append(" AND (titulo LIKE '%"+Titulo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
