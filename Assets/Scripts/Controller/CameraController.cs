using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 _camera_Move_Vector = default;

    private void Update()
    {
        _camera_Move_Vector.x = Variables._three * Time.deltaTime;
        transform.position += (Vector3)_camera_Move_Vector;
    }
}
