using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sabesp.BO
{
	[Serializable]
	public class BuscaConteudo
	{
		// Construtor
		public BuscaConteudo() { }

		// Construtor com identificador
		public BuscaConteudo(int conteudoId)
		{
			_conteudoId = conteudoId;
		}

		private int _conteudoId;
		private string _titulo;
		private string _descricao;
		private ConteudoTipo _conteudoTipo;

		public int ConteudoId
		{
			get { return _conteudoId; }
			set { _conteudoId = value; }
		}

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		[NotNullValidator]
		public ConteudoTipo ConteudoTipo
		{
			get { return _conteudoTipo; }
			set { _conteudoTipo = value; }
		}
	}
}
