
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManger : MonoBehaviour
{
    private int points = 0;
    [SerializeField]    TextMeshProUGUI pointsText; // Reference to the UI Text element

    // Singleton instance
    private static GameManger _instance;

    
     private void Start()
    {
        UpdatePointsUI();
    }


    public static GameManger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManger>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManger).Name;
                    _instance = obj.AddComponent<GameManger>();
                }
            }
            return _instance;
        }
    }

    // Add points to the total and update UI
    public void AddPoints(int amount)
    {
      
       points += amount;

       UpdatePointsUI();

    }

   

 

    // Update UI with current points
    void UpdatePointsUI()
    {
     
              
       if (pointsText != null)
        {
            pointsText.text = "Points: " + ( points / 2  ).ToString(); // Update UI Text with current points
        }
    }

    // You can add more methods here for other game management functionalities
}

