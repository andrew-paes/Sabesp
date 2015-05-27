using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_conteudoAvaliacao : SmartUserControl
{

	#region Properties

	public string UrlRSS
	{
		get
		{
			return lnkRSS.NavigateUrl;
		}
		set
		{
			lnkRSS.NavigateUrl = value;
		}
	}

	public bool HideRSS
	{
		get
		{
			return !(liRSS.Visible);
		}
		set
		{
			liRSS.Visible = !(value);
		}
	}
	public bool HideTwitter { get; set; }
	public bool HideFacebook { get; set; }
	public bool HideYoutube { get; set; }
	public bool HideDelicious { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	#endregion

	protected void LoadPage()
	{
		var lblConteudo = (Label)this.FindControl("lblConteudo");
		var ltrComportilhe = (Literal)this.FindControl("ltrComportilhe");
		var ltrImprima = (Literal)this.FindControl("ltrImprima");
		var hlVoteBad = (HyperLink)this.FindControl("hlVoteBad");
		var hlVoteGood = (HyperLink)this.FindControl("hlVoteGood");
		var hdnConteudoId = (HtmlInputHidden)this.FindControl("hdnConteudoId");

		lblConteudo.Text = GetLocalResourceObject(lblConteudo.ID).ToString();
		ltrComportilhe.Text = GetLocalResourceObject(ltrComportilhe.ID).ToString();
		ltrImprima.Text = GetLocalResourceObject(ltrImprima.ID).ToString();

		ConteudoAvaliacaoService conteudoAvaliacaoService = new ConteudoAvaliacaoService();
		ConteudoAvaliacao conteudoAvaliacao = conteudoAvaliacaoService.CarregarToSite(RegistroId);
		if (conteudoAvaliacao != null)
		{
			hlVoteBad.Text = conteudoAvaliacao.TotalNegativo.ToString();
			hlVoteGood.Text = conteudoAvaliacao.TotalPositivo.ToString();

			Cookie ck = new Cookie();
			if (ck.Avaliados.Contains(RegistroId))
			{
				hlVoteBad.NavigateUrl = string.Empty;
				hlVoteGood.NavigateUrl = string.Empty;
			}
		}
		else
		{
			hlVoteBad.Text = "0";
			hlVoteGood.Text = "0";
		}

		hdnConteudoId.Value = RegistroId.ToString();

		hlCompartilhe.NavigateUrl = String.Concat(Request.Url.AbsoluteUri, "#");
	}


	#region altera icones de compartilhamentos individuais

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do twitter.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	public void SetTwitter(string titulo, string url)
	{
		if (!this.HideTwitter)
		{
			if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
			{
				lnkTwitter.NavigateUrl = String.Format("http://twitter.com/home?status={0}+{1}", titulo, url);
			}
		}
		else
		{
			liTwitter.Visible = false;
		}
	}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Delicious.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	public void SetDelicious(string titulo, string url)
	{
		if (!this.HideDelicious)
		{
			if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
			{
				lnkDelicious.NavigateUrl = String.Format("http://del.icio.us/post?url={1}&amp;title={0}", titulo, url);
			}
		}
		else
		{
			liDelicious.Visible = false;
		}
	}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Facebook.
	/// </summary>
	/// <param name="url">Link</param>
	public void SetFacebook(string url)
	{
		if (!this.HideFacebook)
		{
			if (!string.IsNullOrEmpty(url))
			{
				lnkFacebook.NavigateUrl = String.Format("http://www.facebook.com/share.php?u={0}", url);
			}
		}
		else
		{
			liFacebook.Visible = false;
		}
	}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Digg.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	//public void SetDigg(string titulo, string url)
	//{
	//    if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
	//    {
	//        hl_digg.NavigateUrl = String.Format("http://digg.com/submit?phase=2&amp;url={1}&amp;title={0}", titulo, url);
	//    }
	//}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Technorati.
	/// </summary>
	/// <param name="url">Link</param>
	//public void SetTechnorati(string url)
	//{
	//    if (!string.IsNullOrEmpty(url))
	//    {
	//        hl_technorati.NavigateUrl = String.Format("http://technorati.com/faves?add={0}", url);
	//    }
	//}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Reddit.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	//public void SetReddit(string titulo, string url)
	//{
	//    if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
	//    {
	//        hl_reddit.NavigateUrl = String.Format("http://reddit.com/submit?url={1}&amp;title={0}", titulo, url);
	//    }
	//}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do Stumbleupon.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	//public void SetStumbleupon(string titulo, string url)
	//{
	//    if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
	//    {
	//        hl_stumbleupon.NavigateUrl = String.Format("http://www.stumbleupon.com/submit?url={1}&amp;title={0}", titulo, url);
	//    }
	//}

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar do FriendFeed.
	/// </summary>
	/// <param name="titulo">Descrição</param>
	/// <param name="url">Link</param>
	//public void SetFriendFeed(string titulo, string url)
	//{
	//    if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
	//    {
	//        hl_ff.NavigateUrl = String.Format("http://friendfeed.com/?url={1}&title={0}", titulo, url);
	//    }
	//}

	#endregion

	/// <summary>
	/// Metodo para preencher os parametros de compartilhar de todos.
	/// </summary>
	/// <param name="titulo">Descricao</param>
	/// <param name="url">Link</param>
	public void SetAll(string titulo, string url)
	{
		url = HttpUtility.UrlEncode(url);
		titulo = HttpUtility.UrlEncode(titulo);
		if ((!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(titulo)))
		{
			SetTwitter(titulo, url);
			SetDelicious(titulo, url);
			//SetDigg(titulo, url);
			//SetStumbleupon(titulo, url);
			//SetFriendFeed(titulo, url);
			//SetReddit(titulo, url);
			if (!string.IsNullOrEmpty(url))
			{
				//SetTechnorati(url);
				SetFacebook(url);
			}
		}
	}

}
