using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using AG2.Sabesp.HotWords;

public partial class rss_rss_imprensa : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.ContentType = "text/xml";
		Response.Write(MontaRSS());
	}

	protected List<Release> BindRSS()
	{
		ReleaseService releaseService = new ReleaseService();
		List<Release> releaseBOList = new List<Release>();
		ReleaseFH releaseFH = new ReleaseFH();

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		releaseBOList = (List<Release>)releaseService.CarregarTodosSite(50, dataExibicaoInicio, orderBy, releaseFH);

		return releaseBOList;
	}

	public string MontaRSS()
	{
		StringBuilder rss = new StringBuilder();
		rss.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
		rss.Append("<rss xmlns:itunes=\"http://www.itunes.com/dtds/podcast-1.0.dtd\" version=\"2.0\">");
		rss.Append("<channel>");
		rss.Append("<title><![CDATA[SABESP]]></title>");
		rss.Append(String.Concat("<link>", "<![CDATA[", "http://www.sabesp.com.br", "]]>", "</link>"));
		rss.Append("<description><![CDATA[SABESP]]></description>");
		rss.Append("<copyright><![CDATA[Copyright 2010 Sabesp - Todos os direitos reservados]]></copyright>");

		List<Release> releaseBOList = this.BindRSS();

		if (releaseBOList != null && releaseBOList.Count > 0)
		{
			foreach (Release releaseBOTemp in releaseBOList)
			{
				ReleaseIdioma releaseIdiomaBOTemp = new ReleaseIdioma();
				releaseIdiomaBOTemp.Release = new Release();
				releaseIdiomaBOTemp.Release.Conteudo = new Conteudo();
				releaseIdiomaBOTemp.Release.Conteudo.ConteudoId = releaseBOTemp.Conteudo.ConteudoId;
				releaseIdiomaBOTemp.Idioma = new Idioma();
				releaseIdiomaBOTemp.Idioma.IdiomaId = Convert.ToInt32(Request.QueryString["idioma"]);

				ReleaseIdioma releaseIdiomaBO = new ReleaseIdioma();
				releaseIdiomaBO = new ReleaseIdiomaService().Carregar(releaseIdiomaBOTemp);

				if (releaseIdiomaBO != null)
				{
					string urlSiteMasterPage = Request.Url.ToString();
					string rawUrlSiteMasterPage = Convert.ToString(Request.RawUrl);
					string diretorioRaizSite = urlSiteMasterPage.Replace(rawUrlSiteMasterPage, "");
					string urlLink = ResolveUrl("~/imprensa/Releases-Detalhes.aspx?secaoId=193&id=" + releaseBOTemp.Conteudo.ConteudoId);
					string urlLinkAbsoluth = String.Concat(diretorioRaizSite, urlLink);

					rss.Append("<item>");
					rss.AppendFormat("<title><![CDATA[{0}]]></title>", releaseIdiomaBO.TituloRelease);
					rss.Append(String.Concat("<link>", "<![CDATA[", urlLinkAbsoluth, "]]>", "</link>"));
					rss.AppendFormat("<description><![CDATA[{0}]]></description>", String.Empty);

					string[] ordenacao = { "ordem" };
					string[] orientacao = { "ASC" };
					/*
					ReleaseImagemService releaseImagemService = new ReleaseImagemService();
					ReleaseImagemFH releaseImagemFH = new ReleaseImagemFH();
					releaseImagemFH.ReleaseId = releaseBOTemp.Conteudo.ConteudoId.ToString();

					List<ReleaseImagem> releaseImagens = (List<ReleaseImagem>)releaseImagemService.RetornaTodos(0, 0, ordenacao, orientacao, releaseImagemFH);

					if (releaseImagens != null && releaseImagens.Count > 0)
					{
						Arquivo arquivoBO = new Arquivo();
						arquivoBO.ArquivoId = releaseImagens[0].Arquivo.ArquivoId;
						arquivoBO = new ArquivoService().Carregar(arquivoBO);

						string urlMedia = ResolveUrl("~/Uploads/secao/" + arquivoBO.NomeArquivo);
						string urlMediaAbsoluth = String.Concat(diretorioRaizSite, urlMedia);

						rss.AppendFormat("<enclosure url=\"{0}\" length=\"\" type=\"audio/mpeg\"/>", urlMediaAbsoluth);
						rss.AppendFormat("<itunes:author><![CDATA[{0}]]></itunes:author>", releaseBOTemp.Autor);
						rss.AppendFormat("<itunes:subtitle><![CDATA[{0}]]></itunes:subtitle>", String.Empty);
						rss.AppendFormat("<itunes:keywords><![CDATA[{0}]]></itunes:keywords>", String.Empty);
					}
					*/
					rss.AppendFormat("<pubDate><![CDATA[{0}]]></pubDate>", Convert.ToDateTime(releaseBOTemp.DataHoraPublicacao).ToString("yyyy-MM-dd HH:mm:ss"));
					rss.Append("</item>");
				}
			}
		}

		rss.Append("</channel>");
		rss.Append("</rss>");

		return rss.ToString();
	}
}
