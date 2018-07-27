using NTCore.DataModel.Entities;

namespace NTCore.Service.Interface
{
    public interface IContextService
    {
        SiteInfo GetCurrentSiteInfo();
        void SetLanguageInfo(LanguageInfo languageInfo);
        LanguageInfo GetCurrentLanguageInfo();
        ThemeInfo GetCurrentThemeInfo();
        UserInfo GetCurrentUserInfo();
    }
}
