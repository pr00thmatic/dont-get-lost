using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Wall : MonoBehaviour {
  public Transform a;
  public Transform b;
  public SpriteRenderer r;
  public BoxCollider c;

  void Update () {
    r.size = new Vector2(Mathf.Abs(a.position.x - b.position.x) * 0.16f,
                         Mathf.Abs(a.position.z - b.position.z) * 0.16f);
    // r.size = new Vector2(Mathf.Round(r.size.x * 100) / 100,
    //                      Mathf.Round(r.size.y * 100) / 100);
    c.size = r.size / 0.16f / c.transform.localScale.x;
    r.transform.position = (a.position + b.position) / 2f;
  }
}
