using UnityEngine;

public class Line
{
    Coords a, b, vector;

    public enum LINETYPE { LINE, SEGMENT, RAY };
    LINETYPE type;

    public Line(Coords _A, Coords _B, LINETYPE _type)
    {
        a = _A;
        b = _B;
        vector = b - a;
        type = _type;
    }

    public Line(Coords _A, Coords vector)
    {
        type = LINETYPE.SEGMENT;
        a = _A;
        this.vector = vector;
        b = a + this.vector;
    }

    public Coords Lerp(float t) //t is short for time as time at.
    {
        //Line t -inf <= t <= inf
        //Segment 0 <= t <= 1
        //Ray 0 <= t <= inf

        if (type == LINETYPE.RAY && t < 0)
        {
            t = 0;
        }
        else if (type == LINETYPE.SEGMENT)
        {
            t = Mathf.Clamp(t, 0, 1);
        }

        float xt = a.x + vector.x * t;
        float yt = a.y + vector.y * t;
        float zt = a.z + vector.z * t;

        return new Coords(xt, yt, zt);
    }

    public float IntersectsAt(Line otherLine)
    {
        if (HolisticMath.Dot(Coords.Perp(otherLine.vector), vector) == 0)
        {
            //Is parallel, NaN is Not a Number
            return float.NaN;
        }
        //t is time at which point lines intersect.       
        //c is vector between both starting points of lines.
        Coords c = otherLine.a - this.a;
        float t = HolisticMath.Dot(Coords.Perp(otherLine.vector), c) / HolisticMath.Dot(Coords.Perp(otherLine.vector), this.vector);
        //t ranges from 0 to 1 on segment, if outside that range, intersect not on the line
        if ((t < 0 || t > 1) && type == LINETYPE.SEGMENT)
        {
            return float.NaN;
        }
        return t;
    }

    public void Draw(float width, Color col)
    {
        Coords.DrawLine(a, b, width, col);
    }
}
