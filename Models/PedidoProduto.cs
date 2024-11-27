public class PedidoProduto
{
    public int Id { get; set; }
    public int ProdutoId { get; set; } // Chave estrangeira para o Produto
    public int PedidoId {get; set; } // Chave estrangeira para o Pedido
}
