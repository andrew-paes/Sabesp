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
    public class SecaoIdioma
    {
        private Idioma _idioma;
        private Secao _secao;
        private string _titulo;
        private string _tituloMenu;
        private bool? _ativo;
        private string _palavraChave;
        private string _texto;
        private string _tituloArquivos;
        private string _textoArquivos;

        [NotNullValidator]
        public Idioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

        public Secao Secao
        {
            get { return _secao; }
            set { _secao = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string TituloMenu
        {
            get { return _tituloMenu; }
            set { _tituloMenu = value; }
        }

        public bool? Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        public string PalavraChave
        {
            get { return _palavraChave; }
            set { _palavraChave = value; }
        }

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public string TituloArquivos
        {
            get { return _tituloArquivos; }
            set { _tituloArquivos = value; }
        }

        public string TextoArquivos
        {
            get { return _textoArquivos; }
            set { _textoArquivos = value; }
        }

        /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<SecaoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<SecaoIdioma>(this);
        }
    }

    public struct SecaoIdiomaColunas
    {
        public static string IdiomaId = @"idiomaId";
        public static string SecaoId = @"secaoId";
        public static string Titulo = @"titulo";
        public static string TituloMenu = @"tituloMenu";
        public static string Ativo = @"ativo";
        public static string PalavraChave = @"palavraChave";
        public static string Texto = @"texto";
        public static string TituloArquivos = @"tituloArquivos";
        public static string TextoArquivos = @"textoArquivos";
    }
}
