using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Distraction : MonoBehaviour
{
   private int _moneyValue;
   private float _lifeTime;
   private float _rotateSpeed;

   [SerializeField] private Transform modelHolder;
   [SerializeField] private Image fillTimer;
   
   private float _internalTimer;
   
   public void Initialize(float lifetime, int amount)
   {
      _moneyValue = amount;
      _lifeTime = lifetime;
      _internalTimer = 0f;
      _rotateSpeed = UnityEngine.Random.Range(-10f, 10f);

      Destroy(gameObject,_lifeTime);
   }

   private void Update()
   {
      _internalTimer += Time.deltaTime;
      fillTimer.fillAmount = _internalTimer / _lifeTime;
      modelHolder.Rotate(Vector3.one, _rotateSpeed);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
      {
         _rotateSpeed = 0;
      }
      
      if(other.CompareTag("Player"))
      {
         MoneyManager.Instance.AddMoney(-_moneyValue);
         Destroy(gameObject);
      }
   }
}
