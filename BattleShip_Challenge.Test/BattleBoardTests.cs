namespace BattleShip_Challenge.Test {
	using BattleShip_Challenge.Models;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class BattleBoardTests {
		[TestMethod]
		public void ShouldNotAddShipWhichHaveInvalidLocations() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			// Act
			board.OnBoardShips(new Ship(), "Q2");
			board.OnBoardShips(new Ship(), "P2");
			// Assert
			Assert.IsTrue(board.HaveAllShipDestroyed());
		}
		[TestMethod]
		public void ShouldAddShipWhichHaveValidLocations() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			// Act
			board.OnBoardShips(new Ship(), "A1");
			board.OnBoardShips(new Ship(), "E3");
			// Assert
			Assert.IsFalse(board.HaveAllShipDestroyed());
		}
		[TestMethod]
		public void ShouldCleanValidShipFields() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			// Act
			board.OnBoardShips(new Ship(), "A1");
			board.OnBoardShips(new Ship(), "E3");
			board.ClearShipField("A1");
			board.ClearShipField("E3");
			// Assert
			Assert.IsTrue(board.HaveAllShipDestroyed());
		}
		[TestMethod]
		public void ShouldReturnValidShipFieldsWhenCordinatesAreValid() {
			// Arrange
			int width = 5;
			int height = 5;
			BattleBoard board = new BattleBoard(width, height);
			// Act
			board.OnBoardShips(new Ship(), "A1");
			var a = board.GetCordinates("A1");

			// Assert
			Assert.IsTrue(a.Shot() == ShotResult.DESTROYED);
		}
		[TestMethod]
		public void ShouldNotAddShipWhenShipIsNull() {
			// Arrange
			int width = 45;
			int height = 34;
			BattleBoard board = new BattleBoard(width, height);
			// Act
			board.OnBoardShips(null, "A1");
			// Assert
			Assert.IsTrue(board.HaveAllShipDestroyed());
		}
	}
}
