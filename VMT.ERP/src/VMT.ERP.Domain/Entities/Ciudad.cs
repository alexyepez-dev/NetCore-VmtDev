namespace VMT.ERP.Domain.Entities;

public partial class Ciudad
{
    public int CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? PaisId { get; set; }

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual Pais? Pais { get; set; }
}