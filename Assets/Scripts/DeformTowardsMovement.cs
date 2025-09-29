using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeformTowardsMovement : MonoBehaviour
{
    [Header("Squash&Stretch")]
    [SerializeField] private Vector2 m_minMaxStretchAmount;
    [SerializeField] private Transform m_spriteSizeHandler;
    [SerializeField] private float m_speedMultiplier = 0.0002f;

    private Vector3 m_velocity;
    private Vector3 m_previousPos;
    private bool m_isActive = false;

    private void Start()
    {
        m_isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSquashAndStretch();
    }

    private void FixedUpdate()
    {
        m_velocity = (transform.position - m_previousPos) / Time.fixedDeltaTime;
        m_previousPos = transform.position;
    }

    private void HandleSquashAndStretch()
    {
        float stretchAmount = Mathf.Abs(m_velocity.sqrMagnitude * m_speedMultiplier);
        float horizontalStretch = Mathf.Clamp(1 - stretchAmount, m_minMaxStretchAmount.x, m_minMaxStretchAmount.y);
        float verticalStretch = Mathf.Clamp(1 - stretchAmount, m_minMaxStretchAmount.x, m_minMaxStretchAmount.y);
        float depthStretch = Mathf.Clamp(1 + stretchAmount, m_minMaxStretchAmount.x, m_minMaxStretchAmount.y);

        Vector3 targetScale;
        if (m_isActive)
            targetScale = new Vector3(horizontalStretch, verticalStretch, depthStretch);
        else
            targetScale = Vector3.one;

        m_spriteSizeHandler.localScale = Vector3.MoveTowards(m_spriteSizeHandler.localScale, targetScale, Time.deltaTime * 15);
    }

    public void Activate(bool isActive)
    {
        m_isActive = isActive;

        if (!isActive)
            ResetValues();
    }

    private void ResetValues()
    {
        m_spriteSizeHandler.localPosition = Vector3.zero;
        m_spriteSizeHandler.localEulerAngles = Vector3.zero;
        m_spriteSizeHandler.localScale = Vector3.one;
    }
}
