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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Sabesp.BO
{

	[Serializable]
	public class Contato
	{
		// Construtor
		public Contato() { }

		// Construtor com identificador
		public Contato(int contatoId)
		{
			_contatoId = contatoId;
		}

		private int _contatoId;
		private string _nomeContato;
		private string _emailContato;
		private List<Formulario> _formularios;

		public int ContatoId
		{
			get { return _contatoId; }
			set { _contatoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string NomeContato
		{
			get { return _nomeContato; }
			set { _nomeContato = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string EmailContato
		{
			get { return _emailContato; }
			set { _emailContato = value; }
		}

		public List<Formulario> Formularios
		{
			get { return _formularios; }
			set { _formularios = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Contato>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Contato>(this);
		}
	}

	public struct ContatoColunas
	{
		public static string ContatoId = @"contatoId";
		public static string NomeContato = @"nomeContato";
		public static string EmailContato = @"emailContato";
	}
}
