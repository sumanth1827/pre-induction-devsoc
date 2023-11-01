using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Image imageToToggle;
    public StartButton startb;// Reference to the Image you want to toggle

    private void Start()
    {
        // Ensure the image starts off by disabling it
        imageToToggle.gameObject.SetActive(false);
        startb.gameObject.SetActive(true);
    }

    public void OnStartButtonClick()
    {
        // Enable the Image when the Start button is clicked
        imageToToggle.gameObject.SetActive(true);
        startb.gameObject.SetActive(false);
    }
}