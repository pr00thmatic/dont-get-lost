using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnslaveAudioSource : MonoBehaviour {
  public AudioSource master;
  public AudioSource slave;

  void Reset () {
    master = transform.parent.GetComponentInParent<AudioSource>();
    slave = GetComponent<AudioSource>();
  }

  void Update () {
    slave.timeSamples = master.timeSamples;
  }
}
