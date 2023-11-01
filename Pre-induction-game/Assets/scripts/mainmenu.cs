using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField] Animator playeranim;
    // Start is called before the first frame update
    void Start()
    {
        playeranim.SetBool("jump", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Loadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
