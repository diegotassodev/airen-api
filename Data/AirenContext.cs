using AirenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AirenApi.Data;

public class AirenContext : DbContext {

    public AirenContext(DbContextOptions<AirenContext> opts) : base (opts) {}
    public DbSet<Personagem>? Personagens {get;set;}
    public DbSet<Potentia>? Potentias {get;set;}


    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Personagem>()
            .HasOne(personagem => personagem.Potentia)
            .WithOne(potentia => potentia.Personagem)
            .OnDelete(DeleteBehavior.Restrict);
    }
}