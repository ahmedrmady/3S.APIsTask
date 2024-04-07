using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                   .IsRequired().HasColumnType("nvarchar(20)")
                   .HasMaxLength(20);

            builder.Property(u => u.MiddleName)
                   .HasColumnType("nvarchar(40)")
                   .HasMaxLength(40);


            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasColumnType("nvarchar(20)")
                   .HasMaxLength(20);

            builder.Property(u => u.BirthDate)
                   //.Hasche("CK_User_BirthDate", "DATEDIFF(year, BirthDate, GETDATE()) >= 20")
                   .IsRequired();

            builder.Property(u => u.MobileNumber)
                   .IsRequired();

            builder.Property(u=>u.Email)
                   .IsRequired();

            //Realationship between the user and addresses => user with many addresses
            builder.HasMany(u => u.Addresses)
                   .WithOne(a=>a.User)
                   .HasForeignKey(a=>a.UserId);

		}
    }
}
