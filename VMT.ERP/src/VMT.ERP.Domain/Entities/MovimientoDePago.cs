namespace VMT.ERP.Domain.Entities;

public partial class MovimientoDePago
{
    public int MovidetPagoId { get; set; }

    public int? MovicabId { get; set; }

    public int? FpagoId { get; set; }

    public decimal? ValorPagado { get; set; }

    public int? IndustriaId { get; set; }

    public string? Lote { get; set; }

    public string? Voucher { get; set; }

    public int? TarjetacredId { get; set; }

    public int? BancoId { get; set; }

    public int? ComprobanteId { get; set; }

    public string? FechaPago { get; set; }

    public int? ClienteId { get; set; }

    public virtual FormaPago? Fpago { get; set; }

    public virtual MovimientoCab? Movicab { get; set; }

    public virtual TarjetaCredito? Tarjetacred { get; set; }
}