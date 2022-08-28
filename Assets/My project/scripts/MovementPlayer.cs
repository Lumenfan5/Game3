using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float turningSpeed = 10f;
    [SerializeField] private static float vertical, horizontal;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        vertical = Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, 0, vertical);
    }
}
