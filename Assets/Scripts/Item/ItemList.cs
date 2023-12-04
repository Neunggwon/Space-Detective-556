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
    public string name;
    public ItemType type;
    public float maxSizeX = 2.8f; // ī�޶� ����
    public float maxSizeY = 5f; // ī�޶� ����
    public Rigidbody _rigidbody;

    public float speed = 10f; //�ӽ�
    public abstract void ItemEffect();
    public abstract void SpawnItem();


    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        Move();       
    }

    protected void Move()
    {
        _rigidbody.AddForce(transform.forward*-speed,ForceMode.Force);
        if(this.transform.position.y <  -maxSizeY ) //�ϴ� ī�޶� ������ ����� ������ ���ư��� �ϴµ� �ٸ� �̵������ ���� �� ����
        {
            
        }else if(this.transform.position.x > maxSizeX || this.transform.position.x < -maxSizeX)
        {

        }

    }
}
