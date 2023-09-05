namespace G253504_VashkevichLab5.Entities;

public class CustomMessage : EventArgs
{
    public string Message { get; }

    public CustomMessage(string message)
    {
        Message = message;
    }
}