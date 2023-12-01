using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ModeSelect : MonoBehaviour
{
    public TextMeshProUGUI textMeshProObject; // This variable will hold your TextMeshPro object reference

    private void Start(){

        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the unique identifier for the scene (using scene path)
        string sceneID = currentScene.name;

        // Print the scene ID to the console
        textMeshProObject.text = sceneID;

       
    }
}
