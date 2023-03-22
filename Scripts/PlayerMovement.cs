
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Sprite SterSprite;
    public Sprite PoisonSprite;
    public Sprite DefSprite;


    private void Awake()
    {
        DataStoreMovement.Instance.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() || collision.GetComponent<Enemy1>())
        {
            DataStoreMovement.Instance.Health = 0.0f;
            SceneManager.LoadScene("Death");
        }
        if (collision.GetComponent<OxygenTank>())
        {
            DataStoreMovement.Instance.MoveSpeed = 2f;
            DataStoreMovement.Instance.HitOxygen = true;
            DataFunctions.Instance.OxygenAmount += 1;
            DataStoreMovement.Instance.spriteRenderer.sprite = DefSprite;
        }
        if (collision.GetComponent<QuestionMark>())
        {
            DataStoreMovement.Instance.Health += DataFunctions.RandomFloat(-0.3f, 0.5f);
            DataStoreMovement.Instance.Health = Math.Clamp(DataStoreMovement.Instance.Health, 0, 1);
        }
        if (collision.GetComponent<Ster>())
        {
            DataStoreMovement.Instance.MoveSpeed = 3f;
            DataStoreMovement.Instance.spriteRenderer.sprite = SterSprite;
        }
        if (collision.GetComponent<Poison>())
        {
            DataStoreMovement.Instance.MoveSpeed = 1.5f;
            DataStoreMovement.Instance.spriteRenderer.sprite = PoisonSprite;
        }
        if (collision.GetComponent<O2>())
        {
            DataStoreMovement.Instance.Health += 0.6f;
        }
    }
    void Update()
    {
        ProcessInputs();
        DataFunctions.Instance.win();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        DataStoreMovement.Instance.MoveDirection = new Vector2(MoveX, MoveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2
            (DataStoreMovement.Instance.MoveDirection.x * DataStoreMovement.Instance.MoveSpeed,
            DataStoreMovement.Instance.MoveDirection.y * DataStoreMovement.Instance.MoveSpeed);
    }
}
