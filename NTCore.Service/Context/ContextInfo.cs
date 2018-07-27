using NTCore.DataModel.Entities;

namespace NTCore.Service.Context
{
    public class ContextInfo
    {
        public SiteInfo Site { get; set; }
        public UserInfo User { get; set; }
        public ThemeInfo Theme { get; set; }
        public LanguageInfo Language { get; set; }
    }

}
