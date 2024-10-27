using FinalTaskV2.Utils;
using FinalTaskV2.FileSystem;
using FinalTaskV2.Game.Games;
using System;

namespace FinalTaskV2.Game
{
    [Serializable] //удалить
    //2.	Класс должен реализовывать интерфейс IGame с публичным методом StartGame
    public sealed class Casino : IGame
    {
        public Casino()
        {
            //Экземпляры игр создаются в конструкторе.
            blackJack = new BlackJack(54);
            diceGame = new DiceGame();
        }

        BlackJack blackJack;
        DiceGame diceGame;
        private string _playerName;
        private int _maxMoney = 10000;
        private int _playerBank = 1000; //заменить на значение в профиле
        private int _bet;
        private int _casinoBet;
        private bool _gameResult;
        //c.	Путь может быть любым, главное - в реализации методов должна быть проверка, что путь существует, и если его нет - создать.
        public string _path = @"G:\Учеба\GameDev\Курс Разработчик Unity3d Netologia\Итоговая работа по C#\FinalTaskV2\FileSystem\Profiles";

        private string _profile;

        public void StartGame()
        {
            //1.	Приветствие игрока.
            Console.WriteLine("Welcome to the our Casino"); //перегрузить метод и использовать StringBuilder

            //2.	Загрузка профиля игрока. Если профиля нет - создать. Предложить игроку ввести имя.
            Console.WriteLine("What is your name?");
            _profile = Console.ReadLine();
            FileSystemSaveLoadService<string> fileService = new FileSystemSaveLoadService<string>(_path);

            //разобраться как правильно обработать возвращаемый generic
            string savingData = fileService.LoadData(_profile);
            if (savingData == "")
            {
                fileService.SaveData(_playerBank.ToString(), _profile);
            } 
            else
            {
                _playerBank = int.Parse(savingData);
                Console.WriteLine($"You already have bank {_playerBank}");
            }

            //2.	Казино с выбором игр. На выбор даётся две игры: Блэкджек(21)  и Игра в Кости.
            while (_playerBank > 0)
            {
                //3.	Выбор игры.
                int game = ChooseGame();
                if (game == 3)
                {
                    break;
                }
                //1.	Если игрок проиграл все деньги, то после выбора игры выводится сообщение о игра заканчивается с сообщением: “No money? Kicked!”
                if (!HasMoney())
                {
                    break;
                }
                //5.	Механика ставок. Механика выигрыша.
                MakeBet();
                switch (game)
                {
                    case 1:
                        _gameResult = blackJack.StartGame();
                        break;
                    case 2:
                        //new DiceGame
                        break;
                    default:
                        Console.WriteLine("Error in number game");
                        break;
                }
                //5.	Механика ставок. Механика выигрыша.
                if (!CalculateResult(_gameResult))
                {
                    break;
                }
            }
            //6.Прощаемся с игроком.
            Console.WriteLine($"Goodbye, {_playerName}");
            //7.Сохраняем профиль.
            fileService.SaveData(_playerBank.ToString(), _profile);
            //8.Выход из игры.
            ExitGame();
        }

        private int ChooseGame()
        {
            while (true)
            {
                Console.WriteLine("1. Black Jeck");
                Console.WriteLine("2. Dices");
                Console.WriteLine("3. Leave Casino");
                if (int.TryParse(Console.ReadLine(), out int game))
                {
                    if (game != 1 && game != 2 && game != 3)
                    {
                        Console.WriteLine("Incorrect choosen");
                    }
                    else
                    {
                        return game;
                    }
                }
            }
        }

        private bool HasMoney()
        {
            if(_playerBank > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("No money? Kicked!");
                return false;
            }
        }

        private void MakeBet()
        {
            while (true)
            {
                Console.WriteLine($"Your bank: {_playerBank}. Make your bet:");
                if (int.TryParse(Console.ReadLine(), out _bet))
                {
                    if (_bet > _playerBank)
                    {
                        Console.WriteLine($"You have only: {_playerBank}");
                    }
                    else
                    {
                        Console.WriteLine($"Your bet: {_bet}");
                        _playerBank -= _bet;
                        _casinoBet = _bet;
                        Console.WriteLine($"Casino bet: {_casinoBet}");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Incorrect value");
                }
            }
        }

        public bool CalculateResult(bool _gameResult)
        {
            if (_gameResult)
            {
                int bank = _bet + _casinoBet;
                Console.WriteLine($"You win: {bank}");
                if (_playerBank > _maxMoney)
                {
                    _playerBank = _maxMoney;
                    Console.WriteLine("Вы разорили казино и на его месте построят новое");
                    Console.WriteLine($"Your bank: {_playerBank}");
                    return false;
                } 
                else
                {
                    _playerBank += bank;
                    Console.WriteLine($"Your bank: {_playerBank}");
                }
            }
            else
            {
                Console.WriteLine("You lost");
            }
            return true;
        }

        private void ExitGame()
        {
            Console.WriteLine("Game is finished. Input something");
            Console.ReadLine();
        }
    }
}
