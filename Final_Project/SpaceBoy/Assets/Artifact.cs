using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] Wormhole WormManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WormManager.AddArtifact();
            Collected();
        }
    }

    void Collected()
    {
        gameObject.SetActive(false);
    }
}
