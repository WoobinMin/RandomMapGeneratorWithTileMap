using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbstrractDungeonGenerator) , true)]
public class RandomDungeonGeneratorEditor : Editor
{
    AbstrractDungeonGenerator generator;

    private void Awake()
    {
        generator = (AbstrractDungeonGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon();
        }

    }
}
