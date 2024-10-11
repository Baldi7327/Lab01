using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] GameObject obj;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        SetTarget();
    }
    private void SetTarget()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Clicked");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Casted");
                obj.transform.position = hit.point;
            }
        }
    }
}
