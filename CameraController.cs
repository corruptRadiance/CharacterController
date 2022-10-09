using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float deltaX, deltaY;
    float x, y;

    void Update()
    {
        x = Mathf.Lerp(transform.position.x, target.transform.position.x, deltaX * Time.deltaTime);
        y = Mathf.Lerp(transform.position.y, target.transform.position.y, deltaY * Time.deltaTime);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
