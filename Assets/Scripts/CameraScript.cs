using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform John; // jugador
    public float smoothSpeed = 0.125f;
    public float fixedY = 0f;     // Y fijo
    public float fixedZ = -10f;   // Z fijo para 2D

    void LateUpdate()
    {
        if (John != null)
        {
            // Solo sigue en X
            Vector3 desiredPosition = new Vector3(John.position.x, fixedY, fixedZ);

            // Movimiento suave
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
