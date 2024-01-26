using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMaps");
            builder.HasKey(x => new { x.PostId, x.TagId });

            // Configure the one-to-many relationship between PostTagMap and Post
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between PostTagMap and Tag
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}