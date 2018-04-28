using Sdl.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExSegmentLocker
{
    public class MyCustomBatchTaskSettings : SettingsGroup
    {

        /// <summary>
        /// Multiple regular expressions. One per line.
        /// </summary>
        public BindingList<RegExPattern> RegexPatterns
        {
            get => GetSetting<BindingList<RegExPattern>>(nameof(RegexPatterns)); 
            set => GetSetting<BindingList<RegExPattern>>(nameof(RegexPatterns)).Value = value; 
        }


        /// <summary>
        /// Include text inside tags into the regex scan.
        /// </summary>
        /// <example>
        /// For example in HTML tags, the href, class, style, etc. stuff
        /// </example>
        public bool IncludeTagContent
        {
            get { return GetSetting<bool>(nameof(IncludeTagContent)); }
            set { GetSetting<bool>(nameof(IncludeTagContent)).Value = value; }
        }


    }
}
