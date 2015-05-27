using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncodeToHtmlAnsiExtension
/// </summary>
public static class EncodeToHtmlEntityExtension
{
	/// <summary>
	/// Generate a resume of strings
	/// </summary>
	/// <param name="str"></param>
	/// <param name="length">Max legth size of the resume</param>
	/// <returns></returns>
	public static string EncodeToHtmlEntity(this string str)
	{
		//check if the string is not null, empty or whitespaces
		if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(str.Trim()))
		{
			
		    return str.Replace("<","&lt;")
		                .Replace(">","&gt;")
		                .Replace("&","&amp;")
		                .Replace("\"","&quot;")
		                .Replace("Ç","&Ccedil;")
		                .Replace("ç","&ccedil;")
		                .Replace("Ñ","&Ntilde;")
		                .Replace("ñ","&ntilde;")
		                .Replace("Þ","&THORN;")
		                .Replace("þ","&thorn;")
		                .Replace("Ý","&Yacute;")
		                .Replace("ý","&yacute;")
		                .Replace("ÿ","&yuml;")
		                .Replace("ß","&szlig;")
		                .Replace("Æ","&AElig;")
		                .Replace("Á","&Aacute;")
		                .Replace("Â","&Acirc;")
		                .Replace("À","&Agrave;")
		                .Replace("Å","&Aring;")
		                .Replace("Ã","&Atilde;")
		                .Replace("Ä","&Auml;")
		                .Replace("æ","&aelig;")
		                .Replace("á","&aacute;")
		                .Replace("â","&acirc;")
		                .Replace("à","&agrave;")
		                .Replace("å","&aring;")
		                .Replace("ã","&atilde;")
		                .Replace("ä","&auml;")
		                .Replace("Ð","&ETH;")
		                .Replace("É","&Eacute;")
		                .Replace("Ê","&Ecirc;")
		                .Replace("È","&Egrave;")
		                .Replace("Ë","&Euml;")
		                .Replace("ð","&eth;")
		                .Replace("é","&eacute;")
		                .Replace("ê","&ecirc;")
		                .Replace("è","&egrave;")
		                .Replace("ë","&euml;")
		                .Replace("Í","&Iacute;")
		                .Replace("Î","&Icirc;")
		                .Replace("Ì","&Igrave;")
		                .Replace("Ï","&Iuml;")
		                .Replace("í","&iacute;")
		                .Replace("î","&icirc;")
		                .Replace("ì","&igrave;")
		                .Replace("ï","&iuml;")
		                .Replace("Ó","&Oacute;")
		                .Replace("Ô","&Ocirc;")
		                .Replace("Ò","&Ograve;")
		                .Replace("Ø","&Oslash;")
		                .Replace("Õ","&Otilde;")
		                .Replace("§","&sect;")
		                .Replace("«","&laquo;")
		                .Replace("»","&raquo;")
		                .Replace("³","&sup3;")
		                .Replace("¿","&iquest;")
		                .Replace("°","&deg;")
		                .Replace("¦","&brvbar;")
		                .Replace("½","&frac12;")
		                .Replace("¾","&frac34;")
		                .Replace("¹","&sup1;")
		                .Replace("²","&sup2;")
		                .Replace("¢","&cent;")
		                .Replace("£","&pound;")
		                .Replace("¥","&yen;")
		                .Replace("¼","&frac14;")
		                .Replace("±","&plusmn;")
		                .Replace("µ","&micro;")
		                .Replace("¶","&para;")
		                .Replace("·","&middot;")
		                .Replace("û","&ucirc;")
		                .Replace("ù","&ugrave;")
		                .Replace("ü","&uuml;")
		                .Replace("®","&reg;")
		                .Replace("Û","&Ucirc;")
		                .Replace("Ù","&Ugrave;")
		                .Replace("Ü","&Uuml;")
		                .Replace("ú","&uacute;")
		                .Replace("ø","&oslash;")
		                .Replace("õ","&otilde;")
		                .Replace("ö","&ouml;")
		                .Replace("Ú","&Uacute;")
		                .Replace("Ö","&Ouml;")
		                .Replace("ó","&oacute;")
		                .Replace("ô","&ocirc;")
		                .Replace("ò","&ograve;");
		}
		return string.Empty;
	}
}