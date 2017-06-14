using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Aula_13._06_MVC.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório, favor verificar.")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
    }
}