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
	public class FaleConoscoAssunto 
	{
		// Construtor
		public FaleConoscoAssunto() {}

		// Construtor com identificador
		public FaleConoscoAssunto(int faleConoscoAssuntoId) {
			_faleConoscoAssuntoId = faleConoscoAssuntoId;
		}

		private int _faleConoscoAssuntoId;
		private string _assunto;
		private string _email;
		private bool? _ativo;
		private List<FaleConoscoMensagem> _faleConoscoMensagens;

		public int FaleConoscoAssuntoId {
			get { return _faleConoscoAssuntoId; }
			set { _faleConoscoAssuntoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 255)]
		public string Assunto {
			get { return _assunto; }
			set { _assunto = value; }
		}

		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		public bool? Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public List<FaleConoscoMensagem> FaleConoscoMensagens {
			get { return _faleConoscoMensagens; }
			set { _faleConoscoMensagens = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FaleConoscoAssunto>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaleConoscoAssunto>(this);
        }
	}
	
	public struct FaleConoscoAssuntoColunas
	{	
		public static string FaleConoscoAssuntoId = @"faleConoscoAssuntoId";
		public static string Assunto = @"assunto";
		public static string Email = @"email";
		public static string Ativo = @"ativo";
	}
}
		