using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecorder : MonoBehaviour
{
    public int artifacts = 0;

    // Start is called before the first frame update
    void Awake()
    {
        int Loaders = FindObjectsOfType<DataRecorder>().Length;
        if (Loaders != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PurgeData()
    {
        artifacts = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
