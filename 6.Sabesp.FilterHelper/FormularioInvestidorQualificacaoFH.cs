
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
	public class FormularioInvestidorQualificacaoFH : IFilterHelper
	{
		private string _formularioInvestidorQualificacaoId;
		public string FormularioInvestidorQualificacaoId {
			get { return _formularioInvestidorQualificacaoId==null?String.Empty:_formularioInvestidorQualificacaoId; }
			set { _formularioInvestidorQualificacaoId=value; }
		}

		private string _qualificacao;
		public string Qualificacao {
			get { return _qualificacao==null?String.Empty:_qualificacao; }
			set { _qualificacao=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FormularioInvestidorQualificacaoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (formularioInvestidorQualificacaoId="+FormularioInvestidorQualificacaoId+")");
			}

			if (!Qualificacao.Equals(String.Empty)) {
				sbWhere.Append(" AND (qualificacao LIKE '%"+Qualificacao+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
