﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data
{
    public class TravelDBContext : IdentityDbContext<TravelUser>
    {


        public DbSet<TRoute> TRoutes { get; set; }
        public DbSet<MidWaypoint> MidWaypoints { get; set; }
        public DbSet<TrouteSectionDescription> TrouteSectionDescriptions { get; set; }
        public DbSet<TroutePointDescription> TroutePointDescriptions { get; set; }
        public DbSet<AdditionalPoints> AdditionalPointPoints { get; set; }
        public DbSet<AdditionalPoints> AdditionalSectionPoints { get; set; }
        public DbSet<RImagesUrl> RimagesUrl { get; set; }
        public DbSet<RRecommendationUrl> RrecommendationUrl { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =(LocalDb)\\MSSQLLocalDB; Database=TravelGuru; Trusted_Connection = True");
        }

    }
}
