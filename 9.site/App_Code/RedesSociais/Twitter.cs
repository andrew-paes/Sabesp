using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Net;
using System.Configuration;
using Sabesp.Interfaces;

namespace RedesSociais
{
	/// <summary>
	/// Summary description for Twitter
	/// </summary>
	public class Twitter : IRedesSociais
	{
		public Twitter()
		{
			Nome = "Twitter";
			Page = 1;
		}

		#region IRedesSociais Members

		private string _nome;

		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}

		public int Total
		{
			get
			{
				return 20;
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
			return new RedesSociais.Twitter()
			{
				Nome = "Twitter Teste"
			};
		}

		#endregion

		#region Properties

		public static string TwitterAccount
		{
			get
			{
				return ConfigurationManager.AppSettings["TwitterAccount"]; ;
			}
		}

		public int Posts { get; set; }

		public int Page { get; set; }

		#endregion

		public DataSet GetPostsTwitter(Twitter twitter)
		{
			WebRequest Req = WebRequest.Create(String.Concat("http://twitter.com/statuses/user_timeline/", TwitterAccount, ".xml?", GetUrlPart()));
			WebResponse Resp = Req.GetResponse();
			StreamReader sr = new StreamReader(Resp.GetResponseStream());
			DataSet ds = new DataSet();
			ds.ReadXml(sr);
			sr.Close();
			Resp.Close();

			return ds;
		}

		private string GetUrlPart()
		{
			if (Posts > 0)
			{
				return String.Concat("count=", Posts);
			}
			else
			{
				return String.Concat("page=", Page);
			}
		}
	}
}