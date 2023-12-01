using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public float translationSpeed = 3.0f;
    public float zoomSpeed = 3.0f;

    public Transform hapticPen; // Assign the haptic pen in the inspector
    private Vector3 initialOffset; // Store the initial offset between the camera and the haptic pen


    void Start(){
        // Calculate the initial offset between the camera and the haptic pen
        initialOffset = transform.position - hapticPen.position;
    }



    void Update(){
        // Rotation with A and D keys around the point (0,y,0)
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Translation with W and S keys up and down 
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * translationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * translationSpeed * Time.deltaTime, Space.World);
        }


        // Zooming with Q and E keys and the z and c keys 
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.C))
        {
            // Adjust the camera's position to zoom in
            transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Z))
        {
            // Adjust the camera's position to zoom out
            transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime, Space.Self);
        }


        // to make sure the haptic pen also follows the camera 

        // Simple Method
        // Update the haptic pen's position and rotation based on the camera's changes
        // hapticPen.position = transform.position;
        // hapticPen.rotation = transform.rotation;

        // with offset
        // Update the haptic pen's position and rotation based on the initial offset
        //hapticPen.position = transform.position - initialOffset;
        //hapticPen.rotation = transform.rotation;

        // slighly more complex method
        // Update the haptic pen's position and rotation relative to the camera

        Vector3 cameraPos = transform.position;
        Vector3 relativePosition = new Vector3(0, cameraPos.y, 0);

        Quaternion relativeRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);


           // hapticPen.transform 
     
        // Vector3 relativePosition = transform.TransformPoint(Vector3.forward * 20); // Adjust the multiplier as needed


       // Quaternion relativeRotation = transform.rotation;
        hapticPen.position = relativePosition;
        hapticPen.rotation = relativeRotation;

    }
}

