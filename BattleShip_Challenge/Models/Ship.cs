namespace BattleShip_Challenge.Models {

	public class Ship {
		private ShotResult _state;
		public ShipType Type { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }

		public ShotResult HitResult() {
			return _state;
		}
		public void Hit() {
			if (this.Type == ShipType.TYPE_Q) {
				this.Type = ShipType.TYPE_P;
				_state = ShotResult.PARTIAL_HIT;
			} else {
				_state = ShotResult.DESTROYED;
			}
		}
	}
}
