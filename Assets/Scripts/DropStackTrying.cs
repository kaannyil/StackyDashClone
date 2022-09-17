using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Sirenix.OdinInspector;
using DG.Tweening;

public class DropStackTrying : MonoBehaviour
{
    public float speed = 5;
    private float timer;
    private float timeInterval = 0.05f;
    bool goBool = false;
    private Rigidbody rb;
    public GameObject stack;
    private IDisposable stackDrop;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0.05f;

        // transform.DOMove(targetPosition.transform.position, speed).SetSpeedBased().SetEase(Ease.Linear);
    }
    private void FixedUpdate()
    {
        if (goBool)
        {
            rb.velocity = Vector3.forward * speed;

            timer += 0.01f;

            if (timer >= timeInterval)
            {
                timer = 0f;
                Instantiate(stack, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EdgeCollider"))
        {
            Debug.Log("Trigger !");
        }
    }

    [Button]
    private void go()
    {
        goBool = true;
    }
}
