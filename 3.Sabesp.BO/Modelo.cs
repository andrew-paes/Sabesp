/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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

namespace Sabesp.BO
{

	[Serializable]
	public class Modelo
	{
		// Construtor
		public Modelo() { }

		// Construtor com identificador
		public Modelo(int modeloId)
		{
			_modeloId = modeloId;
		}

		private int _modeloId;
		private string _nome;
		private string _arquivo;

		public int ModeloId
		{
			get { return _modeloId; }
			set { _modeloId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 128)]
		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 128)]
		public string Arquivo
		{
			get { return _arquivo; }
			set { _arquivo = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Modelo>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Modelo>(this);
		}
	}

	public struct ModeloColunas
	{
		public static string ModeloId = @"modeloId";
		public static string Nome = @"nome";
		public static string Arquivo = @"arquivo";
	}
}
