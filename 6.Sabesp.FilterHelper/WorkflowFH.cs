
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
	public class WorkflowFH : IFilterHelper
	{
		private string _workflowId;
		public string WorkflowId {
			get { return _workflowId==null?String.Empty:_workflowId; }
			set { _workflowId=value; }
		}

		private string _userId;
		public string UserId {
			get { return _userId==null?String.Empty:_userId; }
			set { _userId=value; }
		}

		private string _fluxoId;
		public string FluxoId {
			get { return _fluxoId==null?String.Empty:_fluxoId; }
			set { _fluxoId=value; }
		}

		private string _statusId;
		public string StatusId {
			get { return _statusId==null?String.Empty:_statusId; }
			set { _statusId=value; }
		}

		private string _moduleId;
		public string ModuleId {
			get { return _moduleId==null?String.Empty:_moduleId; }
			set { _moduleId=value; }
		}

		private string _conteudoId;
		public string ConteudoId {
			get { return _conteudoId==null?String.Empty:_conteudoId; }
			set { _conteudoId=value; }
		}

		private string _ultimaAlteracaoPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string UltimaAlteracaoPeriodoInicial {
			get { return _ultimaAlteracaoPeriodoInicial==null?String.Empty:_ultimaAlteracaoPeriodoInicial; }
			set { _ultimaAlteracaoPeriodoInicial=value; }
		}
		private string _ultimaAlteracaoPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string UltimaAlteracaoPeriodoFinal {
			get { return _ultimaAlteracaoPeriodoFinal==null?String.Empty:_ultimaAlteracaoPeriodoFinal; }
			set { _ultimaAlteracaoPeriodoFinal=value; }
		}

		private string _conteudoDescricao;
		public string ConteudoDescricao {
			get { return _conteudoDescricao==null?String.Empty:_conteudoDescricao; }
			set { _conteudoDescricao=value; }
		}

		private string _comentario;
		public string Comentario {
			get { return _comentario==null?String.Empty:_comentario; }
			set { _comentario=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!WorkflowId.Equals(String.Empty)) {
				sbWhere.Append(" AND (workflowId="+WorkflowId+")");
			}

			if (!UserId.Equals(String.Empty)) {
				sbWhere.Append(" AND (userId LIKE '%"+UserId+"%')");
			}

			if (!FluxoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (fluxoId="+FluxoId+")");
			}

			if (!StatusId.Equals(String.Empty)) {
				sbWhere.Append(" AND (statusId="+StatusId+")");
			}

			if (!ModuleId.Equals(String.Empty)) {
				sbWhere.Append(" AND (moduleId="+ModuleId+")");
			}

			if (!ConteudoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudoId="+ConteudoId+")");
			}

			if( !UltimaAlteracaoPeriodoInicial.Equals(String.Empty) && !UltimaAlteracaoPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (ultimaAlteracao >='"+UltimaAlteracaoPeriodoInicial+"'");
				sbWhere.Append(" AND ultimaAlteracao <='"+UltimaAlteracaoPeriodoFinal+"')");
			} else if (!UltimaAlteracaoPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (ultimaAlteracao >='"+UltimaAlteracaoPeriodoInicial+"')");
			} else if (!UltimaAlteracaoPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (ultimaAlteracao <='"+UltimaAlteracaoPeriodoFinal+"')");
			}

			if (!ConteudoDescricao.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudoDescricao LIKE '%"+ConteudoDescricao+"%')");
			}

			if (!Comentario.Equals(String.Empty)) {
				sbWhere.Append(" AND (comentario LIKE '%"+Comentario+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
