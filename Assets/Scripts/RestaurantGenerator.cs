using UnityEngine;
using System.Collections.Generic;

public static class RestaurantGenerator
{
    private static string[] restNames = { 
        "Burger Shot", "Luigi's", "Wok This Way", 
        "Seoul Food", "Taco Bell", "Curry In A Hurry",
        "The Salty Spitoon", "Puzzles", "Central Perk"
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

        return new Restaurant
        {
            Name = restNames[Random.Range(0, restNames.Length)],
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
