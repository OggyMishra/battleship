using System;

namespace BattleShip_Challenge.Models {

	public class ShipCoveredField : IFields {
		private Ship _ship;
		public ShipCoveredField(Ship ship) {
			_ship = ship;
		}
		public ShotResult Shot() {
			_ship.Hit();
			return _ship.HitResult();
		}
	}
}
