
//using Cinemachine;
using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial
{
    public class PhotonPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab = null;
        [SerializeField] private GameObject playerMobilePrefab = null;

        int device;

        private void Start()
        {
            device = PlayerPrefs.GetInt("device");

            if (device == 1)
            {
                int spawnPicker = Random.Range(0, GameSetup.GS.Spawnpoint.Length);
                var player = PhotonNetwork.Instantiate(playerPrefab.name, GameSetup.GS.Spawnpoint[spawnPicker].position, GameSetup.GS.Spawnpoint[spawnPicker].rotation, 0);
            }
            if (device == 0)
            {               
                var player = PhotonNetwork.Instantiate(playerMobilePrefab.name, GameSetup.GS.SpawnMobile[0].position, GameSetup.GS.SpawnMobile[0].rotation, 0);
            }

        }
    }
}

/*
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    PhotonView PV;
    public GameObject myAvatar;

    private void Start()
    {
        PV = GetComponent<PhotonView>();

        int spawnPicker = Random.Range(0, GameSetup.GS.Spawnpoint.Length);
        myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefab/Player/Player"),
     GameSetup.GS.Spawnpoint[spawnPicker].position, GameSetup.GS.Spawnpoint[spawnPicker].rotation, 0);
        /*
        if (PV.IsMine)
        {

        }
    }
}*/


