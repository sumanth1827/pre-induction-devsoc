using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_spawner : MonoBehaviour
{
    [SerializeField] GameObject ncs;
    public static NC_spawner instance;
    Transform self;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void spawner(Transform pos)
    {
        //var v = Instantiate(ncs, new Vector2(transform.position.x, pos.position.y), Quaternion.identity);
        //v.GetComponent<Rigidbody2D>().velocity = new Vector2(-40f, 0f);
        var v = Instantiate(ncs, new Vector2(pos.position.x, transform.position.y), Quaternion.identity);
        v.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 40f);
        // v = Instantiate(ncs, new Vector2(transform.position.x, Random.Range(self.position.y+7f, self.position.y + 12f)), Quaternion.identity);
        //  v.GetComponent<Rigidbody2D>().velocity = new Vector2(-30f, 0f);
        // v = Instantiate(ncs, new Vector2(transform.position.x, Random.Range(self.position.y + 13f, self.position.y + 18f)), Quaternion.identity);
        //v.GetComponent<Rigidbody2D>().velocity = new Vector2(-30f, 0f);
    }
}
