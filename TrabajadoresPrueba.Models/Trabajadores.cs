using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresPrueba.DAL.DataContext;

public partial class Trabajadores
{
    public int Id { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Nombres { get; set; }

    public string? Sexo { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdProvincia { get; set; }

    public int? IdDistrito { get; set; }

    [JsonIgnore]
    public virtual Departamento? oDepartamento { get; set; }

    [JsonIgnore]
    public virtual Distrito? oDistrito { get; set; }

    [JsonIgnore]
    public virtual Provincia? oProvincia { get; set; }
}
