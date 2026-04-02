using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CharacterCardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cuisineText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI noiseText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI ratingText;
    public TextMeshProUGUI hungerText;

    [Header("Kick Functionality")]
    public GameObject kickButtonObj;

    [Header("Avatar Display")]
    public Image faceImage;
    public Image eyesImage;
    public Image hairImage;
    public Image mouthImage;

    private Character currentCharacter;

    public void Setup(Character character)
    {
        currentCharacter = character;

        if (kickButtonObj != null)
            kickButtonObj.SetActive(false);

        // Apply Avatar Layers
        if (AvatarManager.Instance != null)
        {
            if (faceImage != null) faceImage.sprite = AvatarManager.Instance.GetFace(character.FaceID);
            if (eyesImage != null) eyesImage.sprite = AvatarManager.Instance.GetEyes(character.EyesID);
            if (hairImage != null) hairImage.sprite = AvatarManager.Instance.GetHair(character.HairID);
            
            UpdateMouthMood(character.IsSad);
        }
        if (nameText != null) nameText.text = character.Name;
        if (cuisineText != null) cuisineText.text = $"Cuisine: {character.CuisinePreference}";
        if (priceText != null) priceText.text = $"Price: ${character.PricePreference}";
        
        string noiseLabel = character.NoisePreference == 1 ? "Low" : character.NoisePreference == 2 ? "Med" : "High";
        if (noiseText != null) noiseText.text = $"Noise: {noiseLabel}";
        
        if (distanceText != null) distanceText.text = $"Distance: {character.DistancePreference} mins";
        if (ratingText != null) ratingText.text = $"Rating: {character.RatingPreference} Stars";
        
        string hungerLabel = character.HungerLevel == 1 ? "Low" : character.HungerLevel == 2 ? "Med" : "High";
        if (hungerText != null) hungerText.text = $"Hunger: {hungerLabel}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (kickButtonObj != null)
            kickButtonObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (kickButtonObj != null)
            kickButtonObj.SetActive(false);
    }

    public void OnKickButtonClicked()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null && currentCharacter != null)
        {
            gm.KickCharacter(currentCharacter);
        }
    }

    public void UpdateMouthMood(bool isSad)
    {
        if (AvatarManager.Instance == null || mouthImage == null || currentCharacter == null) return;
        
        currentCharacter.IsSad = isSad;
        
        if (isSad)
            mouthImage.sprite = AvatarManager.Instance.GetSadMouth(currentCharacter.FaceID);
        else
            mouthImage.sprite = AvatarManager.Instance.GetHappyMouth(currentCharacter.FaceID);
    }

    public void FlashColor(Color color)
    {
        StartCoroutine(FlashRoutine(color));
    }

    private System.Collections.IEnumerator FlashRoutine(Color color)
    {
        Color originalColor = nameText != null ? nameText.color : Color.white;

        SetTextColor(color);
        yield return new WaitForSeconds(1.0f);
        SetTextColor(originalColor);
    }

    private void SetTextColor(Color color)
    {
        if (nameText != null) nameText.color = color;
        if (cuisineText != null) cuisineText.color = color;
        if (priceText != null) priceText.color = color;
        if (noiseText != null) noiseText.color = color;
        if (distanceText != null) distanceText.color = color;
        if (ratingText != null) ratingText.color = color;
        if (hungerText != null) hungerText.color = color;
    }
}
