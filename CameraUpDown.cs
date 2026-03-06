using UnityEngine;

public class CameraUpDown : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float turnSpeed = 5.0f;
    public float minLook = -90f;
    public float maxLook = 90f;
    private float lookUpDown = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        lookUpDown -= mouseY;
        lookUpDown = Mathf.Clamp(lookUpDown, minLook, maxLook);
        transform.localRotation = Quaternion.Euler(lookUpDown, 0.0f, 0.0f);
        

    }
}
