using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerDeathEffect;
    public Vector2 movement;
    Vector2 OldMovement;
    private float horizontalRight = 0, horizontalLeft = 0, verticalUp = 0, verticalDown = 0;
    public GameObject bullet;
    public float timeBetweenShots = 0.1f;
    float timer;
    public float maxSpeed = 10;
    float speed = 0;
    public float turnAmount = 20;
    public float speedIncrease = 25;
    Rigidbody2D rb;
    Camera mainCam;
    public SpriteRenderer sRenderer;
    bool isWrappingX = false;
    public Animator canvasAnim;
    bool startedGame = false;
    public GameObject boss1Summon;

    // Start is called before the first frame update
    void Start()
    {
        if (sRenderer == null)
        {
            sRenderer = GetComponent<SpriteRenderer>();
        }
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (timer >= timeBetweenShots)
            {
                GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
                RegularEnemyBulletScript bulletScript = bul.GetComponent<RegularEnemyBulletScript>();
                bulletScript.SetMoveDirection(new Vector2(0, 1), 90 + transform.eulerAngles.z);

                timer = 0;
            }
        }
    }

    public void killPlayer()
    {
        canvasAnim.Play("Restart");

        Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    void FixedUpdate()
    {
        if (Input.anyKeyDown && !startedGame)
        {
            startedGame = true;
            canvasAnim.Play("RemoveUI");
            Instantiate(boss1Summon);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //spriteRenderer.flipX = false;
            horizontalRight = 0.1f;
            OldMovement = movement;
        }
        else
        {
            horizontalRight = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //spriteRenderer.flipX = true;
            horizontalLeft = -0.1f;
            OldMovement = movement;
        }
        else
        {
            horizontalLeft = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //spriteRenderer.flipX = false;
            verticalUp = 0.1f;
            OldMovement = movement;
        }
        else
        {
            verticalUp = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //spriteRenderer.flipX = true;
            verticalDown = -0.1f;
            OldMovement = movement;
        }
        else
        {
            verticalDown = 0;
        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, -turnAmount, speedIncrease * 0.2f));
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, turnAmount, speedIncrease * 0.2f));
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, 0, speedIncrease * 0.4f));
        }

        if (movement != Vector2.zero)
        {
            speed = Mathf.Lerp(speed, maxSpeed, speedIncrease * 0.1f);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0, speedIncrease * 0.2f);
        }

        movement = new Vector2(horizontalRight + horizontalLeft, verticalUp + verticalDown);
        rb.MovePosition(rb.position + (OldMovement * speed * Time.fixedDeltaTime));

        ScreenWrap();
    }

    void ScreenWrap()
    {
        bool isVisible = sRenderer.isVisible;
        if (isVisible)
        {
            isWrappingX = false;
            //isWrappingY = false;
            return;
        }
        if (isWrappingX)
        {
            return;
        }
        var viewportPosition = mainCam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;
        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }
        //if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        //{
        //    newPosition.y = -newPosition.y;
        //    isWrappingY = true;
        //}
        transform.position = newPosition;
    }
}
