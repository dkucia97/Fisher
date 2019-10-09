using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fisher.Core.Utilities
{
    public class NoteFileStrategyResolver:INoteFileStrategyResolver
    {
        private IEnumerable<INoteFileConverterStrategy> _strategies;

        public NoteFileStrategyResolver(IEnumerable<INoteFileConverterStrategy> strategies)
        {
            _strategies = strategies;
        }
        
        public INoteFileConverterStrategy Resolve(FileType type)=>
            _strategies.First(s => s.Type == type);
    }
}