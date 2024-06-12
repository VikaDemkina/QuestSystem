using Confluent.Kafka;

namespace QuestSystem.Domain.Messages;
public record NewBookingMessage(string OrderNumber, string Date, string Timestamp);