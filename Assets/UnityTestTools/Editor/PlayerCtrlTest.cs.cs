﻿using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Saiyaku
{
	[TestFixture]
	[Category ("PlayerCtrl Test")]
	public class PlayerCtrlTest
	{
		public IPlayerCtrl iplayer;
		public PlayerController player;
		
		[SetUp] public void Init()
		{
			this.iplayer = GetEffectMock ();
			this.player = GetControllerMock (iplayer);
		}
		
		[TearDown] public void Cleanup()
		{
		}
		
		[Test]
		[Category ("Click Test: A")]
		public void ClickWTest() {
			player.IsClickedA ().Returns (true);
			
		}
		
		[Test]
		[Category ("Click Test: W")]
		public void ClickSTest() {
			player.IsClickedW ().Returns (true);
		}
		
		[Test]
		[Category ("Click Test: D")]
		public void ClickDTest() {
			player.IsClickedD ().Returns (true);
			
		}
		
		
		private IPlayerCtrl GetEffectMock () {
			return Substitute.For<IPlayerCtrl> ();
		}
		private PlayerController GetControllerMock(IPlayerCtrl iplayer) {
			var player = Substitute.For<PlayerController> ();
			
			player.SetPlayerController (iplayer);
			return player;
		}
	}
}