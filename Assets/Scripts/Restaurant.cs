using System.Collections.Generic;

[System.Serializable]
public class Restaurant
{
    public string Name;
    public List<CuisineType> Cuisines; // Up to 2
    public int Price;        // 10 to 200
    public int NoiseLevel;   // 1 to 3
    public int Distance;     // 1 to 50
    public int Rating;       // 1 to 5
}
