using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManTweener : MonoBehaviour
{
    private Tween activeTween;
    public Animator animatorController;
    private Vector3 topLeft, topRight, bottomLeft, bottomRight;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        topRight = new Vector3(-3.5f, 4.5f, 0.0f);
        topLeft = new Vector3(-8.4f, 4.5f, 0.0f);
        bottomLeft = new Vector3(-8.4f, 0.5f, 0.0f);
        bottomRight = new Vector3(-3.5f, 0.5f, 0.0f);
        player.transform.position = topLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.Equals(topLeft))
        {
            AddTween(player.transform, player.transform.position, topRight, 1.5f);
            animatorController.SetBool("walkRight",true);
        }
        else if (player.transform.position.Equals(topRight))
        {
            AddTween(player.transform, player.transform.position, bottomRight, 1.2f);
            animatorController.SetBool("walkDown",true);
        }
        else if (player.transform.position.Equals(bottomRight))
        {
            AddTween(player.transform, player.transform.position, bottomLeft, 1.5f);
            animatorController.SetBool("walkLeft",true);
        }
        else if (player.transform.position.Equals(bottomLeft))
        {
            AddTween(player.transform, player.transform.position, topLeft, 1.2f);
            animatorController.SetBool("walkUp",true);
        }

        if (activeTween != null)
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            if (distance > 0.1f)
            {
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            if (distance <= 0.1f)
            {

                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
                animatorController.SetBool("walkRight", false);
                animatorController.SetBool("walkDown", false);
                animatorController.SetBool("walkLeft", false);
                animatorController.SetBool("walkUp", false);

            }
        }

    }
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
    }
}
