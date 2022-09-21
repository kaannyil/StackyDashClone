using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using System;

public class LevelEndController : MonoBehaviour
{
    private GameObject finalDash;
    PlayerControl playerControl;
    

    public void levelEndControl(Transform myPosition,Transform yPosition, RaycastHit hit, float counter, float speedTime, AnimationController animationC, Animator animator, List<GameObject> dashList, GameObject finalTakeDash)
    {
        // leaveStack(dashList, finalTakeDash);
        // StartCoroutine(finalDashWait(dashList, finalTakeDash));
        // finalDashUniRX(dashList, finalTakeDash);

        // yPosition.DOLocalMove(Vector3.zero,  .45f).SetSpeedBased(true);

        myPosition.transform.DOMove((new Vector3(myPosition.transform.position.x,0,hit.point.z)) + (new Vector3(0, 0, counter + 3)), speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            animationC.runAnimationFinish(animator);
            Debug.Log(myPosition.transform.localPosition);
        });
    }

    IEnumerator finalDashWait(List<GameObject> dashList, GameObject finalTakeDash)
    {
        while (true)
        {
            if (dashList.Count > 0)
            {
                yield return new WaitForSeconds(.05f);
                // yield return Observable.Timer(System.TimeSpan.FromSeconds(.1)).ToYieldInstruction();

                finalDash = dashList[dashList.Count - 1];
                dashList[dashList.Count - 1].transform.SetParent(finalTakeDash.transform);
                dashList.Remove(finalDash);
                Debug.Log("FinalDash alýndý.");
            }
            else
            {
                break;
            }
        }
    }   // Final Dash Wait Second

    public void leaveStack(List<GameObject> dashList, GameObject finalTakeDash)
    {
        Observable.Interval(TimeSpan.FromSeconds(0.05f)).Subscribe(_ =>
        {
            if (dashList.Count > 0)
            {
                finalDash = dashList[dashList.Count - 1];
                finalDash.transform.SetParent(finalTakeDash.transform);
                Vector3 lastPosition = new Vector3(finalDash.transform.localPosition.x, 1, finalDash.transform.localPosition.z);
                finalDash.transform.localPosition = lastPosition;
                dashList.Remove(finalDash);
                Debug.Log("FinalDash alýndý.");
            }
        });
    }

    public void finalFixedControl(List<GameObject> dashList, GameObject finalTakeDash)
    {
        if (dashList.Count > 0)
        {
            playerControl.finalControl = true;

            finalDash = dashList[dashList.Count - 1];
            dashList[dashList.Count - 1].transform.SetParent(finalTakeDash.transform);
            dashList.Remove(finalDash);
            Debug.Log("FinalDash alýndý.");
        }
        else
        {
            playerControl.finalControl = false;
        }
    }

    /*private void finalDashUniRX(List<GameObject> dashList, GameObject finalTakeDash)
    {
        while (true)
        {
            if (dashList.Count > 0)
            {
                Observable.EveryEndOfFrame().Subscribe(_ =>
                {
                    finalDash = dashList[dashList.Count - 1];
                    dashList[dashList.Count - 1].transform.SetParent(finalTakeDash.transform);
                    dashList.Remove(finalDash);
                    Debug.Log("FinalDash alýndý.");
                });
            }
            else
            {
                break;
            }
        }
    }*/
}
