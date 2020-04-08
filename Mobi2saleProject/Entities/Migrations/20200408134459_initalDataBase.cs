using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initalDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.EnsureSchema(
                name: "Purchase");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationName = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(1)))"),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5260826+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5261372+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forcasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forcasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_Countries",
                schema: "Admin",
                columns: table => new
                {
                    pk_Countries_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_Countries", x => x.pk_Countries_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Departments",
                schema: "HR",
                columns: table => new
                {
                    pk_Departments_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    fk_Employees_Departments_MgrId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4563958+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4564581+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Departments", x => x.pk_Departments_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Branches",
                schema: "Sales",
                columns: table => new
                {
                    pk_Branches_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    fk_Salesmen_Branches_MgrId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4304629+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4305224+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Branches", x => x.pk_Branches_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Categories",
                schema: "Sales",
                columns: table => new
                {
                    pk_Categories_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4374693+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4375464+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Categories", x => x.pk_Categories_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Offers",
                schema: "Sales",
                columns: table => new
                {
                    pk_Offers_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OfferPctg = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5401593+02:00')"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ReadOnly = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5402211+02:00')"),
                    Target = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Offers", x => x.pk_Offers_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Promos",
                schema: "Sales",
                columns: table => new
                {
                    pk_Promos_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OfferPctg = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5593234+02:00')"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5593843+02:00')"),
                    AllClients = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Promos", x => x.pk_Promos_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesArea",
                schema: "Sales",
                columns: table => new
                {
                    pk_SalesArea_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4875410+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4876006+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesArea", x => x.pk_SalesArea_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "lkp_Governorates",
                schema: "Admin",
                columns: table => new
                {
                    pk_Governorates_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_Governorates", x => x.pk_Governorates_Id);
                    table.ForeignKey(
                        name: "FK_lkp_Governorates_lkp_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Admin",
                        principalTable: "lkp_Countries",
                        principalColumn: "pk_Countries_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Suppliers",
                schema: "Purchase",
                columns: table => new
                {
                    pk_Suppliers_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile1 = table.Column<string>(nullable: false),
                    Mobile2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: false),
                    TaxRecordNumber = table.Column<string>(nullable: true),
                    TradeRecordNumber = table.Column<string>(nullable: true),
                    TaxRecordUrl = table.Column<string>(nullable: true),
                    TradeRecordUrl = table.Column<string>(nullable: true),
                    fk_Country_Supplier_CountryId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5221625+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5222252+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Suppliers", x => x.pk_Suppliers_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Suppliers_lkp_Countries_fk_Country_Supplier_CountryId",
                        column: x => x.fk_Country_Supplier_CountryId,
                        principalSchema: "Admin",
                        principalTable: "lkp_Countries",
                        principalColumn: "pk_Countries_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SubDepartments",
                schema: "HR",
                columns: table => new
                {
                    pk_SubDepartments_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    fk_Departments_SubDepartments_DepartmentId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    fk_Employees_SubDepartments_ManagerID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5144659+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5145315+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsStore = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(1)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SubDepartments", x => x.pk_SubDepartments_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartments_tbl_Departments_fk_Departments_SubDepartments_DepartmentId",
                        column: x => x.fk_Departments_SubDepartments_DepartmentId,
                        principalSchema: "HR",
                        principalTable: "tbl_Departments",
                        principalColumn: "pk_Departments_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SubCategories",
                schema: "Sales",
                columns: table => new
                {
                    pk_SubCategories_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5072697+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5073276+02:00')"),
                    fk_Categories_subCategories_CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SubCategories", x => x.pk_SubCategories_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SubCategories_tbl_Categories_fk_Categories_subCategories_CategoryId",
                        column: x => x.fk_Categories_subCategories_CategoryId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Categories",
                        principalColumn: "pk_Categories_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OfferTarget",
                schema: "Store",
                columns: table => new
                {
                    pk_OfferTarget_Id = table.Column<Guid>(nullable: false),
                    fk_Offer_OfferTarget_OffreId = table.Column<Guid>(nullable: false),
                    TargetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OfferTarget", x => x.pk_OfferTarget_Id);
                    table.ForeignKey(
                        name: "FK_tbl_OfferTarget_tbl_Offers_fk_Offer_OfferTarget_OffreId",
                        column: x => x.fk_Offer_OfferTarget_OffreId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Offers",
                        principalColumn: "pk_Offers_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lkp_Districts",
                schema: "Admin",
                columns: table => new
                {
                    pk_Districts_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GovernorateId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_Districts", x => x.pk_Districts_Id);
                    table.ForeignKey(
                        name: "FK_lkp_Districts_lkp_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Admin",
                        principalTable: "lkp_Governorates",
                        principalColumn: "pk_Governorates_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SupplierAccounts",
                schema: "Accounting",
                columns: table => new
                {
                    pk_SupplierAccounts_Id = table.Column<Guid>(nullable: false),
                    fk_Suppliers_SupplierAccounts_SuppliersId = table.Column<Guid>(nullable: false),
                    TransactionId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5795113+02:00')"),
                    Debit = table.Column<decimal>(nullable: false),
                    Credit = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5795629+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5796080+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SupplierAccounts", x => x.pk_SupplierAccounts_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SupplierAccounts_tbl_Suppliers_fk_Suppliers_SupplierAccounts_SuppliersId",
                        column: x => x.fk_Suppliers_SupplierAccounts_SuppliersId,
                        principalSchema: "Purchase",
                        principalTable: "tbl_Suppliers",
                        principalColumn: "pk_Suppliers_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ExchangeVouchers",
                schema: "Store",
                columns: table => new
                {
                    pk_ExchangeVouchers_Id = table.Column<Guid>(nullable: false),
                    SerialNo = table.Column<int>(nullable: false),
                    fk_Stores_ExchangeVoucher_FromStoresId = table.Column<Guid>(nullable: false),
                    fk_ToStoresId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3526370+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3527182+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsBranch = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ExchangeVouchers", x => x.pk_ExchangeVouchers_Id);
                    table.ForeignKey(
                        name: "FK_tbl_ExchangeVouchers_tbl_SubDepartments_fk_Stores_ExchangeVoucher_FromStoresId",
                        column: x => x.fk_Stores_ExchangeVoucher_FromStoresId,
                        principalSchema: "HR",
                        principalTable: "tbl_SubDepartments",
                        principalColumn: "pk_SubDepartments_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Items",
                schema: "Sales",
                columns: table => new
                {
                    pk_Items_Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupplyPrice = table.Column<decimal>(type: "money", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "money", nullable: false),
                    WholesalePrice = table.Column<decimal>(type: "money", nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SafeLimit = table.Column<int>(nullable: false),
                    MainImageUrl = table.Column<string>(nullable: false),
                    CoverImageUrl = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4754110+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4754755+02:00')"),
                    fk_subCategories_Items_SubcategoryId = table.Column<Guid>(nullable: false),
                    fk_Offers_Items_OfferId = table.Column<Guid>(nullable: false),
                    BookedUp = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true, computedColumnSql: "([Quantity]-[BookedUp])")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Items", x => x.pk_Items_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Items_tbl_Offers_fk_Offers_Items_OfferId",
                        column: x => x.fk_Offers_Items_OfferId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Offers",
                        principalColumn: "pk_Offers_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Items_tbl_SubCategories_fk_subCategories_Items_SubcategoryId",
                        column: x => x.fk_subCategories_Items_SubcategoryId,
                        principalSchema: "Sales",
                        principalTable: "tbl_SubCategories",
                        principalColumn: "pk_SubCategories_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Client",
                schema: "Admin",
                columns: table => new
                {
                    pk_Client_Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ManagerName = table.Column<string>(nullable: false),
                    Mobile1 = table.Column<string>(nullable: false),
                    Mobile2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: true),
                    TaxRecordNumber = table.Column<string>(nullable: false),
                    TradeRecordNumber = table.Column<string>(nullable: false),
                    TaxRecordUrl = table.Column<string>(nullable: true),
                    TradeRecordUrl = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    fk_Clients_Districts_DistrictId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4479911+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4480828+02:00')"),
                    Limit = table.Column<decimal>(type: "money", nullable: false),
                    Target = table.Column<decimal>(type: "money", nullable: false),
                    TargetSatrt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4516256+02:00')"),
                    TargetEnd = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4515727+02:00')"),
                    BonusBeforeTime = table.Column<decimal>(nullable: false),
                    Bonus = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Client", x => x.pk_Client_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Client_lkp_Districts_fk_Clients_Districts_DistrictId",
                        column: x => x.fk_Clients_Districts_DistrictId,
                        principalSchema: "Admin",
                        principalTable: "lkp_Districts",
                        principalColumn: "pk_Districts_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Client_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Employees",
                schema: "HR",
                columns: table => new
                {
                    pk_Employees_Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBrith = table.Column<DateTime>(nullable: false),
                    Mobile1 = table.Column<string>(nullable: false),
                    Mobile2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    VisaNumber = table.Column<string>(nullable: false),
                    VisaImage = table.Column<string>(nullable: false),
                    fk_District_Employees_DistrictId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4655407+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4656221+02:00')"),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    SubDepartmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employees", x => x.pk_Employees_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Employees_tbl_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "tbl_Departments",
                        principalColumn: "pk_Departments_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Employees_lkp_Districts_fk_District_Employees_DistrictId",
                        column: x => x.fk_District_Employees_DistrictId,
                        principalSchema: "Admin",
                        principalTable: "lkp_Districts",
                        principalColumn: "pk_Districts_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Employees_tbl_SubDepartments_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalSchema: "HR",
                        principalTable: "tbl_SubDepartments",
                        principalColumn: "pk_SubDepartments_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_BranchStocks",
                schema: "Store",
                columns: table => new
                {
                    pk_BranchStock_Id = table.Column<Guid>(nullable: false),
                    fk_Branch_BranchStock_BranchId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3439990+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3440805+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BranchStocks", x => x.pk_BranchStock_Id);
                    table.ForeignKey(
                        name: "FK_tbl_BranchStocks_tbl_Branches_fk_Branch_BranchStock_BranchId",
                        column: x => x.fk_Branch_BranchStock_BranchId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Branches",
                        principalColumn: "pk_Branches_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_BranchStocks_tbl_Items_fk_Branch_BranchStock_BranchId",
                        column: x => x.fk_Branch_BranchStock_BranchId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ExchangeVoucherDetails",
                schema: "Store",
                columns: table => new
                {
                    pk_ExchangeVoucherDetails_Id = table.Column<Guid>(nullable: false),
                    fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId = table.Column<Guid>(nullable: false),
                    fk_Items_ExchangeVoucherDetails_ItemsId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ExchangeVoucherDetails", x => x.pk_ExchangeVoucherDetails_Id);
                    table.ForeignKey(
                        name: "FK_tbl_ExchangeVoucherDetails_tbl_ExchangeVouchers_fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId",
                        column: x => x.fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId,
                        principalSchema: "Store",
                        principalTable: "tbl_ExchangeVouchers",
                        principalColumn: "pk_ExchangeVouchers_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ExchangeVoucherDetails_tbl_Items_fk_Items_ExchangeVoucherDetails_ItemsId",
                        column: x => x.fk_Items_ExchangeVoucherDetails_ItemsId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ItemTransactionss",
                schema: "Store",
                columns: table => new
                {
                    pk_ItemTransaction_Id = table.Column<Guid>(nullable: false),
                    fk_Items_Stocks_ItemId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: false),
                    SerialNo = table.Column<int>(nullable: false),
                    TransactionType = table.Column<string>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ItemTransactionss", x => x.pk_ItemTransaction_Id);
                    table.ForeignKey(
                        name: "FK_tbl_ItemTransactionss_tbl_Items_fk_Items_Stocks_ItemId",
                        column: x => x.fk_Items_Stocks_ItemId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Stocks",
                schema: "Store",
                columns: table => new
                {
                    pk_Stocks_Id = table.Column<Guid>(nullable: false),
                    fk_Items_Stocks_ItemId = table.Column<Guid>(nullable: false),
                    QtyPerStore = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Stocks", x => x.pk_Stocks_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Stocks_tbl_Items_fk_Items_Stocks_ItemId",
                        column: x => x.fk_Items_Stocks_ItemId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ClientAccounts",
                schema: "Accounting",
                columns: table => new
                {
                    pk_ClientAccounts_Id = table.Column<Guid>(nullable: false),
                    fk_Clients_ClientAccounts_ClientId = table.Column<Guid>(nullable: false),
                    TransactionId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5728354+02:00')"),
                    Debit = table.Column<decimal>(nullable: false),
                    Credit = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5728866+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5729475+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ClientAccounts", x => x.pk_ClientAccounts_Id);
                    table.ForeignKey(
                        name: "FK_tbl_ClientAccounts_tbl_Client_fk_Clients_ClientAccounts_ClientId",
                        column: x => x.fk_Clients_ClientAccounts_ClientId,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Favorites",
                schema: "Sales",
                columns: table => new
                {
                    pk_Favorites_Id = table.Column<Guid>(nullable: false),
                    fk_Client_Id = table.Column<Guid>(nullable: false),
                    fk_Items_Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3901801+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3903097+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Favorites", x => x.pk_Favorites_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Favorites_tbl_Client_fk_Client_Id",
                        column: x => x.fk_Client_Id,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Favorites_tbl_Items_fk_Items_Id",
                        column: x => x.fk_Items_Id,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Orders",
                schema: "Sales",
                columns: table => new
                {
                    pk_Orders_Id = table.Column<Guid>(nullable: false),
                    fk_Clients_Orders_ClientId = table.Column<Guid>(nullable: false),
                    Order_Date = table.Column<DateTime>(nullable: false),
                    Order_IsOrder = table.Column<bool>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    OnDelivery = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    Order_IsPaid = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsCancelled = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3999346+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3999858+02:00')"),
                    OrderNo = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true, defaultValueSql: "(N'No Action')"),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Orders", x => x.pk_Orders_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Orders_tbl_Client_fk_Clients_Orders_ClientId",
                        column: x => x.fk_Clients_Orders_ClientId,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PromoTargets",
                schema: "Sales",
                columns: table => new
                {
                    pk_PromoTargets_Id = table.Column<Guid>(nullable: false),
                    fk_Promos_PromoTargets_PromoId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PromoTargets", x => x.pk_PromoTargets_Id);
                    table.ForeignKey(
                        name: "FK_tbl_PromoTargets_tbl_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_PromoTargets_tbl_Promos_fk_Promos_PromoTargets_PromoId",
                        column: x => x.fk_Promos_PromoTargets_PromoId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Promos",
                        principalColumn: "pk_Promos_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesAreaClients",
                schema: "Sales",
                columns: table => new
                {
                    pk_SalesAreaClient_Id = table.Column<Guid>(nullable: false),
                    fk_SalesAreaClients_SalesAreas_salesAreaId = table.Column<Guid>(nullable: false),
                    fk_SalesAreaClients_Clients_ClientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4822684+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4823254+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesAreaClients", x => x.pk_SalesAreaClient_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SalesAreaClients_tbl_Client_fk_SalesAreaClients_Clients_ClientId",
                        column: x => x.fk_SalesAreaClients_Clients_ClientId,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_SalesAreaClients_tbl_SalesArea_fk_SalesAreaClients_SalesAreas_salesAreaId",
                        column: x => x.fk_SalesAreaClients_SalesAreas_salesAreaId,
                        principalSchema: "Sales",
                        principalTable: "tbl_SalesArea",
                        principalColumn: "pk_SalesArea_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IndoorInvoiceHeader",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    fk_Branches_IndoorSalesInvoice_BranchId = table.Column<Guid>(nullable: false),
                    fk_Employees_IndoorSalesInvoice_EmployeeId = table.Column<Guid>(nullable: false),
                    SerialNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5538141+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5538777+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IndoorInvoiceHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_IndoorInvoiceHeader_tbl_Branches_fk_Branches_IndoorSalesInvoice_BranchId",
                        column: x => x.fk_Branches_IndoorSalesInvoice_BranchId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Branches",
                        principalColumn: "pk_Branches_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_IndoorInvoiceHeader_tbl_Employees_fk_Employees_IndoorSalesInvoice_EmployeeId",
                        column: x => x.fk_Employees_IndoorSalesInvoice_EmployeeId,
                        principalSchema: "HR",
                        principalTable: "tbl_Employees",
                        principalColumn: "pk_Employees_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Salesmen",
                schema: "Sales",
                columns: table => new
                {
                    pk_Salesman_Id = table.Column<Guid>(nullable: false),
                    Limit = table.Column<decimal>(type: "money", nullable: false),
                    Target = table.Column<decimal>(type: "money", nullable: false),
                    TargetSatrt = table.Column<DateTime>(nullable: false),
                    TargetEnd = table.Column<DateTime>(nullable: false),
                    fk_Salesmen_Employee_Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5018798+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5018215+02:00')"),
                    BonusBeforeTime = table.Column<decimal>(nullable: false),
                    Bonus = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Salesmen", x => x.pk_Salesman_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Salesmen_tbl_Employees_fk_Salesmen_Employee_Id",
                        column: x => x.fk_Salesmen_Employee_Id,
                        principalSchema: "HR",
                        principalTable: "tbl_Employees",
                        principalColumn: "pk_Employees_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AdditionVouchers",
                schema: "Store",
                columns: table => new
                {
                    pk_AdditionVouchers_Id = table.Column<Guid>(nullable: false),
                    fk_Stores_AdditionVoucher_StoresId = table.Column<Guid>(nullable: false),
                    fk_Employees_AdditionVoucher_EmployeeId = table.Column<Guid>(nullable: false),
                    fk_Suppliers_AdditionVoucher_SuppliersId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3139232+02:00')"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3216442+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3217243+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    SerialNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AdditionVouchers", x => x.pk_AdditionVouchers_Id);
                    table.ForeignKey(
                        name: "FK_tbl_AdditionVouchers_tbl_Employees_fk_Employees_AdditionVoucher_EmployeeId",
                        column: x => x.fk_Employees_AdditionVoucher_EmployeeId,
                        principalSchema: "HR",
                        principalTable: "tbl_Employees",
                        principalColumn: "pk_Employees_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_AdditionVouchers_tbl_SubDepartments_fk_Stores_AdditionVoucher_StoresId",
                        column: x => x.fk_Stores_AdditionVoucher_StoresId,
                        principalSchema: "HR",
                        principalTable: "tbl_SubDepartments",
                        principalColumn: "pk_SubDepartments_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_AdditionVouchers_tbl_Suppliers_fk_Suppliers_AdditionVoucher_SuppliersId",
                        column: x => x.fk_Suppliers_AdditionVoucher_SuppliersId,
                        principalSchema: "Purchase",
                        principalTable: "tbl_Suppliers",
                        principalColumn: "pk_Suppliers_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OrderDetails",
                schema: "Sales",
                columns: table => new
                {
                    pk_OrderDetails_Id = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4068740+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4069555+02:00')"),
                    fk_Items_Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OrderDetails", x => x.pk_OrderDetails_Id);
                    table.ForeignKey(
                        name: "FK_tbl_OrderDetails_tbl_Items_fk_Items_Id",
                        column: x => x.fk_Items_Id,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_OrderDetails_tbl_Orders_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Sales",
                        principalTable: "tbl_Orders",
                        principalColumn: "pk_Orders_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IndoorInvoiceDetails",
                schema: "Sales",
                columns: table => new
                {
                    pk_IndoorInvoiceDetails_Id = table.Column<Guid>(nullable: false),
                    fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId = table.Column<Guid>(nullable: false),
                    fk_Items_AdditionVoucherDetails_ItemsId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Barcode = table.Column<string>(nullable: false),
                    RetailPrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IndoorInvoiceDetails", x => x.pk_IndoorInvoiceDetails_Id);
                    table.ForeignKey(
                        name: "FK_tbl_IndoorInvoiceDetails_tbl_IndoorInvoiceHeader_fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId",
                        column: x => x.fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId,
                        principalSchema: "Sales",
                        principalTable: "tbl_IndoorInvoiceHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_IndoorInvoiceDetails_tbl_Items_fk_Items_AdditionVoucherDetails_ItemsId",
                        column: x => x.fk_Items_AdditionVoucherDetails_ItemsId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesAreaPersonnel",
                schema: "Sales",
                columns: table => new
                {
                    pk_SalesAreaPersonnel_Id = table.Column<Guid>(nullable: false),
                    fk_SalesAreaPersonnel_SalesAreas_salesAreaId = table.Column<Guid>(nullable: false),
                    fk_SalesAreaPersonnel_Salesmen_salesId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4932542+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsSupervisor = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.4933148+02:00')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesAreaPersonnel", x => x.pk_SalesAreaPersonnel_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SalesAreaPersonnel_tbl_SalesArea_fk_SalesAreaPersonnel_SalesAreas_salesAreaId",
                        column: x => x.fk_SalesAreaPersonnel_SalesAreas_salesAreaId,
                        principalSchema: "Sales",
                        principalTable: "tbl_SalesArea",
                        principalColumn: "pk_SalesArea_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_SalesAreaPersonnel_tbl_Salesmen_fk_SalesAreaPersonnel_Salesmen_salesId",
                        column: x => x.fk_SalesAreaPersonnel_Salesmen_salesId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Salesmen",
                        principalColumn: "pk_Salesman_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Visit",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    fk_Salesman_Visit_SalesmanId = table.Column<Guid>(nullable: false),
                    fk_Clients_Visit_ClientId = table.Column<Guid>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5658536+02:00')"),
                    SerialNo = table.Column<string>(nullable: true),
                    VisitImage = table.Column<string>(nullable: true),
                    FeedBack = table.Column<string>(nullable: false, defaultValueSql: "(N'Open Visit')"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5659051+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.5659518+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Visit_tbl_Client_fk_Clients_Visit_ClientId",
                        column: x => x.fk_Clients_Visit_ClientId,
                        principalSchema: "Admin",
                        principalTable: "tbl_Client",
                        principalColumn: "pk_Client_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Visit_tbl_Salesmen_fk_Salesman_Visit_SalesmanId",
                        column: x => x.fk_Salesman_Visit_SalesmanId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Salesmen",
                        principalColumn: "pk_Salesman_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HandStockValue",
                schema: "Store",
                columns: table => new
                {
                    pk_HandStockValue_Id = table.Column<Guid>(nullable: false),
                    fk_Salesman_HandStockValue_SalesId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3647144+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3647812+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HandStockValue", x => x.pk_HandStockValue_Id);
                    table.ForeignKey(
                        name: "FK_tbl_HandStockValue_tbl_Salesmen_fk_Salesman_HandStockValue_SalesId",
                        column: x => x.fk_Salesman_HandStockValue_SalesId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Salesmen",
                        principalColumn: "pk_Salesman_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesStock",
                schema: "Store",
                columns: table => new
                {
                    pk_SalesStock_Id = table.Column<Guid>(nullable: false),
                    fk_Items_SalesStock_ItemsId = table.Column<Guid>(nullable: false),
                    fk_Salesman_SalesStock_SalesId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: false),
                    Isclient = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CraetedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3805962+02:00')"),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "('2020-04-07T01:01:37.3806535+02:00')"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    fk_ExchangeVouchers_SalesStock_ExchangeVoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesStock", x => x.pk_SalesStock_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SalesStock_tbl_Items_fk_Items_SalesStock_ItemsId",
                        column: x => x.fk_Items_SalesStock_ItemsId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_SalesStock_tbl_Salesmen_fk_Salesman_SalesStock_SalesId",
                        column: x => x.fk_Salesman_SalesStock_SalesId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Salesmen",
                        principalColumn: "pk_Salesman_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AdditionVoucherDetails",
                schema: "Store",
                columns: table => new
                {
                    pk_AdditionVoucherDetails_Id = table.Column<Guid>(nullable: false),
                    fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId = table.Column<Guid>(nullable: false),
                    fk_Items_AdditionVoucherDetails_ItemsId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AdditionVoucherDetails", x => x.pk_AdditionVoucherDetails_Id);
                    table.ForeignKey(
                        name: "FK_tbl_AdditionVoucherDetails_tbl_AdditionVouchers_fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId",
                        column: x => x.fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId,
                        principalSchema: "Store",
                        principalTable: "tbl_AdditionVouchers",
                        principalColumn: "pk_AdditionVouchers_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AdditionVoucherDetails_tbl_Items_fk_Items_AdditionVoucherDetails_ItemsId",
                        column: x => x.fk_Items_AdditionVoucherDetails_ItemsId,
                        principalSchema: "Sales",
                        principalTable: "tbl_Items",
                        principalColumn: "pk_Items_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

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
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ClientAccounts_fk_Clients_ClientAccounts_ClientId",
                schema: "Accounting",
                table: "tbl_ClientAccounts",
                column: "fk_Clients_ClientAccounts_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SupplierAccounts_fk_Suppliers_SupplierAccounts_SuppliersId",
                schema: "Accounting",
                table: "tbl_SupplierAccounts",
                column: "fk_Suppliers_SupplierAccounts_SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Districts_GovernorateId",
                schema: "Admin",
                table: "lkp_Districts",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Governorates_CountryId",
                schema: "Admin",
                table: "lkp_Governorates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Client_fk_Clients_Districts_DistrictId",
                schema: "Admin",
                table: "tbl_Client",
                column: "fk_Clients_Districts_DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Client_IdentityId",
                schema: "Admin",
                table: "tbl_Client",
                column: "IdentityId",
                unique: true,
                filter: "([IdentityId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employees_DepartmentId",
                schema: "HR",
                table: "tbl_Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employees_fk_District_Employees_DistrictId",
                schema: "HR",
                table: "tbl_Employees",
                column: "fk_District_Employees_DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employees_SubDepartmentId",
                schema: "HR",
                table: "tbl_Employees",
                column: "SubDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartments_fk_Departments_SubDepartments_DepartmentId",
                schema: "HR",
                table: "tbl_SubDepartments",
                column: "fk_Departments_SubDepartments_DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Suppliers_fk_Country_Supplier_CountryId",
                schema: "Purchase",
                table: "tbl_Suppliers",
                column: "fk_Country_Supplier_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Favorites_fk_Client_Id",
                schema: "Sales",
                table: "tbl_Favorites",
                column: "fk_Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Favorites_fk_Items_Id",
                schema: "Sales",
                table: "tbl_Favorites",
                column: "fk_Items_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IndoorInvoiceDetails_fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId",
                schema: "Sales",
                table: "tbl_IndoorInvoiceDetails",
                column: "fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IndoorInvoiceDetails_fk_Items_AdditionVoucherDetails_ItemsId",
                schema: "Sales",
                table: "tbl_IndoorInvoiceDetails",
                column: "fk_Items_AdditionVoucherDetails_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IndoorInvoiceHeader_fk_Branches_IndoorSalesInvoice_BranchId",
                schema: "Sales",
                table: "tbl_IndoorInvoiceHeader",
                column: "fk_Branches_IndoorSalesInvoice_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IndoorInvoiceHeader_fk_Employees_IndoorSalesInvoice_EmployeeId",
                schema: "Sales",
                table: "tbl_IndoorInvoiceHeader",
                column: "fk_Employees_IndoorSalesInvoice_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Items_fk_Offers_Items_OfferId",
                schema: "Sales",
                table: "tbl_Items",
                column: "fk_Offers_Items_OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Items_fk_subCategories_Items_SubcategoryId",
                schema: "Sales",
                table: "tbl_Items",
                column: "fk_subCategories_Items_SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OrderDetails_fk_Items_Id",
                schema: "Sales",
                table: "tbl_OrderDetails",
                column: "fk_Items_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OrderDetails_OrderID",
                schema: "Sales",
                table: "tbl_OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orders_fk_Clients_Orders_ClientId",
                schema: "Sales",
                table: "tbl_Orders",
                column: "fk_Clients_Orders_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PromoTargets_ClientId",
                schema: "Sales",
                table: "tbl_PromoTargets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PromoTargets_fk_Promos_PromoTargets_PromoId",
                schema: "Sales",
                table: "tbl_PromoTargets",
                column: "fk_Promos_PromoTargets_PromoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesAreaClients_fk_SalesAreaClients_Clients_ClientId",
                schema: "Sales",
                table: "tbl_SalesAreaClients",
                column: "fk_SalesAreaClients_Clients_ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesAreaClients_fk_SalesAreaClients_SalesAreas_salesAreaId",
                schema: "Sales",
                table: "tbl_SalesAreaClients",
                column: "fk_SalesAreaClients_SalesAreas_salesAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesAreaPersonnel_fk_SalesAreaPersonnel_SalesAreas_salesAreaId",
                schema: "Sales",
                table: "tbl_SalesAreaPersonnel",
                column: "fk_SalesAreaPersonnel_SalesAreas_salesAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesAreaPersonnel_fk_SalesAreaPersonnel_Salesmen_salesId",
                schema: "Sales",
                table: "tbl_SalesAreaPersonnel",
                column: "fk_SalesAreaPersonnel_Salesmen_salesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Salesmen_fk_Salesmen_Employee_Id",
                schema: "Sales",
                table: "tbl_Salesmen",
                column: "fk_Salesmen_Employee_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubCategories_fk_Categories_subCategories_CategoryId",
                schema: "Sales",
                table: "tbl_SubCategories",
                column: "fk_Categories_subCategories_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Visit_fk_Clients_Visit_ClientId",
                schema: "Sales",
                table: "tbl_Visit",
                column: "fk_Clients_Visit_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Visit_fk_Salesman_Visit_SalesmanId",
                schema: "Sales",
                table: "tbl_Visit",
                column: "fk_Salesman_Visit_SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AdditionVoucherDetails_fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId",
                schema: "Store",
                table: "tbl_AdditionVoucherDetails",
                column: "fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AdditionVoucherDetails_fk_Items_AdditionVoucherDetails_ItemsId",
                schema: "Store",
                table: "tbl_AdditionVoucherDetails",
                column: "fk_Items_AdditionVoucherDetails_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AdditionVouchers_fk_Employees_AdditionVoucher_EmployeeId",
                schema: "Store",
                table: "tbl_AdditionVouchers",
                column: "fk_Employees_AdditionVoucher_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AdditionVouchers_fk_Stores_AdditionVoucher_StoresId",
                schema: "Store",
                table: "tbl_AdditionVouchers",
                column: "fk_Stores_AdditionVoucher_StoresId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AdditionVouchers_fk_Suppliers_AdditionVoucher_SuppliersId",
                schema: "Store",
                table: "tbl_AdditionVouchers",
                column: "fk_Suppliers_AdditionVoucher_SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BranchStocks_fk_Branch_BranchStock_BranchId",
                schema: "Store",
                table: "tbl_BranchStocks",
                column: "fk_Branch_BranchStock_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExchangeVoucherDetails_fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId",
                schema: "Store",
                table: "tbl_ExchangeVoucherDetails",
                column: "fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExchangeVoucherDetails_fk_Items_ExchangeVoucherDetails_ItemsId",
                schema: "Store",
                table: "tbl_ExchangeVoucherDetails",
                column: "fk_Items_ExchangeVoucherDetails_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExchangeVouchers_fk_Stores_ExchangeVoucher_FromStoresId",
                schema: "Store",
                table: "tbl_ExchangeVouchers",
                column: "fk_Stores_ExchangeVoucher_FromStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HandStockValue_fk_Salesman_HandStockValue_SalesId",
                schema: "Store",
                table: "tbl_HandStockValue",
                column: "fk_Salesman_HandStockValue_SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ItemTransactionss_fk_Items_Stocks_ItemId",
                schema: "Store",
                table: "tbl_ItemTransactionss",
                column: "fk_Items_Stocks_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OfferTarget_fk_Offer_OfferTarget_OffreId",
                schema: "Store",
                table: "tbl_OfferTarget",
                column: "fk_Offer_OfferTarget_OffreId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesStock_fk_Items_SalesStock_ItemsId",
                schema: "Store",
                table: "tbl_SalesStock",
                column: "fk_Items_SalesStock_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalesStock_fk_Salesman_SalesStock_SalesId",
                schema: "Store",
                table: "tbl_SalesStock",
                column: "fk_Salesman_SalesStock_SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Stocks_fk_Items_Stocks_ItemId",
                schema: "Store",
                table: "tbl_Stocks",
                column: "fk_Items_Stocks_ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Forcasts");

            migrationBuilder.DropTable(
                name: "tbl_ClientAccounts",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "tbl_SupplierAccounts",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "tbl_Favorites",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_IndoorInvoiceDetails",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_OrderDetails",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_PromoTargets",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_SalesAreaClients",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_SalesAreaPersonnel",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Visit",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_AdditionVoucherDetails",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_BranchStocks",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_ExchangeVoucherDetails",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_HandStockValue",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_ItemTransactionss",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_OfferTarget",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_SalesStock",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_Stocks",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbl_IndoorInvoiceHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Orders",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Promos",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_SalesArea",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_AdditionVouchers",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_ExchangeVouchers",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "tbl_Salesmen",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Items",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Branches",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_Client",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "tbl_Suppliers",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "tbl_Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "tbl_Offers",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "tbl_SubCategories",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "lkp_Districts",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "tbl_SubDepartments",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "tbl_Categories",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "lkp_Governorates",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "tbl_Departments",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "lkp_Countries",
                schema: "Admin");
        }
    }
}
