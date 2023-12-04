using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        EnemyA,
        EnemyB,
        EnemyC
    };

    public EnemyType enemyType;
    //Vector2 pos;
    //float delta = 2.0f;
    //public int stage;
    int damage;
    public float speed = 3.0f;
    public float enemyHp;

    public float shotDelay;
    public float maxShotDelay = 2f;

    private float moveDelay;
    private float maxMoveDelay = 2f;

    public Transform bulletPos;
    public GameObject bulletObj;

    public GameObject player;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Move();
    }

    void Update()
    {
        EnemyAttack();
    }

    private void Move()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                StartCoroutine(MovementA1());
                break;
            case EnemyType.EnemyB:
                StartCoroutine(MovementB1());
                break;
            case EnemyType.EnemyC:
                //MovementC();
                StartCoroutine(MovementC1());
                break;
        }
    }
    
    IEnumerator MovementA1()
    {
        int ranPointY = Random.Range(1, 5);
        int ranPointX = Random.Range(-2, 3);
        Vector2 ranVec = new Vector2(ranPointX, ranPointY);
        transform.DOMove(ranVec, 2);
        yield return null;
    }

    IEnumerator MovementB1()
    {
        while (true)
        {
            float ranPointY = Random.Range(1f, 5f);
            float ranPointX = Random.Range(-2.2f, 2.2f);
            //Vector2 pos = new Vector2(ranPointX, ranPointY);
            Vector2 randomPosition = new Vector2(ranPointX, ranPointY);

            while (Vector2.Distance(transform.position, randomPosition) > 0.1f)
            {
                transform.DOMove(randomPosition, 3);
                //transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(maxMoveDelay);
        }
    }
    

    IEnumerator MovementC1()
    {
        //int ranPointX = Random.Range(-2, 3);
        float ranPointY = Random.Range(0f, 3f);
        Vector2 randomPosition = new Vector2(transform.position.x, ranPointY);
        transform.DOMove(randomPosition, 7);

        yield return null;
    }
    private void EnemyAttack()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                AttackA();
                break;
            case EnemyType.EnemyB:
                AttackB();
                break;
            case EnemyType.EnemyC:
                AttackC();
                break;
        }
    }
    void AttackA()
    {
        shotDelay += Time.deltaTime;
        if (shotDelay >= maxShotDelay)
        {
            GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
            Rigidbody2D bulletRigidbody = instantBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletPos.forward * 2;
            bulletRigidbody.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
            maxShotDelay = Random.Range(3f, 5f);
            shotDelay = 0;
        }
    }

    
    void AttackB()
    {
        maxShotDelay = 2f;
        shotDelay += Time.deltaTime;
        if (shotDelay >= maxShotDelay)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
                instantBullet.transform.position = transform.position;
                Vector2 bulletDir = Vector2.down;
                bulletDir.x -= 0.3f;
                bulletDir.x += 0.3f * i;
                instantBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * 10, ForceMode2D.Impulse);
            }
            shotDelay = 0;
            maxShotDelay = Random.Range(3f, 4f);
        }
    }

    void AttackC()
    {
        maxShotDelay = 2f;
        shotDelay += Time.deltaTime;

        //Bullet ��ȯ
        if (shotDelay >= maxShotDelay)
        {

            GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
            Rigidbody2D bulletRigidbody = instantBullet.GetComponent<Rigidbody2D>();
            //bulletRigidbody.velocity = bulletPos.forward * 2;
            bulletRigidbody.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

            //GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
            //instantBullet.transform.position = transform.position;
            ////Vector2 bulletDir = player.transform.position - transform.position;

            //instantBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * 10, ForceMode2D.Impulse);
            shotDelay = 0;
            maxShotDelay = Random.Range(3f, 4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Bullet Hit!");
            StartCoroutine(OnDamage());
            //Destroy(other.gameObject);
        }
    }


    IEnumerator OnDamage()
    {
        Debug.Log("OnDamage");
        //enemyHp -= playerAttackDamage;
        //MyMaterial.color = Color.red;
        if (enemyHp > 0)
        {
            //Enemy Hit anim
            //MyMaterial.color = new Color(1,1,1);
        }

        if (enemyHp <= 0)
        {
            //Enemy �״� anim
            Disappearing();
        }
        yield return new WaitForSeconds(0.2f);
    }

    void Disappearing()
    {
        Debug.Log("Disappearing");
        Destroy(this.gameObject);
    }
}
