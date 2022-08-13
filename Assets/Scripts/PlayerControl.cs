using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject dashesParent, prevDash;
    [SerializeField] private float speedTime;
    [SerializeField] private Transform target, myPosition, yPosition;

    private Transform characterPos;

    public static PlayerControl instance;

    RaycastHit hit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        // transform.rotation = target.rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(-.5f, 0f, 0f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);
            }

            //*rb.velocity = Vector3.left * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(.5f, 0f, 0f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);
            }

            //*rb.velocity = Vector3.right * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(0f, 0f, .5f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);
            }

            //*rb.velocity = Vector3.forward * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(0f, 0f, -.5f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);
            }
            //*rb.velocity = -Vector3.forward * speed;*//*
        }
        //*Debug.Log(rb.velocity);*//*
    }
    public void takeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;
        Vector3 characterPos = yPosition.transform.position;
        characterPos.y += 0.047f;
        yPosition.transform.position = characterPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }




    /*Animator animator;

    [SerializeField] private GameObject dashesParent, prevDash;
    [SerializeField] private float speed, positionSpeed, rotationSpeed = 720;
    [SerializeField] private Transform target, targetPosition, playerMovement;

    public static PlayerControl instance;

    private Rigidbody rb;
    private bool isMoving;

    RaycastHit hit;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        // transform.rotation = target.rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving)
        {
            target.rotation = Quaternion.Euler(0, -90, 0);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), rotationSpeed * Time.deltaTime

            animator.SetBool("isRunning", true);
            isMoving = true;

            if (Physics.Raycast(target.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.position = hit.point;
                playerMovement.DOMove(target.position, 2);
                Debug.Log(hit.point);
            }

            *//*rb.velocity = Vector3.left * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving)
        {
            target.rotation = Quaternion.Euler(0, 90, 0);

            animator.SetBool("isRunning", true);
            isMoving = true;

            if (Physics.Raycast(target.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.position = hit.point;
                playerMovement.DOMove(target.position, 2);
                Debug.Log(hit.point);
            }

            *//*rb.velocity = Vector3.right * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving)
        {
            target.rotation = Quaternion.Euler(0, 0, 0);

            animator.SetBool("isRunning", true);
            isMoving = true;

            if (Physics.Raycast(target.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.position = hit.point;
                playerMovement.DOMove(target.position, 2);
                Debug.Log(hit.point);
            }

            *//*rb.velocity = Vector3.forward * speed;*//*
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving)
        {
            target.rotation = Quaternion.Euler(0, 180, 0);

            animator.SetBool("isRunning", true);
            isMoving = true;

            if (Physics.Raycast(target.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.position = hit.point;
                playerMovement.DOMove(target.position, 2).SetEase(Ease.Linear);
                Debug.Log(hit.point);
            }
            *//*rb.velocity = -Vector3.forward * speed;*//*
        }
        *//*Debug.Log(rb.velocity);*//*

        if (rb.velocity == Vector3.zero)
        {
            // Durduysak
            isMoving = false;
            animator.SetBool("isRunning", false);
        }
    }
    public void takeDashes(GameObject dash) {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;

        Vector3 characterPos = transform.localPosition;
        characterPos.y += 0.047f;
        transform.localPosition = characterPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }*/
}
