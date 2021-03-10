﻿using System.Net.NetworkInformation;
using Enemy.Enemy_Types;
using UnityEngine;

namespace Enemy.States
{
	public class DeathState : NpcState
	{
		private float randomValue;
		private bool animTriggered;
		public bool deathTriggered;

		public DeathState(AIEntity aiEntity) : base(aiEntity) {
			randomValue = Random.value;
			animTriggered = false;
			deathTriggered = false;
			Debug.Log(randomValue);
		}

		public override void DoActions() {
			if (!deathTriggered) DropItem();
		}

		public void DropItem() {
			if (!animTriggered) {
				aiEntity.animationHandler.animator.SetTrigger(ZombieAnimationHandler.DeathTrigger);
				animTriggered = !animTriggered;
			}

			aiEntity.StartCoroutine(WaitForAnimationFinish(aiEntity));
			if (randomValue <= (aiEntity.dropPercent * .01f)) {
				Debug.Log("Item Drop");
				var item = DropManager.dropManager.GetRandomItem();
				aiEntity.SpawnItem(item);
			}

			deathTriggered = true;
		}

		// 	aiEntity.navAgent.enabled = false;
		// 	aiEntity.animator.enabled = false;
		// 	aiEntity.ToggleRagdoll();
		// 	//method to de-spawn 
		// }
	}
}