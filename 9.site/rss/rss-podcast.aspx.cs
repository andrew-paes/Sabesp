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

public partial class rss_rss_podcast : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.ContentType = "text/xml";
		Response.Write(MontaRSS());
	}

	protected List<Podcast> BindRSS()
	{
		PodcastService podcastService = new PodcastService();
		List<Podcast> podcastBOList = new List<Podcast>();
		PodcastFH podcastFH = new PodcastFH();
		podcastFH.BancoAudio = "0";

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		podcastBOList = (List<Podcast>)podcastService.RetornaTodosSite(50, dataExibicaoInicio, orderBy, podcastFH);

		return podcastBOList;
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

		List<Podcast> podcastBOList = this.BindRSS();

		if (podcastBOList != null && podcastBOList.Count > 0)
		{
			foreach (Podcast podcastBOTemp in podcastBOList)
			{
				PodcastIdioma podcastIdiomaBOTemp = new PodcastIdioma();
				podcastIdiomaBOTemp.Podcast = new Podcast();
				podcastIdiomaBOTemp.Podcast.Conteudo = new Conteudo();
				podcastIdiomaBOTemp.Podcast.Conteudo.ConteudoId = podcastBOTemp.Conteudo.ConteudoId;
				podcastIdiomaBOTemp.Idioma = new Idioma();
				podcastIdiomaBOTemp.Idioma.IdiomaId = Convert.ToInt32(Request.QueryString["idioma"]);

				PodcastIdioma podcastIdiomaBO = new PodcastIdioma();
				podcastIdiomaBO = new PodcastIdiomaService().Carregar(podcastIdiomaBOTemp);

				if (podcastIdiomaBO != null)
				{
					string urlSiteMasterPage = Request.Url.ToString();
					string rawUrlSiteMasterPage = Convert.ToString(Request.RawUrl);
					string diretorioRaizSite = urlSiteMasterPage.Replace(rawUrlSiteMasterPage, "");
					string urlLink = ResolveUrl("~/fique-por-dentro/podcasts-Detalhes.aspx?secaoId=65&id=" + podcastBOTemp.Conteudo.ConteudoId);
					string urlLinkAbsoluth = String.Concat(diretorioRaizSite, urlLink);

					rss.Append("<item>");
					rss.AppendFormat("<title><![CDATA[{0}]]></title>", podcastIdiomaBO.TituloPodcast);
					rss.Append(String.Concat("<link>", "<![CDATA[", urlLinkAbsoluth, "]]>", "</link>"));
					rss.AppendFormat("<description><![CDATA[{0}]]></description>", String.Empty);

					if (podcastIdiomaBO.ArquivoPodcast != null && podcastIdiomaBO.ArquivoPodcast.ArquivoId > 0)
					{
						Arquivo arquivoBO = new Arquivo();
						arquivoBO.ArquivoId = podcastIdiomaBO.ArquivoPodcast.ArquivoId;
						arquivoBO = new ArquivoService().Carregar(arquivoBO);

						string urlMedia = ResolveUrl("~/Uploads/secao/" + arquivoBO.NomeArquivo);
						string urlMediaAbsoluth = String.Concat(diretorioRaizSite, urlMedia);

						rss.AppendFormat("<enclosure url=\"{0}\" length=\"\" type=\"audio/mpeg\"/>", urlMediaAbsoluth);
						rss.AppendFormat("<itunes:author><![CDATA[{0}]]></itunes:author>", podcastBOTemp.Autor);
						rss.AppendFormat("<itunes:subtitle><![CDATA[{0}]]></itunes:subtitle>", String.Empty);
						rss.AppendFormat("<itunes:keywords><![CDATA[{0}]]></itunes:keywords>", String.Empty);
					}

					rss.AppendFormat("<pubDate><![CDATA[{0}]]></pubDate>", Convert.ToDateTime(podcastBOTemp.DataHoraPublicacao).ToString("yyyy-MM-dd HH:mm:ss"));
					rss.Append("</item>");
				}
			}
		}

		rss.Append("</channel>");
		rss.Append("</rss>");

		return rss.ToString();
	}
}
