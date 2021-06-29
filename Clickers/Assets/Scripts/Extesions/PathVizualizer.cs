using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathVizualizer : MonoBehaviour
{
    [SerializeReference] private NavMeshAgent navigationAgent;
    [SerializeField] private Color gizmosColor;
    [SerializeField, Min(0)] private float pointsRadius = 0.1f;

    private void OnDrawGizmosSelected()
    {
        if (navigationAgent != null)
        {
            if (navigationAgent.path.corners.Length > 0)
            {
                var points = navigationAgent.path.corners;
                Gizmos.color = gizmosColor;
                Gizmos.DrawSphere(navigationAgent.transform.position, pointsRadius);
                Gizmos.DrawLine(navigationAgent.transform.position, points[0]);
                for (int i = 0; i < points.Length; i++)
                {
                    Gizmos.DrawSphere(points[i], pointsRadius);
                    if (i + 1 < points.Length)
                    {
                        Gizmos.DrawLine(points[i], points[i + 1]);
                    }
                }
            }
        }
    }
}
