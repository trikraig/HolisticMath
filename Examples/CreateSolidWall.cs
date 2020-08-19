using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSolidWall : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform C;
    [SerializeField] Transform D;
    [SerializeField] Transform E;
    [SerializeField] GameObject ball;

    Plane wall;
    Line ballPath;
    Line trajectory;

    // Start is called before the first frame update
    void Start()
    {
        //CREATE PLANE
        wall = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));

        for (float s = 0; s <= 1; s += 0.1f)
        {
            for (float t = 0; t <= 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = wall.Lerp(s, t).ToVector();
            }
        }
        //CREATE BALL LINE

        ballPath = new Line(new Coords(D.position), new Coords(E.position), Line.LINETYPE.RAY);
        ballPath.Draw(1, Color.green);

        ball.transform.position = ballPath.A.ToVector();

        float interceptT = ballPath.IntersectsAt(wall);
        
        if(!(float.IsNaN(interceptT)))
        {
            trajectory = new Line(ballPath.A, ballPath.Lerp(interceptT), Line.LINETYPE.SEGMENT);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time <= 1)
        {
            ball.transform.position = trajectory.Lerp(Time.time).ToVector();
        }
        else
        {
            ball.transform.position += trajectory.Reflect(HolisticMath.Cross(wall.v, wall.u)).ToVector() * Time.deltaTime * 2.5f;
        }
      
    }
}
