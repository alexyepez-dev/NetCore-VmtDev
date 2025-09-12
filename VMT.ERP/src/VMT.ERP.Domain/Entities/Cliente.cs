namespace VMT.ERP.Domain.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? ClienteRuc { get; set; }

    public string? ClienteNombre1 { get; set; }

    public string? ClienteNombre2 { get; set; }

    public string? ClienteApellido1 { get; set; }

    public string? ClienteApellido2 { get; set; }

    public string? ClienteEmail { get; set; }

    public string? ClienteTelefono { get; set; }

    public string? ClienteDireccion { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateOnly? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();
}