using UnityEngine;

public class MouseRotate : RotateInput
{
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
        RotateEntity(mouseX);
        RotateCamera(mouseY);
    }
}