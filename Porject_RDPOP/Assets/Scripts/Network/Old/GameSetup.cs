﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] Spawnpoint;
    public Transform[] SpawnMobile;

    private void OnEnable()
    {
        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }
    }

}
