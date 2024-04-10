using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3S.Task.Persistence.Configurations
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasOne(c=>c.Governate)
				.WithMany()
				.HasForeignKey(c=>c.GovernateId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
