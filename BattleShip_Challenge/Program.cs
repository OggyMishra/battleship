using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip_Challenge.Models;

namespace BattleShip_Challenge {
	class Program {
		static void Main(string[] args) {
			string testCaseFileName = @"TestFile.txt";
			var battle = new FleetBattle();
			battle.Play(testCaseFileName);
			Console.ReadLine();
		}
	}
}
