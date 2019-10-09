using System;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Infrastructure.Utilities
{
    public class PdfGenerator:IPdfGenerator
    {
        private ITemplateProvider _templateProvider;

        public PdfGenerator(ITemplateProvider provider )
        {
            _templateProvider = provider;
        }
        
        public PdfNotesDto Generate(NotePackage notePackage, int limitOfNotes = 30)
        {
            throw  new NotImplementedException();
        }
    }
}