namespace VMT.ERP.Domain.Entities;

public partial class Producto
{
    public int ProdId { get; set; }

    public string? ProdDescripcion { get; set; }

    public decimal? ProdUltPrecio { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? Estado { get; set; }

    public int? CategoriaId { get; set; }

    public int? EmpresaId { get; set; }

    public int? ProveedorId { get; set; }

    public int? MarcaId { get; set; }

    public virtual Categorias? Categoria { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<MovimientoDeProducto> MovimientoDetProductos { get; set; } = [];
}