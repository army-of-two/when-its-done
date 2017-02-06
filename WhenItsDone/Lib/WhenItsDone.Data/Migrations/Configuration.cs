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
                var mozart = new VideoItem();
                mozart.YouTubeUrl = "Rb0UmrCXxVA";
                mozart.Rating = 100;
                context.VideoItems.Add(mozart);

                var minimal = new VideoItem();
                minimal.YouTubeUrl = "_3P4j6iIVew";
                minimal.Rating = 100;
                context.VideoItems.Add(minimal);

                var metallica = new VideoItem();
                metallica.YouTubeUrl = "md3B3I7Nmvw";
                metallica.Rating = 100;
                context.VideoItems.Add(metallica);
            }
        }
    }
}
