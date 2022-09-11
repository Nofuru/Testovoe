using UnityEngine;

public class MovingByTouch : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject building;

    private float _distanceFromBuilding = 10.0f;

    private float _rotationSpeed = 4f;

    private float XRotation = 0.0f;
    private float YRotation = 0.0f;

    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * _rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * _rotationSpeed;

        XRotation -= YaxisRotation;
        XRotation = Mathf.Clamp(XRotation, -1f, 90f);
        YRotation -= XaxisRotation;
        mainCamera.transform.rotation = Quaternion.Euler(XRotation, -YRotation, 0f);

        mainCamera.transform.position = building.transform.position - mainCamera.transform.forward * _distanceFromBuilding;
    }
}