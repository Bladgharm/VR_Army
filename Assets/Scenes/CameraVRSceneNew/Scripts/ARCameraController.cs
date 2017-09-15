using UnityEngine;

public class ARCameraController : MonoBehaviour
{
    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("CameraParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;
    }

    private void Update()
    {
        Quaternion camerRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = camerRotation;
    }
}
