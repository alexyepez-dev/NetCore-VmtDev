namespace VMT.ERP.Domain.Entities;

public partial class Stock
{
    public long StockId { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public int? BodegaId { get; set; }

    public int? ProdId { get; set; }

    public int? CantidadStock { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Empresa? Empresa { get; set; }
}