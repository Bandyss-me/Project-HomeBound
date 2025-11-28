using UnityEngine;

public class enemy_script : MonoBehaviour
{
    void Start()
    {
        float x,z;
        x=Random.Range(-200f,200f);
        z=Random.Range(-200f,200f);
        transform.position=new Vector3(x, 500f, z);
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.GetComponent<gun_bullet_script>() != null){
            Instantiate(gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("ok");
        }
    }
}
