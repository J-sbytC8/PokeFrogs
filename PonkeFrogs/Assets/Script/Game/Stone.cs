using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每个石头回挂载
/// </summary>
public class Stone : MonoBehaviour {

    /// <summary>
    /// 是否包含时钟
    /// </summary>
    public bool isHasColock = false;
    public bool isHasStone = false;

    /// <summary>
    /// 石头索引
    /// </summary>
    public int index = 0;

    public Vector3 buildPos = Vector3.zero;


	void Start () {
        if (isHasColock)
        {
            //设置位置 父对象
            GameObject clock = Instantiate( PrefabManager.Instance.GetPrefab("Clock"));
            clock.transform.position = this.transform.position;
            clock.transform.parent = this.gameObject.transform;
        }
	}
 
}
