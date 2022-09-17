using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Sirenix.OdinInspector;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> dashList = new List<GameObject>();
    [SerializeField] private GameObject dashesParent, prevDash, firstStack, finalTakeDash;

    [HideInInspector] [SerializeField] private AnimationController animationC;
    [HideInInspector] [SerializeField] private PathScript pathControl;
    [HideInInspector] [SerializeField] private LevelEndController levelEnd;
    [HideInInspector] [SerializeField] private Follower follower;
    [HideInInspector] [SerializeField] private StackScript stackScript;

    [HideInInspector] public float pathTime;

    public float speedTime;
    float counter,timer,timeInterval = 0.03f;
    [HideInInspector] public bool finalControl = false;

    GameObject finalDash;
    Rigidbody rb;

    public Transform target, yPosition;
    [HideInInspector] public Transform myPosition;

    [HideInInspector] public Vector3[] wayPoints;
    [HideInInspector] public Animator animator;

    public static PlayerControl instance;

    RaycastHit hit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()    // Animator Component
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        timer = 0.0f;

        // Observable.(100).Subscribe(_ => Debug.Log("100 frame"));
    }
    void FixedUpdate()
    {
        if (finalControl == true)
        {
            // Debug.Log("Fixed Girdi");
            rb.velocity = Vector3.forward * speedTime * 0.8f;
            timer += 0.01f;

            if (timer >= timeInterval)
            {
                if (dashList.Count > 0)
                {
                    timer = 0.0f;

                    finalDash = dashList[dashList.Count - 1];
                    dashList[dashList.Count - 1].transform.SetParent(finalTakeDash.transform);

                    Vector3 yPositionZero = dashList[dashList.Count - 1].transform.localPosition;
                    yPositionZero.y = 0.506f;
                    dashList[dashList.Count - 1].transform.localPosition = yPositionZero;

                    dashList.Remove(finalDash);
                    // Debug.Log("Final Dash al�nd�.");
                }
                else
                {
                    rb.velocity = Vector3.zero;
                    animationC.runAnimationFinish(animator);
                }
            }
        }
    }

    void Update()  // Character X and Z Axis Movement
    {
        follower.PathTravelled();

        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                target.transform.position = hit.point - new Vector3(-.5f, 0f, 0f);
                transform.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnUpdate(() =>
                {
                    /*if (stackScript.stackTriggerControl == true)
                    {
                        Debug.Log("Stack al�nd�.");
                        DOTween.KillAll(true);

                        *//*Vector3 newTargetPos = target.transform.position;
                        newTargetPos.y += 0.047f;
                        target.transform.position = newTargetPos;
                        myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);*//*
                    }*/
                }).OnComplete(animationFinish);
            }

        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(.5f, 0f, 0f);
                transform.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnUpdate(() =>
                {
                    /*if (stackScript.stackTriggerControl == true)
                    {
                        Debug.Log("Stack al�nd�.");
                        DOTween.KillAll(true);

                        *//*Vector3 newTargetPos = target.transform.position;
                        newTargetPos.y += 0.047f;
                        target.transform.position = newTargetPos;
                        myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);*//*
                    }*/
                }).OnComplete(animationFinish);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(0f, 0f, .5f);
                transform.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnUpdate(() =>
                {
                    /*if (stackScript.stackTriggerControl == true)
                    {
                        Debug.Log("Stack al�nd�.");
                        DOTween.KillAll(true);

                        *//*Vector3 newTargetPos = target.transform.position;
                        newTargetPos.y += 0.047f;
                        target.transform.position = newTargetPos;
                        myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);*//*
                    }*/
                }).OnComplete(animationFinish);
            }   
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                target.transform.position = hit.point - new Vector3(0f, 0f, -.5f);
                transform.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
                .OnStart(animationStart).OnUpdate(() =>
                {
                    /*if (stackScript.stackTriggerControl == true)
                    {
                        Debug.Log("Stack al�nd�.");
                        DOTween.KillAll();

                        *//*Vector3 newTargetPos = target.transform.position;
                        newTargetPos.y += 0.047f;
                        target.transform.position = newTargetPos;
                        myPosition.DOMove(target.transform.position, speedTime).SetSpeedBased(true).SetEase(Ease.Linear);*//*
                    }*/
                }).OnComplete(animationFinish);
            }
        }
    }
    public void takeDashes(GameObject dash) // Dash and Character Y Axis Movement
    {
        dash.transform.SetParent(dashesParent.transform);
        dashList.Add(dash);
        counter = dashList.Count;
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;
        Vector3 characterPos = yPosition.transform.position;
        characterPos.y += 0.047f;
        yPosition.transform.position = characterPos;
        prevDash = dash;
        // prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }


    #region Animations
    private void animationStart()
    {
        animationC.runAnimationStart(animator);
    }   // Run

    private void animationFinish()
    {
        if (hit.collider.gameObject.CompareTag("Path")) // Path Movement and Animation
        {
            follower.distanceTravelledBool = true;
            animationC.runAnimationFinish(animator);
            animationC.flyAnimationStart(animator);
            // pathControl.pathDraw(myPosition,wayPoints,pathTime,animator,animationC);
        }

        else if (hit.collider.gameObject.CompareTag("Path2")) // Path Movement and Animation
        {
            follower.distanceTravelledBoolBack = true;
            animationC.runAnimationFinish(animator);
            animationC.flyAnimationStart(animator);
            // pathControl.pathDraw(myPosition,wayPoints,pathTime,animator,animationC);
        }

        else if (hit.collider.gameObject.CompareTag("FinalPoint"))   // Final Movement and Animation
        {
            // levelEnd.levelEndControl(myPosition, yPosition, hit, counter, speedTime, animationC, animator,dashList,finalTakeDash;
            // hit.collider.gameObject.SetActive(false);
            finalControl = true;

            /*for (int i = 0; i < dashList.Count-1; i++)
            {
                dashList[i].GetComponent<BoxCollider>().isTrigger = true;
            }*/

            yPosition.DOLocalMoveY(0f, speedTime * 0.04f).SetSpeedBased().SetEase(Ease.Linear);
        }
        else
        {
            animationC.runAnimationFinish(animator);
        }
    }   // Path and Final Point
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EdgeCollider") 
        {
            other.gameObject.SetActive(false);

            animationC.runAnimationFinish(animator);
            animationC.flyAnimationFinish(animator);
            StartCoroutine(halfsecond());
        }
    }
    IEnumerator halfsecond()
    {
        yield return new WaitForSeconds(.2f);
        follower.distanceTravelledBool = false;
        follower.distanceTravelledBoolBack = false;
    }

    [Button]
    private void vectorTrying()
    {
        rb.velocity = Vector3.forward * speedTime;
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
