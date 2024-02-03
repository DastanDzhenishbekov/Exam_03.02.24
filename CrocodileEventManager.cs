namespace EXAM_4;

public static class CrocodileEventManager
{
    // Метод для подписки на событие "крокодил умер"
    public static void SubscribeCrocodileDied(Crocodile crocodile)
    {
        crocodile.CrocodileDied += CrocodileDiedHandler;
    }

    // Обработчик события "крокодил умер"
    private static void CrocodileDiedHandler(object sender, EventArgs e)
    {
        if (sender is Crocodile crocodile)
        {
            Console.WriteLine($"{crocodile.Name} has died!");
        }
    }
}