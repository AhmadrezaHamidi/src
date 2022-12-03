using System;
using System.Threading.Tasks;
using ENode.Commanding;

namespace BaseShop.SharedKernel.Commanding.Impl;

  public class NotImplementedCommandService : ICommandService
  {
      public void Send(ICommand command)
      {
          throw new NotImplementedException();
      }
      public Task SendAsync(ICommand command)
      {
          throw new NotImplementedException();
      }
      public Task<CommandResult> ExecuteAsync(ICommand command)
      {
          throw new NotImplementedException();
      }
      public Task<CommandResult> ExecuteAsync(ICommand command, CommandReturnType commandReturnType)
      {
          throw new NotImplementedException();
      }
  }
