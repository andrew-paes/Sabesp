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
    public class ComunicadoIdioma
    {
        private string _tituloComunicado;
        private string _textoComunicado;
        private Comunicado _comunicado;
        private Idioma _idioma;

        [NotNullValidator]
        [StringLengthValidator(0, 200)]
        public string TituloComunicado
        {
            get { return _tituloComunicado; }
            set { _tituloComunicado = value; }
        }

        [NotNullValidator]
        [StringLengthValidator(0, 1073741823)]
        public string TextoComunicado
        {
            get { return _textoComunicado; }
            set { _textoComunicado = value; }
        }

        [NotNullValidator]
        public Comunicado Comunicado
        {
            get { return _comunicado; }
            set { _comunicado = value; }
        }

        [NotNullValidator]
        public Idioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

        /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ComunicadoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ComunicadoIdioma>(this);
        }
    }

    public struct ComunicadoIdiomaColunas
    {
        public static string ComunicadoId = @"comunicadoId";
        public static string IdiomaId = @"idiomaId";
        public static string TituloComunicado = @"tituloComunicado";
        public static string TextoComunicado = @"textoComunicado";
    }
}
