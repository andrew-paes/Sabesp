
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
	public class ProdutoFH : IFilterHelper
	{
		private string _produtoId;
		public string ProdutoId
		{
			get { return _produtoId == null ? String.Empty : _produtoId; }
			set { _produtoId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}

		private string _destaqueProdutos;
		public string DestaqueProdutos
		{
			get { return _destaqueProdutos == null ? String.Empty : _destaqueProdutos; }
			set { _destaqueProdutos = value; }
		}

		private string _arquivoIdThumb;
		public string ArquivoIdThumb
		{
			get { return _arquivoIdThumb == null ? String.Empty : _arquivoIdThumb; }
			set { _arquivoIdThumb = value; }
		}

		private string _produtoTipoId;
		public string ProdutoTipoId
		{
			get { return _produtoTipoId == null ? String.Empty : _produtoTipoId; }
			set { _produtoTipoId = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!ProdutoId.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (produtoId=", ProdutoId, ")"));
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (ativo=", Ativo, ")"));
			}

			if (!DestaqueProdutos.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueProdutos=", DestaqueProdutos, ")"));
			}

			if (!ArquivoIdThumb.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (arquivoIdThumb=", ArquivoIdThumb, ")"));
			}

			if (!ProdutoTipoId.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (produtoTipoId=", ProdutoTipoId, ")"));
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
