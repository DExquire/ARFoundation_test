using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelColor : MonoBehaviour
{
    [SerializeField] public CUIColorPicker colorPicker;
    [SerializeField] private MeshRenderer modelRenderer;

    private void OnEnable()
    {
        modelRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
//        colorPicker = GameObject.Find("CUIColorPicker").GetComponent<CUIColorPicker>();
    }

    private void Update()
    {
        SetModelColor();
    }

    public void SetModelColor()
    {
        modelRenderer.material.color = colorPicker.Color;
    }
}
