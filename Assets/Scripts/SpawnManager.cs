using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField]
    private Vector3 ObjectPosition = new Vector3(19, 0, 0);
    [SerializeField]
    private float spawnIntervel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2f, spawnIntervel);
    }

    void SpawnObject()
    {
        if(!PlayerController.IsGameOver)
        {
            Instantiate(objectToSpawn, ObjectPosition, objectToSpawn.transform.rotation);
        }
    }

}
