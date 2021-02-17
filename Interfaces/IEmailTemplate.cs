using System.Threading.Tasks;
using TaxComputationSoftware.Respoonse;

namespace TaxComputationSoftware.Interfaces
{
    public interface IEmailTemplate
    {
        EmailTemplateResponse Template();
    }
}