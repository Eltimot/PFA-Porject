using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_buton : MonoBehaviourPun
{
    public GameObject[] GameObjectTest;
    GameObject[] theGameObjects;
    public GameObject MyCam;
    public GameObject CameraObserve;

    public Text text_;
    string place_s;
    string color;
    int place;

    void Awake()
    {
        theGameObjects = GameObject.FindGameObjectsWithTag("Spawn");
        gauche();
        CameraObserve = GameObject.FindWithTag("CameraObserve");
        //CameraObserve = GameObject.Find("CameraObserve");
       
        /*
        if (photonView.IsMine)
        {
            MyCam.SetActive(true);
            CameraObserve.SetActive(false);
        }*/
    }
    private void Update()
    {
        text_.text = place_s + " "+ color;
    }

    #region object
    public void red()
    {
        PhotonNetwork.Instantiate(GameObjectTest[0].name, theGameObjects[place].transform.position, theGameObjects[place].transform.rotation);
        color = "red";
    }

    public void blue()
    {
        PhotonNetwork.Instantiate(GameObjectTest[1].name, theGameObjects[place].transform.position, theGameObjects[place].transform.rotation);
        color = "blue";

    }

    public void green()
    {
        PhotonNetwork.Instantiate(GameObjectTest[2].name, theGameObjects[place].transform.position, theGameObjects[place].transform.rotation);
        color = "green";

    }
    #endregion

    #region place
    public void droite()
    {
        place = 0;
        place_s = "droite";
    }

    public void milieu()
    {
        place = 1;
        place_s = "milieu";

    }

    public void gauche()
    {
        place = 2;
        place_s = "gauche";

    }
    #endregion

    #region Observe
    public void ObservePlayer()
    {
        CameraObserve = GameObject.FindWithTag("CameraObserve");
        MyCam.SetActive(false);
        CameraObserve.SetActive(true);
    }

    public void DEObservePlayer()
    {
        MyCam.SetActive(true);
        CameraObserve.SetActive(false);
    }
    #endregion
}
