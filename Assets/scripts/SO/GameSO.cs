using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class GameSO : ScriptableObject
{
    public MapSO[] mapArray;
    public int SelectedMapID=-1;
    public int selectedLevelID=-1;

    public void UpdateLevel(int number)
    {
        if(number<=0) return;
        if (number > mapArray[SelectedMapID-1].levelof_doronum[selectedLevelID-1])
        {
            mapArray[SelectedMapID-1].levelof_doronum[selectedLevelID-1]=number;
            int sum = 0;
            foreach(int num in mapArray[SelectedMapID-1].levelof_doronum)
            {
                if (num > 0)
                {
                    sum += num;
                }
            }
            mapArray[SelectedMapID-1].doronum = sum;
            //�ж��Ƿ������һ��
            if (selectedLevelID>= mapArray[SelectedMapID - 1].levelof_doronum.Length)
            {
                //�ж���һ����ͼ�Ƿ��ѿ���
                if (SelectedMapID<mapArray.Length && mapArray[SelectedMapID].doronum ==-1)
                {
                    mapArray[SelectedMapID].doronum = 0;
                    mapArray[SelectedMapID].levelof_doronum[0] = 0;
                }
            }
            else
            {
                //�ж���һ���Ƿ���
                if (mapArray[SelectedMapID - 1].levelof_doronum[selectedLevelID] == -1)
                {
                    mapArray[SelectedMapID - 1].levelof_doronum[selectedLevelID] = 0;
                }
            }
        }
    }
}
