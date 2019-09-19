using CadeMeuPet.Data.EntityConfiguration;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Data.Contexto
{
    public class CadeMeuPetContexto : DbContext
    {
        public CadeMeuPetContexto() : base("ProjetoCadeMeuPet")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<EspecieAnimal> EspecieAnimal { get; set; }
        public DbSet<CorAnimal> CorAnimal { get; set; }
        public DbSet<RacaAnimal> RacaAnimal { get; set; }
        public DbSet<PorteAnimal> PorteAnimal { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<ImagemAnimal> ImagemAnimal { get; set; }
        public DbSet<Fotos> FotosAnimal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new LocalizacaoConfiguration());
            modelBuilder.Configurations.Add(new AnimalConfiguration());
            modelBuilder.Configurations.Add(new EspecieAnimalConfiguration());
            modelBuilder.Configurations.Add(new RacaAnimalConfiguration());
            modelBuilder.Configurations.Add(new CorAnimalConfiguration());
            modelBuilder.Configurations.Add(new PorteAnimalConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new CidadeConfiguration());
            modelBuilder.Configurations.Add(new FotosConfiguration());
        }
    }
}
