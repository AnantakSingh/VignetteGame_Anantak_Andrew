using UnityEngine;
using System.Collections.Generic;

public static class RestaurantGenerator
{
    private static Dictionary<CuisineType, string[]> cuisineWords = new Dictionary<CuisineType, string[]>()
    {
        { CuisineType.American, new string[] { "Grill", "Smoke", "Diner", "BBQ", "Harvest" } },
        { CuisineType.Italian, new string[] { "Trattoria", "Mozza", "Roma", "Osteria", "Pomodoro" } },
        { CuisineType.Chinese, new string[] { "Wok", "Jade", "Lotus", "Bamboo", "Szechuan" } },
        { CuisineType.Korean, new string[] { "Seoul", "Kimchi", "Bulgogi", "Han", "Bibim" } },
        { CuisineType.Mexican, new string[] { "Cantina", "Taqueria", "Agave", "Casa", "Fuego" } },
        { CuisineType.Indian, new string[] { "Biryani", "Masala", "Curry", "Spice", "Chai" } }
    };

    public static Restaurant GenerateRandomRestaurant()
    {
        List<CuisineType> cuisines = new List<CuisineType>();
        int numCuisines = Random.Range(1, 3); // 1 or 2
        for (int i = 0; i < numCuisines; i++)
        {
            CuisineType type = (CuisineType)Random.Range(0, 6);
            if (!cuisines.Contains(type)) 
            {
                cuisines.Add(type);
            }
        }

        string generatedName = "";
        if (cuisines.Count == 2)
        {
            string word1 = cuisineWords[cuisines[0]][Random.Range(0, cuisineWords[cuisines[0]].Length)];
            string word2 = cuisineWords[cuisines[1]][Random.Range(0, cuisineWords[cuisines[1]].Length)];
            // Randomize word order to make it more interesting? User didn't specify, standard 0 then 1 is fine.
            if (Random.value > 0.5f)
                generatedName = $"{word2} {word1}";
            else
                generatedName = $"{word1} {word2}";
        }
        else if (cuisines.Count == 1)
        {
            string word1 = cuisineWords[cuisines[0]][Random.Range(0, cuisineWords[cuisines[0]].Length)];
            string word2 = cuisineWords[cuisines[0]][Random.Range(0, cuisineWords[cuisines[0]].Length)];
            generatedName = $"{word1} {word2}";
        }
        else
        {
            generatedName = "Mystery Diner";
        }

        return new Restaurant
        {
            Name = generatedName,
            Cuisines = cuisines,
            Price = Random.Range(1, 11) * 10,
            NoiseLevel = Random.Range(1, 4),
            Distance = Random.Range(1, 51),
            Rating = Random.Range(1, 6)
        };
    }

    public static List<Restaurant> GenerateInitialPool(int count)
    {
        List<Restaurant> pool = new List<Restaurant>();
        for (int i = 0; i < count; i++)
        {
            pool.Add(GenerateRandomRestaurant());
        }
        return pool;
    }
}
