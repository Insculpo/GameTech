using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] protected Wormhole WormManager;
    [SerializeField] protected SpriteRenderer ArtifactSprite;
    [SerializeField] protected SpriteRenderer Marker;
    // Start is called before the first frame update
    void Start()
    {
        WormManager = FindObjectOfType<Wormhole>();
        ArtifactSprite = GetComponentInParent<SpriteRenderer>();
        ArtifactSprite = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WormManager.AddArtifact();
            Marker.enabled = false;
            ArtifactSprite.enabled = false;
            gameObject.SetActive(false);
        }
    }

    void Collected(Collider other)
    {

    }
}
