namespace BattleShip_Challenge.Test {
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Models;

	[TestClass]
	public class PlayerTests {
		[TestMethod]
		public void ShouldHitTheDeckIfMissileCordinatesAreValid() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			Player playerA = new Player();
			playerA.Board = board;
			playerA.AddMissiles(new List<string> { "A1" });


			BattleBoard boardB = new BattleBoard(width, height);
			Player playerB = new Player();
			playerB.Board = boardB;
			playerB.FormateFleet(1, 1, "A1", ShipType.TYPE_P);
			//Act
			playerA.LaunchMissileToTarget(playerB);
			//Assert
			Assert.IsTrue(playerA.HaveMissileFinished());

		}
		[TestMethod]
		public void ShouldFireTwoTimesToDestroyQTypeShip() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			Player playerA = new Player();
			playerA.Board = board;
			playerA.AddMissiles(new List<string> { "A1" });


			BattleBoard boardB = new BattleBoard(width, height);
			Player playerB = new Player();
			playerB.Board = boardB;
			playerB.FormateFleet(1, 1, "A1", ShipType.TYPE_Q);
			//Act
			playerA.LaunchMissileToTarget(playerB);
			//Assert
			Assert.IsFalse(playerB.Board.HaveAllShipDestroyed());

		}
		[TestMethod]
		public void ShouldClearBattleAreaToAfterAllHit() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			Player playerA = new Player();
			playerA.Board = board;
			playerA.AddMissiles(new List<string> { "A1", "A1" });


			BattleBoard boardB = new BattleBoard(width, height);
			Player playerB = new Player();
			playerB.Board = boardB;
			playerB.FormateFleet(1, 1, "A1", ShipType.TYPE_Q);
			//Act
			playerA.LaunchMissileToTarget(playerB);
			//Assert
			Assert.IsTrue(playerB.Board.HaveAllShipDestroyed());
		}
		[TestMethod]
		public void ShouldNotAddMissileTargetsWhenNotValid() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			Player player = new Player();
			player.Board = board;
			// Act
			player.AddMissiles(new List<string> { "P1", "K2", "B6" });

			// Assert
			Assert.IsTrue(player.HaveMissileFinished());
		}
		[TestMethod]
		public void ShouldNotOnBoardShipsHavingInvalidDimensions() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			Player player = new Player();
			player.Board = board;
			// Act
			player.FormateFleet(23, 23, "A1", ShipType.TYPE_P);
			// Assert
			Assert.IsTrue(player.Board.HaveAllShipDestroyed());
		}
	}
}

