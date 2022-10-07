using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private BoxCollider spawnArea;
    [SerializeField] private GameManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("objectItem"))
        {
            //will destroy the food item
            Destroy(collision.gameObject);

            //change the position
            MoveToRandomPosition();

            //add a point
            manager.AddPoint();
        }
    }

    private void MoveToRandomPosition()
    {
        var x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        var y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        var z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
