
/// This is a modified javascript conversion of the Standard Assets MouseLook script.
/// Also added is functionallity of using a key to look up, down, left and right in addition to the Mouse.
/// Everything is on by default. You will want to turn off/on stuff depending on what you're doing.
 
/// You can also modify the script to use the KeyLook functions to control an object's rotation.
/// Try using MouseXandY on an object. Actually it works as is but you'll want to clean it up ;)
 
/// As of this version the key and mouse fight if used at the same time (ie up key and down mouse jitters).
 
/// Minimum and Maximum values can be used to constrain the possible rotation
 
/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLookPlus script to the capsule.
///   -> Set the script's Axis to MouseX in the inspector. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule
 
/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add the MouseLookPlus script to the camera.
///   -> Set the script's Axis to MouseY in the inspector. (You want the camera to tilt up and down like a head. The character already turns.)
 
    enum Axes {MouseXandY, MouseX, MouseY}
    var Axis : Axes = Axes.MouseXandY;
 
    var sensitivityX = 5.0;
    var sensitivityY = 5.0;
 
    var minimumX = -360.0;
    var maximumX = 360.0;
 
    var minimumY = -360.0;
    var maximumY = 360.0;
 
    var rotationX = 1.0;
    var rotationY = 1.0;
 
    var lookSpeed = 1.0;

	var SpeedX = 0.05;
	var SpeedY = 0.05;
	
	var StepX = 0.5;
	var StepY = 0.5;

	var MaxSpeedX = 10;
	var MaxSpeedY = 10;

	private var wasClicked = false;

    var cameraReference : Camera;
    var Sun : Light;
 
    function Update ()
    {
	
	   if (Input.GetMouseButton(0)) 
	   {
				wasClicked = true;
		}
		else 
		{
			wasClicked = false;
			if (SpeedX<0.0)
			{
				SpeedX+=StepX*2;
			}
			if (SpeedX>0.0)
			{
				SpeedX-=StepX*2;
			}
			if (SpeedY<0.0)
			{
				SpeedY+=StepY*2;
			}
			if (SpeedY>0.0)
			{
				SpeedY-=StepY*2;
			}

	}
		
		
		if (wasClicked)
		{
      
				// Move toward and away from the camera
			if (Input.GetAxis("Vertical"))
			{
				var translationZ = Input.GetAxis("Vertical");
				transform.localPosition += (cameraReference.transform.localRotation * Vector3(0,0,translationZ)*SpeedY);				
				SpeedY+=StepY;
			}
		   
			// Strafe the camera
			if (Input.GetAxis("Horizontal"))
			{
				var translationX = Input.GetAxis("Horizontal");
				transform.localPosition += (cameraReference.transform.localRotation * Vector3(translationX,0,0)*SpeedX);				
				SpeedX+=StepX;

			}       	
		   
			if (Axis == Axes.MouseXandY)
			{
				// Read the mouse input axis
				rotationX += Mathf.Lerp(Input.GetAxis("Mouse X") ,Input.GetAxis("Mouse X") * sensitivityX,Time.deltaTime );
				rotationY += Mathf.Lerp(Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse Y") * sensitivityY,Time.deltaTime );
	 
				// Call our Adjust to 360 degrees and clamp function
				Adjust360andClamp();
	 
				// Most likely you wouldn't do this here unless you're controlling an object's rotation.
				// Call our look left and right function.
				KeyLookAround();
	 
				// Call our look up and down function.
				KeyLookUp();
			}
			else if (Axis == Axes.MouseX)
			{
				// Read the mouse input axis
				rotationX += Input.GetAxis("Mouse X") * sensitivityX/SpeedX;
	 
				// Call our Adjust to 360 degrees and clamp function
				Adjust360andClamp();
	 
				// if you're doing a standard X on object Y on camera control, you'll probably want to
				// delete the key control in MouseX. Also, take the transform out of the if statement.
				// Call our look left and right function.
				KeyLookAround();
	 
				// Call our look up and down function.
				KeyLookUp();
			}
			else
			{
				// Read the mouse input axis
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY/SpeedY;
		
				// Call our Adjust to 360 degrees and clamp function
				Adjust360andClamp();
	 
				// Call our look left and right function.
				KeyLookAround();
	 
				// Call our look up and down function.
				KeyLookUp();
				SpeedY+=StepY;			
			}
				// forward and backward

			if (SpeedX>MaxSpeedX) SpeedX=MaxSpeedX;
			if (SpeedY>MaxSpeedY) SpeedY=MaxSpeedY;
			if (SpeedX<-MaxSpeedX) SpeedX=-MaxSpeedX;
			if (SpeedY<-MaxSpeedY) SpeedY=-MaxSpeedY;
			if (transform.localPosition.y>2000) transform.localPosition.y=2000;
			if (transform.localPosition.y<100) transform.localPosition.y=100;
			
		}	
			if (Input.GetKey(KeyCode.Q) ) {
				rotationX -=0.5;
			}
			if (Input.GetKey(KeyCode.E) ) {
				rotationX +=0.5;
			}		
    }
 
    function KeyLookAround ()
    {
//      If you're not using it, you can delete this whole function.
//      Just be sure to delete where it's called in Update.
 
        // Call our Adjust to 360 degrees and clamp function
        Adjust360andClamp();
 
        // Transform our X angle
        transform.localRotation = Quaternion.AngleAxis (rotationX, Vector3.up);
    }
 
    function KeyLookUp ()
    {
        // Adjust for 360 degrees and clamp
        Adjust360andClamp();
 
        // Transform our Y angle, multiply so we don't loose our X transform
        transform.localRotation *= Quaternion.AngleAxis (rotationY, Vector3.left);
    }
 
    function Adjust360andClamp ()
    {
//      This prevents your rotation angle from going beyond 360 degrees and also
//      clamps the angle to the min and max values set in the Inspector.
 
        // During in-editor play, the Inspector won't show your angle properly due to
        // dealing with floating points. Uncomment this Debug line to see the angle in the console.
 
        // Debug.Log (rotationX);
 
        // Don't let our X go beyond 360 degrees + or -
        if (rotationX < -360)
        {
            rotationX += 360;
        }
        else if (rotationX > 360)
        {
            rotationX -= 360;
        }   
 
        // Don't let our Y go beyond 360 degrees + or -
        if (rotationY < -360)
        {
            rotationY += 360;
        }
        else if (rotationY > 360)
        {
            rotationY -= 360;
        }
 
        // Clamp our angles to the min and max set in the Inspector
        rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
    }
 
    function Start ()
    {
        // Make the rigid body not change rotation
        if (rigidbody)
        {
            rigidbody.freezeRotation = true;
        }
    }