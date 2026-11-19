using MerkHelp.Domain.Common;

namespace MerkHelp.Domain.Tickets;

public class Ticket : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; private set; }
    public Guid RequesterId { get; private set; }
    public Guid? AssigneeId { get; private set; }

    // Construtor vazio exigido pelo Entity Framework Core
    private Ticket() { }

    public Ticket(string title, string description, TicketPriority priority, Guid requesterId)
    {
        if (string.IsNullOrWhiteSpace(title)) 
            throw new ArgumentException("O titulo nao pode ser vazio.", nameof(title));
        
        if (string.IsNullOrWhiteSpace(description)) 
            throw new ArgumentException("A descricao nao pode ser vazia.", nameof(description));

        Title = title;
        Description = description;
        Priority = priority;
        RequesterId = requesterId;
        Status = TicketStatus.Open;
    }

    public void AssignTo(Guid assigneeId)
    {
        if (Status == TicketStatus.Closed) 
            throw new InvalidOperationException("Nao e possivel atribuir um chamado fechado.");
        
        AssigneeId = assigneeId;
        Status = TicketStatus.InProgress;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Resolve()
    {
        if (Status != TicketStatus.InProgress) 
            throw new InvalidOperationException("Apenas chamados em andamento podem ser resolvidos.");
        
        Status = TicketStatus.Resolved;
        UpdatedAt = DateTime.UtcNow;
    }
}
