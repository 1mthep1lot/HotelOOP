namespace HotelOOP;

internal class Housekeeper : Person
{
    public string CleaningArea { get; set; } = "";
    public CleaningSpeed CleaningSpeed { get; set; } = CleaningSpeed.Average;
    public List<string> SpecialtyAreas { get; } = new List<string>();
    public Dictionary<string, int> SuppliesInventory { get; } = new Dictionary<string, int>();

    public override string Role => "Housekeeper";

    public void Work()
    {
        Console.WriteLine($"{Name} städar området: {CleaningArea}.");
    }

    public override void DoWork()
    {
        Console.WriteLine("The housekeeper is cleaning the hotel rooms.");
    }

    public void AddSpecialtyArea(string area)
    {
        if (!SpecialtyAreas.Contains(area))
            SpecialtyAreas.Add(area);
    }

    public void UpdateSuppliesInventory(string item, int quantity)
    {
        SuppliesInventory.TryGetValue(item, out int current);
        int updated = current + quantity;
        if (updated <= 0)
            SuppliesInventory.Remove(item);
        else
            SuppliesInventory[item] = updated;
    }
}
