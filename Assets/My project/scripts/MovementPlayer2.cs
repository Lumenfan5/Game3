using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer2 : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float turningSpeed = 10f;
    [SerializeField] float abortSpeed = 30;
    public GameObject player;
    private float MouseX;
    //private float MouseX;
    //private float MouseY;
            
        private void Update()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position -= player.transform.right * movementSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += player.transform.right * movementSpeed * Time.deltaTime;
            
        }

        MouseX = Input.GetAxis("Mouse X") * abortSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0, MouseX, 0);
        //MouseX = Input.GetAxis("Mouse X") * 10 * Time.deltaTime;
        //MouseY = -Input.GetAxis("Mouse Y") * 10 * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(MouseY, MouseX, 0);

    }
    
}
