using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); 
    }

    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    // �� óġ�� ��������Ʈ �� ũ�⺰�� ����
    public void StartExplosion(string target)
    {
        anim.SetTrigger("OnExplosion");

        switch (target)
        {
            case "S":
                transform.localScale = Vector3.one * 0.7f;
                break;
            case "M":
            case "P":
                transform.localScale = Vector3.one * 1f;
                break;
            case "L":
                transform.localScale = Vector3.one * 2f;
                break;
            case "B":
                transform.localScale = Vector3.one * 3f;
                break;
        }

    }
}


//GameManager��ũ��Ʈ�� ����  �� ��ġ�� ���� �����ϴ� �Լ�
    
//public void CallExplosion(Vector3 pos, string type)
//{
//    GameObject explosion = objectManager.Makeobj("Explosion");
//    Explosion explosionLogic = explosion.GetComponent<Explosion>();

//    explosion.transform.position = pos;
//    explosionLogic.StartExplosion(type);
//}

//gameManager.CallExplosion(Transform.position, "P"); �÷��̾�� ���� �¾� �׾����� ��ġ���ٰ� ȣ���ؾߵ�
//gameManager.CallExplosion(Transform.position, enemyName);




