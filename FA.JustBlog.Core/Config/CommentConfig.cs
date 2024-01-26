using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CommentHeader).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CommentText).IsRequired().HasColumnType("text");
            builder.Property(x => x.CommentTime).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}
