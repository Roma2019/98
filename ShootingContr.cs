using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//стрельба и вывод количества убитых монстров
public class ShootingContr : MonoBehaviour
{
    public Camera cam;
    [SerializeField] TextMeshProUGUI kills;
    public ParticleSystem partic;
    int kill = 0;
    public GameObject loose;
    public GameObject win;
    int time = 20;
    [SerializeField] TextMeshProUGUI seconds;
    // Start is called before the first frame update

    void timeMinus(){
        time = time - 1;
        seconds.text = "Time: "+time ;
        if( time == 0){
            CancelInvoke();
            loose.SetActive(true);
        }
    }

    void Start()
    {
        InvokeRepeating("timeMinus", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 100f, Color.green);
        RaycastHit hit;
        if(Input.GetButtonDown("Fire1")){
            partic.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100)){
                if(hit.transform.gameObject.tag == "target"){
                    kill = kill + 1;
                    Destroy(hit.transform.gameObject);
                    kills.text = kill + "";
                    if(kill == 9){
                        win.SetActive(true);
                        CancelInvoke();
                    }
                }
            }
        }
        
    }
}
