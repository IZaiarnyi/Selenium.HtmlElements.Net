﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Selenium.HtmlElements.Demo.Pages;
using Selenium.HtmlElements.Elements;

using PageFactory = Selenium.HtmlElements.Factory.PageFactory;

namespace Selenium.HtmlElements.Demo.Elements {

    internal class Pagination : HtmlElement {

        public Pagination(IWebElement wrapped) : base(wrapped) {
            PageFactory.InitElementsIn(this, wrapped);
        }

        [FindsBy(How = How.CssSelector, Using = ".value.rating")]
        private HtmlElement _currentPageNumber;

        [FindsBy(How = How.CssSelector, Using = ".nextPage")]
        private HtmlLink _nextPageLink;

        public int CurrentNumber {
            get { return int.Parse(_currentPageNumber.Text); }
        }

        public DevLifePage OpenNextPage() {
            return _nextPageLink.Open<DevLifePage>();
        }
      
    }

}