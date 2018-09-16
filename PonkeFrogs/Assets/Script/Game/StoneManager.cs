using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理和生成石头
/// </summary>
public class StoneManager : MonoBehaviour {

    public static StoneManager Instance;

    /// <summary>
    /// 石头数量，空的同样计算
    /// </summary>
    [Header("石头总数")]
    public int stoneNumber = 50;
    
    [Header("石头间隔")]
    /// <summary>
    /// 石头间隔
    /// </summary>
    public float stoneSpace = 1.5f;


    [Header("石头初始生成位置")]
    /// <summary>
    /// 初始生成位置
    /// </summary>
    public GameObject stoneStartPos = null;

    public Dictionary<int, GameObject> stoneDict = new Dictionary<int, GameObject>();

    //用来计算
    private int stoneIndex = 0;
    private Vector3 stoneNowPos = Vector3.zero;

    // Use this for initialization



    private void Awake()
    {
        Instance = this;
    }


    void Start () {

        stoneNowPos = stoneStartPos.transform.position; //获取生成位置

		while(stoneIndex < stoneNumber)
        {
            int randomNumber = Random.Range(1, 4);  //石头组 
            for (int i = 0; i < randomNumber; i++)
            {
                CreateStone(true);
                stoneIndex++;
                stoneNowPos.x += stoneSpace;
            }

            //每次生成一组，再创建一个空的石头
            CreateStone(false);
            stoneIndex++;
            stoneNowPos.x += stoneSpace;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 根据bool是否创建石头
    /// </summary>
    /// <param name="isHasStone"></param>
    void CreateStone(bool isHasStone)
    {
        GameObject stone = Instantiate( PrefabManager.Instance.GetPrefab("Stone"));
        //更新石头脚本的位置，索引。是否包含石头
        Stone stoneScript = stone.GetComponent<Stone>();
        stoneScript.isHasStone = isHasStone;
        stoneScript.buildPos = stoneNowPos;
        stoneScript.index = stoneIndex;

        if (isHasStone)
        {          
            stone.name = "石头" + stoneIndex;          
        }
        else
        {
            stone.GetComponent<SpriteRenderer>().sprite = null;
            stone.name = "空石头" + stoneIndex;
        }

        //更新位置，父对象
        stone.transform.parent = this.gameObject.transform; ;
        stone.transform.position = stoneNowPos;

        //添加石头字典
        stoneDict.Add(stoneIndex, stone);
    }

    /// <summary>
    /// 根据索引获取第几个石头对象
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetStone(int index)
    {
        return stoneDict[index];
    }
}
