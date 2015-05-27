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
	public class FormularioSegurancaTrabalho
	{
		// Construtor
		public FormularioSegurancaTrabalho() { }

		// Construtor com identificador
		public FormularioSegurancaTrabalho(int formularioSegurancaTrabalhoId)
		{
			_formularioSegurancaTrabalhoId = formularioSegurancaTrabalhoId;
		}

		private int _formularioSegurancaTrabalhoId;
		private DateTime _dataHoraContato;
		private string _nome;
		private string _email;
		private string _empresa;
		private string _cep;
		private string _cidade;
		private string _bairro;
		private string _endereco;
		private string _telefoneDdd;
		private string _telefoneNumero;
		private bool _receberInformacaoSabesp;
		private bool _receberInformacaoEventos;
		private string _duvida;
		private Estado _estado;
		private Formulario _formulario;

		public int FormularioSegurancaTrabalhoId
		{
			get { return _formularioSegurancaTrabalhoId; }
			set { _formularioSegurancaTrabalhoId = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraContato
		{
			get { return _dataHoraContato; }
			set { _dataHoraContato = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Empresa
		{
			get { return _empresa; }
			set { _empresa = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string Cep
		{
			get { return _cep; }
			set { _cep = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string Cidade
		{
			get { return _cidade; }
			set { _cidade = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Bairro
		{
			get { return _bairro; }
			set { _bairro = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string Endereco
		{
			get { return _endereco; }
			set { _endereco = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 2)]
		public string TelefoneDdd
		{
			get { return _telefoneDdd; }
			set { _telefoneDdd = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 10)]
		public string TelefoneNumero
		{
			get { return _telefoneNumero; }
			set { _telefoneNumero = value; }
		}

		public bool ReceberInformacaoSabesp
		{
			get { return _receberInformacaoSabesp; }
			set { _receberInformacaoSabesp = value; }
		}

		public bool ReceberInformacaoEventos
		{
			get { return _receberInformacaoEventos; }
			set { _receberInformacaoEventos = value; }
		}

		public string Duvida
		{
			get { return _duvida; }
			set { _duvida = value; }
		}

		[NotNullValidator]
		public Estado Estado
		{
			get { return _estado; }
			set { _estado = value; }
		}

		[NotNullValidator]
		public Formulario Formulario
		{
			get { return _formulario; }
			set { _formulario = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<FormularioSegurancaTrabalho>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<FormularioSegurancaTrabalho>(this);
		}
	}

	public struct FormularioSegurancaTrabalhoColunas
	{
		public static string FormularioSegurancaTrabalhoId = @"formularioSegurancaTrabalhoId";
		public static string DataHoraContato = @"dataHoraContato";
		public static string Nome = @"nome";
		public static string Email = @"email";
		public static string Empresa = @"empresa";
		public static string Cep = @"cep";
		public static string EstadoId = @"estadoId";
		public static string Cidade = @"cidade";
		public static string Bairro = @"bairro";
		public static string Endereco = @"endereco";
		public static string TelefoneDdd = @"telefoneDdd";
		public static string TelefoneNumero = @"telefoneNumero";
		public static string ReceberInformacaoSabesp = @"receberInformacaoSabesp";
		public static string ReceberInformacaoEventos = @"receberInformacaoEventos";
		public static string FormularioId = @"formularioId";
		public static string Duvida = @"duvida";
	}
}
