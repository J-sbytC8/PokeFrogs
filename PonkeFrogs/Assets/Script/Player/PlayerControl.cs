using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色控制类
/// </summary>
public class PlayerControl : MonoBehaviour {

    public bool isCanJump = false;

    public int nowIndex = 0;
    public GameObject mainCamera;
    //跟相机的偏移
    public Vector3 offset = Vector3.zero;


	void Start () {
        mainCamera = GameObject.Find("Main Camera");
        offset = mainCamera.transform.position - this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// UI跳跃按钮执行的方法 ，参数几步
    /// </summary>
    /// <param name="step"></param>
    public void Jump(int step)
    {
        if(isCanJump)
        {
            //ToDo
            //进行跳跃
            //判断是否跳到石头上

            //跳跃石头一个动画
            //跳跃空落水一个动画

            //落水后返回

            //成功或者失败都会播放水特效  声音  还有石头
            
           // int index = nowIndex + step;
            nowIndex += step;
            GameObject stone = StoneManager.Instance.GetStone(nowIndex);   //下一个跳跃点位置
            Stone stoneScpite = stone.GetComponent<Stone>();

            iTween.MoveTo(this.gameObject, stone.gameObject.transform.position, 1);
            // 移动位置。不管石头还是空

            //判断是否有石头，可以通过 索引  或者是否有石头
            if (nowIndex >= stoneScpite.index  && stoneScpite.isHasStone) 
            {
                //有石头可以跳过去。
                //执行特效
               
            }
            else
            {
                StartCoroutine(BackStone());
                //下落 ，稍等返回
            }

            //移动相机


            mainCamera.transform.position = this.transform.position + offset;
        }
    }

    //返回上一个石头
   IEnumerator   BackStone()
   {
        yield return new WaitForSeconds(1);
        nowIndex -= 1;
        iTween.MoveTo(this.gameObject, StoneManager.Instance.GetStone(nowIndex).gameObject.transform.position, 1);
   }

}
