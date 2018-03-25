namespace BattleShip_Challenge.Models {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class FleetBattle {
		private Player[] _players;
		public FleetBattle() {
			_players = new Player[]
			{
				new Player() { Id=1 },
				new Player() { Id=2 }
			};
		}
		public void Play(string instructionFile) {
			int index = 0;
			int i = 0;
			int j = 1;
			int playerStrength = 2;
			int playerWon = 0;
			var commands = File.ReadAllLines(instructionFile);
			_players[0].Board = commands[index].GetBoard();
			_players[1].Board = commands[index++].GetBoard();
			var noOfBattleShips = Convert.ToInt32(commands[index++]);
			index = FleetFormation(index, commands, noOfBattleShips);
			_players[0].AddMissiles(commands[index++].GetMissilesCordinates());
			_players[1].AddMissiles(commands[index++].GetMissilesCordinates());

			while ((!_players[0].Board.HaveAllShipDestroyed()) && (!_players[1].Board.HaveAllShipDestroyed()) && (!_players[0].HaveMissileFinished() || !_players[1].HaveMissileFinished())) {
				_players[i++ % playerStrength].LaunchMissileToTarget(_players[j++ % playerStrength]);
			}
			playerWon = _players[0].Board.HaveAllShipDestroyed() ? (!_players[1].Board.HaveAllShipDestroyed() ? _players[1].Id : 0) : (_players[1].Board.HaveAllShipDestroyed() ? _players[0].Id : 0);
			if (playerWon == 0) {
				Console.WriteLine(BattleResources.PeaceMessage);
			} else {
				Console.WriteLine(string.Format(BattleResources.WinMessage, playerWon));
			}
		}

		private int FleetFormation(int index, string[] commands, int noOfBattleShips) {
			for (var i = 0; i < noOfBattleShips; i++) {
				var specs = commands[index].Split(' ');
				var type = specs[0].GetShipType();
				var width = Convert.ToInt32(specs[1]);
				var height = Convert.ToInt32(specs[2]);

				for (var w = 0; w < width; w++) {
					var pA = Convert.ToChar(specs[3][0]).ToString() + (Convert.ToInt32(specs[3][1].ToString()) + w);
					var pB = Convert.ToChar(specs[4][0]).ToString() + (Convert.ToInt32(specs[4][1].ToString()) + w);
					_players[0].FormateFleet(width, height, pA, type);
					_players[1].FormateFleet(width, height, pB, type);
				}
				for (var h = 0; h < height; h++) {
					var pA = (Convert.ToChar(specs[3][0] + h)).ToString() + Convert.ToInt32(specs[3][1].ToString());
					var pB = (Convert.ToChar(specs[4][0] + h)).ToString() + Convert.ToInt32(specs[4][1].ToString());
					_players[0].FormateFleet(width, height, pA, type);
					_players[1].FormateFleet(width, height, pB, type);
				}
				index++;
			}
			return index;
		}
	}

	public static class GameExtension {

		public static IList<string> GetMissilesCordinates(this string cordinate) {
			return cordinate?.Split(' ').ToList();
		}

		public static BattleBoard GetBoard(this string boardSize) {
			var widthOfBattleArea = Convert.ToInt32(boardSize.Split(' ')[0]);
			var heightOfBattleArea = Convert.ToInt32(boardSize.Split(' ')[1][0]) - 64;
			return new BattleBoard(widthOfBattleArea, heightOfBattleArea);
		}

		public static ShipType GetShipType(this string shipType) {
			ShipType type = ShipType.TYPE_P;
			if (shipType == "Q") {
				type = ShipType.TYPE_Q;
			}
			return type;
		}
	}
}
