using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{

    // function to load differnt scenes
    public void playNormalMode(){
        SceneManager.LoadScene(1);
    }
    public void playHardMode(){
        SceneManager.LoadScene(2);
    }

}
