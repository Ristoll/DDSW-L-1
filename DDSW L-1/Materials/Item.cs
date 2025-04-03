using System.Text.Json.Serialization;

namespace DDSW_L_1
{
    public class Item
    {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public int Count { get; set; }
        [JsonInclude]
        public EType Type { get; set; }
        [JsonInclude]
        public EBrand Brand { get; set; }

        public Item() { }

        [JsonConstructor]
        public Item(EType type, string name, int count, EBrand brand)
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
