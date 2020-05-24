using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisobedientRotation : MonoBehaviour {
  public SpriteRenderer r;

  // #if !UNITY_EDITOR
  // void Start () {
  //   Destroy(this);
  // }
  // #endif

  void Update () {
    transform.forward = Vector3.up;
    // r.size = new Vector2(Mathf.Round(r.size.x * 16 * 100) / (16 * 100),
    //                      Mathf.Round(r.size.y * 16 * 100) / (16 * 100));
  }
}
