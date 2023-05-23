using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerVertex : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            if (i >= 400)
                break;
            GameObject olive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            olive.transform.SetParent(transform);
            olive.transform.localPosition = mesh.vertices[i];
            olive.transform.localScale = Vector3.one * 0.04f;
            olive.GetComponent<MeshRenderer>().material.color = new Color32(195, 160, 66, 255);
            olive.name = "olive " + i;
        }
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            // Get the vertices of the face
            Vector3 vertex1 = mesh.vertices[mesh.triangles[i]];
            Vector3 vertex2 = mesh.vertices[mesh.triangles[i + 1]];
            Vector3 vertex3 = mesh.vertices[mesh.triangles[i + 2]];

            // Calculate the center of the face
            Vector3 center = (vertex1 + vertex2 + vertex3) / 3f;

            // Spawn a sphere at the center of the face
            GameObject olive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            olive.transform.SetParent(transform);
            olive.transform.localPosition = center;
            olive.transform.localScale = Vector3.one * 0.04f;
            olive.GetComponent<MeshRenderer>().material.color = new Color32(195, 160, 66, 255);
            olive.name = "oliveFace " + i;
        }
    }

}
