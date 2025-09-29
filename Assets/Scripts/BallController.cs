using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_ball;
    [SerializeField] private float m_acceleration = 5;
    [SerializeField] private float m_maxSpeed = 20;
    [SerializeField] private LayerMask m_hitLayers;

    private Vector3 m_hitPos;
    private bool m_isPressing = false;

    private void Update()
    {
        if (!m_ball) return;

        if (Input.GetMouseButtonDown(0))
        {
            m_ball.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_ball.AddForce(Vector3.down * 7, ForceMode.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            m_isPressing = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, m_hitLayers))
            {
                m_hitPos = hit.point;
            }
        }
        else
            m_isPressing = false;
    }


    private void FixedUpdate()
    {
        if (!m_ball) return;

        if (m_isPressing)
        {
            Vector3 dir = (m_hitPos - m_ball.transform.position).normalized;

            dir.y = 0;
            m_ball.AddForce(dir * m_acceleration, ForceMode.Acceleration);
            if (Vector3.Dot(dir, m_ball.linearVelocity.normalized) < 0.7f)
            {
                Vector3 currentVel = m_ball.linearVelocity;
                Vector3 newVel = m_ball.linearVelocity * 0.9f;
                m_ball.linearVelocity = new Vector3(newVel.x, currentVel.y, newVel.z);
            }
        }
        Vector3 clamped = Vector3.ClampMagnitude(m_ball.linearVelocity, m_maxSpeed);
        m_ball.linearVelocity = new Vector3(clamped.x, m_ball.linearVelocity.y, clamped.z);
    }
}
