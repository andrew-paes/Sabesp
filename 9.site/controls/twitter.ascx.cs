using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using RedesSociais;
using Sabesp.Enumerators;
using Sabesp.Interfaces;

public partial class CtlTwitter : SmartUserControl, IDinamicControl
{

	#region Properties

	public int ControleId { get; set; }

	protected RedesSociais.Control redesSociais = new RedesSociais.Control();

	#endregion

	#region Constructors

	public CtlTwitter() { }

	public CtlTwitter(int controleId)
	{
		this.ControleId = controleId;
	}

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			ttlTwitter.Text = "Siga a Sabesp no Twitter"; //Resources.Blog.ttlTwitter;
			lnkMore.Text = "mais"; //Resources.Blog.lnkTweetsMaisAntigos;
            lnkMore.Target = "_blank";
            lnkMore.NavigateUrl = "http://twitter.com/" + RedesSociais.Twitter.TwitterAccount;
		}
	}

	public override void DataBind()
	{
		base.DataBind();
        ttlTwitter.Text = "Siga a Sabesp no Twitter"; //Resources.Blog.ttlTwitter;
        lnkMore.Text = "mais"; //Resources.Blog.lnkTweetsMaisAntigos;
        lnkMore.Target = "_blank";
        lnkMore.NavigateUrl = "http://twitter.com/" + RedesSociais.Twitter.TwitterAccount;
		//code goes here
	}

	#endregion

}