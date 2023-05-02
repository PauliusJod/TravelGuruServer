using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuruServer.Migrations
{
    public partial class RouteMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commentRating = table.Column<float>(type: "real", nullable: false),
                    commentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRoutes",
                columns: table => new
                {
                    routeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rTripCost = table.Column<double>(type: "float", nullable: false),
                    rRating = table.Column<float>(type: "real", nullable: false),
                    rIsPublished = table.Column<bool>(type: "bit", nullable: false),
                    rCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRoutes", x => x.routeId);
                    table.ForeignKey(
                        name: "FK_TRoutes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MidWaypoints",
                columns: table => new
                {
                    midWaypointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    midWaypointLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    midWaypointStopover = table.Column<bool>(type: "bit", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidWaypoints", x => x.midWaypointId);
                    table.ForeignKey(
                        name: "FK_MidWaypoints_TRoutes_TRouterouteId",
                        column: x => x.TRouterouteId,
                        principalTable: "TRoutes",
                        principalColumn: "routeId");
                });

            migrationBuilder.CreateTable(
                name: "RimagesUrl",
                columns: table => new
                {
                    rImagesUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rImagesUrlLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RimagesUrl", x => x.rImagesUrlId);
                    table.ForeignKey(
                        name: "FK_RimagesUrl_TRoutes_TRouterouteId",
                        column: x => x.TRouterouteId,
                        principalTable: "TRoutes",
                        principalColumn: "routeId");
                });

            migrationBuilder.CreateTable(
                name: "RrecommendationUrl",
                columns: table => new
                {
                    rRecommendationUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rRecommendationUrlLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RrecommendationUrl", x => x.rRecommendationUrlId);
                    table.ForeignKey(
                        name: "FK_RrecommendationUrl_TRoutes_TRouterouteId",
                        column: x => x.TRouterouteId,
                        principalTable: "TRoutes",
                        principalColumn: "routeId");
                });

            migrationBuilder.CreateTable(
                name: "TroutePointDescriptions",
                columns: table => new
                {
                    pointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pointOnRouteId = table.Column<int>(type: "int", nullable: false),
                    routePointDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroutePointDescriptions", x => x.pointId);
                    table.ForeignKey(
                        name: "FK_TroutePointDescriptions_TRoutes_TRouterouteId",
                        column: x => x.TRouterouteId,
                        principalTable: "TRoutes",
                        principalColumn: "routeId");
                });

            migrationBuilder.CreateTable(
                name: "TrouteSectionDescriptions",
                columns: table => new
                {
                    sectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionOnRouteId = table.Column<int>(type: "int", nullable: false),
                    routeSectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRouterouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrouteSectionDescriptions", x => x.sectionId);
                    table.ForeignKey(
                        name: "FK_TrouteSectionDescriptions_TRoutes_TRouterouteId",
                        column: x => x.TRouterouteId,
                        principalTable: "TRoutes",
                        principalColumn: "routeId");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalPoints",
                columns: table => new
                {
                    additionalPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    additionalPointRouteId = table.Column<int>(type: "int", nullable: false),
                    additionalPointIdInList = table.Column<int>(type: "int", nullable: false),
                    additionalPointCoordX = table.Column<float>(type: "real", nullable: false),
                    additionalPointCoordY = table.Column<float>(type: "real", nullable: false),
                    additionalPointInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TroutePointDescriptionpointId = table.Column<int>(type: "int", nullable: true),
                    TrouteSectionDescriptionsectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalPoints", x => x.additionalPointId);
                    table.ForeignKey(
                        name: "FK_AdditionalPoints_TroutePointDescriptions_TroutePointDescriptionpointId",
                        column: x => x.TroutePointDescriptionpointId,
                        principalTable: "TroutePointDescriptions",
                        principalColumn: "pointId");
                    table.ForeignKey(
                        name: "FK_AdditionalPoints_TrouteSectionDescriptions_TrouteSectionDescriptionsectionId",
                        column: x => x.TrouteSectionDescriptionsectionId,
                        principalTable: "TrouteSectionDescriptions",
                        principalColumn: "sectionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPoints_TroutePointDescriptionpointId",
                table: "AdditionalPoints",
                column: "TroutePointDescriptionpointId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPoints_TrouteSectionDescriptionsectionId",
                table: "AdditionalPoints",
                column: "TrouteSectionDescriptionsectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MidWaypoints_TRouterouteId",
                table: "MidWaypoints",
                column: "TRouterouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RimagesUrl_TRouterouteId",
                table: "RimagesUrl",
                column: "TRouterouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RrecommendationUrl_TRouterouteId",
                table: "RrecommendationUrl",
                column: "TRouterouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TroutePointDescriptions_TRouterouteId",
                table: "TroutePointDescriptions",
                column: "TRouterouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TRoutes_UserId",
                table: "TRoutes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrouteSectionDescriptions_TRouterouteId",
                table: "TrouteSectionDescriptions",
                column: "TRouterouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalPoints");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MidWaypoints");

            migrationBuilder.DropTable(
                name: "RimagesUrl");

            migrationBuilder.DropTable(
                name: "RrecommendationUrl");

            migrationBuilder.DropTable(
                name: "TroutePointDescriptions");

            migrationBuilder.DropTable(
                name: "TrouteSectionDescriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TRoutes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
