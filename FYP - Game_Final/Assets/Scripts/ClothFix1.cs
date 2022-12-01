using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothFix1 : MonoBehaviour
{
    static Bounds GetLocalBoundsForObject(GameObject go)
    {
        var referenceTransform = go.transform;
        var b = new Bounds(Vector3.zero, Vector3.zero);
        RecurseEncapsulate(referenceTransform, ref b);
        return b;

        void RecurseEncapsulate(Transform child, ref Bounds bounds)
        {
            var mesh = child.GetComponent<MeshFilter>();
            if (mesh)
            {
                var lsBounds = mesh.sharedMesh.bounds;
                var wsMin = child.TransformPoint(lsBounds.center - lsBounds.extents);
                var wsMax = child.TransformPoint(lsBounds.center + lsBounds.extents);
                bounds.Encapsulate(referenceTransform.InverseTransformPoint(wsMin));
                bounds.Encapsulate(referenceTransform.InverseTransformPoint(wsMax));
            }
            foreach (Transform grandChild in child.transform)
            {
                RecurseEncapsulate(grandChild, ref bounds);
            }
        }
    }
}
