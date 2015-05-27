using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;


public partial class controls_menus_menuRodape : SmartUserControl
{
    #region Properties

    /// <summary>
    /// Propety to apply on Panel (div)
    /// </summary>
    public String CssClass { get; set; }

    /// <summary>
    /// Type of menu to show your children
    /// </summary>
    public MenuPrincipal TipoMenuPrincipal { get; set; }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindControl();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind the control based on property values specified
    /// </summary>
    protected void BindControl()
    {
        pnlBoxMenuRodape.CssClass = this.CssClass;
        SecaoService secaoService = new SecaoService();
        SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
        Secao secao = secaoService.Carregar(new Secao() { SecaoId = this.TipoMenuPrincipal.GetHashCode() });
        if (secao != null)
        {
            SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = secao, Idioma = Util.CurrentIdioma });

			if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
            {
                ltlTituloBox.Text = secaoIdioma.Titulo;
                List<Secao> listaSecao = secaoService.CarregarFilhos(secao.SecaoId, true);

                if (listaSecao != null)
                {
                    foreach (Secao item in listaSecao)
                    {
                        if (Convert.ToBoolean(item.ExibeNoMenu))
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            HyperLink hlSecao = new HyperLink();
							Label lblPipe = new Label();
							lblPipe.Text = "|";
                            secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = item, Idioma = Util.CurrentIdioma });

							if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
                            {
                                ModeloService modeloService = new ModeloService();
                                Modelo modelo = modeloService.Carregar(new Modelo() { ModeloId = item.Modelo.ModeloId });

                                if (modelo != null)
                                {
                                    hlSecao.Text = secaoIdioma.Titulo + " ";
                                    hlSecao.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", item.SecaoId);
                                    li.Controls.Add(hlSecao);
									li.Controls.Add(lblPipe);
                                    ul.Controls.Add(li);
                                }
                            }
                        }
                    }
                }
            }
        }

        if (ul.Controls.Count == 0)
        {
            this.Visible = false;
        }
        else
        {
            HtmlGenericControl lastLi = (HtmlGenericControl)ul.Controls[ul.Controls.Count - 1];
            lastLi.Attributes.Add("class", "last");
        }
    }

    #endregion
}
