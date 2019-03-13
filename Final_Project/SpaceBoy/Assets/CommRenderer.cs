using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer EllipseLine;
    public float PropagationSpeed;
    public float lifespan = 30f;
    public bool ContactFound = false;
    public int Segments;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Comm renderer is online");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Anyone home?");
            StartCoroutine("Propagate");
        }
    }

    IEnumerator Propagate()
    {
        Debug.Log("Propagating...");
        for (int l = 0; l < lifespan; l++)
        {
            ClearEllipse();
            MakeEllipse(i);
            i += PropagationSpeed;
            yield return null;
            
        }
        Debug.Log("No one found");
        ClearEllipse();
        i = 0;
    }

    void MakeEllipse(float i)
    {
        Vector3[] Points = new Vector3[Segments + 1];
        for (int j = 0; j < Segments; j++)
        {
            float angle = ((float)j / (float)Segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * i;
            float y = Mathf.Cos(angle) * i;
            Points[j] = new Vector3(x, y, 0f);
           
        }
        Points[Segments] = Points[0];

        EllipseLine.positionCount = Segments + 1;
        EllipseLine.startColor = Color.green;
        EllipseLine.endColor = Color.green;
        EllipseLine.SetPositions(Points);

    }

    void ClearEllipse()
    {
        EllipseLine.positionCount = 0;
    }
}
