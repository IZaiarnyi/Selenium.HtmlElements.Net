using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.HtmlElements.Locators {

    public class LocatorFactory {

        private readonly ISearchContext _searchContext;

        public LocatorFactory(ISearchContext searchContext) {
            _searchContext = searchContext;
        }

        public IElementLocator CreateLocator(MemberInfo memberInfo) {
            return new ElementLocator(_searchContext, ByFrom(memberInfo));
        }

        private static IEnumerable<By> ByFrom(MemberInfo memberInfo) {
            var findsByAttributes = memberInfo.GetCustomAttributes(typeof(FindsByAttribute), true)
                .Select(a => a as FindsByAttribute).ToList();

            if (findsByAttributes.Any()) return findsByAttributes.Select(ByFactory.From).ToList();

            return new List<By> {By.Name(memberInfo.Name), By.Id(memberInfo.Name), By.ClassName(memberInfo.Name)};
        }

    }

}