namespace DDSW_L_1
{
    public class Item
    {
        public string Name { get; private set; }
        public int Count { get; private set; }
        public EType Type { get; private set; }
        public EBrand Brand { get; private set; }

        public Item() { }
        public Item(EType type, string name, int quantity, EBrand brand) 
        { 
            Type = type;
            Name = name;
            Count = quantity;
            Brand = brand;
        }

        public void SetCount(int count)
        {
            Count = count;
        }
        public override string ToString()
        {
            return $"{Name} {Brand} ({Count} left)";
        }
    }
}
