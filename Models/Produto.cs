public class Produto
{
	public int Id { get; set; }
	public string Nome { get; set; } = string.Empty;
    public string PathImage { get; set; } = string.Empty;
    public decimal Preco { get; set; }  
	public string DescricaoBase { get; set; } = string.Empty;
    public string DescricaoInteira{ get; set; } = string.Empty;
    public int CategoriaId { get; set; } // Chave estrangeira para a Categoria
}
