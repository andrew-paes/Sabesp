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
	public class ControleTipo 
	{
		// Construtor
		public ControleTipo() {}

		// Construtor com identificador
		public ControleTipo(int controleTipoId) {
			_controleTipoId = controleTipoId;
		}

		private int _controleTipoId;
		private string _nome;
		private bool? _hardcode;
		private string _arquivoControle;
		private List<Controle> _controles;

		public int ControleTipoId {
			get { return _controleTipoId; }
			set { _controleTipoId = value; }
		}

		public string Nome {
			get { return _nome; }
			set { _nome = value; }
		}

		public bool? Hardcode {
			get { return _hardcode; }
			set { _hardcode = value; }
		}

		public string ArquivoControle {
			get { return _arquivoControle; }
			set { _arquivoControle = value; }
		}

		public List<Controle> Controles {
			get { return _controles; }
			set { _controles = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ControleTipo>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ControleTipo>(this);
        }
	}
	
	public struct ControleTipoColunas
	{	
		public static string ControleTipoId = @"controleTipoId";
		public static string Nome = @"nome";
		public static string Hardcode = @"hardcode";
		public static string ArquivoControle = @"arquivoControle";
	}
}
		