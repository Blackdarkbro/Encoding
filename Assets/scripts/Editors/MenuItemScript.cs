using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItemScript : MonoBehaviour
{
    [MenuItem("Tools/Change Color")]
    public static void ChangeColor()
    {
        var gameObjects = FindObjectsOfType<MeshRenderer>();
        foreach (var obj in gameObjects)
        {
            obj.GetComponent<MeshRenderer>().material.color = new Color(255, 125, 0);
        }
    }
}
