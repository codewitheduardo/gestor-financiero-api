using Microsoft.EntityFrameworkCore;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Entrada -> TipoIngreso usando shadow FK "TipoIngresoId"
            modelBuilder.Entity<Entrada>()
                .HasOne(e => e.TipoIngreso)
                .WithMany(t => t.Entradas)
                .HasForeignKey("TipoIngresoId")
                .OnDelete(DeleteBehavior.NoAction);

            // Salida -> TipoGasto usando shadow FK "TipoGastoId"
            modelBuilder.Entity<Salida>()
                .HasOne(s => s.TipoGasto)
                .WithMany(t => t.Salidas)
                .HasForeignKey("TipoGastoId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Monto)
                .HasPrecision(18, 2);
        }
     
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<TipoIngreso> TipoIngresos { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
    }
}
