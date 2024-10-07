using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitController : MonoBehaviour
{

  public GameObject hitFx;
  
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      Instantiate(hitFx, null);
    }
  }
}
