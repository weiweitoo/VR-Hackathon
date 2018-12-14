using CLOVR_Plugin;
using UnityEngine;

public class CLOVRManager : CLOVRBehaviour
{
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        CLOVRUpdate();

        //code your logic here
        /*if (CLOVRDeviceManager.DeviceStatus)
        {
            Debug.Log("GYRO: " + CLOVRSensorManager.GetGyroValue[0] + " , " + CLOVRSensorManager.GetGyroValue[1] + " , " + CLOVRSensorManager.GetGyroValue[2]);
            Debug.Log("Accel: " + CLOVRSensorManager.GetAccelValue[0] + " , " + CLOVRSensorManager.GetAccelValue[1] + " , " + CLOVRSensorManager.GetAccelValue[2]);
        }*/

        //Debug.Log("GYRO: " + CLOVRSensorManager.GetGyroValue[0] + " , " + CLOVRSensorManager.GetGyroValue[1] + " , " + CLOVRSensorManager.GetGyroValue[2]);
        transform.rotation = transform.rotation * Quaternion.Euler(CLOVRSensorManager.GetGyroValue[1], -CLOVRSensorManager.GetGyroValue[0], 0);
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);
    }
}
