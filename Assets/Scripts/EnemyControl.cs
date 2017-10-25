using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform Player; //Asignar el personaje al que seguirán
    public float MoveSpeed = 4; //Establecer velocidad de persecución
    public float MaxDist = 20; //Establecer distancia máxima a la que lo seguirá
    public float MinDist = 1; //Establecer distancia mínima a la que lo seguirá
    //public AnimationClip idle; //Animación en estado de reposo
    //public AnimationClip run; //Animación de correr o perseguir

    void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector3 EnemyPos = transform.position;
        Vector3 PlayerPos = Player.position;
        float distancia = Vector3.Distance(EnemyPos, PlayerPos);

        if (distancia >= MinDist && distancia <= MaxDist)
        {
            Vector3 targetPos = new Vector3(Player.position.x, this.transform.position.y, Player.position.z);
            transform.LookAt(targetPos);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //animation.CrossFade(run.name,1); 
            //for (var state : AnimationState in animation)
            //{
            //      state.speed = 2;
            //}
        }
        else
        {
            //animation.CrossFade(idle.name,1); 
            //for (var state : AnimationState in animation)
            //{
            //      state.speed = 1;
            //}
        }
    }
}
