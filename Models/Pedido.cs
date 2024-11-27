public class Pedido
{
	public int Id { get; set; }
    public int StatusId { get; set; } // Chave estrangeira para o Status
    public float Valor { get; set; }
}
