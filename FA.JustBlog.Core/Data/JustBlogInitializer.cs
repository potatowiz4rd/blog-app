using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Entertainment", UrlSlug = "urlslug 1", Description = "Category 1 for you" },
                  new Category { Id = 2, Name = "Politics", UrlSlug = "urlslug 2", Description = "Category 2 for you" },
                  new Category { Id = 3, Name = "Health", UrlSlug = "urlslug 3", Description = "Category 3 for you" },
                  new Category { Id = 4, Name = "Lifestyle", UrlSlug = "urlslug 4", Description = "Category 4 for you" },
                  new Category { Id = 5, Name = "Sport", UrlSlug = "urlslug 5", Description = "Category 5 for you" }
            );
            modelBuilder.Entity<Post>().HasData(
                  new Post
                  {
                      Id = 1,
                      Title = "Fiction Pick of the Week: Mercy",
                      PostContent = "A troubled man's complex acts of mercy",
                      ShortDescription = "Post 1 for you",
                      UrlSlug = "urlslug 1",
                      CategoryId = 1,
                      Published = true,
                      PostedOn = new DateTime(2022, 6, 4),
                      Modified = false,
                  },
                  new Post
                  {
                      Id = 2,
                      Title = "Will the Real Warren Beatty Please Shut Up?",
                      PostContent = "A profile of Beatty on the heels of Bonnie and Clyde.",
                      ShortDescription = "Post 2 for you",
                      UrlSlug = "urlslug 2",
                      CategoryId = 4,
                      Published = false,
                      PostedOn = new DateTime(2022, 8, 4),
                      Modified = false,
                  },
                  new Post
                  {
                      Id = 3,
                      Title = "Post 3",
                      PostContent = "Why Ric Flair's Greatest Legacy Is His Daughter",
                      ShortDescription = "WWE star Charlotte Flair follows in her famous father’s footsteps.",
                      UrlSlug = "urlslug 3",
                      CategoryId = 1,
                      Published = true,
                      PostedOn = new DateTime(2022, 8, 4),
                      Modified = false,
                  },
                  new Post
                  {
                      Id = 4,
                      Title = "Inside the Fury and Fantasy of Donald Trump’s Florida",
                      PostContent = "Roger Stone, Tucker Carlson, Sean Hannity, Ben Shapiro—they’ve all made their way to the Sunshine State, fueling and profiting from a tabloid culture that turns politics into spectacle, arguably Florida’s greatest export.",
                      ShortDescription = "Post 4 for you",
                      UrlSlug = "urlslug 4",
                      CategoryId = 2,
                      Published = false,
                      PostedOn = new DateTime(2022, 6, 4),
                      Modified = false,
                  },
                  new Post
                  {
                      Id = 5,
                      Title = "Brazilian Butt Lift: Behind the World's Most Dangerous Cosmetic Surgery",
                      PostContent = "The BBL is the fastest growing cosmetic surgery in the world, despite the mounting number of deaths resulting from the procedure. What is driving its astonishing rise?",
                      ShortDescription = "Post 5 for you",
                      UrlSlug = "urlslug 5",
                      CategoryId = 2,
                      Published = true,
                      PostedOn = new DateTime(2022, 8, 4),
                      Modified = false,
                  },
                  new Post
                  {
                      Id = 6,
                      Title = "How to Get Rich in Trump’s Washington",
                      PostContent = "A new breed of lobbyist comes to K Street.",
                      ShortDescription = "Post 6 for you",
                      UrlSlug = "urlslug 6",
                      CategoryId = 1,
                      Published = true,
                      PostedOn = new DateTime(2022, 8, 4),
                      Modified = false,
                  }
            );
            modelBuilder.Entity<Tag>().HasData(
                        new Tag { Id = 1, Name = "Trending", UrlSlug = "urlslug 1", Description = "Tag 1 for you" },
                        new Tag { Id = 2, Name = "Hot", UrlSlug = "urlslug 2", Description = "Tag 2 for you" },
                        new Tag { Id = 3, Name = "New", UrlSlug = "urlslug 3", Description = "Tag 3 for you" },
                        new Tag { Id = 4, Name = "Popular", UrlSlug = "urlslug 4", Description = "Tag 4 for you" }
                  );

            modelBuilder.Entity<PostTagMap>().HasData(
                 new PostTagMap { PostId = 1, TagId = 1 },
                 new PostTagMap { PostId = 1, TagId = 2 },
                 new PostTagMap { PostId = 2, TagId = 3 },
                 new PostTagMap { PostId = 2, TagId = 2 },
                 new PostTagMap { PostId = 4, TagId = 3 },
                 new PostTagMap { PostId = 4, TagId = 4 },
                 new PostTagMap { PostId = 5, TagId = 1 },
                 new PostTagMap { PostId = 5, TagId = 2 },
                 new PostTagMap { PostId = 5, TagId = 3 },
                 new PostTagMap { PostId = 3, TagId = 2 },
                 new PostTagMap { PostId = 3, TagId = 4 }
           );
        }
    }
}
