using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezer : MonoBehaviour
{
    private bool isSceneFrozen = true;
    public static freezer instance;

    public void Start()
    {
        // Freeze the scene when the game starts
        instance = this;
        FreezeScene();
    }

    public void Update()
    {
       
        // Check for the key press to unfreeze the scene
        if (isSceneFrozen && Input.GetKeyDown(KeyCode.P))
        {
            UnfreezeScene();
        }
    }

    public void FreezeScene()
    {
        // Set the time scale to 0 to freeze the scene
        Time.timeScale = 0;
        isSceneFrozen = true;
        Debug.Log("freeeeze");
    }

    public void UnfreezeScene()

    {

        // Set the time scale back to 1 to resume normal time
        Time.timeScale = 1;
        isSceneFrozen = false;
    }
}
