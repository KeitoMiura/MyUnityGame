﻿using UnityEngine;
using System.Collections;
namespace Asset.code.AI.CharacterState {
	public class HateState : FSMState
	{
		public HateState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Patrolling;
			
			curRotSpeed = 1.0f;
			curSpeed = 100.0f;
		}
		
		public override void Reason(Transform player, Transform npc)
		{
			int hate = npc.GetComponent<NPCEnemyController> ().hate;
			//憎しみが消えるとおびえる
			if (hate == 0 ) {
				Debug.Log ("Switch to Avoid State");
				npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
		}
		}
		
		public override void Act(Transform player, Transform npc)
		{
			destPos = player.position;
			Vector3 avoidpos = (destPos - npc.position) * -1;
			
			Quaternion targetRotation = Quaternion.LookRotation(avoidpos);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);


			float dist = Vector3.Distance(npc.position, destPos);
			if (dist <= 200.0f)
			{
				//砲台は常にプレーヤーに向きます。
				Transform turret = npc.GetComponent<NPCEnemyController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<NPCEnemyController>().ShootBullet();
			}

		}
	}
}
