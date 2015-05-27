using System;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for GenerateResumeExtension
/// </summary>
public static class GenerateResumeExtension
{
	/// <summary>
	/// Generate a resume of strings
	/// </summary>
	/// <param name="str"></param>
	/// <param name="length">Max legth size of the resume</param>
	/// <returns></returns>
	public static string GenerateResume(this string str, int length)
	{
		//check if the string is not null, empty or whitespaces
		if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(str.Trim()))
		{
			str = HttpContext.Current.Server.HtmlDecode(str).StripHTML();
			//if the length of string is smaller than max length, return the same string
			if (str.Length <= length)
			{
				return str;
			}
			else
			{                
                var texto = str.Substring(0, length); // Corta a string.
                var textoReverso = new String(texto.Reverse().ToArray()); // Reverte ela.
                var textoLimitado = new String(textoReverso.Skip(textoReverso.IndexOf(' ')+1).Reverse().ToArray()); // Remove até o primeiro espaço encontrado e reverte novamente.
                return textoLimitado + "..."; 
			}
		}
		return string.Empty;
	}
}
