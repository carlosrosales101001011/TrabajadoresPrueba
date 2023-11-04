using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresPrueba.DAL.DataContext;

public partial class Provincia
{
    public int Id { get; set; }

    public int? IdDepartamento { get; set; }

    public string? NombreProvincia { get; set; }
    [JsonIgnore]
    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();
    [JsonIgnore]
    public virtual Departamento? oDepartamento { get; set; }
    [JsonIgnore]
    public virtual ICollection<Trabajadores> Trabajadores { get; set; } = new List<Trabajadores>();
}
