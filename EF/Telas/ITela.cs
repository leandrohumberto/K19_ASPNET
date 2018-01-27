namespace EF.Telas
{
    interface ITela
    {
        string Nome { get; }
        ITela Mostra();
    }
}
