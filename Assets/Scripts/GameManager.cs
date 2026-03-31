using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public List<Character> activeCharacters = new List<Character>();
    public List<Restaurant> restaurantPool = new List<Restaurant>();
    public int totalScore = 0;
    public int currentRound = 1;

    [Header("Round State")]
    public List<Restaurant> currentRoundOptions = new List<Restaurant>();
    public int currentRestaurantIndex = 0;
    private float currentRestaurantViewTime;
    
    // Timer state
    private bool isWaitingForInput = false;

    [Header("UI References")]
    [Tooltip("The Layout Group to spawn character cards into (e.g., Horizontal Layout Group at the bottom)")]
    public Transform playersContainer;
    
    [Tooltip("The prefab for individual Character Cards")]
    public GameObject characterCardPrefab;
    
    [Tooltip("The Restaurant UI Card placed at the top center")]
    public RestaurantCardUI restaurantCardUI;
    
    [Tooltip("Text displaying the remaining time (20 to 0)")]
    public TextMeshProUGUI timerText; 
    
    [Tooltip("Text displaying the current global score and round")]
    public TextMeshProUGUI scoreText;

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (isWaitingForInput)
        {
            float timeTaken = Time.time - currentRestaurantViewTime;
            float secondsLeft = 20f - timeTaken;

            if (secondsLeft < 0f) secondsLeft = 0f;

            if (timerText != null)
            {
                timerText.text = $"Time: {Mathf.CeilToInt(secondsLeft)}s";
                
                // Visual cue for low time
                if (secondsLeft <= 5f) 
                    timerText.color = Color.red;
                else 
                    timerText.color = Color.white;
            }
        }
    }

    void InitializeGame()
    {
        totalScore = 0;
        currentRound = 1;

        restaurantPool = RestaurantGenerator.GenerateInitialPool(50);
        
        activeCharacters.Clear();
        activeCharacters.Add(CharacterGenerator.GenerateRandomCharacter());

        UpdatePlayerUI();
        StartRound();
    }

    void StartRound()
    {
        int numRestaurants = 9 + currentRound;
        currentRoundOptions.Clear();
        
        for (int i = 0; i < numRestaurants; i++)
        {
            if (restaurantPool.Count > 0)
            {
                int poolIndex = Random.Range(0, restaurantPool.Count);
                currentRoundOptions.Add(restaurantPool[poolIndex]);
                restaurantPool.RemoveAt(poolIndex);
            }
            else
            {
                currentRoundOptions.Add(RestaurantGenerator.GenerateRandomRestaurant());
            }
        }

        currentRestaurantIndex = 0;
        ShowCurrentRestaurant();
    }

    void ShowCurrentRestaurant()
    {
        // Loop back to the start if we pass all options
        if (currentRestaurantIndex >= currentRoundOptions.Count)
        {
            Debug.Log("Passed all options, looping back to the first restaurant.");
            currentRestaurantIndex = 0; 
        }

        Restaurant currentRest = currentRoundOptions[currentRestaurantIndex];
        currentRestaurantViewTime = Time.time;
        isWaitingForInput = true;
        
        // Visual Update
        if (restaurantCardUI != null)
        {
            restaurantCardUI.Setup(currentRest);
        }
        UpdateScoreUI();
    }

    void UpdatePlayerUI()
    {
        if (playersContainer == null || characterCardPrefab == null) return;

        // Clear existing UI cards
        foreach (Transform child in playersContainer)
        {
            Destroy(child.gameObject);
        }

        // Spawn new UI cards
        foreach (Character character in activeCharacters)
        {
            GameObject cardObj = Instantiate(characterCardPrefab, playersContainer);
            CharacterCardUI cardUI = cardObj.GetComponent<CharacterCardUI>();
            if (cardUI != null)
            {
                cardUI.Setup(character);
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore} | Round: {currentRound}";
        }
    }

    public void OnPassButtonClicked()
    {
        if (!isWaitingForInput) return;
        currentRestaurantIndex++;
        ShowCurrentRestaurant();
    }

    public void OnSelectButtonClicked()
    {
        if (!isWaitingForInput) return;
        
        Restaurant selectedRest = currentRoundOptions[currentRestaurantIndex];
        float timeTaken = Time.time - currentRestaurantViewTime;
        
        int pointsGained = 0;
        foreach (var character in activeCharacters)
        {
            pointsGained += ScoreCalculator.CalculateScore(character, selectedRest, timeTaken);
        }

        totalScore += pointsGained;
        isWaitingForInput = false;

        UpdateScoreUI();

        if (totalScore < 0)
        {
            TriggerGameOver("Game Over! Score dropped below 0.");
            return;
        }

        EndRound();
    }
    
    void EndRound()
    {
        isWaitingForInput = false;
        
        activeCharacters.Add(CharacterGenerator.GenerateRandomCharacter());
        UpdatePlayerUI();
        
        currentRound++;
        StartRound();
    }

    public void KickCharacter(Character c)
    {
        if (activeCharacters.Contains(c))
        {
            activeCharacters.Remove(c);
            totalScore = 0; 
            UpdatePlayerUI();
            UpdateScoreUI();
            Debug.Log($"Kicked character {c.Name}. Score reset to 0!");
        }
    }

    public void ReplaceCharacter(Character c)
    {
        int index = activeCharacters.IndexOf(c);
        if (index != -1)
        {
            activeCharacters[index] = CharacterGenerator.GenerateRandomCharacter();
            totalScore /= 2;
            UpdatePlayerUI();
            UpdateScoreUI();
            Debug.Log($"Replaced character {c.Name}. Score halved to {totalScore}!");
        }
    }

    void TriggerGameOver(string message)
    {
        Debug.Log(message);
        isWaitingForInput = false;
        
        if (scoreText != null)
        {
            scoreText.text = $"GAME OVER! Final Score: {totalScore}";
            scoreText.color = Color.red;
        }
    }
}
