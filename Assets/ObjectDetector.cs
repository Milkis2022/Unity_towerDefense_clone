using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera      mainCamera;
    private Ray         ray;
    private RaycastHit  hit;

    private void Awake()
    {   
        // MainCamera �±׸� ������ �ִ� ������Ʈ�� Ž�� �� Camera ������Ʈ ���� ����
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {   
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ���� ��ġ(ī�޶� ��ġ)
            // ray.direction: ������ �������
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // ������ �ε����� ������Ʈ�� �����Ͽ� hit�� ����
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {   
                // ������ �ε��� ������Ʈ�� �±װ� "Tile"�̶��
                if (hit.transform.CompareTag("Tile"))
                {   
                    // Ÿ�� ����
                    towerSpawner.SpawnTower(hit.transform);
                }
            }
        }
    }
}