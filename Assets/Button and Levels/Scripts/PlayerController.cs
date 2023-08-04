using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Add camera")]
    public GameObject _camera;
    [Header("Camera movement speed")]
    public float moveSpeed;
    [Header("Mouse sensitivity")]
    public float mouseSensitivity;
    private float mouseX;
    private float mouseY;

    private void Update()
    {
        GetInput();
    }
    private void GetInput() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.localPosition += transform.forward * moveSpeed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            transform.localPosition -= transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
           
            transform.Rotate(mouseX * Time.deltaTime * new Vector3(0, 1, 0));
            _camera.transform.Rotate(mouseY * Time.deltaTime * new Vector3(-1,0,0)); 
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

}
