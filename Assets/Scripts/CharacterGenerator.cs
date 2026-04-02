using UnityEngine;

public static class CharacterGenerator
{
    private static string[] firstNames = { 
        "Cole Slawson", "Manny Nara", "Alfredo DeLuca", "Marco Pollo", "Chai Mehta", 
        "Bao Nguyen", "Roman Noodle", "Perry Macaron", "Soyun Lee", "Brie Carter", 
        "Angus Steele", "Curina Patel", "Kim Chi Park", "Nacho Rivera", "Pastina Rossi", 
        "Zac Saffron", "Hana Bulgari", "Annie Mae", "Grill Nye", "Talia Verde", 
        "Woklyn Chen", "Ginger Zhang", "Rosemary Babi", "Ron Swanson", "Patty Krabb", 
        "Ben Delacreme", "Brandy Shine", "Coco Beignet", "Tessa Tart", "Caramel Swinton"
    };

    public static Character GenerateRandomCharacter()
    {
        return new Character
        {
            Name = firstNames[Random.Range(0, firstNames.Length)],
            CuisinePreference = (CuisineType)Random.Range(0, 6),
            PricePreference = Random.Range(1, 11) * 10,   // 10 to 100 in multiples of 10
            NoisePreference = Random.Range(1, 4),      // 1 to 3
            DistancePreference = Random.Range(1, 51),  // 1 to 50
            RatingPreference = Random.Range(1, 6),     // 1 to 5
            HungerLevel = Random.Range(1, 4),          // 1 to 3
            FaceID = Random.Range(0, 1000),
            EyesID = Random.Range(0, 1000),
            HairID = Random.Range(0, 1000),
            IsSad = false
        };
    }
}
