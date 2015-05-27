
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
	public class ProdutoTipoFH : IFilterHelper
	{
		private string _produtoTipoId;
		public string ProdutoTipoId {
			get { return _produtoTipoId==null?String.Empty:_produtoTipoId; }
			set { _produtoTipoId=value; }
		}

		private string _destaqueHome;
		public string DestaqueHome {
			get { return _destaqueHome==null?String.Empty:_destaqueHome; }
			set { _destaqueHome=value; }
		}

		private string _arquivoIdThumb;
		public string ArquivoIdThumb {
			get { return _arquivoIdThumb==null?String.Empty:_arquivoIdThumb; }
			set { _arquivoIdThumb=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ProdutoTipoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (produtoTipoId="+ProdutoTipoId+")");
			}

			if (!DestaqueHome.Equals(String.Empty)) {
				sbWhere.Append(" AND (destaqueHome LIKE '%"+DestaqueHome+"%')");
			}

			if (!ArquivoIdThumb.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdThumb="+ArquivoIdThumb+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
