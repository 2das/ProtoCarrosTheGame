using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    List<GameObject> cameras = new List<GameObject>();

    private void Start()
    {
        foreach(Transform t in transform)
        {
            cameras.Add(t.gameObject);
        }
    }

    void Update()
    {
        //RENDERIZAR CAMARA SELECCIONADA
        if (Input.GetKey(KeyCode.Alpha1))
            SwitchCamera(1);
        if (Input.GetKey(KeyCode.Alpha2))
            SwitchCamera(2);
        if (Input.GetKey(KeyCode.Alpha3))
            SwitchCamera(3);
        if (Input.GetKey(KeyCode.Alpha4))
            SwitchCamera(4);
        if (Input.GetKey(KeyCode.Alpha5))
            SwitchCamera(5);
        if (Input.GetKey(KeyCode.Alpha6))
            SwitchCamera(6);
        if (Input.GetKey(KeyCode.Alpha7))
            SwitchCamera(7);
        if (Input.GetKey(KeyCode.Alpha8))
            SwitchCamera(8);
        if (Input.GetKey(KeyCode.Alpha9))
            SwitchCamera(9);
    }

    void SwitchCamera(int cam)
    {
        if (cameras.Count >= cam)
        {
            foreach (GameObject c in cameras)
                c.GetComponent<Camera>().enabled = false;

            cameras[cam-1].GetComponent<Camera>().enabled = true;
        }
    }
}
