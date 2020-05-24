using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class MapPiece : MonoBehaviour {
  public List<GameObject> possible;
  public GameObject current;

  void Start () {
    Shuffle();
  }

  public void Shuffle () {
    current = transform.GetChild(0).gameObject;
    Destroy(current.gameObject);
    current = Instantiate(possible[Random.Range(0,possible.Count)]);

    current.transform.parent = transform;
    current.transform.localRotation =  Quaternion.identity;
    current.transform.localScale = Vector3.one;
    current.transform.localPosition = Vector3.zero;
  }

}
