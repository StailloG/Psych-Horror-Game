using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyRoute : MonoBehaviour
{
    [Header("The spawned Gameobject's new transform")]
    public Vector3 target = new Vector3(99.1f, 0f, 115.3f);
    [SerializeField] private float speed = 5f;
    [SerializeField] private float movement;
    [SerializeField] public SpawnerByCollision spawnerScript;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //butterfly movement
        movement = speed * Time.deltaTime;

        if (spawnerScript.spawned == true)
        {
            butterflyMovement();
            Debug.Log(transform.position);
        }
    }

    public void butterflyMovement()
    {
        spawnerScript.spawnedItem.transform.position = Vector3.MoveTowards(spawnerScript.spawnedItem.transform.position, target, movement);
    }
}
