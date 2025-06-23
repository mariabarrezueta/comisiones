using System;

namespace MiniCoreComision.Models
{
    public class Venta
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public decimal Monto { get; set; }  // <-- cambiar a decimal

    public int VendedorId { get; set; }
    public Vendedor Vendedor { get; set; }
}

}
