using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeColliderTrigger : MonoBehaviour
{
    [SerializeField] private GameObject otherEdge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            otherEdge.SetActive(true);
        }
    }
}
