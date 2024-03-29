﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductsDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        //private List<Product> products = new List<Product>()
        //{
        //    new Product("AOC 32 CQ32G1", 40_290,"31.5","/images/image1.jpg","2560x1440 (Quad HD)", "VA", "1 мс", "144 Гц", "чёрный","AOC","Монитор AOC Gaming CQ32G1 имеет изогнутую конструкцию и безрамочный трехсторонний дизайн. В сочетании с диагональю 31.5 дюйма и рабочей областью 697.34x392.25 мм это делает модель настоящей находкой для геймера. Разрешение дисплея, основанного на VA-матрице, составляет 2560x1440 пикселей. Технология защиты зрения позволяет владельцу проводить за монитором AOC Gaming CQ32G1 много часов подряд без малейшего чувства усталости для глаз. Контрастность дисплея (3000:1) сочетается с углами обзора по вертикали и горизонтали 178°."),
        //    new Product("AOC CU34G2/BK", 37_855,"34", "/images/image2.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "AOC", "Игровой монитор AOC CU34G2/BK оптимален для любителей и профессиональных геймеров. Модель позволяет наслаждаться захватывающими гонками, опасными сражениями и схватками на изогнутом экране диагональю 34 дюйма. Разрешение 3440x1440 пикселей обеспечивает детализированное и реалистичное изображение. Благодаря быстрому времени отклика и оптимальной частоте обновления на устройстве плавно воспроизводится видео без разрыва, прерывания и размытия картинки даже в динамичных сценах. Это позволяет максимально точно наносить удары сопернику и контролировать действия противника."),
        //    new Product("AOC AGON AG352G6", 98_890, "34","/images/image3.png", "3440x1440","*VA", "1 мс", "100 Гц", "черный", "AOC", "Игровой монитор AOC AG352G6 имеет экран диагональю 34 дюймов. Технология вертикального выравнивания способствует передаче максимально реалистичного изображения. Устройство характеризуется высокой контрастностью и качественной цветопередачей. Модель надежно фиксируется на подставке с шарнирным креплением, что позволяет регулировать наклон и высоту в зависимости от индивидуальных предпочтений пользователя."),
        //    new Product("Acer Predator Z35P", 82_126, "35"," /images/Image4.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "Acer", "Монитор Acer Predator Z35 с изогнутым экраном – настоящая находка для опытных геймеров и киберспортсменов. Высокое качество изображения и широкие возможности для регулировки экрана значительно повышают шансы владельца на победу в игре."),
        //    new Product("Acer 49 EI41Pb Nitro", 96_680, "49", "/images/image5.jpg","3840x1080", "VA", "4 мс", "144 Гц", "чёрный", "Acer", "Большой монитор 49 Acer Nitro EI491CRPbmiiipx [UM.SE1EE.P01] с изогнутым экраном 1800R отлично подойдет для игр и работы за компьютером. Широкий угол обзора и разрешение DFHD позволит увидеть даже самую мелкую деталь. Экран VA с разрешением 3840х1080 передает цвета с максимальной точностью. Система AMD® Radeon™ FreeSync 21 позволяет устранить прерывание и подвисание картинки. Благодаря пропорциям экрана 32:9 и игровой зоне просмотра 16:9, вы получите еще больше погруженности в игру. В мониторе можно увеличить обработку кадров до 144 Гц2, что улучшит плавность динамичных сцен."),
        //    new Product("LG UltraGear 27GL83A-B", 39_220, "27", "/images/image6.PNG","2560x1440", "IPS", "1мс", "144 Гц", "чёрный", "LG", "Игровой монитор 27GL83A-B UltraGear позволит вам почувствовать всю яркость захватывающего приключения в виртуальном мире. Дисплей IPS 99% обладает исключительной точностью передачи цвета и визуальных эффектов, а широкий угол обзора сделает картинку боя более зрелищной. Скорость отклика равна 1 мс на сверхточном дисплее Nano IPS, что обеспечит вашу победу без ненужных побочных последствий."),
        //    new Product("MSI Optix MPG341CQR", 100_685, "34", "/images/image7.jpg", "3440x1440 (21:9)", "*VA", "4мс", "144 Гц", "чёрный", "MSI", "Монитор MSI Optix MPG341CQR в корпусе черного цвета будет оптимален при эксплуатации с игровым системным блоком и позволит вам с комфортом играть в видеоигры с передовой графикой. Модель с минимальным временем отклика пикселя (1 мс) снабжается изогнутым дисплеем с 34-дюймовой диагональю и наибольшим разрешением 3440x1440 пикселей при частоте смены кадров до 144 Гц. Углы обзора как по вертикали, так и по горизонтали у данного устройства вывода графики составляют 178°."),
        //    new Product("MSI Optix G24C4 ", 18_899, "24", "/images/image8.PNG", "1920x1080", "*VA", "1мс", "144 Гц", "чёрный", "MSI", "Монитор MSI Optix G24C4 с диагональю 24 является игровым монитором. Он выполнен в черном цвете и устанавливается на устойчивую подставку. Основой монитора служит VA-панель, особенность которой в поддержке показателя частоты обновления, соответствующего 144 Гц, и времени отклика 1 мс. Такие параметры способствуют получению реалистичного и максимально четкого изображения, которое поможет вам ощутить себя погруженным полностью в игровой мир. Разрешение изображения будет соответствовать 1920x1080."),
        //    new Product("ASUS VG279Q", 21_899, "27", "/images/image9.PNG", "1920x1080", "IPS", "1мс", "144 Гц", "чёрный", "ASUS", "Монитор Asus VG279Q ориентирован на поклонников компьютерных игр. В данной модели установлен 27-дюймовый экран с разрешением 1920x1080 пикселей и матрицей IPS, что обеспечивает детализированное изображение с реалистичной цветопередачей от края до края. Благодаря времени отклика 1 мс, частоте обновления 144 Гц и технологии Adaptive-Sync устраняются разрывы и зависания отображения. Функция Shadow Boost повышает детализацию изображения в темных областях для повышенной реакции на действия противника. При помощи фирменных утилит GamePlus и GameVisual можно настраивать игровые параметры."),
        //    new Product("Samsung Odyssey G5 C27G55TQWI", 26_999, "34", "/images/image10.PNG", "2560x1440", "*VA", "1мс", "144 Гц", "чёрный", "Samsung", "Монитор Samsung C27G55TQWI воплощает оригинальный безрамочный дизайн, мощные технические характеристики и фирменные технологии, предлагая геймерам погрузиться в увлекательный игровой процесс. В мониторе установлен изогнутый экран диагональю 27 дюймов (2560x1440 пикселей), который благодаря высокому разрешению и матрице VA обеспечивает реалистичное изображение. Технология HDR10 позволяет оценить глубокие тона с любого положения. В свою очередь, время отклика 1 мс и частота обновления 144 Гц гарантируют плавный гейминг без зависаний графики в динамичных сюжетах.")
        //};

        public void Add(Product monitorsProduct)
        {
            dataBaseContext.Products.Add(monitorsProduct);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
			
			return dataBaseContext.Products.Include(x => x.Image).ToList();
        }

        public void Remove(Guid productId)
        {
            var product = dataBaseContext.Products.FirstOrDefault(x => x.Id == productId);
            dataBaseContext.Products.Remove(product);
            dataBaseContext.SaveChanges();
        }

        public Product TryGetById(Guid id)
        {
			return dataBaseContext.Products.Include(x => x.Image).FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.Include(x => x.Image).FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Diagonal = product.Diagonal;
            existingProduct.ScreenResolution = product.ScreenResolution;
            existingProduct.Matrix = product.Matrix;
            existingProduct.Response = product.Response;
            existingProduct.Hz = product.Hz;
            existingProduct.Color = product.Color;
            existingProduct.Company = product.Company;
            existingProduct.Description = product.Description;

			foreach (var image in product.Image)
            {
                    image.ProductId = product.Id;
					dataBaseContext.Image.Add(image);
            }

            dataBaseContext.SaveChanges();
        }

        public List<Image> GetImage(Guid productId)
        {
            var product = dataBaseContext.Products.Include(x => x.Image).FirstOrDefault(product => product.Id == productId);
            return product.Image.ToList();
		}
    }
}
