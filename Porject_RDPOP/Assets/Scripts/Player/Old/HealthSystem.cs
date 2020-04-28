using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviourPun
{
    public float HpMax;
    float Hpcurrent;
    public Image HBarre;

    private void Start()
    {
        HpMax = Hpcurrent;

    }

    public void TakeDamage(int dmg)
    {
        Hpcurrent -= dmg;


        if (Hpcurrent <= 0)
        {
            int spawnPicker = Random.Range(0, GameSetup.GS.Spawnpoint.Length);
            gameObject.transform.position = new Vector3(GameSetup.GS.Spawnpoint[spawnPicker].position.x,
                GameSetup.GS.Spawnpoint[spawnPicker].position.y, 
                GameSetup.GS.Spawnpoint[spawnPicker].position.z);
            Hpcurrent = HpMax;
        }

        HBarre.fillAmount = (Hpcurrent / HpMax);
    }
}
