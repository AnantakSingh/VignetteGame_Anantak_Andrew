using UnityEngine;

public static class CharacterGenerator
{
    private static string[] firstNames = { 
        "Dave", "Stella", "Alice", "Bob", "Charlie", "Diana", 
        "Eve", "Frank", "Gina", "Harry", "Irene", "Jack" 
    };

    public static Character GenerateRandomCharacter()
    {
        return new Character
        {
            Name = firstNames[Random.Range(0, firstNames.Length)],
            CuisinePreference = (CuisineType)Random.Range(0, 6),
            PricePreference = Random.Range(10, 201),   // 10 to 200
            NoisePreference = Random.Range(1, 4),      // 1 to 3
            DistancePreference = Random.Range(1, 51),  // 1 to 50
            RatingPreference = Random.Range(1, 6),     // 1 to 5
            HungerLevel = Random.Range(1, 4)           // 1 to 3
        };
    }
}
