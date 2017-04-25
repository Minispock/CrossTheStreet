using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    private PlayerController playerController;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.isDead)
        {
            anim.SetBool("dead", true);
        }

        if (playerController.isJump || playerController.isMove)
        {
            anim.SetBool("jump", true);
        }

        else
        {
            anim.SetBool("jump", false);

        }
    }
}
