using System.Threading.Tasks;

namespace NoteDotNet.Web.Helpers
{
    public interface IJsHelper
    {
        ValueTask CloseModal(string id);
    }
}
