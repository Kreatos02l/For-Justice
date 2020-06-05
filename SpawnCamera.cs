using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnCamera : NetworkBehaviour {

    public GameObject objectToSpawn;
    public Transform spawnPoint;

    void Start()
    {
       // if (Input.GetKey(KeyCode.C))
        {
            GameObject cam = Instantiate(objectToSpawn, spawnPoint);
            NetworkServer.Spawn(cam);
        }
        
    }
}
