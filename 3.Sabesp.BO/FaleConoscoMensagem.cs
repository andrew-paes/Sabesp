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
	public class FaleConoscoMensagem 
	{
		// Construtor
		public FaleConoscoMensagem() {}

		// Construtor com identificador
		public FaleConoscoMensagem(int faleConoscoMensagemId) {
			_faleConoscoMensagemId = faleConoscoMensagemId;
		}

		private int _faleConoscoMensagemId;
		private string _nome;
		private string _email;
		private int _telefoneDDD;
		private int _telefoneComplemento;
		private Regiao _regiao;
		private Estado _estado;
		private Cidade _cidade;
		private string _mensagem;
		private FaleConoscoAssunto _faleConoscoAssunto;
		private bool _atendido;

		public int FaleConoscoMensagemId {
			get { return _faleConoscoMensagemId; }
			set { _faleConoscoMensagemId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 255)]
		public string Nome {
			get { return _nome; }
			set { _nome = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 255)]
		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		public int TelefoneDDD {
			get { return _telefoneDDD; }
			set { _telefoneDDD = value; }
		}

		public int TelefoneComplemento {
			get { return _telefoneComplemento; }
			set { _telefoneComplemento = value; }
		}

		public Regiao Regiao
		{
			get { return _regiao; }
			set { _regiao = value; }
		}

		public Estado Estado {
			get { return _estado; }
			set { _estado = value; }
		}

		public Cidade Cidade {
			get { return _cidade; }
			set { _cidade = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 2147483647)]
		public string Mensagem {
			get { return _mensagem; }
			set { _mensagem = value; }
		}

		[NotNullValidator]
		public FaleConoscoAssunto FaleConoscoAssunto {
			get { return _faleConoscoAssunto; }
			set { _faleConoscoAssunto = value; }
		}

		[NotNullValidator]
		public bool Atendido
		{
			get { return _atendido; }
			set { _atendido = value; }
		}


		/// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FaleConoscoMensagem>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaleConoscoMensagem>(this);
        }
	}
	
	public struct FaleConoscoMensagemColunas
	{	
		public static string FaleConoscoMensagemId = @"faleConoscoMensagemId";
		public static string FaleConoscoAssuntoId = @"faleConoscoAssuntoId";
		public static string Nome = @"nome";
		public static string Email = @"email";
		public static string TelefoneDDD = @"telefoneDDD";
		public static string TelefoneComplemento = @"telefoneComplemento";
		public static string Estado = @"estadoId";
		public static string Cidade = @"cidadeId";
		public static string Mensagem = @"mensagem";
		public static string Atendido = @"atendido";
	}
}
		