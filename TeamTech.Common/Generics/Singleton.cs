using System.Threading;
namespace TeamTech.Common.Generics
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _Instancia;
        private static readonly Mutex Mutex = new Mutex();

        public static T Instancia
        {
            get
            {
                Mutex.WaitOne();
                if (_Instancia == null) _Instancia = new T();
                Mutex.ReleaseMutex();
                return _Instancia;

            }
        }
    }
}
