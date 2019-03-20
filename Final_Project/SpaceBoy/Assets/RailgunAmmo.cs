using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunAmmo : Artifact
{
    [SerializeField] int RailCount = 20;
    // Start is called before the first frame update
    void Start()
    {
        WormManager = FindObjectOfType<Wormhole>();
    }


    void Collected(Collider other)
    {
        other.gameObject.GetComponent<WeaponController>().railgunAmmo += RailCount;
    }
    // Update is called once per frame

}
