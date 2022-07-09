namespace GetAPet.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PetEntityTypeConfig : IEntityTypeConfiguration<Pet>
{
	public void Configure(EntityTypeBuilder<Pet> builder)
	{
		builder.ToTable("Pets");
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id).IsRequired();
		builder.Property( p => p.Name ).IsRequired();
		builder.Property( p => p.Species ).IsRequired();
		builder.Property( p => p.Price ).IsRequired();
		builder.Property( p => p.Price ).HasColumnType("decimal(8,2)");
	}
}