using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisobedientRotation : MonoBehaviour {
  #if !UNITY_EDITOR
  void Start () {
    Destroy(this);
  }
  #endif

  void Update () {
    transform.forward = Vector3.up;
  }
}
