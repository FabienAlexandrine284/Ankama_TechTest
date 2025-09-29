using UnityEngine;

public class WaterDetection : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_rippleVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            m_rippleVFX.transform.position = other.transform.position;
            m_rippleVFX.Play();

            Destroy(other.attachedRigidbody.gameObject);
        }
    }
}
