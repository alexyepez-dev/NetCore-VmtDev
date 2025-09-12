namespace VMT.ERP.Domain.Entities;

public partial class Rol
{
    public int RolId { get; set; }

    public string? RolDescripcion { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public string? UsuIdAct { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = [];
}