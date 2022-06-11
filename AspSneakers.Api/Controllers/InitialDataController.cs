using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private SneakersDbContext _context;

        public InitialDataController(SneakersDbContext context)
        {
            _context = context;
        }

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            var brands = new List<Brand>
            {
                new Brand{Name="Nike"},
                new Brand{Name="Adidas"},
                new Brand{Name="Converse"},
                new Brand{Name="Reebok"},
                new Brand{Name="New Balance"},
                new Brand{Name="Vans"},
                new Brand{Name="Puma"},
                new Brand{Name="Jordan"},
                new Brand{Name="Yeezy"},
                new Brand{Name="Asics"},
                new Brand{Name="Saucony"},
                new Brand{Name="Veja"},
                new Brand{Name="Salomon"},
            };


            var categories = new List<Category>
            {
                new Category{Name="Sportstyle",isDeleted=false},
                new Category{Name="Summer",isDeleted=false },
                new Category{Name="Rain",isDeleted=false},
                new Category{Name="Winter",isDeleted=false},
                new Category{Name="Running",isDeleted=false},
                new Category{Name="Hiking",isDeleted=false},//5
            };

            var genders = new List<Gender>
            {
                new Gender{Name="male"},
                new Gender{Name="female"},
                new Gender{Name="unisex"},
            };
            var roles = new List<Role>
            {
                new Role{Name="Administrator"},
                new Role{Name="Customer"},
            };

            var sizes = new List<Size>
            {
                new Size{Number=32},
                new Size{Number=33},
                new Size{Number=34},
                new Size{Number=35},
                new Size{Number=36},
                new Size{Number=37},
                new Size{Number=38},
                new Size{Number=39},
                new Size{Number=40},
                new Size{Number=42},
                new Size{Number=43},
                new Size{Number=44},
                new Size{Number=45},
                new Size{Number=46},
                new Size{Number=47},//14
            };
            
            var users = new List<User>
            {
                 new User{FirstName="Admin",Username="admin",LastName="Admin",Email="admin@gmail.com",Address="Starine Novaka",Password=BCrypt.Net.BCrypt.HashPassword("Sifra123!"),Role=roles.ElementAt(0)},
                 new User{FirstName="Test",Username="test",LastName="Test",Email="test@gmail.com",Address="Jovana Skerlica 9e",Password=BCrypt.Net.BCrypt.HashPassword("Sifra123!"),Role=roles.ElementAt(1)}
               
            };

            

            var products = new List<Product>
            {
                new Product{Name="ADIDAS SUPERSTAR 5",Brand = brands.ElementAt(1),Gender=genders.FirstOrDefault(),
                Description="Bold and rebellious, striking adidas Rich Mnisi Superstar OT Tech women's lifestyle sneakers represent the latest chapter in the development of the Superstar model."},
                new Product{Name="NIKE AIR FORCE 1 07",Brand = brands.ElementAt(0),Gender=genders.ElementAt(1),
                Description="Nike Air Force 1 07 mens lifestyle sneakers make your style warm. These sneakers added a winter note to what you know best: stitched layers on the top and bold details."},
                new Product{Name="PUMA RSX NEO FADE",Brand = brands.ElementAt(6),Gender=genders.ElementAt(0),
                Description="Puma RSX NEO FADE are men's, lifestyle sneakers. Sneakers that will refresh your shoe collection and bring bright colors, perfect for sunny days. They have an airy upper, with leather reinforcement in the area of ​​the fingers."},
                new Product{Name="ASICS GEL KAYANO 14",Brand = brands.ElementAt(9),Gender=genders.ElementAt(0),
                Description="ASICS GEL KAYANO 14 women's sneakers give your mind and body the energy and strength to constantly move forward. Their appearance is modeled on the cult ASICS model GEL-LYTE ™ III, thus paying homage to the rich ASICS heritage."},
                new Product{Name="Converse Chuck Taylor All Star",Brand = brands.ElementAt(2),Gender=genders.ElementAt(2),
                Description="Converse CHUCK TAYLOR ALL STAR are lifestyle sneakers that combine classic and modern details in their unsurpassed design."},
                new Product{Name="Answer IV Men's Basketball Shoes",Brand = brands.ElementAt(3),Gender=genders.ElementAt(0),
                Description="The shaped part on the heel and the details in the ankle area are taken from the AJ3 model. The skin layers in the upper associate with AJ11,"},
                new Product{Name="QUEST 4 GORE-TEX",Brand = brands.ElementAt(12),Gender=genders.ElementAt(1),
                Description="The pursuit of speed continues with the  Quest 4. Higher foam heights and cushioned comfort combine with a lightweight upper that offers secure support. Intuitive details make it a staple for the everyday runner."},
            };

            var productsizes = new List<ProductSize>
            {
                new ProductSize{Product=products.ElementAt(0),Size = sizes.ElementAt(5),Stock=2},
                new ProductSize{Product=products.ElementAt(0),Size = sizes.ElementAt(6),Stock=4},
                new ProductSize{Product=products.ElementAt(0),Size = sizes.ElementAt(7),Stock=10},
                new ProductSize{Product=products.ElementAt(1),Size = sizes.ElementAt(10),Stock=1},
                new ProductSize{Product=products.ElementAt(1),Size = sizes.ElementAt(14),Stock=1},
                new ProductSize{Product=products.ElementAt(1),Size = sizes.ElementAt(12),Stock=10},
                new ProductSize{Product=products.ElementAt(2),Size = sizes.ElementAt(10),Stock=15},
                new ProductSize{Product=products.ElementAt(2),Size = sizes.ElementAt(9),Stock=4},
                new ProductSize{Product=products.ElementAt(2),Size = sizes.ElementAt(4),Stock=7},
                new ProductSize{Product=products.ElementAt(3),Size = sizes.ElementAt(12),Stock=3},
                new ProductSize{Product=products.ElementAt(3),Size = sizes.ElementAt(13),Stock=20},
                new ProductSize{Product=products.ElementAt(3),Size = sizes.ElementAt(14),Stock=4},
                new ProductSize{Product=products.ElementAt(4),Size = sizes.ElementAt(4),Stock=11},
                new ProductSize{Product=products.ElementAt(4),Size = sizes.ElementAt(3),Stock=6},
                new ProductSize{Product=products.ElementAt(4),Size = sizes.ElementAt(10),Stock=10},
                new ProductSize{Product=products.ElementAt(5),Size = sizes.ElementAt(10),Stock=13},
                new ProductSize{Product=products.ElementAt(5),Size = sizes.ElementAt(11),Stock=16},
                new ProductSize{Product=products.ElementAt(5),Size = sizes.ElementAt(12),Stock=1},
                new ProductSize{Product=products.ElementAt(6),Size = sizes.ElementAt(12),Stock=5},
                new ProductSize{Product=products.ElementAt(6),Size = sizes.ElementAt(14),Stock=24},
                new ProductSize{Product=products.ElementAt(6),Size = sizes.ElementAt(8),Stock=4},
            };

            var priceproducts = new List<PriceProduct>
            {
                new PriceProduct{Product = products.ElementAt(0),Price=120 },
                new PriceProduct{Product = products.ElementAt(1),Price=150 },
                new PriceProduct{Product = products.ElementAt(2),Price=200 },
                new PriceProduct{Product = products.ElementAt(3),Price=190 },
                new PriceProduct{Product = products.ElementAt(4),Price=170 },
                new PriceProduct{Product = products.ElementAt(5),Price=250 },
                new PriceProduct{Product = products.ElementAt(6),Price=40 },
            };


            var productcategories = new List<ProductCategory>
            {
                new ProductCategory{Product = products.ElementAt(0),Category = categories.ElementAt(2)},
                new ProductCategory{Product = products.ElementAt(0),Category = categories.ElementAt(1)},
                new ProductCategory{Product = products.ElementAt(1),Category = categories.ElementAt(5)},
                new ProductCategory{Product = products.ElementAt(1),Category = categories.ElementAt(4)},
                new ProductCategory{Product = products.ElementAt(2),Category = categories.ElementAt(5)},
                new ProductCategory{Product = products.ElementAt(2),Category = categories.ElementAt(2)},
                new ProductCategory{Product = products.ElementAt(3),Category = categories.ElementAt(1)},
                new ProductCategory{Product = products.ElementAt(3),Category = categories.ElementAt(2)},
                new ProductCategory{Product = products.ElementAt(4),Category = categories.ElementAt(4)},
                new ProductCategory{Product = products.ElementAt(5),Category = categories.ElementAt(1)},
                new ProductCategory{Product = products.ElementAt(5),Category = categories.ElementAt(5)},
                new ProductCategory{Product = products.ElementAt(6),Category = categories.ElementAt(1)},
            };

            var userusecases = new List<UserUseCase>
            {
                new UserUseCase{User = users.ElementAt(0),UseCaseId=1},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=2},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=3},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=4},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=5},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=6},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=7},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=8},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=9},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=10},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=11},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=12},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=13},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=14},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=15},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=16},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=17},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=18},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=19},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=20},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=21},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=22},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=23},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=24},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=25},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=26},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=27},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=28},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=29},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=30},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=31},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=32},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=33},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=34},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=35},
                new UserUseCase{User = users.ElementAt(0),UseCaseId=36},
                new UserUseCase{User = users.ElementAt(1),UseCaseId=3},
                new UserUseCase{User = users.ElementAt(1),UseCaseId=6},
                new UserUseCase{User = users.ElementAt(1),UseCaseId=10},
                new UserUseCase{User = users.ElementAt(1),UseCaseId=15},
                new UserUseCase{User = users.ElementAt(1),UseCaseId=32},
            };


            _context.Products.AddRange(products);
            _context.Brands.AddRange(brands);
            _context.Categories.AddRange(categories);
            _context.Genders.AddRange(genders);
            _context.ProductCategories.AddRange(productcategories);
            _context.Users.AddRange(users);
            _context.Roles.AddRange(roles);
            _context.Sizes.AddRange(sizes);
            _context.ProductSizes.AddRange(productsizes);
            _context.PriceProducts.AddRange(priceproducts);
            _context.UserUseCases.AddRange(userusecases);


            _context.SaveChanges();


            return StatusCode(201);



        }

    }
}
