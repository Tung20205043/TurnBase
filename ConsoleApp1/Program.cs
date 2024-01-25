using static System.Net.Mime.MediaTypeNames;

namespace KeThua {
    internal class Program {
        static void Main(string[] args) {
            Hero hero = new Hero("Hero");
            Monster monster = new Monster("Monster");
            Character[] characters = new Character[] { hero, monster };
            string[] equipment = new string[] { "arrow", "sword", "caduceus", "shield" };
            bool startGame = true;
            int currentTurn = hero.Atksp > monster.Atksp ? 0 : 1;

            while (hero.Alive && monster.Alive) {
                int targetIndex = currentTurn == 0 ? 1 : 0;
                if (startGame) {
                    #region Start Game
                    Console.WriteLine("Hero");
                    Console.Write($"Health: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{hero.Health}");
                    Console.ResetColor();
                    Console.Write($"Atk: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{hero.Atk}");
                    Console.ResetColor();
                    Console.Write($"Spell: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{hero.Spell}");
                    Console.ResetColor();
                    Console.Write($"Atksp: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{hero.Atksp}");
                    Console.ResetColor();
                    Console.WriteLine("................");
                    Console.WriteLine("Monster");
                    Console.Write($"Health: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{monster.Health}");
                    Console.ResetColor();
                    Console.Write($"Atk: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monster.Atk}");
                    Console.ResetColor();
                    Console.Write($"Spell: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{monster.Spell}");
                    Console.ResetColor();
                    Console.Write($"Atksp: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{monster.Atksp}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("*The character who the \"Atksp\" stat is greater will atk first");
                    Console.WriteLine("*The character will use atk or spell to cause dmg on whether the \"atk\" or \"spell\" stat is greater");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine("----------------------------------------------------");
                    #endregion

                    #region Equip
                    int heroEquipIndex = (int)hero.RandomEquip();
                    Console.Write($"Hero equiped: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{equipment[heroEquipIndex]}");
                    Console.ResetColor();

                    int monsterEquipIndex = (int)monster.RandomEquip();
                    Console.Write($"Monster equiped: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{equipment[monsterEquipIndex]}");
                    Console.ResetColor();

                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine("----------------------------------------------------");
                    #endregion

                    #region Update
                    Console.WriteLine("Update character's stats");
                    Console.WriteLine("Hero");
                    Console.Write($"Health:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{(hero.Health > hero.baseHealth ? hero.baseHealth
                        + " -> " : "") + hero.Health}");
                    Console.ResetColor();
                    Console.Write($"Atk: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(hero.Atk > hero.baseAtk ? hero.baseAtk
                        + " -> " : "") + hero.Atk}");
                    Console.ResetColor();
                    Console.Write($"Spell: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{(hero.Spell > hero.baseSpell ? hero.baseSpell
                        + " -> " : "") + hero.Spell}");
                    Console.ResetColor();
                    Console.Write($"Atksp: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{(hero.Atksp > hero.baseAtksp ? hero.baseAtksp
                        + " -> " : "") + hero.Atksp}");
                    Console.ResetColor();
                    Console.WriteLine($"Hero will use {(hero.Atk > hero.Spell ? "Atk" : "Spell")} to cause damage");
                    Console.WriteLine("................");
                    Console.WriteLine("Monster");
                    Console.Write($"Health:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{(monster.Health > monster.baseHealth ? monster.baseHealth
                        + " -> " : "") + monster.Health}");
                    Console.ResetColor();
                    Console.Write($"Atk: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(monster.Atk > monster.baseAtk ? monster.baseAtk
                        + " -> " : "") + monster.Atk}");
                    Console.ResetColor();
                    Console.Write($"Spell: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{(monster.Spell > monster.baseSpell ? monster.baseSpell
                        + " -> " : "") + monster.Spell}");
                    Console.ResetColor();
                    Console.Write($"Atksp: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{(monster.Atksp > monster.baseAtksp ? monster.baseAtksp
                        + " -> " : "") + monster.Atksp}");
                    Console.ResetColor();
                    Console.WriteLine($"Monster will use {(monster.Atk > monster.Spell ? "Atk" : "Spell")} to cause damage");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("----------------------------------------------------");
                    Console.ReadKey();
                    #endregion
                    startGame = false;
                }

                #region LogicGame
                Console.WriteLine($"{characters[currentTurn].CharName}'s turn");
                Console.Write("");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.WriteLine("----------------------------------------------------");

                characters[currentTurn].Attack(characters[targetIndex]);
                Console.Write($"{characters[currentTurn].CharName} " +"deals");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {(characters[currentTurn].Atk > characters[currentTurn].Spell ?
                characters[currentTurn].Atk : characters[currentTurn].Spell)}");
                Console.ResetColor();
                Console.WriteLine($" damage to {characters[targetIndex].CharName} ");

                currentTurn = targetIndex;
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.WriteLine("----------------------------------------------------");

                if (!startGame) {
                    Console.Write($"Hero's health left: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{hero.Health}");
                    Console.ResetColor();

                    Console.Write($"Monster's health left: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{monster.Health}");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
                #endregion
            }

            #region EndGame
            Character winCharacter = characters[0].Alive ? characters[0] : characters[1];
            string battleResult = winCharacter is Hero ? "You win" : "You lose";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"----------------------{battleResult}------------------------");
            Console.ResetColor();
            #endregion
        }
    }
}
