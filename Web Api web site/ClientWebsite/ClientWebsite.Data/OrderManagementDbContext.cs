﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientWebsite.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientWebsite.Data
{
    public class OrderManagementDbContext : IdentityDbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //SET CASCADE DELETE TO FALSE by Default
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Add Entities Here     
        public DbSet<CustomerReport> CustomerReport { get; set; }
        public DbSet<InvoiceList> InvoiceList { get; set; }
        public DbSet<RemitList> RemitLists { get; set; }

    }
}
