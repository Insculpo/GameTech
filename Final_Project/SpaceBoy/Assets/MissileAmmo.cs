using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAmmo : Artifact
{
    [SerializeField] int MissileCount = 20;
    [SerializeField] int RailCount = 20;
    // Start is called before the first frame update
    void Start()
    {
        WormManager = FindObjectOfType<Wormhole>();
        ArtifactSprite = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Invoked weapon pickup");
            other.gameObject.GetComponent<WeaponController>().missileAmmo += MissileCount;
            other.gameObject.GetComponent<WeaponController>().railgunAmmo += RailCount;
            WormManager.AddArtifact();
            Marker.enabled = false;
            ArtifactSprite.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
