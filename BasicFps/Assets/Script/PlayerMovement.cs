using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity;
    public float pitchVel;
    public float yawVel;

    // A value between 0-90, it wont permit a rotation about the local x axis superior of 
    // pitchToleranceDegree, and inferior of minus pitchToleranceDegree. Must always be positive.
    public float pitchToleranceDegree;

    public Transform m_camera;

    Transform m_transform;

	// Use this for initialization
	void Start ()
    {
        pitchToleranceDegree = Mathf.Abs(pitchToleranceDegree);

        if (pitchToleranceDegree > 90)
            pitchToleranceDegree = 90;

        m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update position
        {

            Vector3 v_direction = Input.GetAxis("Vertical") * m_transform.forward;
            Vector3 h_direction = Input.GetAxis("Horizontal") * m_transform.right;

            Vector3 direction = Vector3.Normalize(v_direction + h_direction) * velocity * Time.deltaTime;

            m_transform.Translate(direction, Space.World);
        }

        // Update rotation
        {
            float yaw = Input.GetAxis("Mouse X") * yawVel * Time.deltaTime;
            float pitch = -Input.GetAxis("Mouse Y") * pitchVel * Time.deltaTime;

            //Rotate the player on the y axis, but only the camera on the local x axis
            m_transform.Rotate(0, yaw, 0);

            float currentPitch = m_camera.localRotation.eulerAngles.x + pitch;

            // if the camera points too up or too down, adjust it
            if (
                   currentPitch > pitchToleranceDegree &&
                   currentPitch < (360-pitchToleranceDegree)
               )
            {
                
                if (currentPitch - pitchToleranceDegree < (360 - pitchToleranceDegree) - currentPitch)
                {
                    currentPitch = pitchToleranceDegree;
                }
                else
                {
                    currentPitch = -pitchToleranceDegree;
                }
            }

            m_camera.localRotation = Quaternion.Euler(
                                                        currentPitch,
                                                        m_camera.localRotation.eulerAngles.y,
                                                        m_camera.localRotation.eulerAngles.z
                                                     );
        }

    }
}
