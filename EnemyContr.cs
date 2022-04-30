using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;


//движение врага на игрока
public class EnemyContr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hp;
    public GameObject loose;
    public static int hps = 100;
    float distanceToPlayer;
    NavMeshAgent agent;
        public GameObject player;
        Transform playerTR;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            playerTR = player.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(playerTR.position);
            distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
            if(distanceToPlayer <=1){
                hps = hps - 1;
                hp.text = "hp: " + hps;
                if(hps == 0){
                    CancelInvoke();
                    loose.SetActive(true);
                }
            }
        }

}
