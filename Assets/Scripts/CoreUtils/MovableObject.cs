using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable
{
    public void Move(Vector2 dir, float target_speed);
    public void Stop();
}

public abstract class MovableObject : MonoBehaviour, IMovable
{
    private InGameManager gm;

    public MovementSettings movementSettings;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public float speed;
    [HideInInspector] public Vector2 pos;
    Vector2 direction;

    PhotonView photonView;

    protected virtual void Start()
    {
        gm = GameObject.FindObjectOfType<InGameManager>();
        if (gm == null)
        {
            Debug.LogError("GM is missing!");
        }

        photonView = GetComponent<PhotonView>();
        if (photonView == null)
        {
            Debug.LogError("PhotonView component is missing!");
        }
    }

    public virtual void Move(Vector2 dir, float target_speed)
    {
        if (dir == Vector2.zero)
        {
            Stop();
            return;
        }

        direction = dir;
        speed = Mathf.Clamp(target_speed, 0, movementSettings.MAX_SPEED);
        isMoving = true;
    }

    public virtual void Stop()
    {
        speed = 0;
        direction = Vector2.zero;
        isMoving = false;
    }

    protected virtual void Update()
    {
        // Ensure Control Authority
        if (!photonView.IsMine) return;
        if (direction == Vector2.zero) return;

        pos = transform.position;

        // stop for boundary
        if ((pos.x <= movementSettings.MIN_MAP_X && direction.x < 0.0f)
            || (pos.x >= movementSettings.MAX_MAP_X && direction.x > 0.0f))
        {
            direction.x = 0.0f;
        }
        if ((pos.y <= movementSettings.MIN_MAP_Y && direction.y < 0.0f)
            || (pos.y >= movementSettings.MAX_MAP_Y && direction.y > 0.0f))
        {
            direction.y = 0.0f;
        }

        // normalize
        if (direction.magnitude > 1.0f)
        {
            direction = direction.normalized;
        }

        // move
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
