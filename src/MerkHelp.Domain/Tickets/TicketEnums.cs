namespace MerkHelp.Domain.Tickets;

public enum TicketStatus
{
    Open = 1,
    InProgress = 2,
    WaitingForUser = 3,
    Resolved = 4,
    Closed = 5
}

public enum TicketPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}
