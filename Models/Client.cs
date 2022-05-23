using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWebMvcCore.Models
{
    public partial class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es obligatorio.")]
        [MinLength(4, ErrorMessage = "El campo debe tener una longitud mínima de 4 carácteres."),
         MaxLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 carácteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo Apellido es obligatorio.")]
        [MinLength(4, ErrorMessage = "El campo debe tener una longitud mínima de 4 carácteres."),
         MaxLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 carácteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Campo Dni es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo debe tener una longitud máxima de 10 números.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El Campo Correo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 carácteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Campo Dirección es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 carácteres.")]
        public string Address { get; set; }
    }
}
