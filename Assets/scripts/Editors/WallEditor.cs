using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wall))]
public class WallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Wall wall = target as Wall;
        if (GUILayout.Button("Back default color"))
        {
            wall.GetComponent<MeshRenderer>().material.color = wall.defaultColor;
        }
    }
}
