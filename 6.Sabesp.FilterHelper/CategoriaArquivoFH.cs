
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
	public class CategoriaArquivoFH : IFilterHelper
	{
		private string _categoriaArquivoId;
		public string CategoriaArquivoId {
			get { return _categoriaArquivoId==null?String.Empty:_categoriaArquivoId; }
			set { _categoriaArquivoId=value; }
		}

		private string _titulo;
		public string Titulo {
			get { return _titulo==null?String.Empty:_titulo; }
			set { _titulo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!CategoriaArquivoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (categoriaArquivoId="+CategoriaArquivoId+")");
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
