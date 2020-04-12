using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Model
{
    public partial class Mobi2saleContext : IdentityDbContext<IdentityUser>
    {
        public Mobi2saleContext()
        {
        }

        public Mobi2saleContext(DbContextOptions<Mobi2saleContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Forcasts> Forcasts { get; set; }
        public virtual DbSet<LkpCountries> LkpCountries { get; set; }
        public virtual DbSet<LkpDistricts> LkpDistricts { get; set; }
        public virtual DbSet<LkpGovernorates> LkpGovernorates { get; set; }
        public virtual DbSet<TblAdditionVoucherDetails> TblAdditionVoucherDetails { get; set; }
        public virtual DbSet<TblAdditionVouchers> TblAdditionVouchers { get; set; }
        public virtual DbSet<TblBranches> TblBranches { get; set; }
        public virtual DbSet<TblBranchStocks> TblBranchStocks { get; set; }
        public virtual DbSet<TblCategories> TblCategories { get; set; }
        public virtual DbSet<TblClient> TblClient { get; set; }
        public virtual DbSet<TblClientAccounts> TblClientAccounts { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblEmployees> TblEmployees { get; set; }
        public virtual DbSet<TblExchangeVoucherDetails> TblExchangeVoucherDetails { get; set; }
        public virtual DbSet<TblExchangeVouchers> TblExchangeVouchers { get; set; }
        public virtual DbSet<TblFavorites> TblFavorites { get; set; }
        public virtual DbSet<TblHandStockValue> TblHandStockValue { get; set; }
        public virtual DbSet<TblIndoorInvoiceDetails> TblIndoorInvoiceDetails { get; set; }
        public virtual DbSet<TblIndoorInvoiceHeader> TblIndoorInvoiceHeader { get; set; }
        public virtual DbSet<TblItems> TblItems { get; set; }
        public virtual DbSet<TblItemTransactionss> TblItemTransactionss { get; set; }
        public virtual DbSet<TblOffers> TblOffers { get; set; }
        public virtual DbSet<TblOfferTarget> TblOfferTarget { get; set; }
        public virtual DbSet<TblOrderDetails> TblOrderDetails { get; set; }
        public virtual DbSet<TblOrders> TblOrders { get; set; }
        public virtual DbSet<TblPromos> TblPromos { get; set; }
        public virtual DbSet<TblPromoTargets> TblPromoTargets { get; set; }
        public virtual DbSet<TblSalesArea> TblSalesArea { get; set; }
        public virtual DbSet<TblSalesAreaClients> TblSalesAreaClients { get; set; }
        public virtual DbSet<TblSalesAreaPersonnel> TblSalesAreaPersonnel { get; set; }
        public virtual DbSet<TblSalesmen> TblSalesmen { get; set; }
        public virtual DbSet<TblSalesStock> TblSalesStock { get; set; }
        public virtual DbSet<TblStocks> TblStocks { get; set; }
        public virtual DbSet<TblSubCategories> TblSubCategories { get; set; }
        public virtual DbSet<TblSubDepartments> TblSubDepartments { get; set; }
        public virtual DbSet<TblSupplierAccounts> TblSupplierAccounts { get; set; }
        public virtual DbSet<TblSuppliers> TblSuppliers { get; set; }
        public virtual DbSet<TblVisit> TblVisit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Database=Mobi2sale;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          

          

           
           
            
            modelBuilder.Entity<LkpCountries>(entity =>
            {
                entity.HasKey(e => e.PkCountriesId);

                entity.ToTable("lkp_Countries", "Admin");

                entity.Property(e => e.PkCountriesId).HasColumnName("pk_Countries_Id");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<LkpDistricts>(entity =>
            {
                entity.HasKey(e => e.PkDistrictsId);

                entity.ToTable("lkp_Districts", "Admin");

                entity.HasIndex(e => e.GovernorateId);

                entity.Property(e => e.PkDistrictsId).HasColumnName("pk_Districts_Id");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.LkpDistricts)
                    .HasForeignKey(d => d.GovernorateId);
            });

            modelBuilder.Entity<LkpGovernorates>(entity =>
            {
                entity.HasKey(e => e.PkGovernoratesId);

                entity.ToTable("lkp_Governorates", "Admin");

                entity.HasIndex(e => e.CountryId);

                entity.Property(e => e.PkGovernoratesId).HasColumnName("pk_Governorates_Id");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.LkpGovernorates)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<TblAdditionVoucherDetails>(entity =>
            {
                entity.HasKey(e => e.PkAdditionVoucherDetailsId);

                entity.ToTable("tbl_AdditionVoucherDetails", "Store");

                entity.HasIndex(e => e.FkAdditionVouchersAdditionVoucherDetailsAdditionVouchersId);

                entity.HasIndex(e => e.FkItemsAdditionVoucherDetailsItemsId);

                entity.Property(e => e.PkAdditionVoucherDetailsId)
                    .HasColumnName("pk_AdditionVoucherDetails_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkAdditionVouchersAdditionVoucherDetailsAdditionVouchersId).HasColumnName("fk_AdditionVouchers_AdditionVoucherDetails_AdditionVouchersId");

                entity.Property(e => e.FkItemsAdditionVoucherDetailsItemsId).HasColumnName("fk_Items_AdditionVoucherDetails_ItemsId");

                entity.HasOne(d => d.FkAdditionVouchersAdditionVoucherDetailsAdditionVouchers)
                    .WithMany(p => p.TblAdditionVoucherDetails)
                    .HasForeignKey(d => d.FkAdditionVouchersAdditionVoucherDetailsAdditionVouchersId);

                entity.HasOne(d => d.FkItemsAdditionVoucherDetailsItems)
                    .WithMany(p => p.TblAdditionVoucherDetails)
                    .HasForeignKey(d => d.FkItemsAdditionVoucherDetailsItemsId);
            });

            modelBuilder.Entity<TblAdditionVouchers>(entity =>
            {
                entity.HasKey(e => e.PkAdditionVouchersId);

                entity.ToTable("tbl_AdditionVouchers", "Store");

                entity.HasIndex(e => e.FkEmployeesAdditionVoucherEmployeeId);

                entity.HasIndex(e => e.FkStoresAdditionVoucherStoresId);

                entity.HasIndex(e => e.FkSuppliersAdditionVoucherSuppliersId);

                entity.Property(e => e.PkAdditionVouchersId)
                    .HasColumnName("pk_AdditionVouchers_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3216442+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Date).HasDefaultValueSql("('2020-04-07T01:01:37.3139232+02:00')");

                entity.Property(e => e.FkEmployeesAdditionVoucherEmployeeId).HasColumnName("fk_Employees_AdditionVoucher_EmployeeId");

                entity.Property(e => e.FkStoresAdditionVoucherStoresId).HasColumnName("fk_Stores_AdditionVoucher_StoresId");

                entity.Property(e => e.FkSuppliersAdditionVoucherSuppliersId).HasColumnName("fk_Suppliers_AdditionVoucher_SuppliersId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3217243+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkEmployeesAdditionVoucherEmployee)
                    .WithMany(p => p.TblAdditionVouchers)
                    .HasForeignKey(d => d.FkEmployeesAdditionVoucherEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FkStoresAdditionVoucherStores)
                    .WithMany(p => p.TblAdditionVouchers)
                    .HasForeignKey(d => d.FkStoresAdditionVoucherStoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FkSuppliersAdditionVoucherSuppliers)
                    .WithMany(p => p.TblAdditionVouchers)
                    .HasForeignKey(d => d.FkSuppliersAdditionVoucherSuppliersId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TblBranches>(entity =>
            {
                entity.HasKey(e => e.PkBranchesId);

                entity.ToTable("tbl_Branches", "Sales");

                entity.Property(e => e.PkBranchesId)
                    .HasColumnName("pk_Branches_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4304629+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FkSalesmenBranchesMgrId).HasColumnName("fk_Salesmen_Branches_MgrId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4305224+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();
            });

            modelBuilder.Entity<TblBranchStocks>(entity =>
            {
                entity.HasKey(e => e.PkBranchStockId);

                entity.ToTable("tbl_BranchStocks", "Store");

                entity.HasIndex(e => e.FkBranchBranchStockBranchId);

                entity.Property(e => e.PkBranchStockId)
                    .HasColumnName("pk_BranchStock_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3439990+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkBranchBranchStockBranchId).HasColumnName("fk_Branch_BranchStock_BranchId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3440805+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkBranchBranchStockBranch)
                    .WithMany(p => p.TblBranchStocks)
                    .HasForeignKey(d => d.FkBranchBranchStockBranchId);

                entity.HasOne(d => d.FkBranchBranchStockBranchNavigation)
                    .WithMany(p => p.TblBranchStocks)
                    .HasForeignKey(d => d.FkBranchBranchStockBranchId);
            });

            modelBuilder.Entity<TblCategories>(entity =>
            {
                entity.HasKey(e => e.PkCategoriesId);

                entity.ToTable("tbl_Categories", "Sales");

                entity.Property(e => e.PkCategoriesId)
                    .HasColumnName("pk_Categories_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4374693+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4375464+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.PkClientId);

                entity.ToTable("tbl_Client", "Admin");

                entity.HasIndex(e => e.FkClientsDistrictsDistrictId);

                entity.HasIndex(e => e.IdentityId)
                    .IsUnique()
                    .HasFilter("([IdentityId] IS NOT NULL)");

                entity.Property(e => e.PkClientId)
                    .HasColumnName("pk_Client_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4479911+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FkClientsDistrictsDistrictId).HasColumnName("fk_Clients_Districts_DistrictId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Limit).HasColumnType("money");

                entity.Property(e => e.ManagerName).IsRequired();

                entity.Property(e => e.Mobile1).IsRequired();

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4480828+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Target).HasColumnType("money");

                entity.Property(e => e.TargetEnd).HasDefaultValueSql("('2020-04-07T01:01:37.4515727+02:00')");

                entity.Property(e => e.TargetSatrt).HasDefaultValueSql("('2020-04-07T01:01:37.4516256+02:00')");

                entity.Property(e => e.TaxRecordNumber).IsRequired();

                entity.Property(e => e.TradeRecordNumber).IsRequired();

                entity.HasOne(d => d.FkClientsDistrictsDistrict)
                    .WithMany(p => p.TblClient)
                    .HasForeignKey(d => d.FkClientsDistrictsDistrictId);

                //entity.HasOne(d => d.Identity)
                //    .WithOne(p => p.TblClient)
                //    .HasForeignKey<TblClient>(d => d.IdentityId);
            });

            modelBuilder.Entity<TblClientAccounts>(entity =>
            {
                entity.HasKey(e => e.PkClientAccountsId);

                entity.ToTable("tbl_ClientAccounts", "Accounting");

                entity.HasIndex(e => e.FkClientsClientAccountsClientId);

                entity.Property(e => e.PkClientAccountsId)
                    .HasColumnName("pk_ClientAccounts_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5728866+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Date).HasDefaultValueSql("('2020-04-07T01:01:37.5728354+02:00')");

                entity.Property(e => e.FkClientsClientAccountsClientId).HasColumnName("fk_Clients_ClientAccounts_ClientId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5729475+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkClientsClientAccountsClient)
                    .WithMany(p => p.TblClientAccounts)
                    .HasForeignKey(d => d.FkClientsClientAccountsClientId);
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.HasKey(e => e.PkDepartmentsId);

                entity.ToTable("tbl_Departments", "HR");

                entity.Property(e => e.PkDepartmentsId)
                    .HasColumnName("pk_Departments_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4563958+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FkEmployeesDepartmentsMgrId).HasColumnName("fk_Employees_Departments_MgrId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4564581+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();
            });

            modelBuilder.Entity<TblEmployees>(entity =>
            {
                entity.HasKey(e => e.PkEmployeesId);

                entity.ToTable("tbl_Employees", "HR");

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.FkDistrictEmployeesDistrictId);

                entity.HasIndex(e => e.SubDepartmentId);

                entity.Property(e => e.PkEmployeesId)
                    .HasColumnName("pk_Employees_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4655407+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.FkDistrictEmployeesDistrictId).HasColumnName("fk_District_Employees_DistrictId");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Mobile1).IsRequired();

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4656221+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Street).IsRequired();

                entity.Property(e => e.VisaImage).IsRequired();

                entity.Property(e => e.VisaNumber).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.FkDistrictEmployeesDistrict)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.FkDistrictEmployeesDistrictId);

                entity.HasOne(d => d.SubDepartment)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.SubDepartmentId);
            });

            modelBuilder.Entity<TblExchangeVoucherDetails>(entity =>
            {
                entity.HasKey(e => e.PkExchangeVoucherDetailsId);

                entity.ToTable("tbl_ExchangeVoucherDetails", "Store");

                entity.HasIndex(e => e.FkExchangeVouchersExchangeVoucherDetailsExchangeVouchersId);

                entity.HasIndex(e => e.FkItemsExchangeVoucherDetailsItemsId);

                entity.Property(e => e.PkExchangeVoucherDetailsId)
                    .HasColumnName("pk_ExchangeVoucherDetails_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BarCode).IsRequired();

                entity.Property(e => e.FkExchangeVouchersExchangeVoucherDetailsExchangeVouchersId).HasColumnName("fk_ExchangeVouchers_ExchangeVoucherDetails_ExchangeVouchersId");

                entity.Property(e => e.FkItemsExchangeVoucherDetailsItemsId).HasColumnName("fk_Items_ExchangeVoucherDetails_ItemsId");

                entity.HasOne(d => d.FkExchangeVouchersExchangeVoucherDetailsExchangeVouchers)
                    .WithMany(p => p.TblExchangeVoucherDetails)
                    .HasForeignKey(d => d.FkExchangeVouchersExchangeVoucherDetailsExchangeVouchersId);

                entity.HasOne(d => d.FkItemsExchangeVoucherDetailsItems)
                    .WithMany(p => p.TblExchangeVoucherDetails)
                    .HasForeignKey(d => d.FkItemsExchangeVoucherDetailsItemsId);
            });

            modelBuilder.Entity<TblExchangeVouchers>(entity =>
            {
                entity.HasKey(e => e.PkExchangeVouchersId);

                entity.ToTable("tbl_ExchangeVouchers", "Store");

                entity.HasIndex(e => e.FkStoresExchangeVoucherFromStoresId);

                entity.Property(e => e.PkExchangeVouchersId)
                    .HasColumnName("pk_ExchangeVouchers_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3526370+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkStoresExchangeVoucherFromStoresId).HasColumnName("fk_Stores_ExchangeVoucher_FromStoresId");

                entity.Property(e => e.FkToStoresId).HasColumnName("fk_ToStoresId");

                entity.Property(e => e.IsBranch)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3527182+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkStoresExchangeVoucherFromStores)
                    .WithMany(p => p.TblExchangeVouchers)
                    .HasForeignKey(d => d.FkStoresExchangeVoucherFromStoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TblFavorites>(entity =>
            {
                entity.HasKey(e => e.PkFavoritesId);

                entity.ToTable("tbl_Favorites", "Sales");

                entity.HasIndex(e => e.FkClientId);

                entity.HasIndex(e => e.FkItemsId);

                entity.Property(e => e.PkFavoritesId)
                    .HasColumnName("pk_Favorites_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3901801+02:00')");

                entity.Property(e => e.FkClientId).HasColumnName("fk_Client_Id");

                entity.Property(e => e.FkItemsId).HasColumnName("fk_Items_Id");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3903097+02:00')");

                entity.HasOne(d => d.FkClient)
                    .WithMany(p => p.TblFavorites)
                    .HasForeignKey(d => d.FkClientId);

                entity.HasOne(d => d.FkItems)
                    .WithMany(p => p.TblFavorites)
                    .HasForeignKey(d => d.FkItemsId);
            });

            modelBuilder.Entity<TblHandStockValue>(entity =>
            {
                entity.HasKey(e => e.PkHandStockValueId);

                entity.ToTable("tbl_HandStockValue", "Store");

                entity.HasIndex(e => e.FkSalesmanHandStockValueSalesId);

                entity.Property(e => e.PkHandStockValueId)
                    .HasColumnName("pk_HandStockValue_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3647144+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkSalesmanHandStockValueSalesId).HasColumnName("fk_Salesman_HandStockValue_SalesId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3647812+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkSalesmanHandStockValueSales)
                    .WithMany(p => p.TblHandStockValue)
                    .HasForeignKey(d => d.FkSalesmanHandStockValueSalesId);
            });

            modelBuilder.Entity<TblIndoorInvoiceDetails>(entity =>
            {
                entity.HasKey(e => e.PkIndoorInvoiceDetailsId);

                entity.ToTable("tbl_IndoorInvoiceDetails", "Sales");

                entity.HasIndex(e => e.FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeaderId);

                entity.HasIndex(e => e.FkItemsAdditionVoucherDetailsItemsId);

                entity.Property(e => e.PkIndoorInvoiceDetailsId)
                    .HasColumnName("pk_IndoorInvoiceDetails_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Barcode).IsRequired();

                entity.Property(e => e.FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeaderId).HasColumnName("fk_IndoorInvoiceHeader_IndoorInvoiceDetails_HeaderId");

                entity.Property(e => e.FkItemsAdditionVoucherDetailsItemsId).HasColumnName("fk_Items_AdditionVoucherDetails_ItemsId");

                entity.HasOne(d => d.FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeader)
                    .WithMany(p => p.TblIndoorInvoiceDetails)
                    .HasForeignKey(d => d.FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeaderId);

                entity.HasOne(d => d.FkItemsAdditionVoucherDetailsItems)
                    .WithMany(p => p.TblIndoorInvoiceDetails)
                    .HasForeignKey(d => d.FkItemsAdditionVoucherDetailsItemsId);
            });

            modelBuilder.Entity<TblIndoorInvoiceHeader>(entity =>
            {
                entity.ToTable("tbl_IndoorInvoiceHeader", "Sales");

                entity.HasIndex(e => e.FkBranchesIndoorSalesInvoiceBranchId);

                entity.HasIndex(e => e.FkEmployeesIndoorSalesInvoiceEmployeeId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5538141+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkBranchesIndoorSalesInvoiceBranchId).HasColumnName("fk_Branches_IndoorSalesInvoice_BranchId");

                entity.Property(e => e.FkEmployeesIndoorSalesInvoiceEmployeeId).HasColumnName("fk_Employees_IndoorSalesInvoice_EmployeeId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5538777+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkBranchesIndoorSalesInvoiceBranch)
                    .WithMany(p => p.TblIndoorInvoiceHeader)
                    .HasForeignKey(d => d.FkBranchesIndoorSalesInvoiceBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FkEmployeesIndoorSalesInvoiceEmployee)
                    .WithMany(p => p.TblIndoorInvoiceHeader)
                    .HasForeignKey(d => d.FkEmployeesIndoorSalesInvoiceEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TblItems>(entity =>
            {
                entity.HasKey(e => e.PkItemsId);

                entity.ToTable("tbl_Items", "Sales");

                entity.HasIndex(e => e.FkOffersItemsOfferId);

                entity.HasIndex(e => e.FkSubCategoriesItemsSubcategoryId);

                entity.Property(e => e.PkItemsId)
                    .HasColumnName("pk_Items_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasComputedColumnSql("([Quantity]-[BookedUp])");

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.CoverImageUrl).IsRequired();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4754110+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkOffersItemsOfferId).HasColumnName("fk_Offers_Items_OfferId");

                entity.Property(e => e.FkSubCategoriesItemsSubcategoryId).HasColumnName("fk_subCategories_Items_SubcategoryId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MainImageUrl).IsRequired();

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4754755+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RetailPrice).HasColumnType("money");

                entity.Property(e => e.SupplyPrice).HasColumnType("money");

                entity.Property(e => e.WholesalePrice).HasColumnType("money");

                entity.HasOne(d => d.FkOffersItemsOffer)
                    .WithMany(p => p.TblItems)
                    .HasForeignKey(d => d.FkOffersItemsOfferId);

                entity.HasOne(d => d.FkSubCategoriesItemsSubcategory)
                    .WithMany(p => p.TblItems)
                    .HasForeignKey(d => d.FkSubCategoriesItemsSubcategoryId);
            });

            modelBuilder.Entity<TblItemTransactionss>(entity =>
            {
                entity.HasKey(e => e.PkItemTransactionId);

                entity.ToTable("tbl_ItemTransactionss", "Store");

                entity.HasIndex(e => e.FkItemsStocksItemId);

                entity.Property(e => e.PkItemTransactionId)
                    .HasColumnName("pk_ItemTransaction_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkItemsStocksItemId).HasColumnName("fk_Items_Stocks_ItemId");

                entity.Property(e => e.From).IsRequired();

                entity.Property(e => e.To).IsRequired();

                entity.Property(e => e.TransactionType).IsRequired();

                entity.HasOne(d => d.FkItemsStocksItem)
                    .WithMany(p => p.TblItemTransactionss)
                    .HasForeignKey(d => d.FkItemsStocksItemId);
            });

            modelBuilder.Entity<TblOffers>(entity =>
            {
                entity.HasKey(e => e.PkOffersId);

                entity.ToTable("tbl_Offers", "Sales");

                entity.Property(e => e.PkOffersId)
                    .HasColumnName("pk_Offers_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5401593+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5402211+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ReadOnly)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<TblOfferTarget>(entity =>
            {
                entity.HasKey(e => e.PkOfferTargetId);

                entity.ToTable("tbl_OfferTarget", "Store");

                entity.HasIndex(e => e.FkOfferOfferTargetOffreId);

                entity.Property(e => e.PkOfferTargetId)
                    .HasColumnName("pk_OfferTarget_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkOfferOfferTargetOffreId).HasColumnName("fk_Offer_OfferTarget_OffreId");

                entity.HasOne(d => d.FkOfferOfferTargetOffre)
                    .WithMany(p => p.TblOfferTarget)
                    .HasForeignKey(d => d.FkOfferOfferTargetOffreId);
            });

            modelBuilder.Entity<TblOrderDetails>(entity =>
            {
                entity.HasKey(e => e.PkOrderDetailsId);

                entity.ToTable("tbl_OrderDetails", "Sales");

                entity.HasIndex(e => e.FkItemsId);

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.PkOrderDetailsId)
                    .HasColumnName("pk_OrderDetails_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4068740+02:00')");

                entity.Property(e => e.FkItemsId).HasColumnName("fk_Items_Id");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4069555+02:00')");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.FkItems)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.FkItemsId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<TblOrders>(entity =>
            {
                entity.HasKey(e => e.PkOrdersId);

                entity.ToTable("tbl_Orders", "Sales");

                entity.HasIndex(e => e.FkClientsOrdersClientId);

                entity.Property(e => e.PkOrdersId)
                    .HasColumnName("pk_Orders_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3999346+02:00')");

                entity.Property(e => e.FkClientsOrdersClientId).HasColumnName("fk_Clients_Orders_ClientId");

                entity.Property(e => e.IsCancelled)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3999858+02:00')");

                entity.Property(e => e.OnDelivery)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OrderDate).HasColumnName("Order_Date");

                entity.Property(e => e.OrderIsOrder).HasColumnName("Order_IsOrder");

                entity.Property(e => e.OrderIsPaid)
                    .IsRequired()
                    .HasColumnName("Order_IsPaid")
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OrderStatus).HasDefaultValueSql("(N'No Action')");

                entity.HasOne(d => d.FkClientsOrdersClient)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.FkClientsOrdersClientId);
            });

            modelBuilder.Entity<TblPromos>(entity =>
            {
                entity.HasKey(e => e.PkPromosId);

                entity.ToTable("tbl_Promos", "Sales");

                entity.Property(e => e.PkPromosId)
                    .HasColumnName("pk_Promos_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllClients)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5593234+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5593843+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblPromoTargets>(entity =>
            {
                entity.HasKey(e => e.PkPromoTargetsId);

                entity.ToTable("tbl_PromoTargets", "Sales");

                entity.HasIndex(e => e.ClientId);

                entity.HasIndex(e => e.FkPromosPromoTargetsPromoId);

                entity.Property(e => e.PkPromoTargetsId)
                    .HasColumnName("pk_PromoTargets_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkPromosPromoTargetsPromoId).HasColumnName("fk_Promos_PromoTargets_PromoId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblPromoTargets)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.FkPromosPromoTargetsPromo)
                    .WithMany(p => p.TblPromoTargets)
                    .HasForeignKey(d => d.FkPromosPromoTargetsPromoId);
            });

            modelBuilder.Entity<TblSalesArea>(entity =>
            {
                entity.HasKey(e => e.PkSalesAreaId);

                entity.ToTable("tbl_SalesArea", "Sales");

                entity.Property(e => e.PkSalesAreaId)
                    .HasColumnName("pk_SalesArea_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4875410+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4876006+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblSalesAreaClients>(entity =>
            {
                entity.HasKey(e => e.PkSalesAreaClientId);

                entity.ToTable("tbl_SalesAreaClients", "Sales");

                entity.HasIndex(e => e.FkSalesAreaClientsClientsClientId)
                    .IsUnique();

                entity.HasIndex(e => e.FkSalesAreaClientsSalesAreasSalesAreaId);

                entity.Property(e => e.PkSalesAreaClientId)
                    .HasColumnName("pk_SalesAreaClient_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4822684+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkSalesAreaClientsClientsClientId).HasColumnName("fk_SalesAreaClients_Clients_ClientId");

                entity.Property(e => e.FkSalesAreaClientsSalesAreasSalesAreaId).HasColumnName("fk_SalesAreaClients_SalesAreas_salesAreaId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4823254+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkSalesAreaClientsClientsClient)
                    .WithOne(p => p.TblSalesAreaClients)
                    .HasForeignKey<TblSalesAreaClients>(d => d.FkSalesAreaClientsClientsClientId);

                entity.HasOne(d => d.FkSalesAreaClientsSalesAreasSalesArea)
                    .WithMany(p => p.TblSalesAreaClients)
                    .HasForeignKey(d => d.FkSalesAreaClientsSalesAreasSalesAreaId);
            });

            modelBuilder.Entity<TblSalesAreaPersonnel>(entity =>
            {
                entity.HasKey(e => e.PkSalesAreaPersonnelId);

                entity.ToTable("tbl_SalesAreaPersonnel", "Sales");

                entity.HasIndex(e => e.FkSalesAreaPersonnelSalesAreasSalesAreaId);

                entity.HasIndex(e => e.FkSalesAreaPersonnelSalesmenSalesId)
                    .IsUnique();

                entity.Property(e => e.PkSalesAreaPersonnelId)
                    .HasColumnName("pk_SalesAreaPersonnel_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4932542+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkSalesAreaPersonnelSalesAreasSalesAreaId).HasColumnName("fk_SalesAreaPersonnel_SalesAreas_salesAreaId");

                entity.Property(e => e.FkSalesAreaPersonnelSalesmenSalesId).HasColumnName("fk_SalesAreaPersonnel_Salesmen_salesId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.4933148+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkSalesAreaPersonnelSalesAreasSalesArea)
                    .WithMany(p => p.TblSalesAreaPersonnel)
                    .HasForeignKey(d => d.FkSalesAreaPersonnelSalesAreasSalesAreaId);

                entity.HasOne(d => d.FkSalesAreaPersonnelSalesmenSales)
                    .WithOne(p => p.TblSalesAreaPersonnel)
                    .HasForeignKey<TblSalesAreaPersonnel>(d => d.FkSalesAreaPersonnelSalesmenSalesId);
            });

            modelBuilder.Entity<TblSalesmen>(entity =>
            {
                entity.HasKey(e => e.PkSalesmanId);

                entity.ToTable("tbl_Salesmen", "Sales");

                entity.HasIndex(e => e.FkSalesmenEmployeeId)
                    .IsUnique();

                entity.Property(e => e.PkSalesmanId)
                    .HasColumnName("pk_Salesman_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5018798+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkSalesmenEmployeeId).HasColumnName("fk_Salesmen_Employee_Id");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Limit).HasColumnType("money");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5018215+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Target).HasColumnType("money");

                entity.HasOne(d => d.FkSalesmenEmployee)
                    .WithOne(p => p.TblSalesmen)
                    .HasForeignKey<TblSalesmen>(d => d.FkSalesmenEmployeeId);
            });

            modelBuilder.Entity<TblSalesStock>(entity =>
            {
                entity.HasKey(e => e.PkSalesStockId);

                entity.ToTable("tbl_SalesStock", "Store");

                entity.HasIndex(e => e.FkItemsSalesStockItemsId);

                entity.HasIndex(e => e.FkSalesmanSalesStockSalesId);

                entity.Property(e => e.PkSalesStockId)
                    .HasColumnName("pk_SalesStock_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3805962+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkExchangeVouchersSalesStockExchangeVoucherId).HasColumnName("fk_ExchangeVouchers_SalesStock_ExchangeVoucherId");

                entity.Property(e => e.FkItemsSalesStockItemsId).HasColumnName("fk_Items_SalesStock_ItemsId");

                entity.Property(e => e.FkSalesmanSalesStockSalesId).HasColumnName("fk_Salesman_SalesStock_SalesId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.3806535+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkItemsSalesStockItems)
                    .WithMany(p => p.TblSalesStock)
                    .HasForeignKey(d => d.FkItemsSalesStockItemsId);

                entity.HasOne(d => d.FkSalesmanSalesStockSales)
                    .WithMany(p => p.TblSalesStock)
                    .HasForeignKey(d => d.FkSalesmanSalesStockSalesId);
            });

            modelBuilder.Entity<TblStocks>(entity =>
            {
                entity.HasKey(e => e.PkStocksId);

                entity.ToTable("tbl_Stocks", "Store");

                entity.HasIndex(e => e.FkItemsStocksItemId);

                entity.Property(e => e.PkStocksId)
                    .HasColumnName("pk_Stocks_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkItemsStocksItemId).HasColumnName("fk_Items_Stocks_ItemId");

                entity.HasOne(d => d.FkItemsStocksItem)
                    .WithMany(p => p.TblStocks)
                    .HasForeignKey(d => d.FkItemsStocksItemId);
            });

            modelBuilder.Entity<TblSubCategories>(entity =>
            {
                entity.HasKey(e => e.PkSubCategoriesId);

                entity.ToTable("tbl_SubCategories", "Sales");

                entity.HasIndex(e => e.FkCategoriesSubCategoriesCategoryId);

                entity.Property(e => e.PkSubCategoriesId)
                    .HasColumnName("pk_SubCategories_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5072697+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkCategoriesSubCategoriesCategoryId).HasColumnName("fk_Categories_subCategories_CategoryId");

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5073276+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.FkCategoriesSubCategoriesCategory)
                    .WithMany(p => p.TblSubCategories)
                    .HasForeignKey(d => d.FkCategoriesSubCategoriesCategoryId);
            });

            modelBuilder.Entity<TblSubDepartments>(entity =>
            {
                entity.HasKey(e => e.PkSubDepartmentsId);

                entity.ToTable("tbl_SubDepartments", "HR");

                entity.HasIndex(e => e.FkDepartmentsSubDepartmentsDepartmentId);

                entity.Property(e => e.PkSubDepartmentsId)
                    .HasColumnName("pk_SubDepartments_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5144659+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FkDepartmentsSubDepartmentsDepartmentId).HasColumnName("fk_Departments_SubDepartments_DepartmentId");

                entity.Property(e => e.FkEmployeesSubDepartmentsManagerId).HasColumnName("fk_Employees_SubDepartments_ManagerID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsStore)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5145315+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();

                entity.HasOne(d => d.FkDepartmentsSubDepartmentsDepartment)
                    .WithMany(p => p.TblSubDepartments)
                    .HasForeignKey(d => d.FkDepartmentsSubDepartmentsDepartmentId);
            });

            modelBuilder.Entity<TblSupplierAccounts>(entity =>
            {
                entity.HasKey(e => e.PkSupplierAccountsId);

                entity.ToTable("tbl_SupplierAccounts", "Accounting");

                entity.HasIndex(e => e.FkSuppliersSupplierAccountsSuppliersId);

                entity.Property(e => e.PkSupplierAccountsId)
                    .HasColumnName("pk_SupplierAccounts_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5795629+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Date).HasDefaultValueSql("('2020-04-07T01:01:37.5795113+02:00')");

                entity.Property(e => e.FkSuppliersSupplierAccountsSuppliersId).HasColumnName("fk_Suppliers_SupplierAccounts_SuppliersId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5796080+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.HasOne(d => d.FkSuppliersSupplierAccountsSuppliers)
                    .WithMany(p => p.TblSupplierAccounts)
                    .HasForeignKey(d => d.FkSuppliersSupplierAccountsSuppliersId);
            });

            modelBuilder.Entity<TblSuppliers>(entity =>
            {
                entity.HasKey(e => e.PkSuppliersId);

                entity.ToTable("tbl_Suppliers", "Purchase");

                entity.HasIndex(e => e.FkCountrySupplierCountryId);

                entity.Property(e => e.PkSuppliersId)
                    .HasColumnName("pk_Suppliers_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5221625+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.Fax).IsRequired();

                entity.Property(e => e.FkCountrySupplierCountryId).HasColumnName("fk_Country_Supplier_CountryId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Mobile1).IsRequired();

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5222252+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();

                entity.HasOne(d => d.FkCountrySupplierCountry)
                    .WithMany(p => p.TblSuppliers)
                    .HasForeignKey(d => d.FkCountrySupplierCountryId);
            });

            modelBuilder.Entity<TblVisit>(entity =>
            {
                entity.ToTable("tbl_Visit", "Sales");

                entity.HasIndex(e => e.FkClientsVisitClientId);

                entity.HasIndex(e => e.FkSalesmanVisitSalesmanId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CraetedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5659051+02:00')");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.FeedBack)
                    .IsRequired()
                    .HasDefaultValueSql("(N'Open Visit')");

                entity.Property(e => e.FkClientsVisitClientId).HasColumnName("fk_Clients_Visit_ClientId");

                entity.Property(e => e.FkSalesmanVisitSalesmanId).HasColumnName("fk_Salesman_Visit_SalesmanId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("('2020-04-07T01:01:37.5659518+02:00')");

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.VisitDate).HasDefaultValueSql("('2020-04-07T01:01:37.5658536+02:00')");

                entity.HasOne(d => d.FkClientsVisitClient)
                    .WithMany(p => p.TblVisit)
                    .HasForeignKey(d => d.FkClientsVisitClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FkSalesmanVisitSalesman)
                    .WithMany(p => p.TblVisit)
                    .HasForeignKey(d => d.FkSalesmanVisitSalesmanId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
