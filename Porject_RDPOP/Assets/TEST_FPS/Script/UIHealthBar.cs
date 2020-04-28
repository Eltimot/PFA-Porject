using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    static Image Barre;

    public float max { get; set; }

    private float Valeur;
    public float valeur
    {
        get { return Valeur; }

        set
        {
            Valeur = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
