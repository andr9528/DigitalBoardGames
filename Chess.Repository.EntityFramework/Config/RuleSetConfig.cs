﻿using System.Collections.Generic;
using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class RuleSetConfig : IEntityTypeConfiguration<RuleSet>
    {
        public void Configure(EntityTypeBuilder<RuleSet> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("RuleSetId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasIndex(x => new {x.Type, x.TypeName, x.BoardTypeName}).HasName("TypeIndex").IsUnique();

            builder.HasMany(x => (ICollection<Rule>)x.Rules).WithOne();
        }
    }
}