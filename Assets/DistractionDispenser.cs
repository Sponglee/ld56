using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class DistractionDispenser : MonoBehaviour
{
   [SerializeField] private GameObject dispenserPrefab;
   [SerializeField] private Transform targetPoint;
   [SerializeField] private Transform startPoint;
   [SerializeField] private float throwDuration = 1;
   [SerializeField] private Vector3 spread;
   [SerializeField] private float dispenceLifetime = 1f;
   [SerializeField] private float dispenceTime = 1f;
   [SerializeField] private int dispenceAmount = 1;
   [SerializeField] private AnimationCurve _animationCurve;

   private Distraction _distraction;
   private float _timer = 0;
   private IEnumerator Start()
   {
      while (true)
      {
         yield return new WaitForSeconds(dispenceTime);
         _timer = 0f;

         var moneyValue = GameSettings.Instance.distractionMoneyAmount;
         _distraction = Instantiate(dispenserPrefab, transform).GetComponent<Distraction>();
         _distraction.transform.position = startPoint.position;
         _distraction.Initialize(dispenceLifetime, moneyValue);
         _distraction.transform.DOMove(targetPoint.position + GetRandomOffset(), throwDuration).SetEase(Ease.OutCirc).OnUpdate(DoAParabola);
      }
   }

   private void DoAParabola()
   {
      _timer += Time.deltaTime;
      var t = _distraction.transform;
      var localPosition = t.localPosition;
      
      localPosition =
         new Vector3(localPosition.x,  _animationCurve.Evaluate(_timer/throwDuration), localPosition.z);
      t.localPosition = localPosition;
    
   }
   
   private Vector3 GetRandomOffset()
   {
      return new Vector3(UnityEngine.Random.Range(-spread.x, spread.x), 0, UnityEngine.Random.Range(-spread.z, spread.z));
   }
}
