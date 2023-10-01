using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public TMP_Text tmp;
    public Animator anim;
    public float duration_inSec=30f;
    public float duration_inMin=5f;
    public int startTime = 0; 
    int minutes=0;
    int minPassed=0;
    float time=0f;

    void Update()
    {
        time += Time.deltaTime;
        minPassed = (int)(time*duration_inMin/duration_inSec);
        minutes = startTime+minPassed;
        if(minutes<10)
        tmp.text = "Time : 8:0"+(minutes)+"am";
        else
        tmp.text = "Time : 8:"+(minutes)+"am";

        if(minPassed>=duration_inMin)
        anim.SetBool("timeup",true);
    }
}
