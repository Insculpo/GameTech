using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPicker : MonoBehaviour
{
    SpriteRenderer AS;
    [SerializeField] Sprite[] ArtifactCatalog;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<SpriteRenderer>();
        AS.sprite = ArtifactCatalog[Random.Range(0, ArtifactCatalog.Length)];
    }
}
