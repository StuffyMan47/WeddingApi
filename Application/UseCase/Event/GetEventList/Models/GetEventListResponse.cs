﻿namespace Application.UseCase.Event.GetEventList.Models;

public class GetEventListResponse
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public string WelcomeSpeech { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Newlyweds { get; set; } = string.Empty;
}
