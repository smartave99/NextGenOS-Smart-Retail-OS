namespace SmartRetail.Pos.Core.Models;

/// <summary>A customer (POS table <c>Customer</c>, key <c>ID</c>).</summary>
public sealed record Customer
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string? Phone { get; init; }

    /// <summary>The counter customer who is not on record. Bills for them must be paid in full.</summary>
    public static Customer WalkIn { get; } = new() { Id = 0, Name = "Walk-in customer" };

    public bool IsWalkIn => Id == WalkIn.Id;
}
