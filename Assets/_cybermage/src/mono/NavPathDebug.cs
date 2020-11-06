using System;
using UnityEngine;
using UnityEngine.AI;

namespace Cybermage.Common
{
    public class NavPathDebug : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private NavMeshAgent _navMeshAgent;

        
        private void Awake()
        {
            _lineRenderer = gameObject.AddComponent<LineRenderer>();
            _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(_navMeshAgent == null)
                return;

            if (_navMeshAgent.hasPath)
            {
                _lineRenderer.positionCount = _navMeshAgent.path.corners.Length;
                _lineRenderer.SetPositions(_navMeshAgent.path.corners);
                _lineRenderer.enabled = true;
            }
            else
            {
                _lineRenderer.enabled = false;
            }
            
        }
    }
}