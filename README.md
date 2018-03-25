# battleship
A poc on battleship game.

Build Steps:
1. Extract BattleShip_Challenge.zip
2. Run MsBuild on BattleShip_Challenge.sln file using following command
	msbuild BattleShip_Challenge.sln
3. Executing above command will create BattleShip_Challenge.exe in $ROOT\BattleShip_Challenge\BattleShip_Challenge\bin\Debug folder
4. Run the exe to check the result
5. In order to run other test cases feel free to change TestFile.txt under $ROOT\BattleShip_Challenge\BattleShip_Challenge\TestFile.txt



Solution Description:
I have used dicitionary to save the ship's location as there is no use of location which are not been used by ships. Getting fast lookups was the other reason to use dicitionary.

All the model class are under model folder.

1. FleetBattle: this is the entry point of the game. It mostly pipelines the inputs to the core of the program. It creates two different player and assign the different inputs to them
2. Player: player handles the responsiblity of managing 
	- Firing missiles
	- Adding missiles
	- Allocating Ships
	- Board property
	
3. BattleBoard: It contains the collection of ShipFields or EmptyFields. The main motive to create two types of Fields was to change it dynamically so that when someone tries to hit the target 
then callee of that method should not worried about the status of the hit.


All other things seems to be self explanatory. Also there are few UT which i wrote to check some scenarios.
