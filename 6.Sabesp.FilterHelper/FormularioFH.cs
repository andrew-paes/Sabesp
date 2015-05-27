
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
	public class FormularioFH : IFilterHelper
	{
		private string _formularioId;
		public string FormularioId
		{
			get { return _formularioId == null ? String.Empty : _formularioId; }
			set { _formularioId = value; }
		}

		private string _nomeFormulario;
		public string NomeFormulario
		{
			get { return _nomeFormulario == null ? String.Empty : _nomeFormulario; }
			set { _nomeFormulario = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!FormularioId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (formularioId=" + FormularioId + ")");
			}

			if (!NomeFormulario.Equals(String.Empty))
			{
				sbWhere.Append(" AND (nomeFormulario LIKE '%" + NomeFormulario + "%')");
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ativo LIKE '%" + Ativo + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
