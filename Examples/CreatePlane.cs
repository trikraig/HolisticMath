using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    [SerializeField] Transform A, B, C;
    Plane plane;
    [SerializeField] float planeSize = 1f;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));
        for (float s = -planeSize; s < planeSize; s+= 0.1f)
        {
            for (float t = -planeSize; t < planeSize; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
