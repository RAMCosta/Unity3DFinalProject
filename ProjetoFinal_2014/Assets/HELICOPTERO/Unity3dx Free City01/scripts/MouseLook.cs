using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/MouseLook")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

    public float moveSensitivity = 1.0f;

	float rotationX = 0F;
	float rotationY = 0F;
	float SpeedZ1=0.0f;float SpeedZ2=0.0f;
	float SpeedY1=0.0f;float SpeedY2=0.0f;
	float SpeedX1=0.0f;float SpeedX2=0.0f;
	
	public float SpeedSensitivity=0.05f;

	Quaternion originalRotation;

	void Update ()
	{
        if (Input.GetMouseButton(0))
        {
		
            if (axes == RotationAxes.MouseXAndY)
            {
                // Read the mouse input axis
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                rotationY = ClampAngle(rotationY, minimumY, maximumY);

                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

                transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
            else if (axes == RotationAxes.MouseX)
            {
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationX = ClampAngle(rotationX, minimumX, maximumX);

                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation = originalRotation * xQuaternion;
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = ClampAngle(rotationY, minimumY, maximumY);

                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
                transform.localRotation = originalRotation * yQuaternion;
            }
        }

        Vector3 moveVector = new Vector3(0, 0, 0);
		
		//left and right
		if (Input.GetKey(KeyCode.D) ) {
			SpeedX1+=SpeedSensitivity;
		}else{
			if (SpeedX1>0.0f) SpeedX1-=SpeedSensitivity;
		}
		if (Input.GetKey(KeyCode.A) ) {
			SpeedX2+=SpeedSensitivity;
		}else{
			if (SpeedX2>0.0f) SpeedX2-=SpeedSensitivity;
		}
		moveVector.x += moveSensitivity+SpeedX1;
		moveVector.x -= moveSensitivity+SpeedX2;
		if (SpeedX1<SpeedSensitivity && SpeedX1>-SpeedSensitivity) SpeedX1=0.0f;
		if (SpeedX2<SpeedSensitivity && SpeedX2>-SpeedSensitivity) SpeedX2=0.0f;
		
        
		// forward and backward
		if (Input.GetKey(KeyCode.W) ) {
			SpeedZ1+=SpeedSensitivity;
		}else{
			if (SpeedZ1>0.0f) SpeedZ1-=SpeedSensitivity;
		}
		if (Input.GetKey(KeyCode.S) ) {
			SpeedZ2+=SpeedSensitivity;
		}else{
			if (SpeedZ2>0.0f) SpeedZ2-=SpeedSensitivity;
		}
		moveVector.z += moveSensitivity+SpeedZ1;
		moveVector.z -= moveSensitivity+SpeedZ2;
		if (SpeedZ1<SpeedSensitivity && SpeedZ1>-SpeedSensitivity) SpeedZ1=0.0f;
		if (SpeedZ2<SpeedSensitivity && SpeedZ2>-SpeedSensitivity) SpeedZ2=0.0f;
		
		//up and down
		if (Input.GetKey(KeyCode.E) ) {
			SpeedY1+=SpeedSensitivity;
		}else{
			if (SpeedY1>0.0f) SpeedY1-=SpeedSensitivity;
		}
		if (Input.GetKey(KeyCode.Q) ) {
			SpeedY2+=SpeedSensitivity;
		}else{
			if (SpeedY2>0.0f) SpeedY2-=SpeedSensitivity;
		}
		moveVector.y += moveSensitivity+SpeedY1;
		moveVector.y -= moveSensitivity+SpeedY2;
		if (SpeedY1<SpeedSensitivity && SpeedY1>-SpeedSensitivity) SpeedY1=0.0f;
		if (SpeedY2<SpeedSensitivity && SpeedY2>-SpeedSensitivity) SpeedY2=0.0f;
		
		if (Input.GetAxis("Mouse ScrollWheel") != 0) moveVector.z += Input.GetAxis("Mouse ScrollWheel");
		//if (Input.GetKey(KeyCode.E)) moveVector.y += moveSensitivity;
		//if (Input.GetKey(KeyCode.Q)) moveVector.y -= moveSensitivity;
        transform.localPosition += transform.TransformDirection( moveVector );
		//Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
}