using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;

    void Update()
    {
        //RENDERIZAR CAMARA SELECCIONADA
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject c in cameras)
                c.GetComponent<Camera>().enabled = false;

            cameras[0].GetComponent<Camera>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject c in cameras)
                c.GetComponent<Camera>().enabled = false;

            cameras[1].GetComponent<Camera>().enabled = true;
        }
    }
}
