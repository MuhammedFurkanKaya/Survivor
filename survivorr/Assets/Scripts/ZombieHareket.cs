using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieHareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombiCan = 3;
    private float mesafe;
    private OyunKontrol oKontrol;
    private int zombidenGelenPuan = 10;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("Oyuncu");
        oKontrol = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);

        if ( mesafe < 2f && zombiCan>0)
        {
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("Çarpışma gerçekleşti");
            zombiCan -= 1;
            if (zombiCan == 0)
            {
                oKontrol.PuanArttir(zombidenGelenPuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject,1.667f);
            }
        }
    }
}
