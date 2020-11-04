using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Wall : MonoBehaviour
{
    public Color defaultColor;

    private void Reset()
    {
        defaultColor = GetComponent<MeshRenderer>().material.color;
    }
}
