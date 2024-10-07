using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] private int stackMax = 15;
    [SerializeField] private float stackStep = 0.1f;
    [SerializeField] private GameObject stackPrefab;
    [SerializeField] private Transform hint;
    [SerializeField] private Transform stackHolder;
    
    private bool isATarget = false;
    private Stack<Paper> stack = new Stack<Paper>();

    private PaperReciever _paperReciever;
    private bool _isInitialized = false;

    public bool IsAtTarget {
        get => isATarget;
        set
        {
            hint.gameObject.SetActive(value);
            isATarget = value;
        }
    }

    private void Awake()
    {
        InputManager.Instance.interactionPressed += Interact;
    }

    private void OnDestroy()
    {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.interactionPressed -= Interact;
        }

    }

    public void Initialize()
    {
        ClearStack();
        
        if (_isInitialized)
        {
            _isInitialized = false;
        }
        else
        {
            AddStack();
            _isInitialized = true;
        }
    }

    private void Interact()
    {
        if (IsAtTarget)
        {
            RemovePaper();
        }
    }

    public void AddStack()
    {
        for (int i = 0; i < stackMax; i++)
        {
            var paper = Instantiate(stackPrefab, stackHolder).GetComponent<Paper>();
            paper.transform.localPosition = Vector3.up * (stackStep * (stack.Count-1));
        
            stack.Push(paper);
        }
    }
    public void ClearStack()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            var paper = stack.Pop();
            Destroy(paper.gameObject);
        }
        
        stack.Clear();
    }

    public void RemovePaper()
    {
        if(_paperReciever == null) return;
        var paper = stack.Pop();
        paper.MoveTo(_paperReciever);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isInitialized) return;
        
        if (other.CompareTag("PaperTarget"))
        {
            IsAtTarget = true;
            _paperReciever = other.gameObject.GetComponentInParent<PaperReciever>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsAtTarget = false;
    }
}
