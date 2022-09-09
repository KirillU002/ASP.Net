using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<MonitorsProduct> monitorsProducts = new List<MonitorsProduct>()
        {
            new MonitorsProduct("Монитор AOC 32 CQ32G1", 40290,"31.5","/images/image1.jpg","2560x1440 (Quad HD)", "VA", "1 мс", "144 Гц", "чёрный","AOC"),
            new MonitorsProduct("Монитор AOC CU34G2/BK", 37855,"34", "/images/image2.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "AOC"),
            new MonitorsProduct("Монитор AOC AGON AG352UCG6", 98890, "34","/images/image3.png", "3440x1440","*VA", "1 мс", "100 Гц", "черный", "AOC"),
            new MonitorsProduct("Монитор Acer Predator Z35P", 82126, "35"," /images/Image4.jpg", "3440x1440", "*VA", "1 мс", "100 Гц", "черный", "Acer"),
            new MonitorsProduct("Монитор Acer 49 EI491CRPbmiiipx Nitro", 89680, "49", "/images/image5.jpg","3840x1080", "VA", "4 мс", "144 Гц", "чёрный", "Acer"),
            new MonitorsProduct("Монитор Acer Predator Z35P", 89220, "35", "/images/image6.jpg","2560x1080 (UltraWide FHD)", "VA", "4мс", "100 Гц", "чёрный", "Acer"),
            new MonitorsProduct("Монитор MSI MPG341CQR", 34685, "34", "/images/image7.jpg", "3440x1440 (21:9)", "*VA", "4мс", "144 Гц", "чёрный", "MSI")
        };

        private List<TvProduct> tvProducts = new List<TvProduct>()
        {
            new TvProduct("Телевизор LED Xiaomi MI TV P1", 29999,"43","/images/tv1.png","4K UltraHD, 3840x2160","ADS","1 мс", "60 Гц","чёрный","Xiaomi"),
            new TvProduct("Телевизор LED TCL 65C728", 74999,"65","/images/tv2.png","4K UltraHD, 3840x2160","VA","1 мс", "120 Гц","чёрный","TCL"),
            new TvProduct("Телевизор LED TCL 55C728", 54999,"55","/images/tv3.png","4K UltraHD, 3840x2160","VA","1 мс", "120 Гц","чёрный","TCL"),
            new TvProduct("Телевизор LED Xiaomi Mi TV 4S", 67999,"65","/images/tv4.png","4K UltraHD, 3840x2160","IPS","1 мс", "60 Гц","чёрный","Xiaomi"),
            new TvProduct("Телевизор LED DEXP H24F7000E", 9499,"24","/images/tv5.png","HD, 1366x768","MVA","1 мс", "60 Гц","чёрный","DEXP"),
            new TvProduct("Tелевизор LED iFFALCON 50K61", 32999,"50","/images/tv6.png","4K UltraHD, 3840x2160","VA","1 мс", "60 Гц","чёрный","iFFALCON"),
            new TvProduct("Телевизор LED TCL 43P725", 27999,"43","/images/tv1.png","4K UltraHD, 3840x2160","VA","1 мс", "60 Гц","чёрный","TCL")
        };

        private List<PcProduct> pcProducts = new List<PcProduct>()
        {
            new PcProduct("ПК ZET Gaming NEO M032", 59999,"/images/pc1.png","ZET Gaming","GIGABYTE H510M H","2x8GB Kingston FURY Beast Black 3200MHz","Palit GeForce GTX 1650 Gaming Pro 4 GB","DEEPCOOL GAMMAXX 200 V2","-","500GB 2.5 SATA A-Data SU670","DEEPCOOL DN500 500W (80+ Standart)"),
            new PcProduct("ПК HP Pavilion Gaming TG01-2085ur", 59999,"/images/pc2.png","HP","AMD B450","16GB Kingston FURY Beast Black 3200MHz","Palit GeForce GTX 1650 Gaming Pro 4 GB","DEEPCOOL GAMMAXX 200 V2","1TБ WD Blue","500GB 2.5 SATA A-Data SU670","DEEPCOOL DN500 500W (80+ Standart)"),
            new PcProduct("ПК ZET Gaming NEO M037", 59999,"/images/pc3.png","ZET Gaming","GIGABYTE H510M H","2x8GB A-Data XPG SPECTRIX D41 RGB 3200 MHz","MSI GeForce GTX 1650 Ventus XS","DEEPCOOL GAMMAXX GT BK","-","500GB 2.5'' SATA A-Data SU670","DEEPCOOL DN500 500W (80+ Standart)"),
            new PcProduct("ПК ZET Gaming NEO M004", 64999,"/images/pc4.png","ZET Gaming","MSI H510M-A PRO","1x8GB G.Skill RIPJAWS V 3200MHz","Palit GeForce GTX 1650 Gaming Pro 4 GB","DEEPCOOL GAMMAXX 200 V2","-","512GB 2.5 SATA Silicon Power Ace A58","DEEPCOOL DN500 500W (80+ Standart)"),
            new PcProduct("ПК ZET Gaming WARD H235", 289999,"/images/pc5.png","ZET Gaming","MSI PRO Z690-A","2x16GB Kingston FURY Beast RGB 3200MHz","KFA2 GeForce RTX 3080 Ti SG 12 GB","СЖО ZET GAMING CASTLE 360 RGB V2","-","1TБ M.2 Kingston KC2500","DEEPCOOL DQ850-M-V2L 850W (80+ Gold)"),
            new PcProduct("ПК Acer Predator PO3-630", 159999,"/images/pc6.png","Acer","Intel B560","2x16GB Kingston FURY Beast Black 3200MHz","Palit GeForce RTX 3070 Gaming Pro 8 GB","DEEPCOOL GAMMAXX 200 V2","-","1 TБ M.2 PCIe","DEEPCOOL DN500 500W (80+ Standart)"),
            new PcProduct("ПК Lenovo Legion T5 26IOB6", 129999,"/images/pc7.png","Lenovo","Intel B560","2x16GB Kingston FURY Beast Black 3200MHz","Palit GeForce RTX 3070 Gaming Pro 8 GB","DEEPCOOL GAMMAXX 200 V2","1 TБ 3.5 7200 SATA","256 GB M.2 PCIe","DEEPCOOL DN500 500W (80+ Standart)")
        };

        public List<MonitorsProduct> GetAllMonitors()
        {
            return monitorsProducts;
        }

        public List<PcProduct> GetAllPc()
        {
            return pcProducts;
        }

        public List<TvProduct> GetAllTv()
        {
            return tvProducts;
        }

        public MonitorsProduct TryGetByIdMonitors(int id)
        {
            return monitorsProducts.FirstOrDefault(product => product.Id == id);
        }

        public PcProduct TryGetByIdPc(int id)
        {
            return pcProducts.FirstOrDefault(product => product.Id == id);
        }

        public TvProduct TryGetByIdTv(int id)
        {
            return tvProducts.FirstOrDefault(product => product.Id == id);
        }
    }
}
