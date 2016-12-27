using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Transform xAxisTrans;
    Transform yAxisTrans;

    float currentXRotAngle;

    public float sensitivityY;
    public float sensitivityX;

    public float maxXLookUp;
    public float maxXLookDown;

    // Use this for initialization
    void Start ()
    {
        xAxisTrans = this.transform.parent;
        yAxisTrans = xAxisTrans.parent;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Rotate the camera along the y axis
        {
            float yDirection = Input.GetAxis("Mouse X");

            yAxisTrans.Rotate(0, Time.deltaTime * sensitivityY * yDirection, 0);
        }

        // Rotate the camera along the x local axis
        {
            float xDirection = -Input.GetAxis("Mouse Y");

            currentXRotAngle += Time.deltaTime * sensitivityX * xDirection;

            if (currentXRotAngle < maxXLookUp)
                currentXRotAngle = maxXLookUp;
            else if (currentXRotAngle > maxXLookDown)
                currentXRotAngle = maxXLookDown;

            xAxisTrans.localRotation = Quaternion.Euler(currentXRotAngle, 0, 0);

        }
	}
}
