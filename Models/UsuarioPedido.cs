public class UsuarioPedido
{
public int Id { get; set; }
public int UsuarioId { get; set; } // Chave estrangeira para o Usuário
public int PedidoId {get; set; } // Chave estrangeira para o Pedido
}
