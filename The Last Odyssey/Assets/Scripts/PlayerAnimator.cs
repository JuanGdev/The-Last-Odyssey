using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerGrounded += SetGroundTouchedTrue;
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerGrounded -= SetGroundTouchedTrue;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Jumping", playerController.jumping);
        animator.SetFloat("XZSpeedMagnitude", XZSpeedMagnitude());
    }

    float XZSpeedMagnitude()
    {
        Vector2 XZVector = new(playerController.inputDirection.x, playerController.inputDirection.z);
        return XZVector.magnitude;
    }

    void SetGroundTouchedTrue() => StartCoroutine(SetGroundTouchedTrue_());

    IEnumerator SetGroundTouchedTrue_()
    {
        animator.SetBool("GroundTouched", true);
        yield return null;
        animator.SetBool("GroundTouched", false);
    }
}
