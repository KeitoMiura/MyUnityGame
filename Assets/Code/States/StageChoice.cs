﻿using UnityEngine;

namespace Saiyaku{
	public class StageChoice : IState {
		private StateManager manager;
		
		public StageChoice(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		
		public void StateUpdate() { 
			//更新処理
			if(Input.GetKeyUp(KeyCode.Return)) { // Returnキーを押すとStartSceneに遷移
				//Application.LoadLevel("Scene0");
				Debug.Log("Play State");
				manager.SwitchState(new Stage01(manager));
			}
		}
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(50, 100, 100, 50), "Stage01")) {
				Application.LoadLevel("Stage01");
				Time.timeScale = 1;
				manager.SwitchState(new Stage01(manager));    
			}
				if(GUI.Button(new Rect(50, 210, 100, 50), "comingsoon")) {
					Application.LoadLevel("Stage01");
					Time.timeScale = 1;
					manager.SwitchState(new Stage01(manager));    
				}
		}
	}
}