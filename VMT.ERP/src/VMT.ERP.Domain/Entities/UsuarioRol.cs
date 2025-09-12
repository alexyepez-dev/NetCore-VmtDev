namespace VMT.ERP.Domain.Entities;

public partial class UsuarioRol
{
    public int UsuRolId { get; set; }

    public int? UsuId { get; set; }

    public int? RolId { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Rol? Rol { get; set; }

    public virtual Usuario? Usu { get; set; }
}