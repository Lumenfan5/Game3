using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float abortSpeed = 30;
    //private float MouseX;
    private float MouseY;
    private void Update()
    {
        //MouseX = Input.GetAxis("Mouse X") * abortSpeed * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * abortSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(-MouseY, 0 /*MouseX*/, 0);
    }
}
