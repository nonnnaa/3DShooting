using UnityEngine;
using Cinemachine;
public class CamAndMouse : MonoBehaviour
{
    [SerializeField] float mouseSense = 1;
    float xAxis, yAxis;
    [SerializeField] Transform cameraFollowPos;


    [HideInInspector] CinemachineVirtualCamera vCam;
    public float currentFov;
    public float minFov = 20;
    public float maxFov = 30;
    public float zoomSpeed = 10;
    float lockMouse;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        currentFov = vCam.m_Lens.FieldOfView;
        lockMouse = 0f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            lockMouse++;
        }
        if(lockMouse > 1f)
        {
            lockMouse = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        xAxis += Input.GetAxis("Mouse X") * mouseSense;
        yAxis -= Input.GetAxis("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
        zoomCamera();
    }
    public void zoomCamera()
    {
        if (Input.GetMouseButton(1))
        {
            currentFov = minFov;
        }
        else
        {
            currentFov = maxFov;
        }
        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, zoomSpeed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        cameraFollowPos.localEulerAngles = new Vector3(yAxis, cameraFollowPos.localEulerAngles.y, cameraFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
}
