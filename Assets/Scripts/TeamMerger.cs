using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamMerger : MonoBehaviour {
  public static TeamMerger requester;

  public SpriteRenderer connector;
  public Plane floor;
  public bool isDragging = false;

  void Start () {
    requester = null;
    floor = new Plane(-Vector3.forward, connector.transform.position);
  }

  void OnMouseDown () {
    isDragging = true;
    connector.gameObject.SetActive(true);
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

    if (!Input.GetMouseButton(0)) {
      isDragging = false;
      StopConnecting();
    }
  }

  void OnMouseUp () {
    if (requester) {
    }
  }

  public void StopConnecting () {
    connector.gameObject.SetActive(false);
  }
}
