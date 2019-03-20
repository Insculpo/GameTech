using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Artifact
{
    public float HealAmount = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<HealthSystem>().Health += HealAmount;
            GetComponentInParent<SpriteRenderer>().enabled = false;
            gameObject.SetActive(false);
        }
    }

}
