using UnityEngine;
using TMPro;

public class CharacterCardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cuisineText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI noiseText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI ratingText;
    public TextMeshProUGUI hungerText;

    public void Setup(Character character)
    {
        if (nameText != null) nameText.text = character.Name;
        if (cuisineText != null) cuisineText.text = $"Cuisine: {character.CuisinePreference}";
        if (priceText != null) priceText.text = $"Price: ${character.PricePreference}";
        
        string noiseLabel = character.NoisePreference == 1 ? "Low" : character.NoisePreference == 2 ? "Med" : "High";
        if (noiseText != null) noiseText.text = $"Noise Pref: {noiseLabel}";
        
        if (distanceText != null) distanceText.text = $"Distance: {character.DistancePreference} mins";
        if (ratingText != null) ratingText.text = $"Rating Pref: {character.RatingPreference} Stars";
        
        string hungerLabel = character.HungerLevel == 1 ? "Low" : character.HungerLevel == 2 ? "Med" : "High";
        if (hungerText != null) hungerText.text = $"Hunger: {hungerLabel}";
    }
}
