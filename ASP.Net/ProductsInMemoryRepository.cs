using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Монитор AOC 32 CQ32G1", 40290,"31.5","/images/image1.jpg","2560x1440 (Quad HD)", "VA", "1 мс", "144 Гц", "чёрный","AOC"),
            new Product("Монитор AOC CU34G2/BK", 37855,"34", "/images/image2.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "AOC"),
            new Product("Монитор AOC AGON AG352UCG6", 98890, "34","/images/image3.png", "3440x1440","*VA", "1 мс", "100 Гц", "черный", "AOC"),
            new Product("Монитор Acer Predator Z35P", 82126, "35"," /images/Image4.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "Acer"),
            new Product("Монитор Acer 49 EI491CRPbmiiipx Nitro", 89680, "49", "/images/image5.jpg","3840x1080", "VA", "4 мс", "144 Гц", "чёрный", "Acer"),
            new Product("Монитор Acer Predator Z35P", 89220, "35", "/images/image6.jpg","2560x1080 (UltraWide FHD)", "VA", "4мс", "100 Гц", "чёрный", "Acer"),
            new Product("Монитор MSI MPG341CQR", 34685, "34", "/images/image7.jpg", "3440x1440 (21:9)", "*VA", "4мс", "144 Гц", "чёрный", "MSI")
        };

        public void Add(Product monitorsProduct)
        {
            monitorsProduct.ImagePath = "/images/image1.jpg";
            products.Add(monitorsProduct);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void Remove(int productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);
            products.Remove(product);
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);

            if(existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Diagonal = product.Diagonal;
            //existingProduct.ImagePath = product.ImagePath;
            existingProduct.ScreenResolution = product.ScreenResolution;
            existingProduct.Matrix = product.Matrix;
            existingProduct.Response = product.Response;
            existingProduct.Hz = product.Hz;
            existingProduct.Color = product.Color;
            existingProduct.Company = product.Company;
        }
    }
}
