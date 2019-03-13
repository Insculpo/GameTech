using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseGenerator : MonoBehaviour
{

    LineRenderer EllipseLine;
    public int Segments;
    public float XOffset;
    public float YOffset;
    public float PropagationSpeed = 0.1f;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        EllipseLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ClearEllipse();
        MakeEllipse(i);
        i += PropagationSpeed;
    }

    void MakeEllipse(float i)
    {
        Vector3[] Points = new Vector3[Segments + 1];
        for(int j = 0; j < Segments; j++)
        {
            float angle = ((float)j / (float)Segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * i;
            float y = Mathf.Cos(angle) * i;
            Points[j] = new Vector3(x, y, 0f);
        }
        Points[Segments] = Points[0];

        EllipseLine.positionCount = Segments + 1;
        EllipseLine.SetPositions(Points);

    }

    void ClearEllipse()
    {
        EllipseLine.positionCount = 0;
    }

}
