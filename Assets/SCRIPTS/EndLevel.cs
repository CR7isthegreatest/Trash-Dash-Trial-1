using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] int requiredPlasticBottles = 0;
    public GameManager gameManager;
    PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = FindFirstObjectByType<PlayerInventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInventory.NumberOfDiamonds < requiredPlasticBottles)
            {
                gameManager.EndGame();
            }
            else
            {
                gameManager.CompleteLevel();
            }
        }
        
    }
}
