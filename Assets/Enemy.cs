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

        // 적 이동 경로 WayPoints 정보 설정.
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //적의 위치를 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // 다음 이동 방향 설정
        NextMoveTo();

        while (true)
        {
            // 적 오브젝트 회전
            transform.Rotate(Vector3.forward * 10);

            //적의 현재 위치왐 ㅗㄱ표위치의 거리가 0.02* movement보다 낮을 대 if실행
            // movement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면 한 프레임에
            // 0.02보다 크게 움직이기 떄문에 조건문에 걸리지 않고 경로를 이탈하는
            //오브젝트가 발생할 수 있다.
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {   
                // 다음 이동 방향 설정
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // 아직 이동할 wayPoints가 남아있다면
        if(currentIndex < wayPointCount - 1)
        {
            // 적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // 현재 위치가 마지막 wayPoint라면
        else
        {   
            //적 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
