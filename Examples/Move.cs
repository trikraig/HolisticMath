using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] Transform start;
    [SerializeField] Transform end;
    Line line;

    [SerializeField]
    [Range(0, 1)]
    float t = 0.25f;

    [SerializeField] Line.LINETYPE type = Line.LINETYPE.SEGMENT;

    
    // Start is called before the first frame update
    void Start()
    {
        //line = new Line(new Coords(start.position), new Coords(end.position), type);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = line.Lerp(Time.time * 0.1f).ToVector();
        transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), Time.time * 0.1f).ToVector();
    }
}
