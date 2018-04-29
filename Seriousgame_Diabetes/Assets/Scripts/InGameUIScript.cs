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

    // Public
    public float health = 100;

    private void Start() {
        // Disable nextLevelButton at start
        nextLevelButton.enabled = !enabled;
    }
    private void Update() {
        // Calculates the fill ammount for the healthbar
        CalculateFillAmmountHB();
    }

    // Calculates the fill ammount for the healthbar
    private void CalculateFillAmmountHB() {
        fillImage.fillAmount = health / maxHealth;
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
