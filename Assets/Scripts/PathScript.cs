using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    /*[SerializeField] private float pathTime;
    [SerializeField] private Vector3[] wayPoints;*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.DOPath(wayPoints, pathSpeed, PathType.CatmullRom).SetEase(Ease.Linear).SetLookAt(0.05f)
            .SetOptions(false, AxisConstraint.None, AxisConstraint.X);
        }
    }*/

   /* public void testPath(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Path"))
        {
            playerControl.myPosition.transform.DOPath(wayPoints, pathTime, PathType.CatmullRom).SetEase(Ease.Linear).SetLookAt(0.05f)
            .SetOptions(false, AxisConstraint.None, AxisConstraint.X);
        }
        else { }
    }*/
}
