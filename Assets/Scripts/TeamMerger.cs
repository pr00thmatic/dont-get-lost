using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamMerger : MonoBehaviour {
  public SpriteRenderer connector;
  public Plane floor;
  public bool isDragging = false;
  public Team team;

  void Start () {
    floor = new Plane(-Vector3.forward, connector.transform.position);
  }

  void OnMouseDown () {
    isDragging = true;
    connector.transform.parent.gameObject.SetActive(true);
  }

  void Update () {
    if (isDragging) {
      float enter;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      floor.Raycast(ray, out enter);
      Vector3 relativeHitPoint = ray.GetPoint(enter) - connector.transform.position;
      connector.size = new Vector2(relativeHitPoint.magnitude /
                                   connector.transform.lossyScale.x, 0.16f);
      connector.transform.parent.rotation =
        Quaternion.LookRotation(relativeHitPoint, -Vector3.forward);
    }

    if (!Input.GetMouseButton(0) && isDragging) {
      isDragging = false;
      StopConnecting();
    }
  }

  void OnDestroy () {
    Destroy(team);
  }

  public void MergeConsume (TeamMerger toConsume) {
    toConsume.team.head.Follow(team.tail);
    team.tail = toConsume.team.tail;
    foreach (Unit unit in toConsume.GetComponentsInChildren<Unit>()) {
      unit.transform.parent = transform;
    }
    team.Select();
    Destroy(toConsume);
  }

  public void StopConnecting () {
    connector.transform.parent.gameObject.SetActive(false);
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit)) {
      TeamMerger merger = hit.collider.GetComponentInParent<TeamMerger>();
      if (!merger || merger == this) return;
      merger.MergeConsume(this);
    }
  }
}
