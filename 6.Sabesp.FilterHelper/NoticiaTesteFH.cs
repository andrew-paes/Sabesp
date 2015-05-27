
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
	public class NoticiaTesteFH : IFilterHelper
	{
		private string _noticiaTesteId;
		public string NoticiaTesteId {
			get { return _noticiaTesteId==null?String.Empty:_noticiaTesteId; }
			set { _noticiaTesteId=value; }
		}

		private string _dataCadastroPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataCadastroPeriodoInicial {
			get { return _dataCadastroPeriodoInicial==null?String.Empty:_dataCadastroPeriodoInicial; }
			set { _dataCadastroPeriodoInicial=value; }
		}
		private string _dataCadastroPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataCadastroPeriodoFinal {
			get { return _dataCadastroPeriodoFinal==null?String.Empty:_dataCadastroPeriodoFinal; }
			set { _dataCadastroPeriodoFinal=value; }
		}

		private string _workflowId;
		public string WorkflowId {
			get { return _workflowId==null?String.Empty:_workflowId; }
			set { _workflowId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!NoticiaTesteId.Equals(String.Empty)) {
				sbWhere.Append(" AND (noticiaTesteId="+NoticiaTesteId+")");
			}

			if( !DataCadastroPeriodoInicial.Equals(String.Empty) && !DataCadastroPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataCadastro >='"+DataCadastroPeriodoInicial+"'");
				sbWhere.Append(" AND dataCadastro <='"+DataCadastroPeriodoFinal+"')");
			} else if (!DataCadastroPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataCadastro >='"+DataCadastroPeriodoInicial+"')");
			} else if (!DataCadastroPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataCadastro <='"+DataCadastroPeriodoFinal+"')");
			}

			if (!WorkflowId.Equals(String.Empty)) {
				sbWhere.Append(" AND (workflowId="+WorkflowId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
