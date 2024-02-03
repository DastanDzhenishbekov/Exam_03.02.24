namespace EXAM_4;

public static class CrocodileEventManager
{
    public static void SubscribeCrocodileDied(Crocodile crocodile)
    {
        crocodile.CrocodileDied += CrocodileDiedHandler;
    }
    
    private static void CrocodileDiedHandler(object sender, EventArgs e)
    {
        if (sender is Crocodile crocodile)
        {
            Console.WriteLine($"{crocodile.Name} has died!");
        }
    }
}