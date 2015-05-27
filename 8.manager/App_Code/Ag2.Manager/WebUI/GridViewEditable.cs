using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Ag2.Manager.ADO.MSSql;
using Ag2.Manager.Module;
using System.Reflection;
using System.Web.UI.MobileControls;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Helper;

namespace Ag2.Manager.WebUI
{
    [Serializable]
    [ToolboxData("<{0}:GridViewEditable runat=server></{0}:GridViewEditable>")]
    public class GridViewEditable : System.Web.UI.WebControls.GridView, INamingContainer
    {
        private ManagerModule _managerModule;
        private bool _columnMultilanguage = false;
        private DataTable _idiomas;

        public GridViewEditable()
        {
            //
        }

        protected override void CreateChildControls()
        {
            this.ChildControlsCreated = true;
        }

        protected override void OnRowEditing(GridViewEditEventArgs e)
        {
            this.EditIndex = e.NewEditIndex;
            this.DataBind();
        }

        protected override void OnRowCancelingEdit(GridViewCancelEditEventArgs e)
        {
            this.EditIndex = -1;
            this.DataBind();
        }

        public void CreateListColumns()
        {
            int columnsCount = 0;
            BoundField listField;

            List<string> keys = new List<string>();
            keys.Add(ManagerModule.ModuleStructure.PrimaryKeyField);

            //seta campo ID do module
            string[] dataKeyNames = keys.ToArray();

            this.DataKeyNames = dataKeyNames;

            //adiciona campos adicionais a listagem
            foreach (ManagerModuleField field in ManagerModule.ModuleStructure.Fields)
            {
                //verifica se o campo vai ser exibido na lista
                if (field.ShowInList)
                {
                    listField = new BoundField();
                    listField.ShowHeader = true;
                    listField.HeaderText = field.Label;
                    listField.DataField = field.ListFieldName;
                    listField.SortExpression = field.Sort ? field.Name : "";
                    listField.Visible = true;
                    if (field.Type == ManagerModuleFieldType.Date)
                    {
                        listField.HtmlEncode = false;
                        listField.DataFormatString = "{0:dd/MM/yyyy}";
                    }

                    columnsCount++;

                    if (columnsCount == ManagerModule.ModuleStructure.Fields.Count)
                    {
                        listField.HeaderStyle.CssClass = "cabecalhoultimo";
                    }
                    else
                    {
                        listField.HeaderStyle.CssClass = "cabecalhoitem";
                    }

                    this.Columns.Add(listField);
                }
            }

            CreateColumnLanguage();

            ////Insere botões para edição
            //CommandField commandfield = new CommandField();
            //commandfield.HeaderText = string.Empty;
            //commandfield.ShowHeader = true;
            //commandfield.ButtonType = ButtonType.Link;
            //commandfield.ShowEditButton = true;
            //commandfield.EditText = "Editar";
            //commandfield.Visible = true;
            //commandfield.HeaderStyle.CssClass = "cabecalhoultimo";
            //commandfield.HeaderStyle.Width = Unit.Pixel(150);

            //this.Columns.Add(commandfield);
        }

