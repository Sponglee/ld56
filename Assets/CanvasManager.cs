using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    public Transform[] canvases;

    private void Awake()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            var canvas = canvases[i];
            canvas.gameObject.SetActive(false);
        }


        ToggleCanvas("MenuCanvas", true);
    }

    public void ToggleCanvas(string name, bool toggle)
    {
        Transform targetCanvas = null;
        for (int i = 0; i < canvases.Length; i++)
        {
            var canvas = canvases[i];
            if (canvas.name == name)
            {
                targetCanvas = canvas;
            }
        }

        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(toggle);
        }
    }

    public Transform GetCanvas(string name)
    {
        Transform targetCanvas = null;
        for (int i = 0; i < canvases.Length; i++)
        {
            var canvas = canvases[i];
            if (canvas.name == name)
            {
                targetCanvas = canvas;
            }
        }

        return targetCanvas;
    }
}