using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Joystick;
    [HideInInspector] public bool isMovingKeyDown;

    Player player;
    Joystick joystick;

    private void Start()
    {
        player = Player.GetComponent<Player>();
        // joystick = Joystick.GetComponent<Joystick>();
    }

    void Update()
    {
        Vector2 dir = new Vector2(0.0f, 0.0f);
        isMovingKeyDown = false;

        // get joystick input
        if (joystick != null && joystick.isJoystickMoving)
        {
            dir = joystick.dir;
            isMovingKeyDown = true;
        }

        // get moving key
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x -= 1.0f;
            isMovingKeyDown = true;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            dir.x += 1.0f;
            isMovingKeyDown = true;
        }
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            dir.y += 1.0f;
            isMovingKeyDown = true;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            dir.y -= 1.0f;
            isMovingKeyDown = true;
        }

        // control player
        if (player != null)
        {
            if (isMovingKeyDown)
            {
                player.Move(dir, 5.0f);
            }
            else if (player.isMoving)
            {
                player.Stop();
            }

            // change color if enter pressed
            if (Input.GetKeyDown(KeyCode.Return))
            {
                player.ChangeColor();
            }
        }
    }
}
