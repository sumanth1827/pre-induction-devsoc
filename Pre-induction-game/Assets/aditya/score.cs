using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TMP_Text tmp;
    public static float cg=10f;
    public static float retryPenalty = 0.2f;
    public static float bitePenalty = 0.1f;

    void Update()
    {
        if(cg>10f)
        cg=10f;
        else if(cg<0f)
        cg=0f;
        else
        tmp.text = "Your CG : "+cg.ToString("0.0");
    }
}
