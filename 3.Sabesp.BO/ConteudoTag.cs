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
    public class ConteudoTag
    {
        private Tag _tag;
        private Conteudo _conteudo;

        [NotNullValidator]
        public Tag Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        [NotNullValidator]
        public Conteudo Conteudo
        {
            get { return _conteudo; }
            set { _conteudo = value; }
        }

        /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ConteudoTag>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ConteudoTag>(this);
        }
    }

    public struct ConteudoTagColunas
    {
        public static string TagId = @"tagId";
        public static string ConteudoId = @"conteudoId";
    }
}
