using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bluejay.Models
{
    [Table("AspNetCompanies")]
    public class ApplicationCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required, StringLength (250)]
        public string Nombre { get; set; }        
        public bool IsActive { get; set; }

        //Se agrega relacion N-N con la clase ApplictionUser, una compañia puede tener muchos Usuarios.
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}