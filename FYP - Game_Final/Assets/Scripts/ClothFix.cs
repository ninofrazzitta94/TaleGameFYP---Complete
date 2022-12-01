using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Framework.Scripts.Util
{

    public class ClothFix : MonoBehaviour
    {

        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

        private void OnRenderObject()
        {
            skinnedMeshRenderer.localBounds = skinnedMeshRenderer.sharedMesh.bounds;
        }
    }
}

