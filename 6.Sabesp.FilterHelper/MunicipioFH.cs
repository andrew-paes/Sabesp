
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
	public class MunicipioFH : IFilterHelper
	{
		private string _municipioId;
		public string MunicipioId
		{
			get { return _municipioId == null ? String.Empty : _municipioId; }
			set { _municipioId = value; }
		}

		private string _nome;
		public string Nome
		{
			get { return _nome == null ? String.Empty : _nome; }
			set { _nome = value; }
		}

		private string _imagem;
		public string Imagem
		{
			get { return _imagem == null ? String.Empty : _imagem; }
			set { _imagem = value; }
		}

		private string _texto;
		public string Texto
		{
			get { return _texto == null ? String.Empty : _texto; }
			set { _texto = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!MunicipioId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (municipioId=" + MunicipioId + ")");
			}

			if (!Nome.Equals(String.Empty))
			{
				sbWhere.Append(" AND (nome LIKE '%" + Nome + "%')");
			}

			if (!Imagem.Equals(String.Empty))
			{
				sbWhere.Append(" AND (imagem LIKE '%" + Imagem + "%')");
			}

			if (!Texto.Equals(String.Empty))
			{
				sbWhere.Append(" AND (texto LIKE '%" + Texto + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