        private void CreateColumnLanguage()
        {
            if (this.ManagerModule.ModuleStructure.Multilanguage && Ag2.Manager.Helper.ConfigurationManager.EnableMultiLanguage)
            {
                DataControlField datacontrolfield = this.Columns[this.Columns.Count - 1];

                if (datacontrolfield.HeaderText.Equals("Traduções", StringComparison.OrdinalIgnoreCase))
                {
                    this.Columns.Remove(datacontrolfield);
                }

                TemplateField templateField = new TemplateField();
                templateField.HeaderText = string.Empty;
                templateField.ShowHeader = true;
                templateField.Visible = true;
                templateField.HeaderStyle.CssClass = "cabecalhoultimo";
                templateField.HeaderStyle.Width = Unit.Pixel(150);
                templateField.HeaderText = "Traduções";

                //TemplateColumnCulture templatecolumnculture = new TemplateColumnCulture();
                //templateField.ItemTemplate = new TemplateColumnCulture();

                this.Columns.Add(templateField);
            }
        }

        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            //VERIFICA SE TEM A COLUNA DE MULTILANGUAGE
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCell tc = e.Row.Cells[this.Columns.Count - 1];
                if (tc.Text.Equals("Traduções", StringComparison.OrdinalIgnoreCase))
                {
                    _columnMultilanguage = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && _columnMultilanguage)
            {
                this.SelectedIndex = e.Row.RowIndex;
                Int32 registerId = 0;
                ManagerModule manager = new ManagerModule();

                //VERIFICA SE A KEY DA LINHA E UM INTEIRO
                if (int.TryParse(this.SelectedValue.ToString(), out registerId))
                {
                    //COLUNA REFERENTE AO MULTIIDIOMA
                    TableCell tc = e.Row.Cells[this.Columns.Count - 1];

                    List<Ag2.Manager.BusinessObject.Idioma> idiomas = manager.GetActiveIdiomas();

                    //ORDENA POR NOME DESC
                    idiomas.Sort(delegate(Ag2.Manager.BusinessObject.Idioma i1, Ag2.Manager.BusinessObject.Idioma i2)
                    {
                        return i2.Name.CompareTo(i1.Name);
                    });

                    foreach (Ag2.Manager.BusinessObject.Idioma idioma in idiomas)
                    {
                        string colummName = this.Idiomas.Columns[0].ColumnName;

                        DataRow[] rows = this.Idiomas.Select(string.Format("{0} = {1}", colummName, registerId.ToString()));

                        foreach (DataRow dr in rows)
                        {
                            if (idioma.IdiomaId.ToString().Equals(dr[1].ToString()))
                            {
                                string redirect = string.Format("~/content/edit.aspx?md={0}&id={1}&lg={2}", ManagerModule.ModuleStructure.Name, registerId.ToString(), idioma.IdiomaId.ToString());

                                redirect = ((Page)HttpContext.Current.Handler).ResolveUrl(redirect);

                                System.Web.UI.WebControls.ImageButton img = new System.Web.UI.WebControls.ImageButton();
                                img.Click += new ImageClickEventHandler(img_Click);
                                img.ImageUrl = idioma.Flag;
                                img.CssClass = "flagSpace";
                                img.ToolTip = idioma.Name;
                                img.Attributes.Add("OnClick", string.Format("RedirectEdit('{0}', this);", redirect));
                                img.Attributes.Add("style", "cursor: pointer;");
                                img.Attributes.Add("rel", idioma.IdiomaId.ToString());
                                img.CommandArgument = registerId.ToString();
                                tc.Controls.Add(img);
                                break;
                            }
                        }
                    }

                }
            }

            base.OnRowDataBound(e);
        }

        void img_Click(object sender, ImageClickEventArgs e)
        {
            int idiomaId = 0;
            ManagerModule manager = new ManagerModule();
            CurrentSessions cs = new CurrentSessions();
            HiddenField hdnIdioma = (HiddenField)((Page)HttpContext.Current.Handler).Master.FindControl("hdnIdioma");

            System.Web.UI.WebControls.ImageButton img = (System.Web.UI.WebControls.ImageButton)sender;
            idiomaId = Convert.ToInt32(hdnIdioma.Value);
            cs.CurrentIdioma = manager.LoadIdioma(new Idioma(idiomaId));

            string redirect = string.Format("~/content/edit.aspx?md={0}&id={1}&lg={2}", ManagerModule.ModuleStructure.Name, ((ImageButton)sender).CommandArgument.ToString(), idiomaId.ToString());

            HttpContext.Current.Response.Redirect(redirect);
        }

        public ManagerModule ManagerModule
        {
            get { return _managerModule; }
            set { _managerModule = value; }
        }

        public DataTable Idiomas
        {
            get { return _idiomas; }
            set { _idiomas = value; }
        }
    }

    /// <summary>
    /// Implementação do template para a coluna que mostra as informações de multilanguage dos registros
    /// </summary>
    public class TemplateColumnCulture : ITemplate
    {
        public TemplateColumnCulture()
        {

        }

        public void InstantiateIn(Control container)
        {

        }
    }
}
