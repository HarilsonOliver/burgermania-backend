
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

            base.OnModelCreating(modelBuilder);

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
        }
    }

