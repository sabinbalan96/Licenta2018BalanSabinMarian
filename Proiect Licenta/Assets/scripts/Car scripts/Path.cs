using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{ //adaptare dupa tutorialele video realizate de EYEmaginary
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    Vector3 currentNode= Vector3.zero;
    Vector3 previousNode = Vector3.zero;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i=0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
                nodes.Add(pathTransforms[i]);
        }

        for(int i=0; i<nodes.Count; i++)
        {
            currentNode = nodes[i].position;
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
                Gizmos.DrawLine(previousNode, currentNode);
            }
            Gizmos.DrawWireSphere(currentNode, 0.3f);
        }

    }

}