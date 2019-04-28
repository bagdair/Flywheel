namespace Movies.Migrations
{
    using Movies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Models.MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Movies.Models.MoviesContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Name = "UserA" },
                new User() { Id = 2, Name = "UserB" },
                new User() { Id = 3, Name = "UserC" }
            );

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie()
                {
                    Id = 1,
                    Title = "Rocky",
                    Year = 1976,
                    UserId = 1,
                    Price = 9.99M,
                    Genre = "Sports",
                    Ratings = 3
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Back To The Future",
                    Year = 1985,
                    UserId = 1,
                    Price = 12.95M,
                    Genre = "Science Fiction",
                    Ratings = 5
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Hangover",
                    Year = 2009,
                    UserId = 2,
                    Price = 15,
                    Genre = "Comedy",
                    Ratings = 5
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Harry Potter",
                    Year = 1997,
                    UserId = 3,
                    Price = 8.95M,
                    Genre = "Drama",
                    Ratings = 4
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Jurassic World",
                    Year = 2015,
                    UserId = 3,
                    Price = 8.95M,
                    Genre = "Science Fiction",
                    Ratings = 2
                },
                new Movie()
                {
                    Id = 6,
                    Title = "Avengers",
                    Year = 2017,
                    UserId = 2,
                    Price = 8.95M,
                    Genre = "SuperHero",
                    Ratings = 2
                },
                new Movie()
                {
                    Id = 7,
                    Title = "Moneyball",
                    Year = 2011,
                    UserId = 1,
                    Price = 9.99M,
                    Genre = "Sports",
                    Ratings = 3
                },
                new Movie()
                {
                    Id = 8,
                    Title = "Billion Dollor Baby",
                    Year = 2004,
                    UserId = 1,
                    Price = 9.99M,
                    Genre = "Sports",
                    Ratings = 3
                },
                new Movie()
                {
                    Id = 9,
                    Title = "Black Swan",
                    Year = 2010,
                    UserId = 1,
                    Price = 9.99M,
                    Genre = "Drama",
                    Ratings = 3
                },
                new Movie()
                {
                    Id = 10,
                    Title = "First Man",
                    Year = 2018,
                    UserId = 1,
                    Price = 9.99M,
                    Genre = "Drama",
                    Ratings = 3
                },
                new Movie()
                {
                    Id = 11,
                    Title = "Captain Marvel",
                    Year = 2019,
                    UserId = 2,
                    Price = 8.95M,
                    Genre = "SuperHero",
                    Ratings = 2
                },
                new Movie()
                {
                    Id = 12,
                    Title = "Black Panther",
                    Year = 2018,
                    UserId = 2,
                    Price = 8.95M,
                    Genre = "SuperHero",
                    Ratings = 2
                }
                );
        }
    }
}
