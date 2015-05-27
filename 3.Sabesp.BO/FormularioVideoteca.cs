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
	public class FormularioVideoteca 
	{
		// Construtor
		public FormularioVideoteca() {}

		// Construtor com identificador
		public FormularioVideoteca(int formularioVideotecaId) {
			_formularioVideotecaId = formularioVideotecaId;
		}

		private int _formularioVideotecaId;
		private DateTime _dataHoraContato;
		private string _nome;
		private string _email;
		private string _rg;
		private string _cadastroNacionalPessoa;
		private string _profissao;
		private string _empresa;
		private string _cidade;
		private string _bairro;
		private string _endereco;
		private string _telefoneDdd;
		private string _telefoneNumero;
		private bool _interesseGotaBorralheira;
		private bool _interesseAguaNaBoca;
		private bool _interesseAguaVideos;
		private bool _interesseChuaChuagua;
		private bool _interesseTratamento;
		private string _utilizacaoMaterial;
		private string _cep;
		private bool _interesseSuperH20;
		private Estado _estado;
		private Formulario _formulario;

		public int FormularioVideotecaId {
			get { return _formularioVideotecaId; }
			set { _formularioVideotecaId = value; }
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
		[StringLengthValidator(0, 20)]
		public string Rg {
			get { return _rg; }
			set { _rg = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 20)]
		public string CadastroNacionalPessoa {
			get { return _cadastroNacionalPessoa; }
			set { _cadastroNacionalPessoa = value; }
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
		public string TelefoneDdd {
			get { return _telefoneDdd; }
			set { _telefoneDdd = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 10)]
		public string TelefoneNumero {
			get { return _telefoneNumero; }
			set { _telefoneNumero = value; }
		}

		public bool InteresseGotaBorralheira {
			get { return _interesseGotaBorralheira; }
			set { _interesseGotaBorralheira = value; }
		}

		public bool InteresseAguaNaBoca {
			get { return _interesseAguaNaBoca; }
			set { _interesseAguaNaBoca = value; }
		}

		public bool InteresseAguaVideos {
			get { return _interesseAguaVideos; }
			set { _interesseAguaVideos = value; }
		}

		public bool InteresseChuaChuagua {
			get { return _interesseChuaChuagua; }
			set { _interesseChuaChuagua = value; }
		}

		public bool InteresseTratamento {
			get { return _interesseTratamento; }
			set { _interesseTratamento = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string UtilizacaoMaterial {
			get { return _utilizacaoMaterial; }
			set { _utilizacaoMaterial = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string Cep {
			get { return _cep; }
			set { _cep = value; }
		}

		public bool InteresseSuperH20 {
			get { return _interesseSuperH20; }
			set { _interesseSuperH20 = value; }
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

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FormularioVideoteca>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FormularioVideoteca>(this);
        }
	}
	
	public struct FormularioVideotecaColunas
	{	
		public static string FormularioVideotecaId = @"formularioVideotecaId";
		public static string DataHoraContato = @"dataHoraContato";
		public static string Nome = @"nome";
		public static string Email = @"email";
		public static string Rg = @"rg";
		public static string CadastroNacionalPessoa = @"cadastroNacionalPessoa";
		public static string Profissao = @"profissao";
		public static string Empresa = @"empresa";
		public static string EstadoId = @"estadoId";
		public static string FormularioId = @"formularioId";
		public static string Cidade = @"cidade";
		public static string Bairro = @"bairro";
		public static string Endereco = @"endereco";
		public static string TelefoneDdd = @"telefoneDdd";
		public static string TelefoneNumero = @"telefoneNumero";
		public static string InteresseGotaBorralheira = @"interesseGotaBorralheira";
		public static string InteresseAguaNaBoca = @"interesseAguaNaBoca";
		public static string InteresseAguaVideos = @"interesseAguaVideos";
		public static string InteresseChuaChuagua = @"interesseChuaChuagua";
		public static string InteresseTratamento = @"interesseTratamento";
		public static string UtilizacaoMaterial = @"utilizacaoMaterial";
		public static string Cep = @"cep";
		public static string InteresseSuperH20 = @"interesseSuperH20";
	}
}
		