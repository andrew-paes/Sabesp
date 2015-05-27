using System;
using System.Collections.Generic;
using System.Web;


namespace Ag2.Manager.Helper
{
    /// <summary>
    /// Summary description for ConfigurationManager
    /// </summary>
    public class ConfigurationManager
    {
        private static string _siteRoot = string.Empty;
        private static string _baseUrlUpload = string.Empty;
        private static string _build = string.Empty;
        private static bool _enableMultiLanguage = false;

        public ConfigurationManager() { }

        public static string BaseUrlUpload
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["baseUrlUpload"] != null)
                    _baseUrlUpload = System.Configuration.ConfigurationManager.AppSettings["baseUrlUpload"].ToString();

                return _baseUrlUpload;
            }
        }

        public static string Build
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["build"] != null)
                    _build = System.Configuration.ConfigurationManager.AppSettings["build"].ToString();

                return _build;
            }
        }


        public static bool EnableMultiLanguage
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["enableMultiLanguage"] != null)
                    Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["enableMultiLanguage"].ToString(), out _enableMultiLanguage);

                return _enableMultiLanguage;
            }
        }

        /// <summary>
        /// Define o sufixo da tabela idioma. EXEMPLOS: Tabela: Noticia / Tabela Idioma: Noticia[Sufixo] (NoticiaIdioma)
        /// </summary>
        public static string SufixoTabelaIdioma
        {
            get
            {
                return "Idioma";
            }
        }
        /*
        /// <summary>
        /// Define o Sufixo da procedure de busca: Exemplo Noticia[Sufixo] / NoticiaCarregar
        /// </summary>
        public static string SufixoProcedureSelect
        {
            get
            {
                return "Carregar";
            }
        }
        */
        /// <summary>
        /// Define o Sufixo da procedure de inserção: Exemplo Noticia[Sufixo] / NoticiaInsert
        /// </summary>
        public static string SufixoProcedureInsert
        {
            get
            {
                return "Inserir";
            }
        }

        /// <summary>
        /// Define o Sufixo da procedure de atualização: Exemplo Noticia[Sufixo] / NoticiaUpdate
        /// </summary>
        public static string SufixoProcedureUpdate
        {
            get
            {
                return "Atualizar";
            }
        }

        /// <summary>
        /// Define o sufixo da procedure de exclusão: Exemplo Noticia[Sufixo] / NoticiaDelete
        /// </summary>
        public static string SufixoProcedureDelete
        {
            get
            {
                return "Excluir";
            }
        }
    }
}
