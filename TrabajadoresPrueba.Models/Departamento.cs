﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresPrueba.DAL.DataContext;

public partial class Departamento
{
    public int Id { get; set; }

    public string? NombreDepartamento { get; set; }
    [JsonIgnore]
    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
    [JsonIgnore]
    public virtual ICollection<Trabajadores> Trabajadores { get; set; } = new List<Trabajadores>();
}
