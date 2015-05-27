using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;
using Sabesp.Interfaces;

namespace RedesSociais
{
	public enum YoutubeOrderBy
	{
		None,
		Published,
		Relevance,
		ViewCount,
		Rating
	}

	/// <summary>
	/// Summary description for YouTube
	/// </summary>
	public class YouTube : IRedesSociais
	{

		public YouTube()
		{
			OrderBy = YoutubeOrderBy.None;
		}

		#region IRedesSociais Members

		public string Nome
		{
			get
			{
				return "YouTube";
			}
			set
			{
				this.Nome = value;
			}
		}

		public int Total
		{
			get
			{
				return 10;
			}
		}


		public string TipoConteudo
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string Icon
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IRedesSociais GetStatistics()
		{
			return new RedesSociais.YouTube()
			{
				Nome = "teste"
			};
		}

		#endregion

		#region Properties

		private YoutubeOrderBy _orderBy;

		public static string YouTubeChannel
		{
			get
			{
				return ConfigurationManager.AppSettings["YouTubeChannel"]; ;
			}
		}

		public static string YouTubeClientID
		{
			get
			{
				return ConfigurationManager.AppSettings["YouTubeClientID"]; ;
			}
		}

		public static string YouTubeDeveloperKey
		{
			get
			{
				return ConfigurationManager.AppSettings["YouTubeDeveloperKey"]; ;
			}
		}

		public static string YouTubeApplicationName
		{
			get
			{
				return ConfigurationManager.AppSettings["YouTubeApplicationName"]; ;
			}
		}

		public YoutubeOrderBy OrderBy
		{
			get
			{
				return _orderBy;
			}
			set
			{
				_orderBy = value;
			}
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="youtube"></param>
		/// <returns></returns>
		public static string GetVideoFeedUrl(YouTube youtube)
		{
			string url = String.Format("http://gdata.youtube.com/feeds/api/users/{0}/uploads", RedesSociais.YouTube.YouTubeChannel);

			if (youtube.OrderBy != YoutubeOrderBy.None)
			{
				String.Concat(url, "?orderby=", youtube.OrderBy.ToString());
			}

			return url;
		}

		/// <summary>
		/// Transform Youtube keywords in a list of String
		/// </summary>
		/// <param name="youtubeKeywords"></param>
		/// <returns></returns>
		public static List<String> YoutubeKeywordsToList(string youtubeKeywords)
		{
			//split the quotes to find commas
			string[] keywords = Regex.Split(youtubeKeywords, "&quot;");

			//remove the commas of single words
			for (int i = 0; i < keywords.Length - 1; i++)
			{
				if ((keywords[i].Trim().Length > 0) && (keywords[i].Trim()[0] == Convert.ToChar(",")))
				{
					keywords[i] = keywords[i].Trim().Substring(1);
				}

				if ((keywords[i].Trim().Length > 0) && (keywords[i].Trim()[keywords[i].Trim().Length - 1] == Convert.ToChar(",")))
				{
					keywords[i] = keywords[i].Trim().Substring(0, keywords[i].Trim().Length - 2);
				}
			}

			string keys = string.Empty;
			List<String> listKeywords = new List<String>();

			//add quotes if necessary and remove the commas of multiple-words
			foreach (string strKey in keywords)
			{
				if (strKey.Trim().Length > 0)
				{
					string strKeytmp = string.Empty;
					if (strKey.Contains(","))
					{
						strKeytmp = String.Concat("\"", strKey.Trim(), "\"").Replace(",", "");
					}
					else
					{
						strKeytmp = strKey;
					}

					//add keyword to list
					listKeywords.Add(strKeytmp.Trim());
				}
			}

			return listKeywords;
		}

		/// <summary>
		/// Build Html Youtube String to show in site
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="movieId"></param>
		public static string BuildYoutubeHtmlString(int width, int height, string urlVideo, int registroId)
		{
			StringBuilder str = new StringBuilder();

			str.AppendLine("<div id=\"ytapiplayer" + registroId + "\">");
			//str.AppendLine("         You need Flash player 8+ and JavaScript enabled to view this video.");
			str.AppendLine("</div>");
			str.AppendLine(" <script type=\"text/javascript\"> ");
			str.AppendLine(" // <![CDATA[  ");
			str.AppendLine(" // allowScriptAccess must be set to allow the Javascript from one   ");
			str.AppendLine(" // domain to access the swf on the youtube domain ");
			str.AppendLine(" var params = {allowFullScreen:\"true \",  allowScriptAccess: \"always\" }; ");
			str.AppendLine(" // this sets the id of the object or embed tag to 'myytplayer'. ");
			str.AppendLine(" // You then use this id to access the swf and make calls to the player's API ");
			str.AppendLine(" var atts = { id: \"ytapiplayer" + registroId + "\" }; ");
            str.AppendLine(" var agent = navigator.userAgent.toLowerCase();");
            var _stylePlayer = "";
            str.AppendLine("if(agent.indexOf('iphone')!= -1 || agent.indexOf('ipod')!= -1 || agent.indexOf('ipad')!= -1){");

            str.AppendLine(
                string.Format(
                    "document.write('<embed src=\"{0}{1}\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"{2}\" height=\"{3}\"></embed>');",
                    _stylePlayer,
                    formatVideoUrl(urlVideo),
                    width,
                    height));
            str.AppendLine("}else{");
            str.AppendLine(
                string.Format(
                    " swfobject.embedSWF(\"{0}{1}&rel=0&amp;enablejsapi=1&amp;playerapiid=ytapiplayer" + registroId + "\", \"ytapiplayer" + registroId + "\", \"{2}\", \"{3}\", \"8\", null, null, params, atts); ",
                    _stylePlayer,
                    formatVideoUrl(urlVideo),
                    width,
                    height));
            str.AppendLine("}");
			str.AppendLine(" //]]> ");
			str.AppendLine(" </script> ");


			return str.ToString();
		}

		private static string formatVideoUrl(string urlVideo)
		{
            
            if (urlVideo.Contains("user"))
            {
                string[] videoCod;
                videoCod = urlVideo.Split('/');
                return string.Concat("http://www.youtube.com/v/", videoCod[videoCod.Count() - 1]);
            }
            if (urlVideo.Contains("="))
			{
				return string.Concat("http://www.youtube.com/v/", urlVideo.Split('=')[1]);
			}
			else
			{
				return urlVideo;
			}
		}
	}
}