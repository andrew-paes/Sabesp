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
	public class FormularioInvestidor 
	{
		// Construtor
		public FormularioInvestidor() {}

		// Construtor com identificador
		public FormularioInvestidor(int formularioInvestidorId) {
			_formularioInvestidorId = formularioInvestidorId;
		}

		private int _formularioInvestidorId;
		private DateTime _dataHoraContato;
		private string _nome;
		private string _email;
		private string _companhia;
		private string _cargo;
		private string _profissao;
		private string _empresa;
		private string _cidade;
		private string _bairro;
		private string _endereco;
		private string _telefoneDDD;
		private string _telefoneNumero;
		private bool _contatoPorEmail;
		private bool _contatoPorTelefone;
		private string _cep;
		private Estado _estado;
		private Formulario _formulario;
		private FormularioInvestidorQualificacao _formularioInvestidorQualificacao;

		public int FormularioInvestidorId {
			get { return _formularioInvestidorId; }
			set { _formularioInvestidorId = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraContato {
			get { return _dataHoraContato; }
			set { _dataHoraContato = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Nome {
			get { return _nome; }
			set { _nome = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Companhia {
			get { return _companhia; }
			set { _companhia = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Cargo {
			get { return _cargo; }
			set { _cargo = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Profissao {
			get { return _profissao; }
			set { _profissao = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Empresa {
			get { return _empresa; }
			set { _empresa = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string Cidade {
			get { return _cidade; }
			set { _cidade = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Bairro {
			get { return _bairro; }
			set { _bairro = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string Endereco {
			get { return _endereco; }
			set { _endereco = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 2)]
		public string TelefoneDDD {
			get { return _telefoneDDD; }
			set { _telefoneDDD = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 10)]
		public string TelefoneNumero {
			get { return _telefoneNumero; }
			set { _telefoneNumero = value; }
		}

		public bool ContatoPorEmail {
			get { return _contatoPorEmail; }
			set { _contatoPorEmail = value; }
		}

		public bool ContatoPorTelefone {
			get { return _contatoPorTelefone; }
			set { _contatoPorTelefone = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string Cep {
			get { return _cep; }
			set { _cep = value; }
		}

		[NotNullValidator]
		public Estado Estado {
			get { return _estado; }
			set { _estado = value; }
		}

		[NotNullValidator]
		public Formulario Formulario {
			get { return _formulario; }
			set { _formulario = value; }
		}

		[NotNullValidator]
		public FormularioInvestidorQualificacao FormularioInvestidorQualificacao {
			get { return _formularioInvestidorQualificacao; }
			set { _formularioInvestidorQualificacao = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FormularioInvestidor>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FormularioInvestidor>(this);
        }
	}
	
	public struct FormularioInvestidorColunas
	{	
		public static string FormularioInvestidorId = @"formularioInvestidorId";
		public static string DataHoraContato = @"dataHoraContato";
		public static string FormularioId = @"formularioId";
		public static string Nome = @"nome";
		public static string Email = @"email";
		public static string Companhia = @"companhia";
		public static string FormularioInvestidorQualificacaoId = @"formularioInvestidorQualificacaoId";
		public static string Cargo = @"cargo";
		public static string Profissao = @"profissao";
		public static string Empresa = @"empresa";
		public static string EstadoId = @"estadoId";
		public static string Cidade = @"cidade";
		public static string Bairro = @"bairro";
		public static string Endereco = @"endereco";
		public static string TelefoneDDD = @"telefoneDDD";
		public static string TelefoneNumero = @"telefoneNumero";
		public static string ContatoPorEmail = @"contatoPorEmail";
		public static string ContatoPorTelefone = @"contatoPorTelefone";
		public static string Cep = @"cep";
	}
}
		