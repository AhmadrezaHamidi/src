using System.Threading.Tasks;

namespace BaseShop.SharedKernel.Commanding;
    public interface IProcessingCommandHandler
    {
       Task HandleAsync(ProcessingCommand processingCommand);
    }
