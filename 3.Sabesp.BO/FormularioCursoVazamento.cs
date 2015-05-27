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
	public class FormularioCursoVazamento 
	{
		// Construtor
		public FormularioCursoVazamento() {}

		// Construtor com identificador
		public FormularioCursoVazamento(int formularioCursoVazamentoId) {
			_formularioCursoVazamentoId = formularioCursoVazamentoId;
		}

		private int _formularioCursoVazamentoId;
		private DateTime _dataHoraContato;
		private string _nome;
		private string _email;
		private string _cep;
		private string _cidade;
		private string _bairro;
		private string _endereco;
		private string _telefoneDDD;
		private string _telefoneNumero;
		private string _escolaridadeOutro;
		private string _tipoImovelOutro;
		private string _indicacaoOutro;
		private Escolaridade _escolaridade;
		private Estado _estado;
		private Formulario _formulario;
		private HorarioPreferencia _horarioPreferencia;
		private Indicacao _indicacao;
		private LocalCurso _localCurso;
		private TipoImovel _tipoImovel;

		public int FormularioCursoVazamentoId {
			get { return _formularioCursoVazamentoId; }
			set { _formularioCursoVazamentoId = value; }
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
		[StringLengthValidator(0, 50)]
		public string Cep {
			get { return _cep; }
			set { _cep = value; }
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

		public string EscolaridadeOutro {
			get { return _escolaridadeOutro; }
			set { _escolaridadeOutro = value; }
		}

		public string TipoImovelOutro {
			get { return _tipoImovelOutro; }
			set { _tipoImovelOutro = value; }
		}

		public string IndicacaoOutro {
			get { return _indicacaoOutro; }
			set { _indicacaoOutro = value; }
		}

		[NotNullValidator]
		public Escolaridade Escolaridade {
			get { return _escolaridade; }
			set { _escolaridade = value; }
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
		public HorarioPreferencia HorarioPreferencia {
			get { return _horarioPreferencia; }
			set { _horarioPreferencia = value; }
		}

		[NotNullValidator]
		public Indicacao Indicacao {
			get { return _indicacao; }
			set { _indicacao = value; }
		}

		[NotNullValidator]
		public LocalCurso LocalCurso {
			get { return _localCurso; }
			set { _localCurso = value; }
		}

		[NotNullValidator]
		public TipoImovel TipoImovel {
			get { return _tipoImovel; }
			set { _tipoImovel = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FormularioCursoVazamento>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FormularioCursoVazamento>(this);
        }
	}
	
	public struct FormularioCursoVazamentoColunas
	{	
		public static string FormularioCursoVazamentoId = @"formularioCursoVazamentoId";
		public static string FormularioId = @"formularioId";
		public static string DataHoraContato = @"dataHoraContato";
		public static string Nome = @"nome";
		public static string Email = @"email";
		public static string Cep = @"cep";
		public static string EstadoId = @"estadoId";
		public static string Cidade = @"cidade";
		public static string Bairro = @"bairro";
		public static string Endereco = @"endereco";
		public static string TelefoneDDD = @"telefoneDDD";
		public static string TelefoneNumero = @"telefoneNumero";
		public static string EscolaridadeId = @"escolaridadeId";
		public static string EscolaridadeOutro = @"escolaridadeOutro";
		public static string TipoImovelId = @"tipoImovelId";
		public static string TipoImovelOutro = @"tipoImovelOutro";
		public static string IndicacaoId = @"indicacaoId";
		public static string IndicacaoOutro = @"indicacaoOutro";
		public static string LocalCursoId = @"localCursoId";
		public static string HorarioPreferenciaId = @"horarioPreferenciaId";
	}
}
		