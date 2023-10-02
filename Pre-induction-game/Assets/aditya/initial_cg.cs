using UnityEngine;

public class initial_cg : MonoBehaviour
{
    public float InitialCg = 9f;
    void Awake()
    {
        score.cg = InitialCg;
    }

}
