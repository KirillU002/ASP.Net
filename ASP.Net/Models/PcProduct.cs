namespace OnlineShopWebApplication.Models
{
    public class PcProduct
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Company { get; }
        public string Motherboard { get; }
        public string Ram { get; }
        public string VideoAdapter { get; }
        public string CpuCooling { get; }
        public string Hdd { get; }
        public string Ssd { get; }
        public string Psu { get; }
        public string ImagePath { get; }

        public PcProduct(string name, decimal cost, string imagePath, string company, string motherboard, string ram, string videoAdapter, string cpuCooling, string hdd, string ssd, string psu)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Company = company;
            ImagePath = imagePath;
            Motherboard = motherboard;
            Ram = ram;
            VideoAdapter = videoAdapter;
            CpuCooling = cpuCooling;
            Hdd = hdd;
            Ssd = ssd;
            Psu = psu;

            instanceCounter += 1;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }

    }
}