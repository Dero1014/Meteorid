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

        foreach (Vector2 point in s.GridForShow)
        {
            Handles.color = Color.black;
            Handles.CircleCap(1, point, Quaternion.identity, 0.5f);
        }

    }

}
