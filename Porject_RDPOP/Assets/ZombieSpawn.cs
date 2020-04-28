using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    GameObject[] theGameObjects;

    float duration;
    public GameObject zombie;
    int zombieCount;

    void Start()
    {
        theGameObjects = GameObject.FindGameObjectsWithTag("SpawnZOmbie");
    }

    void FixedUpdate()
    {
        duration += Time.deltaTime;

        if (duration >= 2 && zombieCount <= 3)
        {
            int rng = Random.Range(0, theGameObjects.Length);
            PhotonNetwork.Instantiate(zombie.name, theGameObjects[rng].transform.position, theGameObjects[rng].transform.rotation);
            zombieCount++;
            duration = 0;
        }
    }
}
