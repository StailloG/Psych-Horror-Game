using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyRoute : MonoBehaviour
{
    [Header("New transform position")]
    [SerializeField] private Vector3 target = new Vector3(99.1f, 0f, 115.3f);
    [SerializeField] private float speed = 5f;
    [SerializeField] private float movement;

    [Header("Calling Utility Script")]
    public SpawnerByCollision spawnerScript;

    // Update is called once per frame
    void Update()
    {
        //butterfly movement
        movement = speed * Time.deltaTime;

        if (spawnerScript.spawned == true)
        {
            
            butterflyMovement();
            butterflyRotation();
        }
    }

    public void butterflyMovement()
    {
        //spawn butterfly in spawner position from SpawnerByCollision script
        spawnerScript.spawnedItem.transform.position = Vector3.MoveTowards(spawnerScript.spawnedItem.transform.position, target, movement);
    }

    public void butterflyRotation()
    {
        //change butterfly's rotation to face to the left
        var faceLeft = transform.rotation.eulerAngles;
        faceLeft.y = -90;
        transform.rotation = Quaternion.Euler(faceLeft);
    }
}
