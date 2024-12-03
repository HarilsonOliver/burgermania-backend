
using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<UsuarioPedido> UsuarioPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produto>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PedidoProduto>()
                .HasOne<Produto>()
                .WithMany()
                .HasForeignKey(pp => pp.ProdutoId);

            modelBuilder.Entity<PedidoProduto>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<UsuarioPedido>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(up => up.UsuarioId);

            modelBuilder.Entity<UsuarioPedido>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(up => up.PedidoId);

            // Adicionando dados iniciais
             modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "X-Vegan", Descricao = "Para os amantes da vida animal.", PathImage = "/burgersCat.png" },
                new Categoria { Id = 2, Nome = "X-Fitness", Descricao = "Vestuário e acessórios", PathImage = "/burgersCat.png" },
                new Categoria { Id = 3, Nome = "X-Infarto", Descricao = "Comidas e bebidas", PathImage = "/burgersCat.png" }
            );

            // Dados de seed para Produto
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "X-Salada", PathImage = "/burgersCat.png", Preco = 20.00m, DescricaoBase = "Simples e Saudável", DescricaoInteira = "Constituido apenas de folhas frescas, Pão, blend de soja e azeite.", CategoriaId = 1 },
                new Produto { Id = 2, Nome = "X-Whey", PathImage = "/burgersCat.png", Preco = 50.00m, DescricaoBase = "Proteinado", DescricaoInteira = "Contem Pão, Queijos, Blend de Carnes Vermelhas e Brancas, Molho de Whey e Adicional do Suco. ", CategoriaId = 2 },
                new Produto { Id = 3, Nome = "X-Bacon Torrado", PathImage = "/burgersCat.png", Preco = 80.00m, DescricaoBase = "Chama o  SAMU", DescricaoInteira = "Pão  frito, Hamburger frito, Bacon frito e torrado, ovo frito, cebola frita e maionese temperada.", CategoriaId = 3 }
            );
                    base.OnModelCreating(modelBuilder);
        }

    }

