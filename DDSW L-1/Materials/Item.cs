using System.Text.Json.Serialization;

namespace DDSW_L_1
{
    public class Item
    {
        public static List<string> Types = DataSaver<string>.LoadFeatures(EStringData.Type);
        public static List<string> Brands = DataSaver<string>.LoadFeatures(EStringData.Brand);
        private string _brand;
        private string _type;
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public int Count { get; set; }
        [JsonInclude]
        public string Type 
        {
            get => _type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("Brand cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var typeToSet = value.Trim();

                if (!File.Exists(DataSaver<string>.TypeFilePath))
                {
                    File.WriteAllText(DataSaver<string>.BrandFilePath, "");
                }

                var existingBrands = File.ReadAllLines(DataSaver<string>.TypeFilePath)
                                         .Select(b => b.Trim())
                                         .Where(b => !string.IsNullOrWhiteSpace(b))
                                         .ToList();

                if (!existingBrands.Contains(typeToSet, StringComparer.OrdinalIgnoreCase))
                {
                    File.AppendAllText(DataSaver<string>.TypeFilePath, typeToSet + Environment.NewLine);
                }

                _type = typeToSet;
            }
        }
        [JsonInclude]
        public string Brand { 
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("Brand cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var brandToSet = value.Trim();

                if (!File.Exists(DataSaver<string>.BrandFilePath))
                {
                    File.WriteAllText(DataSaver<string>.BrandFilePath, "");
                }

                var existingBrands = File.ReadAllLines(DataSaver<string>.BrandFilePath)
                                         .Select(b => b.Trim())
                                         .Where(b => !string.IsNullOrWhiteSpace(b))
                                         .ToList();

                if (!existingBrands.Contains(brandToSet, StringComparer.OrdinalIgnoreCase))
                {
                    File.AppendAllText(DataSaver<string>.BrandFilePath, brandToSet + Environment.NewLine);
                }

                _brand = brandToSet;
            }
        }

        public Item() { }

        [JsonConstructor]
        public Item(string type, string name, int count,string brand)
        {
            Type = type;
            Name = name;
            Count = count;
            Brand = brand;
        }
        public void SetCount(int count)
        {
            if (count < 0)
            {
                Count = 0;
                return;
            }
            Count = count;
        }
        public override string ToString()
        {
            return $"{Name} {Brand} ({Count} left)";
        }
    }
}
