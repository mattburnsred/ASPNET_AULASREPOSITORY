using ProjetoLoja.Controller;
using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoLoja.View.Produto
{
    public partial class Incluir : Page
    {
        private readonly DatabaseEntity _contexto = new DatabaseEntity();
        private readonly ProdutoController _controller = new ProdutoController();
        private readonly CategoriaController _controllerCategoria = new CategoriaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var categorias = _controllerCategoria.GetAllCategorias();

                listCategorias.DataSource = categorias.ToList();
                listCategorias.DataTextField = "Nome";
                listCategorias.DataValueField = "Id";
                listCategorias.DataBind();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var model = new Model.Produto();
            try
            {
                if (String.IsNullOrEmpty(txtNome.Text))
                {
                    var validaNome = "O campo 'Nome' não pode estar em branco, favor verificar!";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + validaNome + "');", false);

                    return;
                }

                model.Nome = txtNome.Text;
                model.Descricao = txtDescricao.Text;

                if (!chkAtivo.Checked)
                    model.IsAtivo = 0; // Inativo
                else
                    model.IsAtivo = 1; // Ativo

                model.IdCategoria = Convert.ToInt32(listCategorias.SelectedValue);

                _controller.Create(model);
            }
            catch
            {
                throw;
            }

            Response.Redirect("Index.aspx");
        }
    }
}