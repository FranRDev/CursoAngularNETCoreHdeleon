using Microsoft.EntityFrameworkCore;

namespace CursoAngularNETCoreHdeleon.Models {

    public class MyDbContext : DbContext {

        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options) { }

        public DbSet<Message> Message { get; set; }

    }

    public class Message {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

    }

}