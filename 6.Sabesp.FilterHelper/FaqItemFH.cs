
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
	public class FaqItemFH : IFilterHelper
	{
		private string _faqItemId;
		public string FaqItemId
		{
			get { return _faqItemId == null ? String.Empty : _faqItemId; }
			set { _faqItemId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}

		private string _destaque;
		public string Destaque
		{
			get { return _destaque == null ? String.Empty : _destaque; }
			set { _destaque = value; }
		}

		private string _ordemItem;
		public string OrdemItem
		{
			get { return _ordemItem == null ? String.Empty : _ordemItem; }
			set { _ordemItem = value; }
		}

		private string _faqCategoriaId;
		public string FaqCategoriaId
		{
			get { return _faqCategoriaId == null ? String.Empty : _faqCategoriaId; }
			set { _faqCategoriaId = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!FaqItemId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (faqItemId=" + FaqItemId + ")");
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (ativo=", Ativo, ")"));
			}

			if (!OrdemItem.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ordemItem=" + OrdemItem + ")");
			}

			if (!FaqCategoriaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (faqCategoriaId=" + FaqCategoriaId + ")");
			}

			if (!Destaque.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaque=", Destaque, ")"));
			}

			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
