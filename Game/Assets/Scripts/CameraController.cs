using UnityEngine;
using UnityEngine.EventSystems;
using Mapbox.Unity.Map;

public class CameraController : MonoBehaviour
// based on Mapbox CameraMovement
{
    [SerializeField] AbstractMap _map;

    [SerializeField] float _panSpeed = 20f;

    [SerializeField] float _zoomSpeed = 50f;

    [SerializeField] float _maxZoomIn = 10f;

    [SerializeField] float _maxZoomOut = 200f;

    [SerializeField] Camera _referenceCamera;

    Quaternion _originalRotation;
    Vector3 _origin;
    Vector3 _delta;
    bool _shouldDrag;

    void HandleTouch()
    {
        float zoomFactor = 0.0f;
        //pinch to zoom. 
        switch (Input.touchCount)
        {
            case 1:
            {
                HandleMouseAndKeyBoard();
            }
                break;
            case 2:
            {
                // Store both touches.
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                Vector2 prevDistanceVec = touchZeroPrevPos - touchOnePrevPos;
                Vector2 distanceVec = touchZero.position - touchOne.position;

                float prevTouchDeltaMag = (prevDistanceVec).magnitude;
                float touchDeltaMag = (distanceVec).magnitude;

                zoomFactor = 0.05f * (touchDeltaMag - prevTouchDeltaMag);

                // rotation
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = new Ray(transform.position, transform.forward);
                float enter = 0.0f;
                Vector3 hitPoint = transform.position;
                if (plane.Raycast(ray, out enter))
                {
                    hitPoint = ray.GetPoint(enter);
                }

                transform.RotateAround(hitPoint, Vector3.up,
                    Vector2.SignedAngle(distanceVec, prevDistanceVec));
            }
                ZoomMapUsingTouchOrMouse(zoomFactor);
                break;
            default:
                break;
        }
    }

    void ZoomMapUsingTouchOrMouse(float zoomFactor)
    {
        var y = zoomFactor * _zoomSpeed;
        var newPosition = transform.localPosition + (transform.forward * y);
        if (newPosition.y >= _maxZoomIn && newPosition.y <= _maxZoomOut)
        {
            transform.localPosition = newPosition;
        }
        // transform.localPosition += (transform.forward * y);
    }

    void HandleMouseAndKeyBoard()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = _referenceCamera.transform.localPosition.y;
            _delta = _referenceCamera.ScreenToWorldPoint(mousePosition) - _referenceCamera.transform.localPosition;
            _delta.y = 0f;
            if (_shouldDrag == false)
            {
                _shouldDrag = true;
                _origin = _referenceCamera.ScreenToWorldPoint(mousePosition);
            }
        }
        else
        {
            _shouldDrag = false;
        }

        if (_shouldDrag == true)
        {
            var offset = _origin - _delta;
            offset.y = transform.localPosition.y;
            transform.localPosition = offset;
        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var y = Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            if (!(Mathf.Approximately(x, 0) && Mathf.Approximately(y, 0) && Mathf.Approximately(z, 0)))
            {
                transform.localPosition += transform.forward * y +
                                           (_originalRotation * new Vector3(x * _panSpeed, 0, z * _panSpeed));
                _map.UpdateMap();
            }
        }
    }

    void Awake()
    {
        _originalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        if (_referenceCamera == null)
        {
            _referenceCamera = GetComponent<Camera>();
            if (_referenceCamera == null)
            {
                throw new System.Exception("You must have a reference camera assigned!");
            }
        }

        if (_map == null)
        {
            _map = FindObjectOfType<AbstractMap>();
            if (_map == null)
            {
                throw new System.Exception("You must have a reference map assigned!");
            }
        }
    }

    void LateUpdate()
    {
        if (Input.touchSupported && Input.touchCount > 0)
        {
            HandleTouch();
        }
        else
        {
            HandleMouseAndKeyBoard();
        }
    }
}