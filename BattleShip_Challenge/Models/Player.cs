namespace BattleShip_Challenge.Models {
	using System;
	using System.Collections.Generic;

	public class Player {
		private IList<Missile> _activeMissiles;
		public Player() {
			this._activeMissiles = new List<Missile>();
		}
		public int Id { get; set; }
		public BattleBoard Board { get; set; }
		public void LaunchMissileToTarget(Player otherPlayer) {
			if (_activeMissiles?.Count > 0) {
				var missile = _activeMissiles[0];
				string target = string.Format("{0}", missile.TargetLocation);
				var result = otherPlayer.Board.GetCordinates(missile.TargetLocation).Shot();
				this._activeMissiles.Remove(missile);
				if (result == ShotResult.DESTROYED) {
					otherPlayer.Board?.ClearShipField(missile.TargetLocation);
				}
				if (result == ShotResult.DESTROYED || result == ShotResult.PARTIAL_HIT) {
					Console.WriteLine(string.Format(BattleResources.FireMessage, this.Id, target, "hit"));
					if (!otherPlayer.Board.HaveAllShipDestroyed())
						LaunchMissileToTarget(otherPlayer);
				} else {
					Console.WriteLine(string.Format(BattleResources.FireMessage, this.Id, target, "miss"));
				}
			} else {
				Console.WriteLine(string.Format(BattleResources.NoMissleLeftMessage, this.Id));
			}
		}
		public void FormateFleet(int width, int height, string cordinate, ShipType type) {
			if (this.Board.IsValidDimensions(width, height)) {
				var newShip = new Ship
				{
					Height = height,
					Type = type,
					Width = width
				};
				this.Board?.OnBoardShips(newShip, cordinate);
			}
		}

		public void AddMissiles(IList<string> missileStrength) {
			foreach (var item in missileStrength) {
				if (this.Board.IsValidDimensions(item)) {
					this._activeMissiles?.Add(new Missile
					{
						TargetLocation = item[0] + item[1].ToString()
					});
				}
			}
		}

		public bool HaveMissileFinished() {
			return this._activeMissiles?.Count == 0;
		}
	}
}
