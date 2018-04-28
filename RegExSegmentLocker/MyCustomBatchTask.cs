using Sdl.ProjectAutomation.AutomaticTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.Core;
using Sdl.FileTypeSupport.Framework.BilingualApi;


using Sdl.Desktop.IntegrationApi;
//using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.ProjectAutomation.Core;





namespace RegExSegmentLocker
{
    [AutomaticTask("Regular_Expression_Locker_ID",
        "RegEx Segment Locker",
        "Lock segments with regular expressions",
        //[TODO] You can change the file type according to your needs
        GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    //[TODO] You can change the file type according to your needs
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]
    public class MyCustomBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private MyCustomBatchTaskSettings _settings;


        protected override void OnInitializeTask()
        {
            base.OnInitializeTask();

            _settings = GetSetting<MyCustomBatchTaskSettings>();

        }
        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            //In here you should add your custom bilingual processor to the file converter
            // We initialize the class that performs the actual work
            //FileReader _task = new FileReader(_settings, projectFile.LocalFilePath);    //AbstractBilingualContentProcessor
            //multiFileConverter.AddBilingualProcessor(_task);
            //multiFileConverter.Parse();



            //var regExPatterns = new List<string>(_settings.LockerRegEx.Split(
            //                                                                    new[] { Environment.NewLine },
            //                                                                    StringSplitOptions.None
            //                                                                ));

            var patternsFromGrid = _settings.RegexPatterns.ToList();

            multiFileConverter.AddBilingualProcessor(new Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi.BilingualContentHandlerAdapter(new SegmentLockerPreProcessor(patternsFromGrid, _settings.IncludeTagContent)));
        }

        public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            //Returns true to indicate the file is updated.By default it returns false.
            return true;
        }
    }
}
