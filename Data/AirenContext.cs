using AirenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AirenApi.Data;

public class AirenContext : DbContext {

    public AirenContext(DbContextOptions<AirenContext> opts) : base (opts) {}
    public DbSet<Personagem>? Personagens {get;set;}
    public DbSet<Potentia>? Potentias {get;set;}
    public DbSet<Afiliacao>? Afiliacaos {get;set;}
    public DbSet<Capitulo>? Capitulos {get;set;}
    public DbSet<Habilidade>? Habilidades {get;set;}
    public DbSet<Hobby>? Hobbies {get;set;}
    public DbSet<Parentesco>? Parentescos {get;set;}
    public DbSet<Tecnica>? Tecnicas {get;set;}
    public DbSet<Versao>? Versoes {get;set;}
    public DbSet<Volume>? Volumes {get;set;}

    protected override void OnModelCreating(ModelBuilder builder) {

        builder.Entity<Parentesco>()
            .HasOne(p => p.Personagem)
            .WithMany()
            .HasForeignKey(p => p.IdPersonagem)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Parentesco>()
            .HasOne(p => p.Parente)
            .WithMany()
            .HasForeignKey(p => p.IdParente)
            .OnDelete(DeleteBehavior.Restrict);
    }
}