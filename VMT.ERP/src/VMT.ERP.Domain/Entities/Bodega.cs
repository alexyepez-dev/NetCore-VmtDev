namespace VMT.ERP.Domain.Entities;

public partial class Bodega
{
    public int BodegaId { get; set; }

    public string? BodegaNombre { get; set; }

    public string? BodegaDireccion { get; set; }

    public string? BodegaTelefono { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? SucursalId { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}