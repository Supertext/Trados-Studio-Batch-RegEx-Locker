//using Sdl.FileTypeSupport.Framework.BilingualApi;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RegExSegmentLocker
//{
//    public class FileReader : AbstractBilingualContentProcessor
//    {
//        // Variables to retrieve the task settings
//        // as well as the SDL XLIFF file patch to process and
//        // the path of the TXT file that contains the exported content
//        private readonly MyCustomBatchTaskSettings _taskSettings;
//        private readonly string _inputFilePath;


//        public FileReader(MyCustomBatchTaskSettings settings, string inputFilePath)
//        {
//            _taskSettings = settings;
//            _inputFilePath = inputFilePath;
//        }

//        // We use this member to create the TXT export file
//        public override void SetFileProperties(IFileProperties fileInfo)
//        {
//            //_outFile = new StreamWriter(_inputFilePath + ".txt");
//        }


//        // This member loops through all the segments, determines the segment status,
//        // and then outputs the content to the text file (if applicable)
//        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
//        {
//            // Check if this paragraph actually contains segments 
//            // If not, it is just a structure tag content, which is not processed
//            if (paragraphUnit.IsStructure)
//            {
//                return;
//            }

//            // If the paragraph contains segment pairs, we loop through them,
//            // determine their confirmation status, and depending on the status
//            // output the text content to a TXT file
//            foreach (ISegmentPair item in paragraphUnit.SegmentPairs)
//            {
//                //int segmentStatus = _taskSettings.ConfirmationLevelSetting;
//                //if (item.Properties.ConfirmationLevel == (ConfirmationLevel)segmentStatus)
//                //    _outFile.WriteLine(item.Source + ";" + item.Target);

//                var tmpt = item.Source;

//            }


//            paragraphUnit.Properties.LockType = Sdl.FileTypeSupport.Framework.NativeApi.LockTypeFlags.Manual;
//        }


//        public override void FileComplete()
//        {
//            base.FileComplete();
//            //_outFile.Close();
//        }
//    }
//}
