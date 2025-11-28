using UnityEngine;

public class Item_LoadMe : MonoBehaviour
{
    public GameObject obj;

    void LoadItems(){
        var data=Save_manager.Instance.data;
        for(int i=0;i<data.tag.Length;i++){
            if(data.tag[i]==obj.tag){
                Instantiate(obj, data.pos[i], Quaternion.Euler(data.rot[i]));
            }
        }
    }

    public void Load(){
        LoadItems();
    }
}
