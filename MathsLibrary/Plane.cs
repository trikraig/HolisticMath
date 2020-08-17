﻿using UnityEngine;

public class Plane
{
    Coords A, B, C, v, u;

    public Plane(Coords _A, Coords _B, Coords _C)
    {
        A = _A;
        B = _B;
        C = _C;
        v = B - A;
        u = C - A;
    }
    public Plane(Coords _A, Vector3 V, Vector3 U)
    {
        A = _A;
        v = new Coords(V);
        u = new Coords(U);
    }

    public Coords Lerp(float s, float t)
    {
        float xst = A.x + v.x * s + u.x * t;
        float yst = A.y + v.y * s + u.y * t;
        float zst = A.z + v.z * s + u.z * t;

        return new Coords(xst, yst, zst);

    }
}
