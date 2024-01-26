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
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.UrlSlug).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Published).IsRequired();
            builder.Property(x => x.PostedOn).IsRequired();
            builder.Property(x => x.Modified).IsRequired();
        }
    }
}