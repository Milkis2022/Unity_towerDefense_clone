using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{   
    // 타워가 건설되어 있는지 확인
    public bool IsBuildTower { set; get; }

    private void Awake()
    {
        IsBuildTower = false;
    }
}
