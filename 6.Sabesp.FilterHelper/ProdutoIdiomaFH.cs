
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
	public class ProdutoIdiomaFH : IFilterHelper
	{
		private string _produtoId;
		public string ProdutoId {
			get { return _produtoId==null?String.Empty:_produtoId; }
			set { _produtoId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloProduto;
		public string TituloProduto {
			get { return _tituloProduto==null?String.Empty:_tituloProduto; }
			set { _tituloProduto=value; }
		}

		private string _textoProduto;
		public string TextoProduto {
			get { return _textoProduto==null?String.Empty:_textoProduto; }
			set { _textoProduto=value; }
		}

        private string _chamadaProduto;
        public string ChamadaProduto
        {
            get { return _chamadaProduto == null ? String.Empty : _chamadaProduto; }
            set { _chamadaProduto = value; }
        }
	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ProdutoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (produtoId="+ProdutoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloProduto.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloProduto LIKE '%"+TituloProduto+"%')");
			}

			if (!TextoProduto.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoProduto LIKE '%"+TextoProduto+"%')");
			}

            if (!ChamadaProduto.Equals(String.Empty))
            {
                sbWhere.Append(" AND (chamadaProduto LIKE '%" + ChamadaProduto + "%')");
            }

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
