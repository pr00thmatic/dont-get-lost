using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Wall : MonoBehaviour {
  public Transform a;
  public Transform b;
  public SpriteRenderer r;
  public BoxCollider c;
  public NavMeshObstacle obstacle;

  void Update () {
    r.size = new Vector2(Mathf.Abs(a.position.x - b.position.x) * 0.16f,
                         Mathf.Abs(a.position.z - b.position.z) * 0.16f);
    r.size *= 100;
    r.size = (new Vector2(r.size.x / 16, r.size.y / 16) * 16) / 100;
    c.size = (Vector3) (r.size / 0.16f / c.transform.localScale.x) +
      new Vector3(0,0,0.3f);
    r.transform.position = (a.position + b.position) / 2f;
    obstacle.size = c.size;
  }
}
