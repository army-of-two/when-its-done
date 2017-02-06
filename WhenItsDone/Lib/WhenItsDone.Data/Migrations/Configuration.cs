namespace WhenItsDone.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Net;

    internal sealed class Configuration : DbMigrationsConfiguration<WhenItsDone.Data.WhenItsDoneDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WhenItsDone.Data.WhenItsDoneDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.ProfilePictures.Any())
            {
                var defaultProfilePicture = new ProfilePicture();
                defaultProfilePicture.MimeType = "jpg";
                defaultProfilePicture.PictureUrl = "http://cdn.litlepups.net/2016/05/22/cute-cat-profile-for-facebook.jpg";

                using (var client = new WebClient())
                {
                    var downloadedData = client.DownloadData(defaultProfilePicture.PictureUrl);
                    defaultProfilePicture.PictureBase64 = Convert.ToBase64String(downloadedData);
                }

                context.ProfilePictures.Add(defaultProfilePicture);

                context.SaveChanges();
            }

            if (!context.VideoItems.Any())
            {
                var potatoStacks = new VideoItem();
                potatoStacks.Title = "Potato Stacks";
                potatoStacks.YouTubeUrl = "https://www.youtube.com/watch?v=OLUkj1At-GQ";
                potatoStacks.YouTubeId = "OLUkj1At-GQ";
                potatoStacks.Rating = 100;
                context.VideoItems.Add(potatoStacks);

                var schrimpScampi = new VideoItem();
                schrimpScampi.Title = "Shrimp Scampi";
                schrimpScampi.YouTubeUrl = "https://www.youtube.com/watch?v=NLzqkhpniro";
                schrimpScampi.YouTubeId = "NLzqkhpniro";
                schrimpScampi.Rating = 100;
                context.VideoItems.Add(schrimpScampi);

                var ribEye = new VideoItem();
                ribEye.Title = "Rib Eye Steak";
                ribEye.YouTubeUrl = "https://www.youtube.com/watch?v=723K_WxpQe8";
                ribEye.YouTubeId = "723K_WxpQe8";
                ribEye.Rating = 100;
                context.VideoItems.Add(ribEye);

                //var mozart = new VideoItem();
                //mozart.Title = "Mozart";
                //mozart.YouTubeUrl = "https://www.youtube.com/watch?v=Rb0UmrCXxVA";
                //mozart.YouTubeId = "Rb0UmrCXxVA";
                //mozart.Rating = 100;
                //context.VideoItems.Add(mozart);

                //var minimal = new VideoItem();
                //minimal.Title = "Minimal";
                //minimal.YouTubeUrl = "https://www.youtube.com/watch?v=_3P4j6iIVew";
                //minimal.YouTubeId = "_3P4j6iIVew";
                //minimal.Rating = 100;
                //context.VideoItems.Add(minimal);

                //var metallica = new VideoItem();
                //metallica.Title = "Metallica";
                //metallica.YouTubeUrl = "https://www.youtube.com/watch?v=md3B3I7Nmvw";
                //metallica.YouTubeId = "md3B3I7Nmvw";
                //metallica.Rating = 100;
                //context.VideoItems.Add(metallica);

                context.SaveChanges();
            }
        }
    }
}
