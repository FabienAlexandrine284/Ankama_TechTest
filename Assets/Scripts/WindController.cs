using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public class WindController : MonoBehaviour
{
    void Update()
    {
        SetVector();
    }

    void SetVector()
    {
        Shader.SetGlobalVector("_WindDirection", transform.forward);
    }

    private void OnDrawGizmos()
    {
        Vector3 secondPos = transform.position + (transform.forward * 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.3f);
        Gizmos.DrawLine(transform.position, secondPos);
        Gizmos.DrawWireSphere(secondPos, 0.1f);

    }
}
