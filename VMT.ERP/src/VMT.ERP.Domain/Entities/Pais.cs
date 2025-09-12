namespace VMT.ERP.Domain.Entities;

public partial class Pais
{
    public int PaisId { get; set; }

    public string? PaisNombre { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = [];
}