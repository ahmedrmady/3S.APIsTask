using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.Property(a => a.GovernateId)
				   .IsRequired();

			builder.Property(a => a.CityId)
				   .IsRequired();

			builder.Property(a => a.Street)
				   .IsRequired()
				   .HasMaxLength(200);

			builder.Property(a => a.BuildingNumber)
				   .IsRequired();

			builder.Property(a => a.FlatNumber)
				   .IsRequired();

			//builder.HasOne(a => a.City)
			//	   .WithOne()
			//	   .;

			//builder.HasOne(a => a.Governate)
			//	   .WithOne();



		}
	}
}
