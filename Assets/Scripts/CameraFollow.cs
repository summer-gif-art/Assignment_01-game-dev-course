using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The object the camera should follow (Player)
    public Transform target;

    // How fast the camera moves towards the target
    public float smoothSpeed = 10f;

    // Offset so the camera stays a bit behind on Z
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    private void LateUpdate()
    {
        // If there is no target, do nothing
        if (target == null)
            return;

        // Desired position = player position + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
