using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGun : MonoBehaviour
{
    public GameObject[] FullGun;
    public int KelArme = -2;
    public int KelArme2 = -2;

    public bool First;
    public bool Second;

    public bool Chop;

    private void Start()
    {
        First = true;
        Second = false;
        Chop = true;
    }
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            for (int i = 0; i < FullGun.Length; i++)
            {
                if (i == KelArme)
                {
                    FullGun[i].SetActive(true);
                }
                if (i != KelArme)
                {
                    FullGun[i].SetActive(false);
                }
                First = true;
                Second = false;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            for (int i = 0; i < FullGun.Length; i++)
            {
                if (i == KelArme2)
                {
                    FullGun[i].SetActive(true);
                }
                if (i != KelArme2)
                {
                    FullGun[i].SetActive(false);
                }
                Second = true;
                First = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item_sword"))
        {
            if (KelArme >= 0 && KelArme2 >= 0)
            {
                Debug.Log("Switch avec epee");
                if (First == true && Chop == true)
                {
                    KelArme = 0;
                    Chop = false;
                    Debug.Log("Switch avec epee 1ere main");
                }
                if (Second == true && Chop == true)
                {
                    KelArme2 = 0;
                    Chop = false;
                    Debug.Log("Switch avec epee 2eme main");
                }
            }
            if (KelArme <= 0 && Chop == true)
            {
                KelArme = 0;
                Chop = false;
            }
            if (KelArme2 <= 0 && Chop == true)
            {
                KelArme2 = 0;
                Chop = false;
            }
            Chop = true;

        }
        if (other.CompareTag("item_assalt"))
        {
            if (KelArme >= 0 && KelArme2 >= 0)
            {
                Debug.Log("Switch avec assalt");
                if (First == true && Chop == true)
                {
                    KelArme = 1;
                    Chop = false;
                    Debug.Log("Switch avec assalt 1ere main");

                }
                if (Second == true && Chop == true)
                {
                    KelArme2 = 1;
                    Chop = false;
                    Debug.Log("Switch avec assalt 2eme main");

                }
            }
            if (KelArme <= 0 && Chop == true)
            {
                KelArme = 1;
                Chop = false;
            }
            if (KelArme2 <= 0 && Chop == true)
            {
                KelArme2 = 0;
                Chop = false;
            }
            Chop = true;
        }
    }

}
