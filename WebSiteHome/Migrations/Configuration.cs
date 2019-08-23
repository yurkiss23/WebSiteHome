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
        }
    }
}
