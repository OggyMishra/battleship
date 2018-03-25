namespace BattleShip_Challenge.Models {
	public class EmptyFields : IFields {
		public ShotResult Shot() {
			return ShotResult.MISS;
		}
	}
}
