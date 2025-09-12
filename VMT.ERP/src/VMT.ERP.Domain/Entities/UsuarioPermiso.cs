namespace VMT.ERP.Domain.Entities;

public partial class UsuarioPermiso
{
    public int PermisoId { get; set; }

    public int? ModuloId { get; set; }

    public int? OpcionId { get; set; }

    public int? UsuId { get; set; }

    public short? EstadoPermiso { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Opcion? Opcion { get; set; }

    public virtual Usuario? Usu { get; set; }
}