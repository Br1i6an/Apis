﻿using System.ComponentModel.DataAnnotations;

namespace Ejercicio.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
