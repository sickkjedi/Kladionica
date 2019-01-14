namespace Kladionica.DAL
{
    using System.Data.Entity;
    using Models;

    public sealed class KladionicaContext : DbContext
    {
        // Your context has been configured to use a 'KladionicaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Kladionica.DAL.KladionicaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KladionicaContext' 
        // connection string in the application configuration file.
        public KladionicaContext()
            : base($"name=KladionicaContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketPair> TicketPairs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}