namespace BlazorCommerce.Server.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData
          (
              new CategoryModel()
              {
                  Id = 1,
                  Name = "Books",
                  NameForUrl = "books"
              },

              new CategoryModel()
              {
                  Id = 2,
                  Name = "Movies",
                  NameForUrl = "movies"
              },

               new CategoryModel()
               {
                   Id = 3,
                   Name = "Video Games",
                   NameForUrl = "video-games"
               }

          );


            modelBuilder.Entity<ProductModel>().HasData
                (
                    new ProductModel
                    {
                        Id = 1,
                        Title = "A Balcony in the Forest",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries,",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/A_Balcony_in_the_Forest.jpg",
                        Price = 9.99M,
                        CategoryId = 1
                    },

                    new ProductModel
                    {
                        Id = 2,
                        Title = "A Beast the Color of Winter cover",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries,",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d1/A_Beast_the_Color_of_Winter_cover.jpg",
                        Price = 8.99M,
                        CategoryId = 1
                    },

                    new ProductModel
                    {
                        Id = 3,
                        Title = "A Blade So Black",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries,",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/db/A_Blade_So_Black_cover.jpg",
                        Price = 32.99M,
                        CategoryId = 1
                    }

                );

          
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
