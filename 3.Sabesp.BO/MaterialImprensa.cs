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
	public class MaterialImprensa 
	{
		// Construtor
		public MaterialImprensa() {}

		// Construtor com identificador
		public MaterialImprensa(int materialImprensaId) {
			_materialImprensaId = materialImprensaId;
		}

		private int _materialImprensaId;
		private bool _ativo;
		private DateTime _dataHoraPublicacao;
		private List<MaterialImprensaIdioma> _materialImprensaIdiomas;
		private Arquivo _arquivoThumb;

		public int MaterialImprensaId {
			get { return _materialImprensaId; }
			set { _materialImprensaId = value; }
		}

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraPublicacao {
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public List<MaterialImprensaIdioma> MaterialImprensaIdiomas {
			get { return _materialImprensaIdiomas; }
			set { _materialImprensaIdiomas = value; }
		}

		[NotNullValidator]
		public Arquivo ArquivoThumb {
			get { return _arquivoThumb; }
			set { _arquivoThumb = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<MaterialImprensa>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<MaterialImprensa>(this);
        }
	}
	
	public struct MaterialImprensaColunas
	{	
		public static string MaterialImprensaId = @"materialImprensaId";
		public static string Ativo = @"ativo";
		public static string ArquivoIdThumb = @"arquivoIdThumb";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
	}
}
		