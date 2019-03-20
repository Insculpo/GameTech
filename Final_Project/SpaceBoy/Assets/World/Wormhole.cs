using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wormhole : MonoBehaviour
{
    Scene RealityBender;
    [SerializeField] DataRecorder RecordDevice;
    [SerializeField] int ArtifactCount = 0;
    [SerializeField] float wormRot = 2f;
    [SerializeField] string TargetScene = "ReleaseSystem";
    Artifact[] ArtifactManager;
    Color wormCol;

    // Start is called before the first frame update
    void Start()
    {
        RecordDevice = FindObjectOfType<DataRecorder>();
        ArtifactManager = FindObjectsOfType<Artifact>();
        wormCol = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, wormRot);
    }

    public void AddArtifact()
    {
        CheckCount();
        ArtifactCount++;
        RecordDevice.artifacts++;
    }

    void CheckCount()
    {
        if(ArtifactCount * 0.5f == ArtifactManager.Length * 0.5f)
        {
            wormRot *= 2f;
            wormCol = Color.blue;
        }
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
