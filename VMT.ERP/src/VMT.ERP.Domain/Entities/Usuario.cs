namespace VMT.ERP.Domain.Entities;

public partial class Usuario
{
    public int UsuId { get; set; }

    public string? UsuNombre { get; set; }

    public int? EmpresaId { get; set; }

    public int? Estado { get; set; }

    public string? FechaHoraReg { get; set; }

    public string? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = [];

    public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = [];

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = [];
}