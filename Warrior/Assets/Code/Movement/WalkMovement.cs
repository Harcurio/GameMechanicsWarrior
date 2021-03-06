using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkMovement : MonoBehaviour
{
    public static int playerPoints = 0;

    [SerializeField]
    public float knockbackStrength;

    [SerializeField]
    public float knockBackLength;

    [SerializeField]
    public float walkSpeed = 50;

    [SerializeField]
    LayerMask layerMask;

    public delegate void OnPlayerAttackKnockback(GameObject enemy);
    public static event OnPlayerAttackKnockback onPlayerAttackKnockback;

    public float knockbackTimeCount { get; set; }

    public bool knockFromRight { get; set; }

    public float desiredWalkDirection { get; set; }

    Rigidbody2D myBody;
    CrouchMovement crouchMovement;
    SpriteRenderer spriteRenderer;
    Color startColor;
    FloorDetector floorDetector;
    Animator animator;

    public bool knockbackFinished { get; set; }

    protected void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        crouchMovement = GetComponent<CrouchMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        floorDetector = GetComponent<FloorDetector>();
        animator = GetComponent<Animator>();
    }

    protected void Start()
    {
        

        startColor = spriteRenderer.color;
        knockbackFinished = true;
    }

    protected void FixedUpdate()
    {
       // Debug.Log("corre la clase walkmovement fixedupdate");
        float desiredXVelocity;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Attack+Up"))
        {
            desiredXVelocity = desiredWalkDirection * walkSpeed * 0.2f * Time.fixedDeltaTime;
        }
        else
        {
            desiredXVelocity = desiredWalkDirection * walkSpeed * Time.fixedDeltaTime;
        }

        // TODO it in cooroutine
        if (knockbackTimeCount <= 0)
        {
            myBody.velocity = new Vector2(desiredXVelocity, myBody.velocity.y);
            spriteRenderer.color = startColor;
            knockbackFinished = true;
        }
        else
        {
            if (knockFromRight)
            {
                myBody.velocity = new Vector2(-knockbackStrength, knockbackStrength / 3);
                spriteRenderer.color = new Color(1, 0, 0);
            }
            if (!knockFromRight)
            {
                myBody.velocity = new Vector2(knockbackStrength, knockbackStrength / 3);
                spriteRenderer.color = new Color(1, 0, 0);
            }
            knockbackTimeCount -= Time.deltaTime;
        }
    }

    public void Knockback(GameObject enemy)
    {
        knockbackFinished = false;
        knockbackTimeCount = knockBackLength;

        // Can appear some problem with "enemy.transform.parent.position.x", keep that in mind
        float enemyPos;
        if (enemy.transform.parent != null)
        {
            enemyPos = enemy.transform.parent.position.x;
        }
        else
        {
            enemyPos = enemy.transform.position.x;
        }

        if (transform.position.x < enemyPos)
        {
            knockFromRight = true;
        }
        else
        {
            knockFromRight = false;
        }
        HealthManager.onPlayerHurtKnockback -= Knockback;
    }

    public int GetKnockbackDirection()
    {
        return knockFromRight ? -1 : 1;
    }
}
