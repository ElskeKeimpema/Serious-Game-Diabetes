using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Private and visible in the inspector
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private Animation creditsAnim;
    [SerializeField]
    private GameObject creditsCanvas;
    [SerializeField]
    private GameObject InstructionsCanvas;
    [SerializeField]
    private GameObject infoObjects;
    [SerializeField]
    private GameObject mainObjects;

    // Sends the player back to the main menu when clicked on the "Back to main menu" button
    public void BackToMainMenu(){
        SceneManager.LoadScene("StartScene");
        creditsCanvas.SetActive(false);
        infoObjects.SetActive(false);
        InstructionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ChangeToInfoMenu() {
        mainObjects.SetActive(false);
        infoObjects.SetActive(true);
    }
    public void ChangeToMainMenu() {
        infoObjects.SetActive(false);
        mainObjects.SetActive(true);
    }


    // Sends the player to the first level when clicked on the startbutton
    public void ToLevel1() {
        SceneManager.LoadScene("Level1");
    }
    // Shows the player the creditscreen and plays the text animation
    public void GoToCredits() {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
        creditsAnim.Play();
    }
    // Shows the player the Instructionscreen
    public void GoToInstruction() {
        mainMenuCanvas.SetActive(false);
        InstructionsCanvas.SetActive(true);
    }

    // Opens a webbrowser and shows the player a informationvideo of Het Klokhuis
    public void GoToLink1() {
        Application.OpenURL("https://schooltv.nl/video/het-klokhuis-3/#q=diabetes");
    }

    // Opens a webbrowser and shows the player a youtubevideo about diabetes by Lenny de Leeuw
    public void GoToLink2() {
        Application.OpenURL("https://www.youtube.com/watch?v=oiX2KrvzLLY");
    }

    // Opens a webbrowser and shows the player a video about diabetes of Nieuws uit de natuur
    public void GoToLink3() {
        Application.OpenURL("https://schooltv.nl/video/nieuws-uit-de-natuur-ziek-van-suiker/#q=diabetes");
    }

    // Quits the game
    public void QuitGame() {
        Application.Quit();
    }
}
