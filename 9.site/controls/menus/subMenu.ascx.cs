using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;

public partial class controls_menus_subMenu : SmartUserControl
{
	#region Properties

	SecaoService secaoService = new SecaoService();

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.CreateSubMenu();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Bind the submenu based on current section
	/// </summary>
	protected void CreateSubMenu()
	{
		SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
		ModeloService modeloService = new ModeloService();
		bool showSubMenu = false;

		Secao verificaSecao = secaoService.Carregar(new Secao() { SecaoId = SecaoId });

		if (verificaSecao != null && verificaSecao.SecaoPai != null)
		{
			//load the first section of tree
			Secao secaoPai = secaoService.GetRoot(SecaoId);

			if (secaoPai != null)
			{
				//list the children of first section
				List<Secao> listaFilhos = secaoService.CarregarFilhos(secaoPai.SecaoId, true);

				if (listaFilhos != null)
				{
					HtmlGenericControl ul = new HtmlGenericControl("ul");

					foreach (Secao litem in listaFilhos)
					{
						//verify if item will be appear on menu
						if (litem.ExibeNoMenu != null && litem.ExibeNoMenu == true)
						{
							//load the current language to this section
							SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Idioma = Util.CurrentIdioma, Secao = litem });

							if (secaoIdioma != null && secaoIdioma.Ativo != null && secaoIdioma.Ativo.Value == true)
							{
								//load the model to this section
								Modelo modelo = modeloService.Carregar(litem.Modelo);

								if (modelo != null)
								{
									HtmlGenericControl li = new HtmlGenericControl("li");
									HyperLink linkMenu = new HyperLink();
									linkMenu.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", litem.SecaoId);
									linkMenu.Text = secaoIdioma.Titulo;
									li.Controls.Add(linkMenu);

									//Verify if the section or one of children is the current section to mark as ative
									if (this.SectionOnTree(litem.SecaoId))
									{
										li.Attributes.Add("class", "itmAtivo");
									}

									ul.Controls.Add(li);
									showSubMenu = true;
								}
							}
						}
					}

					if (ul.Controls.Count > 0)
					{
						//verify if is the last li to apply the class attribute
						HtmlGenericControl lastLi = ((HtmlGenericControl)ul.Controls[ul.Controls.Count - 1]);

						if (lastLi.Attributes["class"] != null)
						{
							lastLi.Attributes["class"] = String.Concat(lastLi.Attributes["class"], " ", "itmLast");
						}
						else
						{
							lastLi.Attributes.Add("class", "itmLast");
						}

						pnlSubMenu.Controls.Add(ul);
					}
				}
			}
		}

		this.Visible = showSubMenu;
	}

	/// <summary>
	/// Verify if the section or one of children is the current section to mark as ative
	/// </summary>
	/// <param name="secaoIdMenu"></param>
	/// <returns></returns>
	protected bool SectionOnTree(int secaoIdMenu)
	{
		Secao secaoAtual = secaoService.Carregar(new Secao() { SecaoId = SecaoId });

		if (secaoAtual != null)
		{
			if (secaoAtual.SecaoId == secaoIdMenu || (secaoAtual.SecaoPai != null && secaoAtual.SecaoPai.SecaoId == secaoIdMenu))
			{
				return true;
			}
			else
			{
				if (secaoAtual.SecaoPai != null)
				{
					secaoAtual.SecaoPai = secaoService.Carregar(secaoAtual.SecaoPai);

					if (secaoAtual.SecaoPai != null && secaoAtual.SecaoPai.SecaoPai != null && secaoAtual.SecaoPai.SecaoPai.SecaoId == secaoIdMenu)
					{
						return true;
					}
				}
			}
		}

		return false;
	}

	#endregion
}

