namespace VMT.ERP.Domain.Entities;

public partial class MovimientoDeProducto
{
    public int MovidetProdId { get; set; }

    public int? MovicabId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual MovimientoCab? Movicab { get; set; }

    public virtual Producto? Producto { get; set; }
}