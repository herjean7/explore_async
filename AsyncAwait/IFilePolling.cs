using System.Threading.Tasks;

namespace AsyncAwait
{
    public interface IFilePolling
    {
        Task<string> CheckFileIDAsync(string file_directory, string keyword);
    }
}