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
	public class ControleSessao 
	{
		// Construtor
		public ControleSessao() {}

		// Construtor com identificador
		public ControleSessao(int controleSessaoId) {
			_controleSessaoId = controleSessaoId;
		}

		private int _controleSessaoId;
		private int _secaoId;
		private int _coluna;
		private int? _posicao;
		private Controle _controle;

		public int ControleSessaoId {
			get { return _controleSessaoId; }
			set { _controleSessaoId = value; }
		}

		public int SecaoId {
			get { return _secaoId; }
			set { _secaoId = value; }
		}

		public int Coluna {
			get { return _coluna; }
			set { _coluna = value; }
		}

		public int? Posicao {
			get { return _posicao; }
			set { _posicao = value; }
		}

		[NotNullValidator]
		public Controle Controle {
			get { return _controle; }
			set { _controle = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ControleSessao>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ControleSessao>(this);
        }
	}
	
	public struct ControleSessaoColunas
	{	
		public static string ControleSessaoId = @"controleSessaoId";
		public static string SecaoId = @"secaoId";
		public static string ControleId = @"controleId";
		public static string Coluna = @"coluna";
		public static string Posicao = @"posicao";
	}
}
		