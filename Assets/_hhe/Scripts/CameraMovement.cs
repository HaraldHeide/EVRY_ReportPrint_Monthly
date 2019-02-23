using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float speed = 10.0f;
	private float zoomSpeed = 10.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;
    float rotation2Y = 0.0f;
    float rotation2X = 0.0f;


    void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
        //transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
        transform.Translate(0, 0, scroll * zoomSpeed, Space.World);


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
			transform.position += Vector3.right * -speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
			transform.position += Vector3.left * -speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
			transform.position += Vector3.up * -speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
			transform.position += Vector3.down * -speed * Time.deltaTime;
		}

        if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        if (Input.GetMouseButton(2))
        {
            rotation2X += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotation2Y += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotation2Y = Mathf.Clamp(rotation2Y, minY, maxY);
            rotation2X = Mathf.Clamp(rotation2X, minX, maxX);
            transform.position += Vector3.left * rotation2X * Time.deltaTime;
            transform.position += Vector3.up * rotation2Y * Time.deltaTime;
        }

    }
}
