using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	
	public float mouseSensitivity = 10;
	public float speed = 1;
//	bool RightMouseDown = false;
	float rotX;
	float rotY;
	//float rotZ;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (!Physics.Raycast(transform.position, transform.forward, 0.5f))
		transform.parent.position += Input.GetAxis ("Vertical") * transform.forward * speed / 100 * Time.deltaTime +
							  Input.GetAxis ("Horizontal") * transform.right * speed / 100 * Time.deltaTime;
	}
	
	private float xtargetRotation = 90;
	private float ytargetRotation = 180;
	public float smoothing = 5;
	public float min = -60;
	public float max = 60;

	void LateUpdate ()
	{
		if (Input.GetMouseButton (1)) {
			float yAxisMove = Input.GetAxis ("Mouse Y") * mouseSensitivity; // how much has the mouse moved?
			ytargetRotation += -yAxisMove; // what is the target angle of rotation
			ytargetRotation = ytargetRotation % 360;
			ytargetRotation = Mathf.Clamp (ytargetRotation, min, max);

			float xAxisMove = Input.GetAxis ("Mouse X") * mouseSensitivity; // how much has the mouse moved?
			xtargetRotation += xAxisMove; // what is the target angle of rotation
			xtargetRotation = xtargetRotation % 360;


			transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler (ytargetRotation, 0, 0), Time.deltaTime * 10 / smoothing);
			transform.parent.rotation = Quaternion.Lerp (transform.parent.rotation, Quaternion.Euler (0, 0, xtargetRotation), Time.deltaTime * 10 / smoothing);
		}
	}
	/*
	void LateUpdate ()
	{
		if (Input.GetMouseButton (1)) {
			if (!RightMouseDown) {
				RightMouseDown = true;
				//rotX = transform.rotation.x;
				//rotY = transform.rotation.y;
				//rotZ = transform.localEulerAngles.z;
			}
			rotX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime / 180 * Mathf.PI;
			rotY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime;
			transform.Rotate (new Vector3 (1, 0, 0), -rotY);
			transform.RotateAround (new Vector3 (0, 0, 1), rotX);
		} else {
			RightMouseDown = false;
		}
	}
	*/
}
