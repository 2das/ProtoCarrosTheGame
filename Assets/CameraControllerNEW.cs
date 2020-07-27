using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerNEW : MonoBehaviour
{
    public float detectionRange = 20;

    List<GameObject> cars = new List<GameObject>();
    List<GameObject> carsAtRange = new List<GameObject>();
    

    private void Start()
    {
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("car"))
            cars.Add(c);
    }

    void Update()
    {
        //DETECTAMOS COCHES ALREDEDOR
        foreach (GameObject c in cars)
        {
            if (Vector3.Distance(transform.position, c.transform.position) < detectionRange)
            {
                if (!carsAtRange.Contains(c))
                    carsAtRange.Add(c);
            }

            else
            {
                if(carsAtRange.Contains(c))
                    carsAtRange.Remove(c);
            }
        }

        //MIRAMOS COCHES ALREDEDOR
        Vector3 groupPoint = Vector3.zero;
        foreach (GameObject c in carsAtRange)
            groupPoint += c.transform.position;
       
        groupPoint /= carsAtRange.Count;

        transform.LookAt(groupPoint);
    }
}
