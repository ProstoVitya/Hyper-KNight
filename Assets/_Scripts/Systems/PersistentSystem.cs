using Utilities;

namespace Systems
{
    /// <summary>
    /// Класс создан только чтобы указывавть системе, что этот объект не нужно уничтожать во время перехода между сценами
    /// </summary>
    public class PersistentSystem : SingletonPersistent<PersistentSystem> { }   
}
