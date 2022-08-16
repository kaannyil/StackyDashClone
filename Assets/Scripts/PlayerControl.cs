using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    Animator animator;

    [SerializeField] private GameObject dashesParent, prevDash;
    [SerializeField] private float speedTime,pathTime;
    [SerializeField] private Transform target, myPosition, yPosition, finalPoint;
    [SerializeField] private Vector3[] wayPoints;

    public static PlayerControl instance;

    RaycastHit hit;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()  // Character X and Z Axis Movement
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(-.5f, 0f, 0f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnComplete(animationFinish);
            }

        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(.5f, 0f, 0f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnComplete(animationFinish);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(0f, 0f, .5f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnComplete(animationFinish);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(0f, 0f, -.5f);
                myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnComplete(animationFinish);
            }
        }
    }
    public void takeDashes(GameObject dash) // Dash and Character Y Axis Movement
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;
        Vector3 characterPos = yPosition.transform.localPosition;
        characterPos.y += 0.047f;
        yPosition.transform.localPosition = characterPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }


    #region Animations
    private void animationStart()
    {
        animator.SetBool("isRunning", true);

    }

    private void animationFinish()
    {
        if (hit.collider.gameObject.CompareTag("Path")) // Path Movement and Animation
        {
            animator.SetBool("isRunning", false);

            myPosition.transform.DOPath(wayPoints, pathTime, PathType.CatmullRom).SetSpeedBased(true).SetEase(Ease.Linear).SetLookAt(0.05f)
            .SetOptions(false, AxisConstraint.None, AxisConstraint.X)
            .OnStart(() => animator.SetBool("isFlying", true)).OnComplete(() => animator.SetBool("isFlying", false));
        }

        else if (hit.collider.gameObject.CompareTag("FinalPoint"))   // Final Movement and Animation
        {
            myPosition.transform.DOMove(finalPoint.transform.position - new Vector3(0,0,1), speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
            .OnStart(() => animator.SetBool("isRunning", true)).OnComplete(() => animator.SetBool("isRunning", false));
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    #endregion


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

            /*rb.velocity = Vector3.left * speed;*//*
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
