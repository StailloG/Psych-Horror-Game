using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnerByCollision : MonoBehaviour
{
    [Header("Location of the object that the item will spawn at")]
    [SerializeField] private Transform whereToSpawn;

    [Header("The Gameobject that will be spawned")]
    [SerializeField] private GameObject itemToSpawn;

    [Header("Delay in seconds before it spawns")]
    [SerializeField] private float timeDelay;

    [Header("Debugging Help")]
    [SerializeField]  private BoxCollider boxCollider;
    [SerializeField] private Color radiusOfSpawnerColor;
    private GameObject spawnedItem;
    private bool spawned = false; //simple bool check to make sure item only spawns once

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(boxCollider.size.x);
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player") && !spawned)
        {
            //spawn object
            SpawnObject(0.0f);
            spawned = true;
            //todo make a script that makes butterfly already flapping wings 
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = radiusOfSpawnerColor;
        Gizmos.DrawSphere(transform.position, boxCollider.size.x - 6.0f);
        
        //boxCollider.size.x
    }
    private void SpawnObject(float timeDelay)
    {
        spawnedItem = Instantiate(itemToSpawn, whereToSpawn.position, Quaternion.identity);
    }
}
