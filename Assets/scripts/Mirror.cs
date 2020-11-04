using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private Material mirror;
    [SerializeField] private Camera mirrorCamera;
    private RenderTexture rt;

    private void Start()
    {
        rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();
        
        mirrorCamera.targetTexture = rt;
        mirror.mainTexture = rt;
        
    }
}
