﻿using UnityEngine;

public class CreateLines : MonoBehaviour
{
    Line L1;
    Line L2;
    // Start is called before the first frame update
    void Start()
    {
        L1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
        L1.Draw(1, Color.green);

        L2 = new Line(new Coords(-100, 10, 0), new Coords(200, 150, 0));
        L2.Draw(1, Color.red);

        float intersectTime = L1.IntersectsAt(L2);
        float intersectS = L2.IntersectsAt(L1);
        //If is not a number, lines dont intersect.
        if (!(float.IsNaN(intersectTime) || float.IsNaN(intersectS)))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = L1.Lerp(intersectTime).ToVector();
        }
        print("T: " + intersectTime + " S: " + intersectS);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
