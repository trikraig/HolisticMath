using UnityEngine;

public class PlaneRayIntersection : MonoBehaviour
{

    [SerializeField] GameObject sphere;
    [SerializeField] GameObject quad;
    //[SerializeField] Transform corner1;
    //[SerializeField] Transform corner2;
    //[SerializeField] Transform corner3;
    [SerializeField] GameObject[] fences;
    Vector3[] fenceNormals;

    UnityEngine.Plane mPlane;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        //quad.transform.transformpoint changes mesh coords into world space
        mPlane = new UnityEngine.Plane(quad.transform.TransformPoint(vertices[0]), quad.transform.TransformPoint(vertices[1]), quad.transform.TransformPoint(vertices[2]));
        print(vertices[0]);
        print(vertices[1]);
        print(vertices[2]);
        //mPlane = new UnityEngine.Plane(corner1.position, corner2.position, corner3.position);

        fenceNormals = new Vector3[fences.Length];

        for (int i = 0; i < fences.Length; i++)
        {
            Vector3 normal = fences[i].GetComponent<MeshFilter>().mesh.normals[0];
            fenceNormals[i] = fences[i].transform.TransformVector(normal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (mPlane.Raycast(ray, out float t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                float hitPointX = Mathf.Clamp(hitPoint.x, -6, 6);
                float hitPointZ = Mathf.Clamp(hitPoint.z, -6, 6);

                bool inside = true;
                for (int i = 0; i < fences.Length; i++)
                {
                    Vector3 hitPointToFence = fences[i].transform.position - hitPoint;
                    inside = inside && (Vector3.Dot(hitPointToFence, fenceNormals[i]) <= 0);
                }

                if (inside)
                {
                    sphere.transform.position = new Vector3(hitPointX, hitPoint.y, hitPointZ);
                }
            }
        }
    }
}
