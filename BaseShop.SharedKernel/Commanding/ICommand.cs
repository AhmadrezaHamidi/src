using ENode.Messaging;

namespace BaseShop.SharedKernel.Commanding;

  /// <summary>Represents a command.
  /// </summary>
  public interface ICommand : IMessage
  {
      /// <summary>Represents the associated aggregate root string id.
      /// </summary>
      string AggregateRootId { get; }
  }
