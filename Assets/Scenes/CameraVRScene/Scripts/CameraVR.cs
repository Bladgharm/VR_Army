using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraVR : MonoBehaviour
{
    private bool _camAvailable;
    private WebCamTexture _backCam;
    private Texture _defaultBackground;
    [SerializeField]
    private RawImage _background;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;
    [SerializeField]
    private Text _debugText;

    private void Start()
    {
        _debugText.text += "\nStart";
        _defaultBackground = _background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected!");
            _debugText.text += "\nNo camera detected!";
            _camAvailable = false;
            return;
        }

        foreach (WebCamDevice device in devices)
        {
            if (!device.isFrontFacing)
            {
                _backCam = new WebCamTexture(device.name, Screen.width, Screen.height);
            }
        }

        if (_backCam == null)
        {
            Debug.Log("Unable to find back camera!");
            _debugText.text += "\nUnable to find back camera!";
            return;
        }
        else
        {
            _debugText.text += "\n Camera found!";
        }

        _backCam.Play();
        _background.texture = _backCam;

        _camAvailable = true;
    }

    private void Update()
    {
        if (!_camAvailable)
        {
            _debugText.text += "\nCamera !available!";
            return;
        }

        float ratio = (float) _backCam.width / (float) _backCam.height;
        _aspectRatioFitter.aspectRatio = ratio;

        float scaleY = _backCam.videoVerticallyMirrored ? -1f : 1f;
        _background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -_backCam.videoRotationAngle;
        _background.rectTransform.localEulerAngles = new Vector3(0,0,orient);
    }
}
