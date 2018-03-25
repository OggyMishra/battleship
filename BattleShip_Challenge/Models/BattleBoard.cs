namespace BattleShip_Challenge.Models {
	using System;
	using System.Collections.Generic;

	public class BattleBoard {
		private IDictionary<string, IFields> _battleArea;
		private readonly int _width;
		private readonly int _height;
		public BattleBoard(int width, int height) {
			_width = width;
			_height = height;
			_battleArea = new Dictionary<string, IFields>();
		}

		public void OnBoardShips(Ship ship, string cordinate) {
			if (IsValidDimensions(cordinate) && !_battleArea.ContainsKey(cordinate) && ship != null)
				_battleArea.Add(cordinate, new ShipCoveredField(ship));
		}

		public IFields GetCordinates(string loc) {
			if (this.IsValidDimensions(loc) && this._battleArea.ContainsKey(loc)) {
				return _battleArea[loc];
			} else {
				return new EmptyFields();
			}
		}

		public bool IsValidDimensions(string cordinates) {
			int x = cordinates[0] - 64;
			int y = Convert.ToInt32(cordinates[1].ToString());
			return x > 0 && y > 0 && x <= _width && y <= _height;
		}
		public bool IsValidDimensions(int x, int y) {
			return x > 0 && y > 0 && x <= _width && y <= _height;
		}

		public void ClearShipField(string cordinate) {
			if (_battleArea.ContainsKey(cordinate))
				_battleArea.Remove(cordinate);
		}
		public bool HaveAllShipDestroyed() {
			return _battleArea.Count == 0;
		}
	}
}
