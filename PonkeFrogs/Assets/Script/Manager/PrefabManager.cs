using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 预制管理类
/// </summary>
public class PrefabManager : MonoBehaviour {

    public static PrefabManager Instance;

    public GameObject[] prefabArray;

    //预制体字典
    public Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

  
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < prefabArray.Length; i++)
        {
            if (!prefabDict.ContainsKey(prefabArray[i].name))
            {
                prefabDict.Add(prefabArray[i].name, prefabArray[i]);
            }
            else
            {
                Debug.LogWarning("预制件名字重复");
            }

        }
    }
  
	
    /// <summary>
    /// 根据名称获取prefab
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
	public GameObject GetPrefab(string name)
    {
        if (prefabDict.ContainsKey(name))
        {
            return prefabDict[name];
        }
        else
        {
            Debug.LogWarning("预制字典，没有找到此物体 " + name);
            return null;
        }
    }
}
