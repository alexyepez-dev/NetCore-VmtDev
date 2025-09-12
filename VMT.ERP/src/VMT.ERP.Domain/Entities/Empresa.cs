namespace VMT.ERP.Domain.Entities;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string? EmpresaRuc { get; set; }

    public string? EmpresaNombre { get; set; }

    public string? EmpresaRazon { get; set; }

    public string? EmpresaDireccionMatriz { get; set; }

    public string? EmpresaTelefonoMatriz { get; set; }

    public int? CiudadId { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = [];

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSris { get; set; } = [];

    public virtual ICollection<Stock> Stocks { get; set; } = [];
}