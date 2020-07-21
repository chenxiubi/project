using System.Threading.Tasks;

namespace WebApplication.knowledge
{
    public interface IMyDependency
    {
        Task<string> WriteMessage(string message);
    }
}
