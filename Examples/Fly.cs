using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float speed = 1f;


    void Update()
    {
        float translateX = Input.GetAxis("Horizontal") * speed;
        float translateY = Input.GetAxis("VerticalY") * speed;
        float translateZ = Input.GetAxis("Vertical") * speed;

        transform.Translate(translateX, translateY, translateZ);
    }
}
