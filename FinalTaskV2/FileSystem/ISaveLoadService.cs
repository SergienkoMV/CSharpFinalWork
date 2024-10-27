namespace FinalTaskV2.FileSystem
{
    //1.Реализация чтения и загрузки данных должно быть через отдельный класс-сервис.
    public interface ISaveLoadService<T>
    {
        //a.Интерфейс должен содержать только методы.
        //b.Интерфейс должен быть Generic.Без ограничений.

        // + c.	Метод SaveData. Тип void. На вход - Generic тип T,
        // - который необходимо сохранить и строковый идентификатор.
        public void SaveData(T param1, string path);

        //d.	Метод LoadData. Тип Generic T. На вход -  строковый идентификатор. Возвращаем сохраненный тип.
        //public Dictionary<string, int> LoadData<T>(string path);
        public T1 LoadData<T1>(string path);
    }
}
