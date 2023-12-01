using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour{

    // boolean to determine if thigns are paused or not
    private bool isPaused = false;

    // The canvas of the pause system
    public GameObject pauseMenu; 


    private void Start(){
        pauseMenu.SetActive(false); // Show the pause menu UI
        isPaused = false;
        Time.timeScale = 1;
    }

    // function to toggle the pause 
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            TogglePause();
        }
    }

    // changes between paused and not paused with the 
    public void TogglePause(){
        isPaused = !isPaused; // flip the boolean 

        if (isPaused){
            Time.timeScale = 0; // Pause the game
            pauseMenu.SetActive(true); // Show the pause menu UI
        
        }else{
            Time.timeScale = 1; // Resume the game
            pauseMenu.SetActive(false); // Hide the pause menu UI
        }
    }

    // return to the main menu scene
    public void goToMenu(){
        SceneManager.LoadScene(0); // Load scene by index
    }

}
