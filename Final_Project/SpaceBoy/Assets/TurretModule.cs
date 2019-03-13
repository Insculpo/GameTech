using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModule : MonoBehaviour
{
    [SerializeField]public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<ControlShip>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
