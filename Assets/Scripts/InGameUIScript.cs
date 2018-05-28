using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIScript : MonoBehaviour {
    // Private and invisible in inspector
    private float maxHealth = 100;

    // Private and visible in inspector
    [SerializeField]
    private Button nextLevelButton;
    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private Text collectedCoinsText;

    public static InGameUIScript instance;
    // Public
    public float health = 100;

    void Awake() {
        instance = this.gameObject.GetComponent<InGameUIScript>();
    }

    private void Start() {
        // Disable nextLevelButton at start
        nextLevelButton.enabled = !enabled;
        
        // At the beginning Money is 0
        int collectedAtBeginning = 0;
        collectedCoinsText.text = collectedAtBeginning.ToString();
    }
    private void Update() {
        // Calculates the fill ammount for the healthbar
        CalculateFillAmmountHB();
    }

    // Calculates the fill ammount for the healthbar
    private void CalculateFillAmmountHB() {
        fillImage.fillAmount = health / maxHealth;
    }

    // Set the collectedCoinsText to the correct value
    public void ManageCollectedText(int coins)
    {
        collectedCoinsText.text = coins.ToString();
    }

    // Play level 1 again
    public void PlayAgain() {
        nextLevelButton.enabled = !enabled;
        SceneManager.LoadScene("Level1");
    }

    // To go to the startmenu
    public void ToStartMenu() {
        SceneManager.LoadScene("StartScene");
    }

    // If won nextLevelButton is enabled
    public void Won() {
        nextLevelButton.enabled = enabled;
    }

    // Navigates to Level2
    public void ToLevel2() {
        nextLevelButton.enabled = !enabled;
        SceneManager.LoadScene("Level2"); 
    }

    // Navigates to Level3
    public void ToLevel3() {
        nextLevelButton.enabled = !enabled;
        SceneManager.LoadScene("Level3");
    }
}
