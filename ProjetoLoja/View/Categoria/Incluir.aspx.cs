﻿using ProjetoLoja.Controller;
using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoLoja.View.Categoria
{
    public partial class Incluir : System.Web.UI.Page
    {
        private readonly DatabaseEntity _contexto = new DatabaseEntity();
        private readonly CategoriaController _controller = new CategoriaController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var model = new Model.Categoria();
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