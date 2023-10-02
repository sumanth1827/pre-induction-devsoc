using UnityEngine;
using TMPro;

public class final_cg : MonoBehaviour
{
    public TMP_Text tmp;
    void Start()
    {
        
    }

    void Update()
    {
        if(score.cg>10f)
        score.cg=10f;
        else if(score.cg<0f)
        score.cg=0f;
        else
        tmp.text = "Your Final CG : "+score.cg.ToString("0.0");
    }
}
