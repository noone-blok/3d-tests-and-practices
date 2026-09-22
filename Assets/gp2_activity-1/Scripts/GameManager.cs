using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int totalScore = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore()
    {
        totalScore++;
        Debug.Log("Add Score");
    }

    public void DeductScore()
    {
        totalScore--;
        Debug.Log("Deduct Score");
    }
}
