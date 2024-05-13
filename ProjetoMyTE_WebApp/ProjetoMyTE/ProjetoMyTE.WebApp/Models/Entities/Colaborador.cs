﻿using System.ComponentModel;

namespace ProjetoMyTE.WebApp.Models.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [DisplayName("Cargo")]
        public int IdCargo { get; set; }
        [DisplayName("Numero de Matrícula")]
        public int NumMatricula { get; set; }
        public string? Email { get; set; }
        [DisplayName("Administrador")]
        public bool Admin { get; set; }
        public Cargo? Cargo { get; set; }
    }
}
