using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public static AvatarManager Instance { get; private set; }

    [Header("Avatar Layers")]
    public Sprite[] faces;
    public Sprite[] eyes;
    public Sprite[] hairs;

    [Header("Mouth States")]
    public Sprite[] happyMouths; // In case they have multiple, but normally just 1
    public Sprite[] sadMouths;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Sprite GetFace(int id)
    {
        if (faces == null || faces.Length == 0) return null;
        return faces[id % faces.Length];
    }

    public Sprite GetEyes(int id)
    {
        if (eyes == null || eyes.Length == 0) return null;
        return eyes[id % eyes.Length];
    }

    public Sprite GetHair(int id)
    {
        if (hairs == null || hairs.Length == 0) return null;
        return hairs[id % hairs.Length];
    }

    public Sprite GetHappyMouth(int id)
    {
        if (happyMouths == null || happyMouths.Length == 0) return null;
        return happyMouths[id % happyMouths.Length];
    }

    public Sprite GetSadMouth(int id)
    {
        if (sadMouths == null || sadMouths.Length == 0) return null;
        return sadMouths[id % sadMouths.Length];
    }
}