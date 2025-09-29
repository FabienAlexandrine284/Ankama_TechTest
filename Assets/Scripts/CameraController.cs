using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera m_grassCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_grassCam)
        {
            Shader.SetGlobalVector("_CaptureLocation", m_grassCam.transform.position);
            Shader.SetGlobalFloat("_CaptureSize", m_grassCam.orthographicSize);
        }
    }
}
