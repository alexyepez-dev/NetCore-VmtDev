namespace VMT.ERP.Domain.Entities;

public partial class MovimientoCab
{
    public int MovicabId { get; set; }

    public int? TipomovId { get; set; }

    public int? TipomovIngEgr { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public int? BodegaId { get; set; }

    public string? SecuenciaFactura { get; set; }

    public string? AutorizacionSri { get; set; }

    public string? ClaveAcceso { get; set; }

    public int? ClienteId { get; set; }

    public int? PuntovtaId { get; set; }

    public int? ProveedorId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<MovimientoDePago> MovimientoDetPagos { get; set; } = [];

    public virtual ICollection<MovimientoDeProducto> MovimientoDetProductos { get; set; } = [];

    public virtual Proveedor? Proveedor { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual TipoMovimiento? Tipomov { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}