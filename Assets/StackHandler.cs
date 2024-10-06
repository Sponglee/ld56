using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] private int stackMax = 15;
    [SerializeField] private float stackStep = 0.1f;
    [SerializeField] private GameObject stackPrefab;

    private List<GameObject> stack = new List<GameObject>();

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            AddStack();
        }
    }

    public void AddStack()
    {
        if (stack.Count > 15)
        {
            return;
        }
        
        var paper = Instantiate(stackPrefab, transform);
        paper.transform.localPosition = Vector3.up * (stackStep * (stack.Count-1));
        
        stack.Add(paper);
    }
}
