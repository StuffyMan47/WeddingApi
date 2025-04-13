namespace Application.Exception.Base;

public class InternalServerException(string message) : CustomException(message);