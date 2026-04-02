using System;

[System.Serializable]
public enum CuisineType
{
    American,
    Italian,
    Chinese,
    Korean,
    Mexican,
    Indian
}

[System.Serializable]
public class Character
{
    public string Name;
    public CuisineType CuisinePreference;
    public int PricePreference;     // 10 to 200
    public int NoisePreference;     // 1 to 3 (Low, Medium, High)
    public int DistancePreference;  // 1 to 50
    public int RatingPreference;    // 1 to 5
    public int HungerLevel;         // 1 to 3 (Low, Medium, High)

    // Avatar configuration
    public int FaceID;
    public int EyesID;
    public int HairID;
    public bool IsSad;
}
