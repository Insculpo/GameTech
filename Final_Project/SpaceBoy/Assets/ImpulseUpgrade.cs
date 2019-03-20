using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseUpgrade : Artifact
{
    [SerializeField] bool ImpulsePowerUp = true;
    [SerializeField] float ImpUpFactor = 10f;
    [SerializeField] float ThrustUpFactor = 10f;
    [SerializeField] float StrafeUpFactor = 10f;
    [SerializeField] float NewImpDelay = 10f;
    [SerializeField] float betterShield = 10f;

    // Start is called before the first frame update
    void Start()
    {
        WormManager = FindObjectOfType<Wormhole>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ControlShip>().ImpulseFactor += ImpUpFactor;
            other.gameObject.GetComponent<ControlShip>().ThrustFactor += ThrustUpFactor;
            other.gameObject.GetComponent<ControlShip>().StrafeFactor += StrafeUpFactor;
            other.gameObject.GetComponent<ControlShip>().ImpulseDelay -= NewImpDelay;
            other.gameObject.GetComponent<ControlShip>().Shielding += betterShield;
            other.gameObject.GetComponent<ControlShip>().UpdeadImpulse = ImpulsePowerUp;
            WormManager.AddArtifact();

            Marker.enabled = false;
            ArtifactSprite.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
