using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Photon.Pun;

public class Weapon_System : MonoBehaviourPun
{
    
    public string Name;

    public enum TypeShoot
    {
            Automatic,
            SemiAutomatic,
            Rafale
    }
    public TypeShoot Typebool;

    [Range(1,100)]
    public int damage;
    [Range(1, 7)]
    public float TimeToReload;
    [Range(0, 15)] [Tooltip("En degree")]
    public float Precision;

    [Header("Hit")]
    public bool Hitscan;
    public Transform Cam;
    public Transform Precision_g;

    [Header("Physics")]
    public bool BulletPhysics;
    public GameObject BulletPhysicG;

    [Space]
    [Range(1, 40)]
    public int BulletsMax;
           int Bullets;
    [Range(1, 10)]
    public int NombreBulletsParBullet;
    int NombreBB;
    [Range(0, 8)]
    public float FireRate;
           float timeToFire;

    [Header("Bonus")]
    public ParticleSystem Particle_muzzle;
    public Animator anim_weapon;
    public Text text_ammo;
    public Text Text_Name;
    public Text text_info;



    bool firing;

    private void Start()
    {
        Bullets = BulletsMax;
    }

    void Update()
    {

        if (timeToFire < FireRate)
        {
            timeToFire += Time.deltaTime;
        }
        if (photonView.IsMine)
        {
            InputDamn();
            DebugUI();
        }

        if (firing)
        {
            if (Hitscan)
            {
                HitScan_v();
            }
            if (BulletPhysics)
            {
                BulletPhysic_v();
            }

            timeToFire = 0;
            Bullets -= 1;

        }

        if (Bullets <= 0 /*|| Input.GetAxis("Reload") > 0*/)
        {
            StartCoroutine(Reload());
        }
    }

    void InputDamn()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Typebool == TypeShoot.Automatic && Bullets > 0 && timeToFire >= FireRate)
        {
            //Debug.Log("Automatic");
            firing = true;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Typebool == TypeShoot.SemiAutomatic && Bullets > 0 && timeToFire >= FireRate)
        {
            //Debug.Log("Semi-Automatic");
            firing = true;
        }
        /*
        if (Input.GetAxis("Fire") > 0 && timeToFire >= FireRate && Bullets > 0)
        {
            firing = true;
        }*/
    }

    HealthSystem HS;
    [PunRPC]
    void HitScan_v()
    {

        for (NombreBB = 0; NombreBB < NombreBulletsParBullet; NombreBB++)
        {
            
            float rng = Random.Range(-Precision, Precision);
            Precision_g.eulerAngles = new Vector3(rng, rng, 0);
            
            RaycastHit hit;
            if (Physics.Raycast(Cam.position, Precision_g.forward, out hit))
            {
                //Debug.DrawRay(Cam.position, Precision_g.forward, Color.red);
                /*HS = hit.collider.gameObject.GetComponent<HealthSystem>();
                HS.TakeDamage(damage);
                Debug.Log(Name + " shoot in HitScan " + " DMG: " + damage + " on " + hit.collider.gameObject.name);*/
                photonView.RPC("TakeDamage", hit.collider.gameObject,);

            }
        }
        firing = false;
    }

    void BulletPhysic_v()
    {
        Debug.Log(Name + " shoot in Physical Bullets " + " DMG: " + damage);
        firing = false;
    }


    IEnumerator Reload()
    {
        text_info.text = "Reloading";
        yield return new WaitForSeconds(FireRate);
        Bullets = BulletsMax;
        text_info.text = "";
    }

    void DebugUI()
    {
        text_ammo.text = Bullets + " / " + BulletsMax;
        Text_Name.text = Name;
    }
}
