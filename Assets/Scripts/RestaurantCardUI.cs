using UnityEngine;
using TMPro;

public class RestaurantCardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cuisinesText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI noiseText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI ratingText;

    public void Setup(Restaurant restaurant)
    {
        if (nameText != null) nameText.text = restaurant.Name;
        
        // Format cuisines (could be 1 or 2)
        if (cuisinesText != null && restaurant.Cuisines != null && restaurant.Cuisines.Count > 0)
        {
            string cuisinesFormatted = restaurant.Cuisines[0].ToString();
            if (restaurant.Cuisines.Count > 1)
            {
                cuisinesFormatted += $" & {restaurant.Cuisines[1]}";
            }
            cuisinesText.text = $"Cuisine: {cuisinesFormatted}";
        }
        
        if (priceText != null) priceText.text = $"Price: ${restaurant.Price}";
        
        string noiseLabel = restaurant.NoiseLevel == 1 ? "Low" : restaurant.NoiseLevel == 2 ? "Med" : "High";
        if (noiseText != null) noiseText.text = $"Noise: {noiseLabel}";
        
        if (distanceText != null) distanceText.text = $"Distance: {restaurant.Distance} mins";
        if (ratingText != null) ratingText.text = $"Rating: {restaurant.Rating} Stars";
    }
}
