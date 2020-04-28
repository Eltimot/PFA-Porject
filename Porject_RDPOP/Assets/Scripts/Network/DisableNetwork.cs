using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNetwork : MonoBehaviourPun
{
    public GameObject[] DisableComponents;
    public GameObject[] DisableComponentsOnME;
    public GameObject[] WeaponsG;
    public enum Weapons
    {
        AK,
        Snipe,
        M14,
        M1911,
        Pompe
    }
    public Weapons wp;

    public int device;

    void Start()
    {
        device = PlayerPrefs.GetInt("device");

        if (!photonView.IsMine && DisableComponents.Length > 0)
        {
            for (int i = 0; i < DisableComponents.Length; i++)
            {
                DisableComponents[i].SetActive(false);
            }
        }
        if (photonView.IsMine && DisableComponentsOnME.Length > 0)
        {
            for (int i = 0; i < DisableComponentsOnME.Length; i++)
            {
                DisableComponentsOnME[i].SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (WeaponsG.Length > 0)
        {
            switch (wp)
            {
                case Weapons.AK:
                    for (int i = 0; i < WeaponsG.Length; i++)
                    {
                        WeaponsG[i].SetActive(false);
                    }
                    WeaponsG[0].SetActive(true);
                    break;

                case Weapons.Snipe:
                    for (int i = 0; i < WeaponsG.Length; i++)
                    {
                        WeaponsG[i].SetActive(false);
                    }
                    WeaponsG[1].SetActive(true);
                    break;

                case Weapons.M14:
                    for (int i = 0; i < WeaponsG.Length; i++)
                    {
                        WeaponsG[i].SetActive(false);
                    }
                    WeaponsG[2].SetActive(true);
                    break;

                case Weapons.M1911:
                    for (int i = 0; i < WeaponsG.Length; i++)
                    {
                        WeaponsG[i].SetActive(false);
                    }
                    WeaponsG[3].SetActive(true);
                    break;

                case Weapons.Pompe:
                    for (int i = 0; i < WeaponsG.Length; i++)
                    {
                        WeaponsG[i].SetActive(false);
                    }
                    WeaponsG[4].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
