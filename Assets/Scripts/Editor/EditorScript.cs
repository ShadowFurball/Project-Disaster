using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class EditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameManager gm = (GameManager)target;

        if (GUILayout.Button("Create Whirlwind"))
        {
            gm.CreateWhirlwind();
        }

        if (GUILayout.Button("Create Meteor"))
        {
            gm.CreateMeteor();
        }
    }
}
