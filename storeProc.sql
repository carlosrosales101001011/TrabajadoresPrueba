use TrabajadoresPrueba
go
create proc sp_listar_trabajadores
as
begin
	
	SELECT
    T.Id,
    T.TipoDocumento,
    T.NumeroDocumento,
    T.Nombres,
    T.Sexo,
	D.Id[IdDep],
    D.NombreDepartamento AS 'Departamento',
	Ds.Id[IdDis],
    Ds.NombreDistrito AS 'Distrito',
	P.Id[IdProv],
    P.NombreProvincia AS 'Provincia'
FROM [dbo].[Trabajadores] T
    INNER JOIN [dbo].[Departamento] D ON T.IdDepartamento = D.Id
    INNER JOIN [dbo].[Provincia] P ON T.IdProvincia = P.Id
    INNER JOIN [dbo].[Distrito] Ds ON T.IdDistrito = Ds.Id;
end
