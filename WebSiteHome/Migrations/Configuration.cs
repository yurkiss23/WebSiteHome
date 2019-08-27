namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSiteHome.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebSiteHome.Models.ApplicationDbContext context)
        {
            context.Guitars.AddOrUpdate(g => g.Id,
                new Entities.TGuitar
                {
                    Id = 1,
                    Name = "Stratocaster",
                    Image = "https://media.sweetwater.com/api/i/q-82__ha-f48398094f630936__hmac-e3690791c0f95b33c771d6d181aa5219837dfc80/images/items/750/StratPMTP-large.jpg"
                });
            context.Guitars.AddOrUpdate(g => g.Id,
                new Entities.TGuitar
                {
                    Id = 2,
                    Name = "LesPaul",
                    Image = "https://media.sweetwater.com/api/i/q-82__ha-77b6f0aa5ca2e84b__hmac-b76d52f1240a4a0728229e98665c5defb30792a4/images/items/750/ENTPBCNH-large.jpg"
                });
            context.Guitars.AddOrUpdate(g => g.Id,
                new Entities.TGuitar
                {
                    Id = 3,
                    Name = "SG",
                    Image = "https://cdn11.bigcommerce.com/s-8wy6p2/images/stencil/2000x2000/products/6827/46472/IMG_0152__55875.1548883907.jpg?c=2"
                });
            context.Guitars.AddOrUpdate(g => g.Id,
                new Entities.TGuitar
                {
                    Id = 4,
                    Name = "Telecaster",
                    Image = "https://images.reverb.com/image/upload/s--0sC-r5D2--/f_auto,t_supersize/v1544743060/bz3nu4jvrs16phy3oatm.jpg"
                });

            context.SiteUsers.AddOrUpdate(u => u.Id,
                new Entities.User
                {
                    Id = 1,
                    FirstName = "Samppa",
                    LastName = "Nori",
                    DateBirth = Convert.ToDateTime("2012/01/01"),
                    Email = "q@q.q",
                    Phone = "123456789",
                    Password = "1",
                    Status = 1
                });
            context.SiteUsers.AddOrUpdate(u => u.Id,
                new Entities.User
                {
                    Id = 2,
                    FirstName = "Estavan",
                    LastName = "Lykos",
                    DateBirth = Convert.ToDateTime("2012/02/01"),
                    Email = "q@q.q",
                    Phone = "123456789",
                    Password = "2",
                    Status = 0
                });
            context.SiteUsers.AddOrUpdate(u => u.Id,
                new Entities.User
                {
                    Id = 3,
                    FirstName = "Chetan",
                    LastName = "Mohamed",
                    DateBirth = Convert.ToDateTime("2012/02/01"),
                    Email = "q@q.q",
                    Phone = "123456789",
                    Password = "3",
                    Status = 1
                });
            context.SiteUsers.AddOrUpdate(u => u.Id,
                new Entities.User
                {
                    Id = 4,
                    FirstName = "Derick",
                    LastName = "Maximinus",
                    DateBirth = Convert.ToDateTime("2012/03/01"),
                    Email = "q@q.q",
                    Phone = "123456789",
                    Password = "4",
                    Status = 0
                });
        }
    }
}
