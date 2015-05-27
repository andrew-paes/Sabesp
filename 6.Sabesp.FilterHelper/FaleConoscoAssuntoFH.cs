
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
	public class FaleConoscoAssuntoFH : IFilterHelper
	{
		private string _faleConoscoAssuntoId;
		public string FaleConoscoAssuntoId {
			get { return _faleConoscoAssuntoId==null?String.Empty:_faleConoscoAssuntoId; }
			set { _faleConoscoAssuntoId=value; }
		}

		private string _assunto;
		public string Assunto {
			get { return _assunto==null?String.Empty:_assunto; }
			set { _assunto=value; }
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

			if (!FaleConoscoAssuntoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (faleConoscoAssuntoId="+FaleConoscoAssuntoId+")");
			}

			if (!Assunto.Equals(String.Empty)) {
				sbWhere.Append(" AND (assunto LIKE '%"+Assunto+"%')");
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
