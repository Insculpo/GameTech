using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSomeone : MonoBehaviour
{
    public CubeFollow mommy;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mommy.PlayerHit = true;
        }
    }
}
