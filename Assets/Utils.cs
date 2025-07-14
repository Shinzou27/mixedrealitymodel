using UnityEngine;

public static class Utils
{
    public static Vector3 GetTopCenter(GameObject targetObject)
    {
        if (targetObject == null)
        {
            Debug.LogError("Target GameObject cannot be null.");
            return Vector3.zero;
        }

        MeshFilter meshFilter = targetObject.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("GameObject has no MeshFilter component.");
            return Vector3.zero;
        }

        Mesh mesh = meshFilter.mesh;
        if (mesh == null)
        {
            Debug.LogError("Mesh is null.");
            return Vector3.zero;
        }

        Vector3[] vertices = mesh.vertices;

        if (vertices.Length == 0)
        {
            Debug.LogError("Mesh has no vertices.");
            return Vector3.zero;
        }

        float maxY = float.MinValue;
        Vector3 highestVertex = Vector3.zero;

        foreach (Vector3 vertex in vertices)
        {
            Vector3 worldVertex = targetObject.transform.TransformPoint(vertex);
            if (worldVertex.y > maxY)
            {
                maxY = worldVertex.y;
                highestVertex = worldVertex;
            }
        }

        Vector3 centerXZ = targetObject.transform.TransformPoint(mesh.bounds.center);
        centerXZ.y = maxY;

        return centerXZ;
    }
}