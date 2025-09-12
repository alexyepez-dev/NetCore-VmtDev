namespace VMT.ERP.Domain.Entities;

public partial class TarjetaCredito
{
    public int TarjetacredId { get; set; }

    public string? TarjetacredDescripcion { get; set; }

    public int? IndustriaId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Industrias? Industria { get; set; }

    public virtual ICollection<MovimientoDePago> MovimientoDetPagos { get; set; } = [];
}