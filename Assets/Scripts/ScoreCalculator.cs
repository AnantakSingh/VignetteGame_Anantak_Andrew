using UnityEngine;

public static class ScoreCalculator
{
    public static int CalculateScore(Character character, Restaurant restaurant, float timeTaken)
    {
        int baseScore = 0;

        // Cuisine match: add 10 points
        if (restaurant.Cuisines.Contains(character.CuisinePreference))
            baseScore += 10;

        // Price: subtract restaurant parameter from character parameter
        baseScore += (character.PricePreference - restaurant.Price);

        // Noise/Crowd level: if the parameter matches, add 10 points
        if (character.NoisePreference == restaurant.NoiseLevel)
            baseScore += 10;

        // Distance: subtract restaurant parameter from character parameter
        baseScore += (character.DistancePreference - restaurant.Distance);

        // Rating: if the parameter matches add 10 points
        if (character.RatingPreference == restaurant.Rating)
            baseScore += 10;

        // Multiplier calculation
        // Hunger level times amount of seconds saved from twenty second time countdown. 
        // Example: (20 - 6) + 1 = 15
        int secondsSaved = 30 - Mathf.FloorToInt(timeTaken);
        
        // Ensure multiplier doesn't break if timeout
        if (secondsSaved < 0) secondsSaved = 0;
        
        int multiplier = secondsSaved + character.HungerLevel;

        return baseScore * multiplier;
    }
}
