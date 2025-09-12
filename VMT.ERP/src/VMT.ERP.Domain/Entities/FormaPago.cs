namespace VMT.ERP.Domain.Entities;

public partial class FormaPago
{
    public int FpagoId { get; set; }

    public string? FpagoDescripcion { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<MovimientoDePago> MovimientoDetPagos { get; set; } = [];
}