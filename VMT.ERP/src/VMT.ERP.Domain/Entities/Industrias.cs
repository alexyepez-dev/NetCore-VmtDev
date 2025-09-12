namespace VMT.ERP.Domain.Entities;

public partial class Industrias
{
    public int IndustriaId { get; set; }

    public string? IndustriaDescripcion { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<TarjetaCredito> TarjetaCreditos { get; set; } = [];
}