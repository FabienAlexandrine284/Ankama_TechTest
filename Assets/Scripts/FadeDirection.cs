using UnityEngine;

public class FadeDirection : MonoBehaviour
{
    [SerializeField] private Vector3 m_worldPos;
    // Update is called once per frame
    void Update()
    {
        transform.forward = m_worldPos;
    }
}
