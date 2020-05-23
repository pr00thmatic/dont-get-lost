using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof(GenerateMap))]
public class MapEdit : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GenerateMap map = target as GenerateMap;

        map.GenMap();
    }

}
