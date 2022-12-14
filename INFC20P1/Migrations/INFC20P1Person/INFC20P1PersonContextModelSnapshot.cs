// <auto-generated />
using INFC20P1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INFC20P1.Migrations.INFC20P1Person
{
    [DbContext(typeof(INFC20P1PersonContext))]
    partial class INFC20P1PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("INFC20P1.Models.Person", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pid"), 1L, 1);

                    b.Property<string>("pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("recieved")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("sent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("pid");

                    b.ToTable("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
