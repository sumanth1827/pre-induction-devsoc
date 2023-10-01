using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TMP_Text tmp;
    public static float cg=7f;
    public float InitialCg = 7f;
    public static float CgReduction = 0.2f;
    void Start()
    {
        
    }

    void Update()
    {
        if(cg>10f)
        cg=10f;
        else if(cg<0f)
        cg=0f;
        else
        tmp.text = "CGPA : "+cg;
    }
}
