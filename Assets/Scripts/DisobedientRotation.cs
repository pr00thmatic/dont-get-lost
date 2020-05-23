using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisobedientRotation : MonoBehaviour {
  void Start () {
    Destroy(this);
  }

  void Update () {
    transform.forward = -Vector3.forward;
  }
}
