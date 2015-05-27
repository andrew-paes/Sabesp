
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
	public class FaqCategoriaIdiomaFH : IFilterHelper
	{
		private string _faqCategoriaId;
		public string FaqCategoriaId {
			get { return _faqCategoriaId==null?String.Empty:_faqCategoriaId; }
			set { _faqCategoriaId=value; }
		}

		private string _nomeCategoria;
		public string NomeCategoria {
			get { return _nomeCategoria==null?String.Empty:_nomeCategoria; }
			set { _nomeCategoria=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FaqCategoriaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (faqCategoriaId="+FaqCategoriaId+")");
			}

			if (!NomeCategoria.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeCategoria LIKE '%"+NomeCategoria+"%')");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
