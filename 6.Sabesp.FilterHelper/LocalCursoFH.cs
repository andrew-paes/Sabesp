
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
	public class LocalCursoFH : IFilterHelper
	{
		private string _localCursoId;
		public string LocalCursoId {
			get { return _localCursoId==null?String.Empty:_localCursoId; }
			set { _localCursoId=value; }
		}

		private string _local;
		public string Local {
			get { return _local==null?String.Empty:_local; }
			set { _local=value; }
		}

		private string _email;
		public string Email {
			get { return _email==null?String.Empty:_email; }
			set { _email=value; }
		}

		private string _ativo;
		public string Ativo {
			get { return _ativo==null?String.Empty:_ativo; }
			set { _ativo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!LocalCursoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (localCursoId="+LocalCursoId+")");
			}

			if (!Local.Equals(String.Empty)) {
				sbWhere.Append(" AND (local LIKE '%"+Local+"%')");
			}

			if (!Email.Equals(String.Empty)) {
				sbWhere.Append(" AND (email LIKE '%"+Email+"%')");
			}

			if (!Ativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativo LIKE '%"+Ativo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
