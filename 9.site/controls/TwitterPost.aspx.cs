using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedesSociais;
using Sabesp.Enumerators;

public partial class TwitterPost : Page
{
	#region Properties

	protected RedesSociais.Control redesSociais = new RedesSociais.Control();

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			readTweets();
		}
	}

	public override void DataBind()
	{
		base.DataBind();
	} 

	#endregion

	#region Methods

	/// <summary>
	/// 
	/// </summary>
	public void readTweets()
	{
		Twitter twitter = new Twitter();

		try
		{
			twitter.Page = 1;
			DataSet dsTwitter = null;
			dsTwitter = (DataSet)Cache["dsTwitter"];
			if (dsTwitter == null)
			{
				dsTwitter = twitter.GetPostsTwitter(twitter);
                Cache.Add("dsTwitter", dsTwitter, null, DateTime.Now.AddMinutes(2), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
			}

			DataTableCollection dtcPostsTwitter = dsTwitter.Tables;
			rptTwitter.DataSource = dtcPostsTwitter["status"];
			rptTwitter.DataBind();

			int totalposts = dtcPostsTwitter["status"].Rows.Count;
			for (int i = 0; i < totalposts; i++)
			{
				Literal litTextoDt = (Literal)rptTwitter.Items[i].FindControl("litTextoDt");
				litTextoDt.Text = this.MakeLink(dtcPostsTwitter["status"].Rows[i][2].ToString(), TwitterLinks.Url);
				litTextoDt.Text = this.MakeLink(litTextoDt.Text, TwitterLinks.HashTag);
				litTextoDt.Text = this.MakeLink(litTextoDt.Text, TwitterLinks.User);
			}
		}
		catch
		{
			//lblErro.Text = "Não foi possivel estabelecer conexão com o twitter. <br /> Erro: " + ex.ToString();
		}
	}

	protected string MakeLink(string txt, TwitterLinks tipoLink)
	{
		Regex regx = null;

		switch (tipoLink)
		{
			case Sabesp.Enumerators.TwitterLinks.Url:
				regx = new Regex("http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
				break;
			case Sabesp.Enumerators.TwitterLinks.HashTag:
				regx = new Regex(@"#([\w]*)", RegexOptions.IgnoreCase);
				break;
			case Sabesp.Enumerators.TwitterLinks.User:
				regx = new Regex(@"@([\w]*)", RegexOptions.IgnoreCase);
				break;
			default:
				break;
		}

		MatchCollection mactches = regx.Matches(txt);

		int totalMatches = mactches.Count;
		for (int i = 0; i < totalMatches; i++)
		{
			switch (tipoLink)
			{
				case Sabesp.Enumerators.TwitterLinks.Url:
					txt = txt.Replace(mactches[i].Value, String.Concat("<a href=\"", mactches[i].Value, "\" target=\"_blank\">", mactches[i].Value, "</a>"));
					break;
				case Sabesp.Enumerators.TwitterLinks.HashTag:
					txt = txt.Replace(mactches[i].Value, String.Concat("<a href=\"http://search.twitter.com/search?q=", mactches[i].Value.Replace("#", "%23"), "\" target=\"_blank\">", mactches[i].Value, "</a>"));
					break;
				case Sabesp.Enumerators.TwitterLinks.User:
					txt = txt.Replace(mactches[i].Value, String.Concat("<a href=\"http://twitter.com/", mactches[i].Value.Replace("@", ""), "\" target=\"_blank\">", mactches[i].Value, "</a>"));
					break;
				default:
					break;
			}
		}

		return txt;
	}  

	#endregion
}
