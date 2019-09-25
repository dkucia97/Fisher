using System.IO;
using System.Threading.Tasks;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Domain;

namespace Fisher.Core.Utilities
{
    public interface IPdfGenerator
    {
        PdfNotesDto Generate(NotePackage notePackage,int limitOfNotes=30);//generate pdf for printing 
    }
}