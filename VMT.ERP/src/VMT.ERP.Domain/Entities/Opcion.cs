namespace VMT.ERP.Domain.Entities;

public partial class Opcion
{
    public int OpcionId { get; set; }

    public string? OpcionDescripcion { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? ModuloId { get; set; }

    public virtual Modulo? Modulo { get; set; }

    public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = [];
}