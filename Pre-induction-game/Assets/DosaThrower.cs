using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosaThrower : MonoBehaviour
{
    public GameObject dosaPrefab;  // Reference to the Dosa prefab.
    public Transform throwPoint;   // The point where Dosa will be thrown from.
    public float throwSpeed = 2f;  // The speed at which Dosa is thrown.
    public Vector2 throwRegionMin;  // Minimum coordinates of the throw region.
    public Vector2 throwRegionMax;  // Maximum coordinates of the throw region.
    private int dosaCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ThrowDosa();
        }
    }

    void ThrowDosa()
    {
        // Create a random position within the throw region.
        Vector2 randomPosition = new Vector2(Random.Range(throwRegionMin.x, throwRegionMax.x),
                                             Random.Range(throwRegionMin.y, throwRegionMax.y));

        // Create a Dosa instance at the throw point.
        GameObject dosa = Instantiate(dosaPrefab, throwPoint.position, Quaternion.identity);

        // Calculate the direction to throw Dosa.
        Vector2 throwDirection = (randomPosition - (Vector2)throwPoint.position).normalized;

        // Apply force to the Dosa to move it slowly.
        dosa.GetComponent<Rigidbody2D>().velocity = throwDirection * throwSpeed;

        DosaCollisionHandler dosaCollisionHandler = dosa.AddComponent<DosaCollisionHandler>();
        dosaCollisionHandler.Initialize(this);
    
}
    public void PlayerTouchedDosa()
    {
        dosaCounter++;
        Debug.Log("Dosa Counter: " + dosaCounter);
     
    }
}
