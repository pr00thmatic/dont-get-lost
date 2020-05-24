using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Wall))]
public class WallEditor : Editor {
  Wall Target { get => (Wall) target; }

  void OnSceneGUI () {
    Target.a.position = Handles.PositionHandle(Target.a.position,
                                               Quaternion.identity);
    Target.b.position = Handles.PositionHandle(Target.b.position,
                                               Quaternion.identity);

    Undo.RecordObject(Target.a, "pos");
    Undo.RecordObject(Target.b, "pos");
  }
}
