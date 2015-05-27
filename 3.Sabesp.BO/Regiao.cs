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
	public class Regiao 
	{
		private int _regiaoId;
		private string _nomeRegiao;
        private List<Municipio> _municipio;

		public int RegiaoId {
			get { return _regiaoId; }
			set { _regiaoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string NomeRegiao {
			get { return _nomeRegiao; }
			set { _nomeRegiao = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Regiao>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Regiao>(this);
        }

        public List<Municipio> Municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
        }
	}
	
	public struct RegiaoColunas
	{	
		public static string RegiaoId = @"regiaoId";
		public static string NomeRegiao = @"nomeRegiao";
	}
}
		