using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{
    [SerializeField] string L = "ReleaseScene";
    [SerializeField] DataRecorder R;
    [SerializeField] TextMeshProUGUI A;
    // Start is called before the first frame update
    void Start()
    {
        R = FindObjectOfType<DataRecorder>();
        A.text = "Final Artifact Count: " + R.artifacts;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            R.PurgeData();
            SceneManager.LoadScene(L);
        }
    }
}
