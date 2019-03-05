using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideRotatio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation.Set(90f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
}
