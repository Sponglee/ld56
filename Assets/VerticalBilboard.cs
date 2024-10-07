using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBilboard : MonoBehaviour
{
   private Transform cam;

   private void Awake()
   {
      cam = Camera.main.transform;
   }

   private void Update()
   {
      transform.LookAt(cam);
   }
}
