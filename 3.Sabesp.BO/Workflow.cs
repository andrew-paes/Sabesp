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
	public class Workflow 
	{
		// Construtor
		public Workflow() {}

		// Construtor com identificador
		public Workflow(int workflowId) {
			_workflowId = workflowId;
		}

		private int _workflowId;
		private int _conteudoId;
		private DateTime _ultimaAlteracao;
		private string _conteudoDescricao;
		private string _comentario;
		private List<Conteudo> _conteudos;
		private List<NoticiaTeste> _noticiaTestes;

		public int WorkflowId {
			get { return _workflowId; }
			set { _workflowId = value; }
		}

		public int ConteudoId {
			get { return _conteudoId; }
			set { _conteudoId = value; }
		}

		public DateTime UltimaAlteracao {
			get { return _ultimaAlteracao; }
			set { _ultimaAlteracao = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 250)]
		public string ConteudoDescricao {
			get { return _conteudoDescricao; }
			set { _conteudoDescricao = value; }
		}

		public string Comentario {
			get { return _comentario; }
			set { _comentario = value; }
		}

		public List<Conteudo> Conteudos {
			get { return _conteudos; }
			set { _conteudos = value; }
		}

		public List<NoticiaTeste> NoticiaTestes {
			get { return _noticiaTestes; }
			set { _noticiaTestes = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Workflow>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Workflow>(this);
        }
	}
	
	public struct WorkflowColunas
	{	
		public static string WorkflowId = @"workflowId";
		public static string UserId = @"userId";
		public static string FluxoId = @"fluxoId";
		public static string StatusId = @"statusId";
		public static string ModuleId = @"moduleId";
		public static string ConteudoId = @"conteudoId";
		public static string UltimaAlteracao = @"ultimaAlteracao";
		public static string ConteudoDescricao = @"conteudoDescricao";
		public static string Comentario = @"comentario";
	}
}
		