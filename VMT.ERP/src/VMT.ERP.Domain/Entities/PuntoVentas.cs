namespace VMT.ERP.Domain.Entities;

public partial class PuntoVentas
{
    public int PuntovtaId { get; set; }

    public string? PuntovtaNombre { get; set; }

    public int? PuntoEmisionId { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? SucursalId { get; set; }

    public virtual PuntoEmisionSri Puntovta { get; set; } = null!;

    public virtual Sucursal? Sucursal { get; set; }
}