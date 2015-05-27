using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;


public partial class controls_menu_direita : SmartUserControl
{
    #region Properties

    SecaoService secaoService = new SecaoService();
    private int Depth { get; set; }
    
    #endregion
    
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CreateMenuLateral();
    }

    protected void rptMenuLateral_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
		if (e.Item.DataItem != null)
		{
			Secao secao = (Secao)e.Item.DataItem;
			if (secao.ExibeNoMenu.Value == true)
			{
				SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
				ModeloService modeloService = new ModeloService();
				SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = secao, Idioma = Util.CurrentIdioma });
				if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
				{
					secao.Modelo = modeloService.Carregar(secao.Modelo);
					if (secao.Modelo != null)
					{
						HtmlGenericControl liMenuLateral = (HtmlGenericControl)e.Item.FindControl("liMenuLateral");
						Label lblItemMenu = (Label)e.Item.FindControl("lblItemMenu");
						HyperLink hlItemMenu = (HyperLink)e.Item.FindControl("hlItemMenu");
						Repeater rptItemSubMenu = (Repeater)e.Item.FindControl("rptItemSubMenu");

						Secao secaoAtual = secaoService.Carregar(new Secao() { SecaoId = SecaoId });
						//if the section is the current, aplly the class attribute
						if (secaoAtual.SecaoId == secao.SecaoId || (secaoAtual.SecaoPai != null && secaoAtual.SecaoPai.SecaoId == secao.SecaoId))
						{
							liMenuLateral.Attributes.Add("class", "on");
						}
						hlItemMenu.Text = secaoIdioma.Titulo;
						hlItemMenu.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

						//verify if is the last item to apply the class attribute
						if (e.Item.ItemIndex == ((List<Secao>)((Repeater)sender).DataSource).Count - 1)
						{
							if (liMenuLateral.Attributes["class"] != null)
							{
								liMenuLateral.Attributes["class"] = String.Concat(liMenuLateral.Attributes["class"], " ", "last");
							}
							else
							{
								liMenuLateral.Attributes.Add("class", "last");
							}
						}

						//if the level is greater than 2 and section is the current, bind the repeater with grandchildren
						if (this.Depth > 2 && (secaoAtual.SecaoId == secao.SecaoId || (secaoAtual.SecaoPai != null && secaoAtual.SecaoPai.SecaoId == secao.SecaoId)))
						{
							List<Secao> grandchildren = secaoService.CarregarFilhos(secao.SecaoId, true);
							rptItemSubMenu.DataSource = grandchildren;
							rptItemSubMenu.DataBind();
						}
					}
					else //hide item if model don't exists
					{
						e.Item.Visible = false;
					}
				}
				else //hide item if there's no record for the current language
				{
					e.Item.Visible = false;
				}
			}
			else //hide 
			{
				e.Item.Visible = false;
			}
		}
    }

    protected void rptItemSubMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            Secao secao = (Secao)e.Item.DataItem;
            SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
            ModeloService modeloService = new ModeloService();
            SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = secao, Idioma = Util.CurrentIdioma });
			if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
            {
                secao.Modelo = modeloService.Carregar(secao.Modelo);
                if (secao.Modelo != null)
                {
                    HtmlGenericControl liSubMenuLateral = (HtmlGenericControl)e.Item.FindControl("liSubMenuLateral");
                    Label lblItemMenu = (Label)e.Item.FindControl("lblItemMenu");
                    HyperLink hlItemSubMenu = (HyperLink)e.Item.FindControl("hlItemSubMenu");

                    hlItemSubMenu.Text = secaoIdioma.Titulo;
                    hlItemSubMenu.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);

                    //if the section is the current, aplly the class attribute
                    if (SecaoId == secao.SecaoId)
                    {
                        hlItemSubMenu.CssClass = "on";
                    }

                    //verify if is the last item to apply the class attribute
                    if (e.Item.ItemIndex == ((List<Secao>)((Repeater)sender).DataSource).Count - 1)
                    {
                        if (liSubMenuLateral.Attributes["class"] != null)
                        {
                            liSubMenuLateral.Attributes["class"] = String.Concat(liSubMenuLateral.Attributes["class"], " ", "last");
                        }
                        else
                        {
                            liSubMenuLateral.Attributes.Add("class", "last");
                        }
                    }
                }
                else //hide item if model don't exists
                {
                    e.Item.Visible = false;
                }
            }
            else //hide item if there's no record for the current language
            {
                e.Item.Visible = false;
            }
        }
    } 

    #endregion

    #region Methods

    /// <summary>
    /// Bind the expansible menu
    /// </summary>
    protected void CreateMenuLateral()
    {
        this.Depth = secaoService.GetDepth(SecaoId);
        Secao secaoPai = null;
        Secao secao = secaoService.Carregar(new Secao() { SecaoId = SecaoId });
        List<Secao> children = null;

        switch (this.Depth)
        {
            case 2: //second level
                secaoPai = secao;
                children = secaoService.CarregarFilhos(secaoPai.SecaoId, true);
                break;
            case 3://third level
                secaoPai = secao.SecaoPai;
                children = secaoService.CarregarFilhos(secaoPai.SecaoId, true);
                break;
            case 4://fourth level
                secao = secaoService.Carregar(secao.SecaoPai);
                secaoPai = secao.SecaoPai;
                children = secaoService.CarregarFilhos(secaoPai.SecaoId, true);
                break;
            default:
                break;
        }

		children = this.GetOnlyActives(children);
        if (children != null && children.Count > 0)
        {
			rptMenuLateral.DataSource = children;
            rptMenuLateral.DataBind();
        }
        else
        {
            this.Visible = false;
        }
    }

	protected List<Secao> GetOnlyActives(List<Secao> secoes)
	{
		List<Secao> listaOk = new List<Secao>();

		if (secoes != null)
		{
			foreach (Secao secao in secoes)
			{
				if (Convert.ToBoolean(secao.ExibeNoMenu))
				{
					listaOk.Add(secao);
				}
			}
		}

		return listaOk;
	}

    #endregion
}
