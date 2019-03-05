using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wormhole : MonoBehaviour
{
    Scene RealityBender;
    [SerializeField] DataRecorder RecordDevice;
    [SerializeField] int ArtifactCount = 0;
    [SerializeField] string TargetScene = "ReleaseSystem";
    // Start is called before the first frame update
    void Start()
    {
        RecordDevice = FindObjectOfType<DataRecorder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddArtifact()
    {
        ArtifactCount++;
        RecordDevice.artifacts++;
    }

    public string ArtifactCountToString()
    {
        return "Artifacts Collected: " + ArtifactCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Into the Wormhole!");
            SceneManager.LoadScene(TargetScene);
            
        }
    }
}
