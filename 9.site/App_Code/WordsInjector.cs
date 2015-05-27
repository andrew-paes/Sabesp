using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Collections.Generic;

namespace AG2.Sabesp.HotWords
{
    public class WordsInjector
    {
        private Stream _responseStream;
        private long _position;
        private StringBuilder _responseHtml;

        public WordsInjector()
        {

        }

        public WordsInjector(Stream inputStream)
        {
            _responseStream = inputStream;
            _responseHtml = new StringBuilder();
        }

        #region Script Injector

        /// <summary>
        /// Insere hotword
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String Hotword(String input)
        {
            if (input == null)
            {
                return input;
            }

            input = WordsInjector.ToUTF8(input);

            MatchEvaluator evaluator = new MatchEvaluator(Mask);

            // Mascara tags específicas e seu conteúdo interno
            String maskedInput = Regex.Replace(input, @"<(a|h[1-4]|dt|th).*?>.*?</\1>", evaluator, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Mascara demais tags HTML, para que não sejam consideradas na substituição
            maskedInput = Regex.Replace(maskedInput, "<.*?>", evaluator, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return input;
        }

        /// <summary>
        /// Retorna uma string mascarada de mesmo comprimento do padrão capturado
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static String Mask(Match match)
        {
            return new String('#', match.Length);
        }

        private static string ToUTF8(String str)
        {
            System.Text.Encoding encASCII = System.Text.Encoding.ASCII;
            System.Text.Encoding encUTF8 = System.Text.Encoding.UTF8;
            System.Text.Encoding encUTF16 = System.Text.Encoding.Unicode;

            byte[] arrByte_origem;
            byte[] arrByte_destino;

            String strDestino;
            str = System.Web.HttpUtility.HtmlDecode(str);
            arrByte_origem = encASCII.GetBytes(str);

            arrByte_destino = System.Text.Encoding.Convert(encASCII, encUTF8, arrByte_origem);
            strDestino = encUTF8.GetString(arrByte_destino);

            strDestino = System.Web.HttpUtility.HtmlDecode(strDestino);

            return strDestino;
        }

        #endregion
    }
}