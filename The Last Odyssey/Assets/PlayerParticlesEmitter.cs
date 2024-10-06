using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticlesEmitter : MonoBehaviour
{
    ParticleSystem particle;
    PlayerController playerController;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        playerController = transform.parent.GetComponent<PlayerController>();
        characterController = transform.parent.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (XZSpeedMagnitude() > 0.1f && !playerController.jumping)
        {
            if (!particle.isPlaying) particle.Play();
        }
        else particle.Stop();
    }

    float XZSpeedMagnitude()
    {
        Vector2 XZVector = new(characterController.velocity.x, characterController.velocity.z);
        return XZVector.magnitude;
    }
}
