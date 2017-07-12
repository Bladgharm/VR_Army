using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCameraSettings : MonoBehaviour
{
    private Camera _vrCamera;
    [SerializeField]
    private Slider _separationSlider;
    [SerializeField]
    private Text _separationValue;

    private void Start()
    {
        _vrCamera = Camera.main;
        
        _separationSlider.onValueChanged.AddListener(SliderValueChanged);

        _separationSlider.value = 0f;
    }

    private void SliderValueChanged(float value)
    {
        _vrCamera.stereoSeparation = value;
        _separationValue.text = value.ToString();
    }
}
