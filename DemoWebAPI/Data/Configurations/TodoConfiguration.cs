using DemoWebAPI.Data.Entities;
using DemoWebAPI.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebAPI.Data.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        // Configuration de la clef primaire
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd(); // Pour dire à EF qu'un Guid est créé à chaque création de l'objet

        // Configuration des propriétés
        builder.Property(t => t.Title)
            .IsRequired() // NOT NULL
            .HasMaxLength(200); // Limite la taille maximum en caractères

        builder.Property(t => t.Description)
            .HasMaxLength(1000);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasDefaultValue(TodoStatus.NotStarted);

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); // TSQL

        builder.Property(t => t.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); // TSQL

        // Configuration de la relation
        builder.HasOne(t => t.User)
            .WithMany(u => u.Todos)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
