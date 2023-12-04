using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemList
{
    public event Action EatPowerUpItem;
    protected override void Start()
    {
        name = "PowerUp";
        type = ItemType.PowerUp;
        _rigidbody = GetComponent<Rigidbody2D>();
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
    public void CallEatPowerUpItem()
    {
        EatPowerUpItem?.Invoke();
        //�÷��̾� ������ �ڵ� ��򰡿� �� �������� �Ծ����� ȣ���ϰ� ¥�ߴ� ���� ¥��
        // �浹ó�� �κ��� �Ϸ�Ǹ� ������ �ɵ�
    }
}
