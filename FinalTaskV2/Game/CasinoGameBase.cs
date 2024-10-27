using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskV2.Game
{
    public abstract class CasinoGameBase
    {
        public CasinoGameBase()
        {
            //8.	Обязательно должна быть проверка на корректность входных параметров конструктора!

            //5.	У класс должен быть защищённый метод FactoryMethod, который вызывается в конструкторе и является абстрактным.
            FactoryMethod();
        }

        //2.	У класса должен быть один публичный метод PlayGame. Метод должен быть абстрактным
        public abstract void PlayGame();

        //3.	У класса должны быть три события - OnWin, OnLoose и OnDraw.
        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        //4.	У класса должно быть три защищенных метода - OnWinInvoke, OnLooseInvoke и OnDrawInvoke, каждый из которых должен вызывать соответствующее событие.
        protected void OnWinInvoke() => OnWin();
        protected void OnLooseInvoke() => OnLoose();
        protected void OnDrawInvoke() => OnDraw();

        //5.	У класс должен быть защищённый метод FactoryMethod, который вызывается в конструкторе и является абстрактным.
        internal abstract void FactoryMethod(); //посмотреть варианты сокрытия. Метод должен быть защищенным

        public void OutputResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
