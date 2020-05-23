using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : NonPersistantSingleton<CameraControl> {
  public Transform target;
  public float smoothTime = 0;
  public Vector3 velocity;

  void FixedUpdate () {
    if (!target) return;

    transform.position =
      Vector3.SmoothDamp(transform.position, target.position,
                         ref velocity, smoothTime);
  }
}
