
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
	public class ProdutoTipoIdiomaFH : IFilterHelper
	{
		private string _produtoTipoId;
		public string ProdutoTipoId {
			get { return _produtoTipoId==null?String.Empty:_produtoTipoId; }
			set { _produtoTipoId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloProdutoTipo;
		public string TituloProdutoTipo {
			get { return _tituloProdutoTipo==null?String.Empty:_tituloProdutoTipo; }
			set { _tituloProdutoTipo=value; }
		}

		private string _textoTipoProduto;
		public string TextoTipoProduto {
			get { return _textoTipoProduto==null?String.Empty:_textoTipoProduto; }
			set { _textoTipoProduto=value; }
		}

        private string _chamadaProdutoTipo;
        public string ChamadaProdutoTipo
        {
            get { return _chamadaProdutoTipo == null ? String.Empty : _chamadaProdutoTipo; }
            set { _chamadaProdutoTipo = value; }
        }
	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ProdutoTipoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (produtoTipoId="+ProdutoTipoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloProdutoTipo.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloProdutoTipo LIKE '%"+TituloProdutoTipo+"%')");
			}

			if (!TextoTipoProduto.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoTipoProduto LIKE '%"+TextoTipoProduto+"%')");
			}

            if (!ChamadaProdutoTipo.Equals(String.Empty))
            {
                sbWhere.Append(" AND (chamadaProdutoTipo LIKE '%" + ChamadaProdutoTipo + "%')");
            }
	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
