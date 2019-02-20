using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragParent : MonoBehaviour
{
    [SerializeField] GameObject HoverMeNow;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = HoverMeNow.transform.position;
    }
}
