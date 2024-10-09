using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEndCutscene : MonoBehaviour
{
    [SerializeField] float speed = 5;
    CinemachineVirtualCamera virtualCamera;
    public static event Action OnLevelEnded;
    bool cutsceneStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = transform.parent.parent.GetComponentInChildren<CinemachineVirtualCamera>();
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cutsceneStarted) return;

            cutsceneStarted = true;
            virtualCamera.LookAt = other.transform;
            virtualCamera.Priority = 11;
            other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<PlayerController>().enabled = false;
            ParticleSystem particleSystem = other.GetComponentInChildren<ParticleSystem>();
            if (!particleSystem.isPlaying) particleSystem.Play();
            StartCoroutine(MovePlayer(other.gameObject));
            StartCoroutine(RotatePlayer(other.gameObject));
        }
    }


    IEnumerator RotatePlayer(GameObject player)
    {
        float rotationSpeed = 0;
        float acceleration = 500f;
        while (true)
        {
            rotationSpeed += acceleration * Time.deltaTime;
            player.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MovePlayer(GameObject player)
    {
        Vector3 targetPosition = transform.position;
        Vector3 currentPosition = player.transform.position;
        float ratio = 0;
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, targetPosition);
            if (distance < 0.1f) break;

            float standardSpeed = speed / Vector3.Distance(currentPosition, targetPosition);
            ratio += Time.deltaTime * standardSpeed;
            Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, ratio);
            player.transform.position = newPosition;
            yield return null;
        }
        yield return new WaitForSeconds(2);

        float upVelocity = 40;
        float upAcceleration = 20;
        while (true)
        {
            upVelocity += upAcceleration * Time.deltaTime;
            player.transform.position += upVelocity * Time.deltaTime * Vector3.up;
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > 150)
            {
                OnLevelEnded();
                yield break;
            }
            yield return null;
        }
    }

    public static void TriggerLevelEndedEvent()
    {
        OnLevelEnded?.Invoke();
    }
}
