using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemList
{
    public PowerUpItem()
    {
        name = "PowerUp";
        type = ItemType.PowerUp;
       
    }
    public override void SpawnItem()
    {
        Instantiate(this, transform);
    }
    public override void ItemEffect()
    {
        //�Ѿ��� ũ�⸦ Ű���(�ݶ��̴���)
        //��߻� ���ð��� ���̰�
        //���� �������� �ִٸ� �������� �ø���.
    }
}
