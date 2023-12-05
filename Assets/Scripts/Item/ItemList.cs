using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    PowerUp,
    Bomb
}

 public abstract class ItemList : MonoBehaviour
{
    public string itemName;
    public ItemType type;
    public float maxSizeX = 2.8f; // ī�޶� ����
    public float maxSizeY = 5f; // ī�޶� ����
    public Rigidbody2D _rigidbody;

    public float speed = 10f; //�ӽ�
    public abstract void ItemEffect(); //�Ⱦ�
    public abstract void SpawnItem(); //�Ⱦ�

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        //Move();
    }

    /* �������� ����Ǹ� �����̰� �ϴºκ�
    protected void Move()
    {
        _rigidbody.AddForce(transform.forward * -speed, ForceMode2D.Force);
        if(this.transform.position.y <  -maxSizeY ) //�ϴ� ī�޶� ������ ����� ������ ���ư��� �ϴµ� �ٸ� �̵������ ���� �� ����
        {
            
        }else if(this.transform.position.x > maxSizeX || this.transform.position.x < -maxSizeX)
        {

        }
    }
    */
}
