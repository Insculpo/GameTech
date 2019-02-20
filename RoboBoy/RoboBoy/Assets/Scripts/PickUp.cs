using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int Points = 1;
    [SerializeField] List<Door> DoorCats;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }


    public void Reset()
    {
        enabled = true;
    }

    private void OnTriggerEnter(Collider pickUp)
    {
        Controller check = pickUp.gameObject.GetComponent<Controller>();
        if (check != null)
        {
            check.score += Points;
            check.newScore = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
