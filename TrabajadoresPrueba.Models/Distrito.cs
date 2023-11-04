using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresPrueba.DAL.DataContext;

public partial class Distrito
{
    public int Id { get; set; }

    public int? IdProvincia { get; set; }

    public string? NombreDistrito { get; set; }
    [JsonIgnore]
    public virtual Provincia? oProvincia { get; set; }
    [JsonIgnore]
    public virtual ICollection<Trabajadores> Trabajadores { get; set; } = new List<Trabajadores>();
}
