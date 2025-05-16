namespace SmallScaleProjectTask2.Records;

public record TodoItem(
    Guid Id,
    string Text,
    bool IsComplete,
    DateTime CreatedAt
);
