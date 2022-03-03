using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawner))]
public class EditSpawner : Editor
{
    public void OnSceneGUI()
    {
        Spawner s = (Spawner)target;

        Handles.color = Color.red;
        Handles.CircleCap(1, s.Player.position, Quaternion.identity, s.PlayerRadius);

    }

}
