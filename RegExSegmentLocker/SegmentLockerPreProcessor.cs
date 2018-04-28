using System.Collections.Generic;
using System.Linq;
//using Sdl.Community.projectAnonymizer.Models;
using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace RegExSegmentLocker
{
    public class SegmentLockerPreProcessor : AbstractBilingualContentProcessor
    {
        private readonly List<RegExPattern> _patterns;
        private readonly bool _includeTagContent;


        public SegmentLockerPreProcessor(List<RegExPattern> patterns, bool includeTagContent)
        {
            _patterns = patterns;
            _includeTagContent = includeTagContent;
        }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            base.ProcessParagraphUnit(paragraphUnit);
            if (paragraphUnit.IsStructure) { return; }

            foreach (var segmentPair in paragraphUnit.SegmentPairs.ToList())
            {
                var segmentVisitor = new SegmentVisitor(_patterns, _includeTagContent);

                segmentVisitor.ReplaceText(segmentPair.Source, ItemFactory, PropertiesFactory);

                if (segmentVisitor.ShouldLockSegment)
                {
                    segmentPair.Properties.IsLocked = true;
                }
            }
        }


    }
}