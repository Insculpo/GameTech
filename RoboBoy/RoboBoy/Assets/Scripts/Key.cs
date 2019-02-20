using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int KeyCode = 1;
    [SerializeField] List<KeyDoor> DoorCats;
    [SerializeField] Color KeyColor;
    [SerializeField] ParticleSystem P;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    //    GetComponent<Material>().color = KeyColor;
    }


    public void Reset()
    {
        enabled = true;
    }

    private void OnTriggerEnter(Collider Key)
    {
        Controller check = Key.gameObject.GetComponent<Controller>();
        if (check != null)
        {
            check.PickUpCollide();
            foreach(KeyDoor KD in DoorCats )
            {
                KD.CheckAddress(KeyCode);
            }
            P.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
