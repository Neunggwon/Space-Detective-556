using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : ItemList
{
    // Start is called before the first frame update
    protected override void Start()
    {
        name = "Bomb";
        type = ItemType.Bomb;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void SpawnItem()
    {
        Instantiate(this, transform);
    }
   
    public override void ItemEffect()
    {
        //��ź ī��Ʈ �߰�(�÷��̾ �ִ�)
    }

    public void BombItemUse()
    {
        // ���ӸŴ������� ȣ��?
        // ��ü �� óġ?
        // ��źī��Ʈ �ϳ�����(�÷��̾����׼�)
    }
}
