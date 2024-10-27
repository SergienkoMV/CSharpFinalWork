using System;
using System.Collections.Generic;
using FinalTaskV2.Utils;

namespace FinalTaskV2.Game.Games
{
    class BlackJack
    {
        public BlackJack(int quantityCards)
        {
            //2.Реализация FactoryMethod.Процесс создания карт - на усмотрение разработчика.
            //Карты сохраняются в список.
         

            //var cards = new Dictionary<int, string>();

            //если создаем список всех карт, непонятно как свчитывать цену каждой карты для подсчета очков

            for (int i = 0; i < quantityCards; i++)
            {
                cardsList.Add(new KeyValuePair<int, string>(i, CardValues[i]));
            }
        }
        List<KeyValuePair<int, string>> cardsList = new List<KeyValuePair<int, string>>();
        //3.Приватное поле типа Queue<Card> с названием Deck.
        private Queue<KeyValuePair<int, string>> Deck = new Queue<KeyValuePair<int, string>>();


        

        public bool StartGame()
        {

            ////выдаётся две карты пользователя, затем две карты компьютера.

            Console.WriteLine("123");


            return true;
        }

        private void Shufle()
        {
            //3.	Приватное поле типа Queue<Card> с названием Deck.
        }
    }
}
