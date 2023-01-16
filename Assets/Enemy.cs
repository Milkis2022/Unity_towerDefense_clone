using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int             wayPointCount;
    private int             currentIndex = 0;
    private Transform[]     wayPoints;
    private Movement2D      movement2D;

    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // �� �̵� ��� WayPoints ���� ����.
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //���� ��ġ�� ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // ���� �̵� ���� ����
        NextMoveTo();

        while (true)
        {
            // �� ������Ʈ ȸ��
            transform.Rotate(Vector3.forward * 10);

            //���� ���� ��ġ�� �Ǥ�ǥ��ġ�� �Ÿ��� 0.02* movement���� ���� �� if����
            // movement2D.MoveSpeed�� �����ִ� ������ �ӵ��� ������ �� �����ӿ�
            // 0.02���� ũ�� �����̱� ������ ���ǹ��� �ɸ��� �ʰ� ��θ� ��Ż�ϴ�
            //������Ʈ�� �߻��� �� �ִ�.
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {   
                // ���� �̵� ���� ����
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // ���� �̵��� wayPoints�� �����ִٸ�
        if(currentIndex < wayPointCount - 1)
        {
            // ���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
            transform.position = wayPoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // ���� ��ġ�� ������ wayPoint���
        else
        {   
            //�� ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
